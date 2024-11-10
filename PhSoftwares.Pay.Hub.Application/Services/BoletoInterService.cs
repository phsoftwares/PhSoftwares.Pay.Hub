using Microsoft.Extensions.Logging;
using PhSoftwares.Pay.Hub.Application.DTOs.AuthorizationDetails.Inter;
using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentOutput;
using PhSoftwares.Pay.Hub.Application.ExternalDTOs.Inter;
using PhSoftwares.Pay.Hub.Application.Interfaces.Mappers;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;

namespace PhSoftwares.Pay.Hub.Application.Services
{
    public class BoletoInterService : IBoletoInterService
    {
        private readonly IBoletoInterMapper _boletoInterMapper;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BoletoInterService> _logger;

        public BoletoInterService(IBoletoInterMapper boletoInterMapper, IHttpClientFactory httpClientFactory, ILogger<BoletoInterService> logger)
        {
            _boletoInterMapper = boletoInterMapper;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        public async Task<BoletoPaymentOutputDTO> StartBillingRegistration(CreatePaymentBoletoInterInputDTO inputDTO)
        {
            var boletoInterInput = await CreateBoletoInput(inputDTO);
            var boletoInterOutput = await RegisterBillingBoleto(boletoInterInput, inputDTO.AuthorizationDetails);
            var paymentDetails = await _boletoInterMapper.MapBoletoInterOutputToNormalized(boletoInterOutput);
            return await Task.FromResult(new BoletoPaymentOutputDTO()
            {
                Success = paymentDetails != null && !string.IsNullOrEmpty(paymentDetails.OurNumber),
                PaymentDetails = paymentDetails,
                Id = Guid.Empty,//"TODO: VOLTARAQUI"
                ErrorDetails = await _boletoInterMapper.MapErrorDetails(boletoInterOutput.DetalhesErro)
            });
        }
        public Task<BoletoInterInputDTO> CreateBoletoInput(CreatePaymentBoletoInterInputDTO inputDTO)
        {
            return _boletoInterMapper.MapBoletoInput(inputDTO);
        }

        public async Task<BoletoInterOutputDTO> RegisterBillingBoleto(BoletoInterInputDTO inputDTO, InterAuthorizationDetailsDTO authorizationDetailsDTO)
        {
            throw new NotImplementedException();
        }
    }
}
