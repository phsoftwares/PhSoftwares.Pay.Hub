﻿using PhSoftwares.Pay.Hub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
