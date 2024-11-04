using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Boleto.ExternalDTOs.Sicredi
{
    public class PessoaSicrediDTO
    {
        public string documento { get; set; }
        public string tipoPessoa { get; set; }
        public string nome { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string cep { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
    }
}
