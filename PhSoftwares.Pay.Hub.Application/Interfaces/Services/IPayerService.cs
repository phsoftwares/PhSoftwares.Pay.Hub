using PhSoftwares.Pay.Hub.Application.DTOs.Person;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Services
{
    public interface IPayerService
    {
        Task<PayerDTO> Insert(PayerDTO payerDTO);
        Task<PayerDTO> Delete(Guid id);
        Task<PayerDTO> Update(PayerDTO payerDTO);
        Task<PayerDTO> UpdateWithId(PayerDTO payerDTO, Guid id);
        Task<IEnumerable<PayerDTO>> GetAll();
        Task<PayerDTO> GetById(Guid id);
        Task<Guid> GetIdIfDocumentIsRegistred(String document);
    }
}
