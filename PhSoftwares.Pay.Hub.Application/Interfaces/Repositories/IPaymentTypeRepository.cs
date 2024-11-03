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
    public interface IPaymentTypeRepository
    {
        Task<PaymentType> Insert(PaymentType paymentType);
        Task<PaymentType> Delete(Guid id);
        Task<PaymentType> Update(PaymentType paymentType);
        Task<IEnumerable<PaymentType>> GetAll();
        Task<PaymentType> GetById(Guid id);
    }
}
