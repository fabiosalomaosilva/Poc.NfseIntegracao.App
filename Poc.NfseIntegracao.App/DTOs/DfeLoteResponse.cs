namespace Poc.NfseIntegracao.App.DTOs
{
    public class DfeLoteResponse
    {
        public string StatusProcessamento { get; set; }
        public Lotedfe[] LoteDFe { get; set; }
        public Alerta[] Alertas { get; set; }
        public Erro[] Erros { get; set; }
        public string TipoAmbiente { get; set; }
        public string VersaoAplicativo { get; set; }
        public DateTime DataHoraProcessamento { get; set; }
    }

    public class Lotedfe
    {
        public int NSU { get; set; }
        public string ChaveAcesso { get; set; }
        public string TipoDocumento { get; set; }
        public string TipoEvento { get; set; }
        public string ArquivoXml { get; set; }
        public DateTime DataHoraRecebimento { get; set; }
        public DateTime DataHoraGeracao { get; set; }
    }
}
