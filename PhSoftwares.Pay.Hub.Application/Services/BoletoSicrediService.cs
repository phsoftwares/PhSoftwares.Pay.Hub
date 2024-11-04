using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.Sicredi;
using PhSoftwares.Pay.Hub.Application.DTOs.CreatePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentMethod;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Application.ExternalDTOs.Sicredi;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;
using PhSoftwares.Pay.Hub.Boleto.Consts;
using PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi;
using PhSoftwares.Pay.Hub.Boleto.Interfaces.Mappers;
using System.Text;

namespace PhSoftwares.Pay.Hub.Application.Services
{
    public class BoletoSicrediService : IBoletoSicrediService
    {
        private readonly IBoletoSicrediMapper _boletoSicrediMapper;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BoletoSicrediService> _logger;

        public BoletoSicrediService(IBoletoSicrediMapper boletoSicrediMapper, IHttpClientFactory httpClientFactory, ILogger<BoletoSicrediService> logger)
        {
            _boletoSicrediMapper = boletoSicrediMapper;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<BoletoPaymentOutputDTO> StartBillingRegistration(CreatePaymentBoletoSicrediInputDTO inputDTO)
        {
            var boletoSicrediInput = await CreateBoletoInput(inputDTO);
            var boletoSicrediOutput = await RegisterBillingBoleto(boletoSicrediInput, inputDTO.AuthorizationDetails);
            var paymentDetails = await _boletoSicrediMapper.MapBoletoSicrediOutputToNormalized(boletoSicrediOutput);
            return await Task.FromResult(new BoletoPaymentOutputDTO()
            {
                Success = paymentDetails != null && !string.IsNullOrEmpty(paymentDetails.OurNumber),
                PaymentDetails = paymentDetails,
                Id = Guid.Empty,//"TODO: VOLTARAQUI"
                ErrorDetails = await _boletoSicrediMapper.MapErrorDetails(boletoSicrediOutput.DetalhesErro)
            });
        }

        public Task<BoletoSicrediInputDTO> CreateBoletoInput(CreatePaymentBoletoSicrediInputDTO inputDTO)
        {
            return _boletoSicrediMapper.MapBoletoInput(inputDTO);
        }

        public async Task<BoletoSicrediOutputDTO> RegisterBillingBoleto(BoletoSicrediInputDTO inputDTO, SicrediAuthorizationDetailsDTO authorizationDetailsDTO)
        {
            var accessToken = await GetAuthorization(authorizationDetailsDTO);
            var url = SicrediConsts.BaseUrlSicredi + SicrediConsts.BaseUrlRegisterBoletoSicredi;
            using (var client = _httpClientFactory.CreateClient())
            {
                var output = new BoletoSicrediOutputDTO();
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("x-api-key", authorizationDetailsDTO.AccessToken);
                request.Headers.Add("cooperativa", authorizationDetailsDTO.Cooperative);
                request.Headers.Add("codigoBeneficiario", authorizationDetailsDTO.RecipientCode);
                request.Headers.Add("posto", authorizationDetailsDTO.Post);
                request.Headers.Add("Authorization", "Bearer " + accessToken);
                var jsonContent = JsonConvert.SerializeObject(inputDTO);
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var apiResponse = await client.SendAsync(request);

                var responseString = await apiResponse.Content.ReadAsStringAsync();
                output = JsonConvert.DeserializeObject<BoletoSicrediOutputDTO>(responseString);
                if (!apiResponse.IsSuccessStatusCode)
                {       
                    _logger.LogError("Problem when making the request to Sicredi on RegisterBillingBoleto!");
                    output.DetalhesErro = JsonConvert.DeserializeObject<BoletoSicrediErroOutputDTO>(responseString);
                }               
                return output;
            }
        }

        private async Task<string> GetAuthorization(SicrediAuthorizationDetailsDTO authorizationDetailsDTO)
        {
            var url = SicrediConsts.BaseUrlSicredi + SicrediConsts.BaseUrlTokenSicredi;
            var body = GetBodyToGetAccessToken(authorizationDetailsDTO);
            using (var client = _httpClientFactory.CreateClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("x-api-key", authorizationDetailsDTO.AccessToken);
                request.Headers.Add("context", "COBRANCA");      

                var formContent = new FormUrlEncodedContent(body);
                request.Content = formContent;
                var apiResponse = await client.SendAsync(request);
                if (!apiResponse.IsSuccessStatusCode)
                {
                    _logger.LogError("Problem when making the request to Sicredi on GetAuthorization!");
                }

                var responseString = await apiResponse.Content.ReadAsStringAsync();
                var output = JsonConvert.DeserializeObject<BoletoAuthorizationSicrediDTO>(responseString);
                if (output == null)
                {
                    return "";
                }
                return output.access_token;
            }
        }

        private Dictionary<string, string> GetBodyToGetAccessToken(SicrediAuthorizationDetailsDTO authorizationDetailsDTO)
        {
            return new Dictionary<string, string>
            { 
                { "username", authorizationDetailsDTO.Username },
                { "password", authorizationDetailsDTO.Password },
                { "scope", "cobranca" },
                { "grant_type", "password" },
            };
        }
    }
}
