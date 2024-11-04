using Microsoft.AspNetCore.Mvc.RazorPages;
using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Application.Interfaces.Mappings;
using PhSoftwares.Pay.Hub.Core.Entities.Person;

namespace PhSoftwares.Pay.Hub.Application.Mappings
{
    public class PayeeMapper : IPayeeMapper
    {
        public Task<Payee> MapFromDTO(PayeeDTO payeeDTO)
        {
            return Task.FromResult(new Payee()
            {
                Id = payeeDTO.Id ?? Guid.NewGuid(),
                FullName = payeeDTO.FullName,
                EmailAddress = payeeDTO.EmailAddress,
                DocumentNumber = payeeDTO.DocumentNumber,
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = DateTime.UtcNow,
                CreationUserId = payeeDTO.CreationUserId ?? Guid.Empty,
                AddressStreet = payeeDTO.Adress.Street,
                AddressNumber = payeeDTO.Adress.Number,
                AddressNeighborhood = payeeDTO.Adress.Neighborhood,
                AddressCity = payeeDTO.Adress.City,
                AddressCountry = payeeDTO.Adress.Country,
                AddressState = payeeDTO.Adress.State,
                ZipCode = payeeDTO.Adress.ZipCode,
                BankAccount = payeeDTO.BankAccount,
                BankAgency = payeeDTO.BankAgency,
            });
        }

        public Task<PayeeDTO> MapFromEntitie(Payee payee)
        {
            return Task.FromResult(new PayeeDTO()
            {
                Id = payee.Id,
                FullName = payee.FullName,
                EmailAddress = payee.EmailAddress,
                DocumentNumber = payee.DocumentNumber,
                Adress = new DTOs.AddressDTO
                {
                    Street = payee.AddressStreet,
                    Number = payee.AddressNumber,
                    City = payee.AddressStreet,
                    Neighborhood = payee.AddressNeighborhood,
                    State = payee.AddressState,
                    Country = payee.AddressCountry,
                    ZipCode = payee.ZipCode
                },
                BankAccount = payee.BankAccount,
                BankAgency = payee.BankAgency,
            });
        }
    }
}
