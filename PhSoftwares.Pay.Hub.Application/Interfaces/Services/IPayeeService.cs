using PhSoftwares.Pay.Hub.Application.DTOs.Person;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Services
{
    public interface IPayeeService
    {
        Task<PayeeDTO> Insert(PayeeDTO payeeDTO);
        Task<PayeeDTO> Delete(Guid id);
        Task<PayeeDTO> Update(PayeeDTO payeeDTO);
        Task<PayeeDTO> UpdateWithId(PayeeDTO payeeDTO, Guid id);
        Task<IEnumerable<PayeeDTO>> GetAll();
        Task<PayeeDTO> GetById(Guid id);
        Task<Guid> GetIdIfDocumentIsRegistred(String document);
    }
}
