using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Core.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Repositories
{
    public interface IPayerRepository
    {
        Task<Payer> Insert(Payer payer);
        Task<Payer> Delete(Guid id);
        Task<Payer> Update(Payer payer);
        Task<IEnumerable<Payer>> GetAll();
        Task<Payer> GetById(Guid id);
    }
}
