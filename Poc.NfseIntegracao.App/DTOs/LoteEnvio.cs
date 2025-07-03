namespace Poc.NfseIntegracao.App.DTOs;

/// <summary>
/// Estrutura para envio conforme RecepcaoRequest do Swagger
/// </summary>
public class LoteEnvio
{
    public string[] LoteXmlGZipB64 { get; set; }
}