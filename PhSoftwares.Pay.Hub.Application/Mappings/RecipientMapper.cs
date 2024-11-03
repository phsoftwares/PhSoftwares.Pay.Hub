using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Application.Interfaces.Mappings;
using PhSoftwares.Pay.Hub.Core.Entities.Person;

namespace PhSoftwares.Pay.Hub.Application.Mappings
{
    public class RecipientMapper : IRecipientMapper
    {
        public Task<Recipient> MapFromDTO(RecipientDTO recipientDTO)
        {
            return Task.FromResult(new Recipient()
            {
                Id = recipientDTO.Id ?? Guid.NewGuid(),
                FullName = recipientDTO.FullName,
                EmailAddress = recipientDTO.EmailAddress,
                DocumentNumber = recipientDTO.DocumentNumber,
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = DateTime.UtcNow,
                CreationUserId = Guid.NewGuid(), ///TODO: VOLTAR AQUI
                AddressStreet = recipientDTO.Adress.Street,
                AddressNumber = recipientDTO.Adress.Number,
                AddressNeighborhood = recipientDTO.Adress.Neighborhood,
                AddressCity = recipientDTO.Adress.City,
                AddressCountry = recipientDTO.Adress.Country,
                AddressState = recipientDTO.Adress.State,
                ZipCode = recipientDTO.Adress.ZipCode,
                BankAccount = recipientDTO.BankAccount,
                BankAgency = recipientDTO.BankAgency,
            });
        }

        public Task<RecipientDTO> MapFromEntitie(Recipient recipient)
        {
            return Task.FromResult(new RecipientDTO()
            {
                Id = recipient.Id,
                FullName = recipient.FullName,
                EmailAddress = recipient.EmailAddress,
                DocumentNumber = recipient.DocumentNumber,
                Adress = new DTOs.AddressDTO
                {
                    Street = recipient.AddressStreet,
                    Number = recipient.AddressNumber,
                    City = recipient.AddressStreet,
                    Neighborhood = recipient.AddressNeighborhood,
                    State = recipient.AddressState,
                    Country = recipient.AddressCountry,
                    ZipCode = recipient.ZipCode
                },
                BankAccount = recipient.BankAccount,
                BankAgency = recipient.BankAgency,
            });
        }
    }
}
