using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Core.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Repositories
{
    public interface IPayeeRepository
    {
        Task<Payee> Insert(Payee payee);
        Task<Payee> Delete(Guid id);
        Task<Payee> Update(Payee payee);
        Task<IEnumerable<Payee>> GetAll();
        Task<Payee> GetById(Guid id);
        Task<Payee> GetByDocument(String document);
    }
}
