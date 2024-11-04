using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PhSoftwares.Pay.Hub.Application.Consts;
using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.BancoBrasil;
using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.Sicredi;
using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Application.ExternalDTOs.BancoBrasil;
using PhSoftwares.Pay.Hub.Application.ExternalDTOs.Sicredi;
using PhSoftwares.Pay.Hub.Application.Interfaces.Mappers;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;
using PhSoftwares.Pay.Hub.Application.Mappers;
using PhSoftwares.Pay.Hub.Boleto.Consts;
using PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi;
using PhSoftwares.Pay.Hub.Boleto.Interfaces.Mappers;
using System.Text;

namespace PhSoftwares.Pay.Hub.Application.Services
{
    public class BoletoBancoBrasilService : IBoletoBancoBrasilService
    {
        private readonly IBoletoBancoBrasilMapper _boletoBancoBrasilMapper;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BoletoBancoBrasilService> _logger;

        public BoletoBancoBrasilService(IBoletoBancoBrasilMapper boletoBancoBrasilMapper, IHttpClientFactory httpClientFactory, ILogger<BoletoBancoBrasilService> logger)
        {
            _boletoBancoBrasilMapper = boletoBancoBrasilMapper;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<BoletoPaymentOutputDTO> StartBillingRegistration(CreatePaymentBoletoBancoBrasilInputDTO inputDTO)
        {
            var boletoBancoBrasilInput = await CreateBoletoInput(inputDTO);
            var boletoBancoBrasilOutput = await RegisterBillingBoleto(boletoBancoBrasilInput, inputDTO.AuthorizationDetails);
            var paymentDetails = await _boletoBancoBrasilMapper.MapBoletoBancoBrasilOutputToNormalized(boletoBancoBrasilOutput);
            return await Task.FromResult(new BoletoPaymentOutputDTO()
            {
                Success = paymentDetails != null && !string.IsNullOrEmpty(paymentDetails.OurNumber),
                PaymentDetails = paymentDetails,
                Id = Guid.Empty,//"TODO: VOLTARAQUI"
                ErrorDetails = await _boletoBancoBrasilMapper.MapErrorDetails(boletoBancoBrasilOutput.DetalhesErro)
            });
        }

        public Task<BoletoBancoBrasilInputDTO> CreateBoletoInput(CreatePaymentBoletoBancoBrasilInputDTO inputDTO)
        {
            return _boletoBancoBrasilMapper.MapBoletoInput(inputDTO);
        }

        public async Task<BoletoBancoBrasilOutputDTO> RegisterBillingBoleto(BoletoBancoBrasilInputDTO inputDTO, BancoBrasilAuthorizationDetailsDTO authorizationDetailsDTO)
        {
            var accessToken = await GetAuthorization(authorizationDetailsDTO);
            var url = BancoBrasilConsts.BaseUrlBancoBrasil + BancoBrasilConsts.BaseUrlRegisterBoletoBancoBrasil + "?gw-dev-app-key=" + authorizationDetailsDTO.DeveloperKey;
            using (var client = _httpClientFactory.CreateClient())
            {
                var output = new BoletoBancoBrasilOutputDTO();
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("Authorization", "Bearer " + accessToken);
                var jsonContent = JsonConvert.SerializeObject(inputDTO);
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var apiResponse = await client.SendAsync(request);

                var responseString = await apiResponse.Content.ReadAsStringAsync();
                output = JsonConvert.DeserializeObject<BoletoBancoBrasilOutputDTO>(responseString);
                if (!apiResponse.IsSuccessStatusCode)
                {
                    _logger.LogError("Problem when making the request to Sicredi on RegisterBillingBoleto!");
                    output.DetalhesErro = JsonConvert.DeserializeObject<BoletoBancoBrasilErroOutputDTO>(responseString);
                    output.qrCode = new BoletoBancoBrasilQrCodeDTO();
                }
                return output;
            }
        }

        private async Task<string> GetAuthorization(BancoBrasilAuthorizationDetailsDTO authorizationDetailsDTO)
        {
            var url = BancoBrasilConsts.BaseUrlTokenBancoBrasil;
            var body = GetBodyToGetAccessToken();
            using (var client = _httpClientFactory.CreateClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("Authorization", authorizationDetailsDTO.BasicAuth);

                var formContent = new FormUrlEncodedContent(body);
                request.Content = formContent;
                var apiResponse = await client.SendAsync(request);
                if (!apiResponse.IsSuccessStatusCode)
                {
                    _logger.LogError("Problem when making the request to Sicredi on GetAuthorization!");
                }

                var responseString = await apiResponse.Content.ReadAsStringAsync();
                var output = JsonConvert.DeserializeObject<BoletoAuthorizationBancoBrasilDTO>(responseString);
                if (output == null)
                {
                    return "";
                }
                return output.access_token;
            }
        }

        private Dictionary<string, string> GetBodyToGetAccessToken()
        {
            return new Dictionary<string, string>
            {
                { "scope", "cobrancas.boletos-info cobrancas.boletos-requisicao" },
                { "grant_type", "client_credentials" },
            };
        }
    }
}
