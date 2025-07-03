namespace Poc.NfseIntegracao.App.DTOs;

/// <summary>
/// Resultado completo para envio ao ADN
/// </summary>
public class ResultadoEnvioADN
{
    public string XmlCancelamento { get; set; }
    public string XmlLoteCompleto { get; set; }
    public LoteEnvio LoteParaEnvio { get; set; }
    public LoteEnvio LoteCompletoParaEnvio { get; set; }
    public EndpointInfo EndpointInfo { get; set; }
    public int AmbienteGerador { get; set; }
    public int TipoAmbiente { get; set; }
}