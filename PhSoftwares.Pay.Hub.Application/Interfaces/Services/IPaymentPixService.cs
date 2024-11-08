﻿using PhSoftwares.Pay.Hub.Application.DTOs.CreatePaymentBoleto;
using PhSoftwares.Pay.Hub.Application.DTOs.MakePayment.PaymentOutput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Services
{
    public interface IPaymentPixService
    {
        Task<BoletoPaymentOutputDTO> CreatePaymentPixSicredi(CreatePaymentBoletoSicrediInputDTO inputDTO);
    }
}
