using Poc.NfseIntegracao.App.DTOs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace Poc.NfseIntegracao.App.Services;

public class NfseIntegrationService : IDisposable
{
    private HttpClient _httpClient;
    private bool _disposed = false;


    public void CriarHttpCliente(TipoEndpoint tipoEndpoint)
    {
        var handler = new HttpClientHandler();
        handler.ClientCertificateOptions = ClientCertificateOption.Manual;

        var certificate = new X509Certificate2("C:/CertificadoClientes/cert.pfx", "123456");
        handler.ClientCertificates.Add(certificate);
        var urlBase = string.Empty;

        switch (tipoEndpoint)
        {
            case TipoEndpoint.Adn:
                urlBase = "https://adn.producaorestrita.nfse.gov.br/";
                break;
            case TipoEndpoint.Sefin:
                urlBase = "https://sefin.producaorestrita.nfse.gov.br/";
                break;
        }

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
            CriarHttpCliente(TipoEndpoint.Adn);
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

    public async Task<ApiResponse<object>> ConsultarNfse(string chaveAcesso)
    {
        try
        {
            CriarHttpCliente(TipoEndpoint.Sefin);

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

    public async Task<ApiResponse<object>> RegistrarEvento(string chaveAcesso, string eventoCompactado)
    {
        try
        {
            var endpoint = $"/nfse/{chaveAcesso}/eventos";

            var request = new
            {
                eventoXmlGZipB64 = eventoCompactado
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
