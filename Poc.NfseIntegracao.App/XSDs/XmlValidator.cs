using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.Xml.Schema;

namespace Poc.NfseIntegracao.App.XSDs;

/// <summary>
/// Classe responsável por validar documentos XML contra esquemas XSD
/// </summary>
public class XmlValidator
{
    private readonly List<string> _validationErrors = [];
    private readonly List<string> _validationWarnings = [];

    public ValidationResult ValidateXml(string xmlContent)
    {
        // Limpa erros e avisos da validação anterior
        _validationErrors.Clear();
        _validationWarnings.Clear();

        try
        {
            var xsdFilePaths = new[]
            {
                Path.GetFullPath("XSDs/pedRegEvento_v1.00.xsd"),
                Path.GetFullPath("XSDs/tiposEventos_v1.00.xsd"),
                Path.GetFullPath("XSDs/evento_v1.00.xsd"),
                Path.GetFullPath("XSDs/NFSe_v1.00.xsd"),
                Path.GetFullPath("XSDs/xmldsig-core-schema_v1.00.xsd"),
                Path.GetFullPath("XSDs/DPS_v1.00.xsd"),
                Path.GetFullPath("XSDs/tiposComplexos_v1.00.xsd"),
                Path.GetFullPath("XSDs/tiposSimples_v1.00.xsd")
            };

            // Valida se o XML não está vazio
            if (string.IsNullOrWhiteSpace(xmlContent))
            {
                throw new ArgumentException("O conteúdo XML não pode estar vazio", nameof(xmlContent));
            }

            // Valida se foram fornecidos arquivos XSD
            if (xsdFilePaths == null || xsdFilePaths.Length == 0)
            {
                throw new ArgumentException("É necessário fornecer pelo menos um arquivo XSD", nameof(xsdFilePaths));
            }

            // Cria o XmlDocument
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlContent);

            // Configura as configurações do XmlReader
            var settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
                ValidationFlags = XmlSchemaValidationFlags.ProcessInlineSchema |
                                  XmlSchemaValidationFlags.ProcessSchemaLocation |
                                  XmlSchemaValidationFlags.ReportValidationWarnings
            };

            // Adiciona os esquemas XSD
            foreach (var xsdPath in xsdFilePaths)
            {
                if (!File.Exists(xsdPath))
                {
                    throw new FileNotFoundException($"Arquivo XSD não encontrado: {xsdPath}");
                }

                var schema = XmlSchema.Read(File.OpenRead(xsdPath), null);
                settings.Schemas.Add(schema);
            }

            // Configura o event handler para capturar erros e avisos
            settings.ValidationEventHandler += ValidationEventHandler;

            // Cria um StringReader para o XML
            using (var stringReader = new StringReader(xmlContent))
            using (var xmlReader = XmlReader.Create(stringReader, settings))
            {
                // Valida o XML
                while (xmlReader.Read()) { }
            }

