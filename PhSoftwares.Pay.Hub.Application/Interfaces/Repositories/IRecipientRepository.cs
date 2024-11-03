using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Core.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Repositories
{
    public interface IRecipientRepository
    {
        Task<Recipient> Insert(Recipient recipient);
        Task<Recipient> Delete(Guid id);
        Task<Recipient> Update(Recipient recipient);
        Task<IEnumerable<Recipient>> GetAll();
        Task<Recipient> GetById(Guid id);
    }
}
