using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Core.Entities;
using PhSoftwares.Pay.Hub.Core.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> Insert(Payment payment);
        Task<Payment> Delete(Guid id);
        Task<Payment> Update(Payment payment);
        Task<IEnumerable<Payment>> GetAll();
        Task<Payment> GetById(Guid id);
    }
}
