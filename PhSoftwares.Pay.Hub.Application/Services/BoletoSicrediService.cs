using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.Sicredi;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentMethod;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;
using PhSoftwares.Pay.Hub.Boleto.Consts;
using PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi;
using PhSoftwares.Pay.Hub.Boleto.Interfaces.Mappers;

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

        public async Task<BoletoPaymentOutputDTO> StartBillingRegistration(MakePaymentInputDTO inputDTO)
        {
            if (inputDTO.PaymentMethod is BoletoPaymentMethodDTO boletoPaymentMethod && boletoPaymentMethod.AuthorizationDetails is SicrediAuthorizationDetailsDTO authorizationDetails)
            {
                var boletoSicrediInput = await CreateBoletoInput(inputDTO);
                var boletoSicrediOutput = await RegisterBillingBoleto(boletoSicrediInput, authorizationDetails);
                var paymentDetails = await _boletoSicrediMapper.MapBoletoSicrediOutputToNormalized(boletoSicrediOutput);
                return await Task.FromResult(new BoletoPaymentOutputDTO()
                {
                    Success = paymentDetails != null && !string.IsNullOrEmpty(paymentDetails.OurNumber),
                    PaymentDetails = paymentDetails,
                    Message = "TODO: VOLTAR AQUI",
                    Id = Guid.Empty//"TODO: VOLTARAQUI"
                });
            }
            return null;
        }

        public Task<BoletoSicrediInputDTO> CreateBoletoInput(MakePaymentInputDTO inputDTO)
        {
            return _boletoSicrediMapper.MapBoletoInput(inputDTO);
        }

        public async Task<BoletoSicrediOutputDTO> RegisterBillingBoleto(BoletoSicrediInputDTO inputDTO, SicrediAuthorizationDetailsDTO authorizationDetailsDTO)
        {
            var accessToken = await GetAuthorization(authorizationDetailsDTO);
            var url = SicrediConsts.BaseUrlSicredi + SicrediConsts.BaseUrlRegisterBoletoSicredi;
            using (var client = _httpClientFactory.CreateClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("x-api-key", authorizationDetailsDTO.AccessToken);
                request.Headers.Add("cooperativa", authorizationDetailsDTO.Cooperative);
                request.Headers.Add("posto", authorizationDetailsDTO.Post);
                request.Headers.Add("Authorization", "Bearer " + accessToken);
                var apiResponse = await client.SendAsync(request);
                if (!apiResponse.IsSuccessStatusCode)
                {
                    _logger.LogError("Problem when making the request to Sicredi on RegisterBillingBoleto!");
                }

                var responseString = await apiResponse.Content.ReadAsStringAsync();
                var output = JsonConvert.DeserializeObject<BoletoSicrediOutputDTO>(responseString);
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
                request.Headers.Add("cooperativa", authorizationDetailsDTO.Cooperative);
                request.Headers.Add("posto", authorizationDetailsDTO.Post);
                var formContent = new FormUrlEncodedContent(body);
                request.Content = formContent;
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
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
                { "posto", authorizationDetailsDTO.Post },
                { "cooperativa", authorizationDetailsDTO.Cooperative },
            };
        }
    }
}
