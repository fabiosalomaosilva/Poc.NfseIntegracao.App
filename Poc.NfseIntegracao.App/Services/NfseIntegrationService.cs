using Poc.NfseIntegracao.App.DTOs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace Poc.NfseIntegracao.App.Services;

public class NfseIntegrationService : IDisposable
{
    private HttpClient _httpClient;
    private bool _disposed = false;


    public void CriarHttpCliente(TipoEndpoint tipoEndpoint, Prefeitura prefeitura, Ambiente ambiente)
    {
        var handler = new HttpClientHandler();
        handler.ClientCertificateOptions = ClientCertificateOption.Manual;

        var pathCert = "";
        var pathCertRegenteFeijo = "C:/CertificadoClientes/cert.pfx";
        var pathCertPatoBranco = "C:/CertificadoClientes/cert.p12";

        pathCert = prefeitura == Prefeitura.RegenteFeijo ? pathCertRegenteFeijo : pathCertPatoBranco;
        var senha = prefeitura == Prefeitura.PatoBranco ? "pqDbFSL1" : "123456";


        var certificate = new X509Certificate2(pathCert, senha);
        handler.ClientCertificates.Add(certificate);

        var urlBase = tipoEndpoint switch
        {
            TipoEndpoint.Adn => ambiente == Ambiente.Homologacao
                ? "https://adn.producaorestrita.nfse.gov.br/"
                : "https://adn.nfse.gov.br/",
            TipoEndpoint.Sefin => ambiente == Ambiente.Homologacao
                ? "https://sefin.producaorestrita.nfse.gov.br/"
                : "https://sefin.nfse.gov.br/",
            _ => string.Empty
        };

        _httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri(urlBase)
        };

