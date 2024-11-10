using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.ExternalDTOs.Inter.Pessoa
{
    public class PagadorInterDTO: PessoaInterDTO
    {
        public string email { get; set; }
        public string ddd { get; set; }
        public string telefone { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
    }
}
