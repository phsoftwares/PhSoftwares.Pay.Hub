﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.DTOs.Person
{
    public class RecipientDTO:PersonDTO
    {
        public string BankAgency { get; set; }
        public string BankAccount { get; set; }
    }
}