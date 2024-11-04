using PhSoftwares.Pay.Hub.Application.ExternalDTOs.BancoBrasil.Pessoa;

namespace PhSoftwares.Pay.Hub.Application.ExternalDTOs.BancoBrasil
{
    public class BoletoBancoBrasilInputDTO
    {
        public int numeroConvenio { get; set; }
        public int numeroCarteira { get; set; }
        public int numeroVariacaoCarteira { get; set; }
        public int codigoModalidade { get; set; }
        public string dataEmissao { get; set; }
        public string dataVencimento { get; set; }
        public decimal valorOriginal { get; set; }
        public decimal valorAbatimento { get; set; }
        public int quantidadeDiasProtesto { get; set; }
        public string indicadorAceiteTituloVencido { get; set; }
        public string numeroDiasLimiteRecebimento { get; set; }
        public string codigoAceite { get; set; }
        public string codigoTipoTitulo { get; set; }
        public string descricaoTipoTitulo { get; set; }
        public string indicadorPermissaoRecebimentoParcial { get; set; }
        public string numeroTituloBeneficiario { get; set; }
        public string textoCampoUtilizacaoBeneficiario { get; set; }
        public string numeroTituloCliente { get; set; }
        public string mensagemBloquetoOcorrencia { get; set; }
        public BoletoDescontoBancoBrasilDTO desconto { get; set; }
        public BoletoJurosMoraBancoBrasilDTO jurosMora { get; set; }
        public BoletoMultaBancoBrasilDTO multa { get; set; }
        public PagadorBancoBrasilDTO pagador { get; set; }
        public BeneficiarioFinalBancoBrasilDTO beneficiarioFinal { get; set; }
        public string indicadorPix { get; set; }
        public string textoEnderecoEmail { get; set; }
    }
}
