namespace Poc.NfseIntegracao.App.DTOs;

/// <summary>
/// Classe para armazenar dados extraídos da NFS-e
/// </summary>
public class DadosNFSe
{
    public string ChaveAcesso { get; set; }
    public string CNPJ { get; set; }
    public int TipoAmbiente { get; set; }
    public int AmbienteGerador { get; set; } // NOVO: 1-Prefeitura, 2-Sistema Nacional
}