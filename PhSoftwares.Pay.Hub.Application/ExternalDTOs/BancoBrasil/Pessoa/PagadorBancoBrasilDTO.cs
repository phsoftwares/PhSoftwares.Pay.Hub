using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.ExternalDTOs.BancoBrasil.Pessoa
{
    public class PagadorBancoBrasilDTO: PessoaBancoBrasilDTO
    {
        public string endereco { get; set; }
        public long cep { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string uf { get; set; }
        public string telefone { get; set; }
    }
}
