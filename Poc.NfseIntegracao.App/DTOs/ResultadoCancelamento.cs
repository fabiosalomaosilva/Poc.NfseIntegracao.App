namespace Poc.NfseIntegracao.App.DTOs;

/// </summary>
public class ResultadoCancelamento
{
    public string XmlCancelamento { get; set; }
    public EndpointInfo EndpointInfo { get; set; }
    public int AmbienteGerador { get; set; }
    public int TipoAmbiente { get; set; }
}