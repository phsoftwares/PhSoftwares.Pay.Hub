using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.DTOs
{
    public class UserDTO
    {
        public Guid? Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string DocumentNumber { get; set; }
        public string Password { get; set; }
    }
}
