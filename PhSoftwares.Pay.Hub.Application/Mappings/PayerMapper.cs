using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Application.Interfaces.Mappings;
using PhSoftwares.Pay.Hub.Core.Entities.Person;

namespace PhSoftwares.Pay.Hub.Application.Mappings
{
    public class PayerMapper : IPayerMapper
    {
        public Task<Payer> MapFromDTO(PayerDTO payerDTO)
        {
            return Task.FromResult(new Payer()
            {
                Id  = payerDTO.Id ?? Guid.NewGuid(),
                FullName = payerDTO.FullName,
                EmailAddress = payerDTO.EmailAddress,
                DocumentNumber = payerDTO.DocumentNumber,
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = DateTime.UtcNow,
                CreationUserId = Guid.NewGuid(), ///TODO: VOLTAR AQUI
                AddressStreet = payerDTO.Adress.Street,
                AddressNumber = payerDTO.Adress.Number,
                AddressNeighborhood = payerDTO.Adress.Neighborhood,
                AddressCity = payerDTO.Adress.City,
                AddressCountry = payerDTO.Adress.Country,
                AddressState = payerDTO.Adress.State,
                ZipCode = payerDTO.Adress.ZipCode
            });
        }

        Task<PayerDTO> IPayerMapper.MapFromEntitie(Payer payer)
        {
            return Task.FromResult(new PayerDTO()
            {
                Id = payer.Id,
                FullName = payer.FullName,
                EmailAddress = payer.EmailAddress,
                DocumentNumber = payer.DocumentNumber,
                Adress = new DTOs.AddressDTO
                {
                    Street = payer.AddressStreet,
                    Number = payer.AddressNumber,
                    City = payer.AddressStreet,
                    Neighborhood = payer.AddressNeighborhood,
                    State = payer.AddressState,
                    Country = payer.AddressCountry,
                    ZipCode = payer.ZipCode
                }
            });
        }
    }
}
