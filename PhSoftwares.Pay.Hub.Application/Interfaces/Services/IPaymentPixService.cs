using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Services
{
    public interface IPaymentPixService
    {
        Task<MakePaymentOutputDTO> MakePayment(MakePaymentInputDTO makePaymentInputDTO);
    }
}