        ConfigureHttpClient();
    }



    private void ConfigureHttpClient()
    {
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        _httpClient.Timeout = TimeSpan.FromMinutes(5);
    }


    public async Task<ApiResponse<object>> CriarNfse(string dpsCompactada)
    {
        try
        {
            CriarHttpCliente(TipoEndpoint.Adn, Prefeitura.RegenteFeijo, Ambiente.Homologacao);
            var request = new
            {
                LoteXmlGZipB64 = new[] { dpsCompactada }
            };

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            var response = await _httpClient.PostAsync("/dfe", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<DfeResponse>(responseContent);
                return new ApiResponse<object> { Success = true, Data = result };
            }
            else
            {
                var erroResponse = JsonSerializer.Deserialize<DfeResponse>(responseContent);
                return new ApiResponse<object>()
                {
                    Success = false,
                    Data = erroResponse
                };
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<object>
            {
                Success = false
            };
        }
    }

    public async Task<ApiResponse<object>> ConsultarNfse(string chaveAcesso, Prefeitura prefeitura, Ambiente ambiente)
    {
        try
        {
            CriarHttpCliente(TipoEndpoint.Sefin, prefeitura, ambiente);

            var endpoint = $"/sefinnacional/danfse/{chaveAcesso}";


            var response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsByteArrayAsync();
                var tempFilePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.pdf");
                await File.WriteAllBytesAsync(tempFilePath, responseContent);

                var process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = tempFilePath,
                    UseShellExecute = true
                };
                process.Start();

                return new ApiResponse<object>
                {
                    Success = true,
                    Data = new { FilePath = tempFilePath }
                };
            }
            else
            {
                MessageBox.Show($"A chave de acesso não existe no ambiente de {ambiente.GetDescription()}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var responseContentError = await response.Content.ReadAsStringAsync();
                var erroResponse = JsonSerializer.Deserialize<NFSePostResponseErro>(responseContentError);
                return new ApiResponse<object>
                {
                    Success = false,
                    ErrorMessage = erroResponse.Erros[0]
                };
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<object>
            {
                Success = false
            };
        }
    }

    public async Task<bool> DowloadDanfeNfse(string chaveAcesso, Prefeitura prefeitura, Ambiente ambiente)
    {
        try
        {
            CriarHttpCliente(TipoEndpoint.Sefin, prefeitura, ambiente);

            var endpoint = $"/sefinnacional/danfse/{chaveAcesso}";


            var response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode) return false;

            var responseContent = await response.Content.ReadAsByteArrayAsync();
            var dialog = new SaveFileDialog();
            dialog.Filter = "PDF files (*.pdf)|*.pdf";
            dialog.FileName = $"{chaveAcesso}.pdf";
            if (dialog.ShowDialog() != DialogResult.OK) return false;
            await File.WriteAllBytesAsync(dialog.FileName, responseContent);

            var openFile = MessageBox.Show("Deseja abrir o documento", "Abrir documento", MessageBoxButtons.OKCancel);

            if (openFile == DialogResult.OK)
            {
                var process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = dialog.FileName,
                    UseShellExecute = true
                };
                process.Start();
                return true;
            }
            return true;

        }
        catch (Exception ex)
        {
            throw;
        }
    }


    public async Task<Lotedfe[]> ConsultarLoteDfe(string nsu, Prefeitura prefeitura, Ambiente ambiente)
    {
        try
        {
            CriarHttpCliente(TipoEndpoint.Adn, prefeitura, ambiente);

            var endpoint = ambiente == Ambiente.Homologacao ? $"/municipios/dfe/{nsu}" : $"/municipios/dfe/{nsu}?tipoNSU=DISTRIBUICAO&lote=true";


            var response = await _httpClient.GetAsync(endpoint);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var jsonData = JsonSerializer.Deserialize<DfeLoteResponse>(responseContent);
                return jsonData.LoteDFe;
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        return Array.Empty<Lotedfe>();
    }

    public async Task<ApiResponse<object>> CancelarNota(string xmlCancelamento, string chaveAcesso)
    {
        try
        {
            CriarHttpCliente(TipoEndpoint.Sefin, Prefeitura.RegenteFeijo, Ambiente.Homologacao);

            var request = new
            {
                pedidoRegistroEventoXmlGZipB64 = xmlCancelamento
            };

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            var response = await _httpClient.PostAsync("/sefinnacional/nfse/{chaveAcesso}/eventos", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<DfeResponse>(responseContent);
                return new ApiResponse<object> { Success = true, Data = result };
            }
            else
            {
                var erroResponse = JsonSerializer.Deserialize<DfeResponse>(responseContent);
                return new ApiResponse<object>()
                {
                    Success = false,
                    Data = erroResponse
                };
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        return new ApiResponse<object>();
    }


    public async Task<ApiResponse<object>> RegistrarEvento(string chaveAcesso, string eventoCompactado)
    {
        try
        {
            CriarHttpCliente(TipoEndpoint.Sefin, Prefeitura.RegenteFeijo, Ambiente.Homologacao);
            var endpoint = $"/sefinnacional/nfse/{chaveAcesso}/eventos";

            var request = new
            {
                pedidoRegistroEventoXmlGZipB64 = eventoCompactado
            };

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            var response = await _httpClient.PostAsync(endpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<object>(responseContent);
                return new ApiResponse<object> { Success = true, Data = result };
            }
            else
            {
                var erroResponse = JsonSerializer.Deserialize<NFSePostResponseErro>(responseContent);
                return new ApiResponse<object>
                {
                    Success = false,
                    ErrorMessage = erroResponse.Erros[0]
                };
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<object>
            {
                Success = false
            };
        }
    }

    public async Task<ApiResponse<object>> ConsultarEventos(string chaveAcesso)
    {
        try
        {
            var endpoint = $"/nfse/{chaveAcesso}/eventos";

            var response = await _httpClient.GetAsync(endpoint);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<object>(responseContent);
                return new ApiResponse<object> { Success = true, Data = result };
            }
            else
            {
                var erroResponse = JsonSerializer.Deserialize<NFSePostResponseErro>(responseContent);
                return new ApiResponse<object>
                {
                    Success = false,
                    ErrorMessage = erroResponse.Erros[0]
                };
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<object>
            {
                Success = false
            };
        }
    }

    public async Task<ApiResponse<object>> DistribuirPorNSU(long nsu)
    {
        try
        {
            var endpoint = $"/DFe/{nsu}";

            var response = await _httpClient.GetAsync(endpoint);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<object>(responseContent);
                return new ApiResponse<object> { Success = true, Data = result };
            }
            else
            {
                var erroResponse = JsonSerializer.Deserialize<NFSePostResponseErro>(responseContent);
                return new ApiResponse<object>
                {
                    Success = false,
                    ErrorMessage = erroResponse.Erros[0]
                };
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<object>
            {
                Success = false
            };
        }
    }

    public async Task<ApiResponse<object>> GerarDanfse(string chaveAcesso, bool isHomologacao = true)
    {
        try
        {
            var endpoint = $"/danfse/{chaveAcesso}";

            var response = await _httpClient.GetAsync(endpoint);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsByteArrayAsync();
                return new ApiResponse<object>
                {
                    Success = true,
                    Data = new
                    {
                        ContentType = response.Content.Headers.ContentType?.ToString(),
                        Content = Convert.ToBase64String(content)
                    }
                };
            }
            else
            {
                var erroResponse = JsonSerializer.Deserialize<NFSePostResponseErro>(responseContent);
                return new ApiResponse<object>
                {
                    Success = false,
                    ErrorMessage = erroResponse.Erros[0]
                };
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<object>
            {
                Success = false
            };
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _httpClient?.Dispose();
            }

            _disposed = true;
        }
    }

    ~NfseIntegrationService()
    {
        Dispose(false);
    }
}
