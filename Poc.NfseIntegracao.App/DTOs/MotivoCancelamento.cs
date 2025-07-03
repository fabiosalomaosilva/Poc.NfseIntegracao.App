namespace Poc.NfseIntegracao.App.DTOs;

/// <summary>
/// Enumeração dos motivos de cancelamento permitidos
/// </summary>
public enum MotivoCancelamento
{
    ErroNaEmissao = 1,
    ServicoNaoPrestado = 2,
    Outros = 9
}