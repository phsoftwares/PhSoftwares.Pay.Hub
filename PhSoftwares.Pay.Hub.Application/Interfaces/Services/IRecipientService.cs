using PhSoftwares.Pay.Hub.Application.DTOs;
using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Services
{
    public interface IRecipientService
    {
        Task<RecipientDTO> Insert(RecipientDTO recipientDTO);
        Task<RecipientDTO> Delete(Guid id);
        Task<RecipientDTO> Update(RecipientDTO recipientDTO);
        Task<IEnumerable<RecipientDTO>> GetAll();
        Task<RecipientDTO> GetById(Guid id);
    }
}
