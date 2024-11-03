using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Services
{
    public interface IPayerService
    {
        Task<PayerDTO> Insert(PayerDTO payerDTO);
        Task<PayerDTO> Delete(Guid id);
        Task<PayerDTO> Update(PayerDTO payerDTO);
        Task<IEnumerable<PayerDTO>> GetAll();
        Task<PayerDTO> GetById(Guid id);
    }
}