            // Retorna o resultado da validação
            return new ValidationResult
            {
                IsValid = _validationErrors.Count == 0,
                Errors = [.. _validationErrors],
                Warnings = [.. _validationWarnings]
            };
        }
        catch (XmlException ex)
        {
            _validationErrors.Add($"Erro de XML: {ex.Message}");
            return new ValidationResult
            {
                IsValid = false,
                Errors = [.. _validationErrors],
                Warnings = [.. _validationWarnings]
            };
        }
        catch (Exception ex)
        {
            _validationErrors.Add($"Erro geral: {ex.Message}");
            return new ValidationResult
            {
                IsValid = false,
                Errors = [.. _validationErrors],
                Warnings = [.. _validationWarnings]
            };
        }
    }

    public ValidationResult ValidateXmlWithXsdContent(string xmlContent, params string[] xsdContents)
    {
        // Limpa erros e avisos da validação anterior
        _validationErrors.Clear();
        _validationWarnings.Clear();

        try
        {
            // Valida se o XML não está vazio
            if (string.IsNullOrWhiteSpace(xmlContent))
            {
                throw new ArgumentException("O conteúdo XML não pode estar vazio", nameof(xmlContent));
            }

            // Valida se foram fornecidos conteúdos XSD
            if (xsdContents == null || xsdContents.Length == 0)
            {
                throw new ArgumentException("É necessário fornecer pelo menos um conteúdo XSD", nameof(xsdContents));
            }

            // Configura as configurações do XmlReader
            var settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema,
                ValidationFlags = XmlSchemaValidationFlags.ProcessInlineSchema |
                                  XmlSchemaValidationFlags.ProcessSchemaLocation |
                                  XmlSchemaValidationFlags.ReportValidationWarnings
            };

            // Adiciona os esquemas XSD a partir do conteúdo string
            foreach (var xsdContent in xsdContents)
            {
                if (string.IsNullOrWhiteSpace(xsdContent))
                {
                    continue;
                }

                using (var xsdReader = new StringReader(xsdContent))
                {
                    var schema = XmlSchema.Read(xsdReader, null);
                    settings.Schemas.Add(schema);
                }
            }

            // Configura o event handler para capturar erros e avisos
            settings.ValidationEventHandler += ValidationEventHandler;

            // Cria um StringReader para o XML
            using (var stringReader = new StringReader(xmlContent))
            using (var xmlReader = XmlReader.Create(stringReader, settings))
            {
                // Valida o XML
                while (xmlReader.Read()) { }
            }

            // Retorna o resultado da validação
            return new ValidationResult
            {
                IsValid = _validationErrors.Count == 0,
                Errors = [.. _validationErrors],
                Warnings = [.. _validationWarnings]
            };
        }
        catch (XmlException ex)
        {
            _validationErrors.Add($"Erro de XML: {ex.Message}");
            return new ValidationResult
            {
                IsValid = false,
                Errors = [.. _validationErrors],
                Warnings = [.. _validationWarnings]
            };
        }
        catch (Exception ex)
        {
            _validationErrors.Add($"Erro geral: {ex.Message}");
            return new ValidationResult
            {
                IsValid = false,
                Errors = [.. _validationErrors],
                Warnings = [.. _validationWarnings]
            };
        }
    }

    private void ValidationEventHandler(object sender, ValidationEventArgs e)
    {
        switch (e.Severity)
        {
            case XmlSeverityType.Error:
                _validationErrors.Add($"Erro de validação: {e.Message} (Linha: {e.Exception?.LineNumber}, Posição: {e.Exception?.LinePosition})");
                break;
            case XmlSeverityType.Warning:
                _validationWarnings.Add($"Aviso de validação: {e.Message} (Linha: {e.Exception?.LineNumber}, Posição: {e.Exception?.LinePosition})");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public bool ValidarAssinaturaXml(string xmlAssinado)
    {
        try
        {
            var xmlDoc = new XmlDocument
            {
                PreserveWhitespace = true
            };
            xmlDoc.LoadXml(xmlAssinado);

            var namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
            namespaceManager.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");

            var signatureNode = xmlDoc.SelectSingleNode("//ds:Signature", namespaceManager) as XmlElement;
            if (signatureNode == null)
                throw new Exception("Elemento <Signature> não encontrado no XML.");

            var signedXml = new SignedXml(xmlDoc);

            signedXml.LoadXml(signatureNode);

            var certNode = signatureNode.SelectSingleNode(".//ds:X509Certificate", namespaceManager);
            if (certNode == null)
                throw new Exception("Certificado digital não encontrado na assinatura.");

            var base64Cert = certNode.InnerText;
            var certificate = X509CertificateLoader.LoadCertificate(Convert.FromBase64String(base64Cert));

            var isValid = signedXml.CheckSignature(certificate, true);
            return isValid;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro na validação da assinatura: {ex.Message}");
            return false;
        }
    }

}