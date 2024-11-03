using PhSoftwares.Pay.Hub.Application.DTOs.Person;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Services
{
    public interface IRecipientService
    {
        Task<RecipientDTO> Insert(RecipientDTO recipientDTO);
        Task<RecipientDTO> Delete(Guid id);
        Task<RecipientDTO> Update(RecipientDTO recipientDTO);
        Task<RecipientDTO> UpdateWithId(RecipientDTO recipientDTO, Guid id);
        Task<IEnumerable<RecipientDTO>> GetAll();
        Task<RecipientDTO> GetById(Guid id);
        Task<Guid> GetIdIfDocumentIsRegistred(String document);
    }
}
