using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Core.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Mappings
{
    public interface IPayerMapper
    {
        Task<Payer> MapFromDTO(PayerDTO payerDTO);
        Task<PayerDTO> MapFromEntitie(Payer payer);
    }
}
