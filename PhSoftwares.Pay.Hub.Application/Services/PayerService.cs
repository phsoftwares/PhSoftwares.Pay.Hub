using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.Services
{
    public class PayerService : IPayerService
    {
        public Task<PayerDTO> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PayerDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PayerDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PayerDTO> Insert(PayerDTO payerDTO)
        {
            throw new NotImplementedException();
        }

        public Task<PayerDTO> Update(PayerDTO payerDTO)
        {
            throw new NotImplementedException();
        }
    }
}
