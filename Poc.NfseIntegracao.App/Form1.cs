using Poc.NfseIntegracao.App.Data;
using Poc.NfseIntegracao.App.DTOs;
using Poc.NfseIntegracao.App.Janelas;
using Poc.NfseIntegracao.App.Services;
using Poc.NfseIntegracao.App.XSDs;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Xml.Linq;

namespace Poc.NfseIntegracao.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VerificaCertificado();
            VerificarArquivoDados();
            txtXml.Controls[0].Text = TemplateXml.XmlExemplo;

            //using var form = new FrmEditarDadosEmitentes(txtXml.Controls[0].Text);

            //if (form.ShowDialog() != DialogResult.OK) return;

            //var xmlModificado = form.XmlAlterado;

            //var rtb = new RichTextBox
            //{
            //    Font = new Font("Consolas", 10),
            //    Text = xmlModificado,
            //    SelectionIndent = 2
            //};

            //txtXml.Controls[0].Text = rtb.Text;
        }

        private void VerificarArquivoDados()
        {
            var fileDir = "c:/CertificadoClientes/Dados";
            var filePath = "c:/CertificadoClientes/Dados/dados.json";

            if (Directory.Exists(fileDir)) return;

            Directory.CreateDirectory(fileDir);
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }


        }

        private void VerificaCertificado()
        {
            if (!Directory.Exists("c:/CertificadoClientes"))
            {
                AbrirJanelaAddCertificadoDigital();
                return;
            }

            if (File.Exists("c:/CertificadoClientes/cert.pfx"))
            {
                return;
            }
            AbrirJanelaAddCertificadoDigital();
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                txtApiResponse.Text = string.Empty;
                txtXmlCompactado.Text = string.Empty;
                txtXmlFinal.Text = string.Empty;

                using var serviceIntegration = new NfseIntegrationService();
                var xmlService = new XmlService();

                var chaveDps = xmlService.GerarChaveDpsAsync(txtXml.Controls[0].Text.Trim());
                var xmlComDps = xmlService.InserirNovaChave(txtXml.Controls[0].Text.Trim(), chaveDps, "infDPS");

                var chaveAcesso = xmlService.GerarChaveAcessoAsync(xmlComDps);
                var xmlComChaveAcesso = xmlService.InserirNovaChave(xmlComDps, chaveAcesso, "infNFSe");

                var xmlAssinado = xmlService.AssinarXml(xmlComChaveAcesso);
                var xmlValidator = new XmlValidator();

                //var xmlValidation = xmlValidator.ValidateXml(txtXml.Controls[0].Text.Trim());
                //if (!xmlValidation.IsValid)
                //{
                //    var json = JsonSerializer.Serialize(xmlValidation.Errors, new JsonSerializerOptions
                //    {
                //        WriteIndented = true,
                //        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                //    });
                //    var decodedJson = Regex.Unescape(json);

                //    using var rtbTemp = new RichTextBox();
                //    rtbTemp.Font = new Font("Consolas", 10);
                //    rtbTemp.Text = decodedJson;

                //    txtApiResponse.Rtf = rtbTemp.Rtf;

                //    return;
                //}

                var xmlFormatado = xmlAssinado;
                try
                {
                    var doc = new System.Xml.XmlDocument();
                    doc.LoadXml(xmlAssinado);
                    await using var stringWriter = new StringWriter();
                    await using var xmlTextWriter = new System.Xml.XmlTextWriter(stringWriter);
                    xmlTextWriter.Formatting = System.Xml.Formatting.Indented;
                    doc.WriteContentTo(xmlTextWriter);
                    xmlTextWriter.Flush();
                    xmlFormatado = stringWriter.GetStringBuilder().ToString();
                }
                catch
                {
                    // Se não for XML válido, mantém o texto original
                }

                txtXmlFinal.Controls[0].Text = xmlFormatado;

                var ehValido = xmlValidator.ValidarAssinaturaXml(xmlAssinado);

                if (!ehValido)
                {
                    MessageBox.Show("A assinatura do XML não é válida.");
                    return;
                }

                var xmlCompactado = await xmlService.CompactarXmlAsync(xmlAssinado);

                txtXmlCompactado.Text = xmlCompactado;

                var response = await serviceIntegration.CriarNfse(xmlCompactado);

                if (response.Success)
                {
                    txtApiResponse.Text = JsonSerializer.Serialize(response.Data,
                        new JsonSerializerOptions
                        { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });

                    var dadosApi = JsonSerializer.Deserialize<DfeResponse>(txtApiResponse.Text);
                    var dataNfse = ObterDadosEmitente(txtXml.Controls[0].Text.Trim(), dadosApi.Lote[0].ChaveAcesso, dadosApi.DataHoraProcessamento);
                    var data = JsonSerializer.Deserialize<DfeResponse>(txtApiResponse.Text);

                    DataService.SaveData(dataNfse, data.DataHoraProcessamento);
                }
                else
                    txtApiResponse.Text = JsonSerializer.Serialize(response.ErrorMessage, new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void certificadoDigitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirJanelaAddCertificadoDigital();
        }

        private static void AbrirJanelaAddCertificadoDigital()
        {
            var frm = new FrmAddCertificado();
            frm.ShowDialog();
        }

        private void editarDadosDoEmitenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var xmlString = txtXml.Controls[0].Text;
            if (string.IsNullOrWhiteSpace(xmlString))
            {
                MessageBox.Show("Por favor, insira o XML antes de editar os dados do emitente.");
                return;
            }

            using var form = new FrmEditarDadosEmitentes(xmlString);

            if (form.ShowDialog() != DialogResult.OK) return;

            var xmlModificado = form.XmlAlterado;

            var rtb = new RichTextBox
            {
                Font = new Font("Consolas", 10),
                Text = xmlModificado,
                SelectionIndent = 2
            };

            txtXml.Controls[0].Text = rtb.Text;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // DTO para armazenar os dados extraídos


        private NfseData ObterDadosEmitente(string xml, string chaveAcesso, DateTime dataProcessamento)
        {
            var xmlDoc = XDocument.Parse(xml);
            XNamespace ns = "http://www.sped.fazenda.gov.br/nfse";
            var emitente = xmlDoc.Descendants(ns + "emit").FirstOrDefault();
            if (emitente == null) return new NfseData();

            var cnpj = emitente.Element(ns + "CNPJ")?.Value ?? string.Empty;
            var nome = emitente.Element(ns + "xNome")?.Value ?? string.Empty;
            if (string.IsNullOrEmpty(cnpj) && emitente.Element(ns + "CPF") != null)
            {
                cnpj = emitente.Element(ns + "CPF")?.Value ?? string.Empty;
            }

            // Busca os valores das tags solicitadas
            var cTribNac = xmlDoc.Descendants(ns + "cTribNac").FirstOrDefault()?.Value ?? string.Empty;
            var vServ = xmlDoc.Descendants(ns + "vServ").FirstOrDefault()?.Value ?? string.Empty;
            var vBC = xmlDoc.Descendants(ns + "vBC").FirstOrDefault()?.Value ?? string.Empty;
            var pAliqAplic = xmlDoc.Descendants(ns + "pAliqAplic").FirstOrDefault()?.Value ?? string.Empty;
            var vISSQN = xmlDoc.Descendants(ns + "vISSQN").FirstOrDefault()?.Value ?? string.Empty;
            var vLiq = xmlDoc.Descendants(ns + "vLiq").FirstOrDefault()?.Value ?? string.Empty;

            return new NfseData
            {
                CadastroNacional = cnpj,
                NomeEmitente = nome,
                cTribNac = cTribNac,
                vServ = vServ,
                vBC = vBC,
                pAliqAplic = pAliqAplic,
                vISSQN = vISSQN,
                vLiq = vLiq,
                DataProcessamento = dataProcessamento,
                ChaveAcesso = chaveAcesso
            };
        }

        private void enviadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmNfseList();
            frm.ShowDialog();
        }

        private void nSUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmNsuList();
            frm.ShowDialog();
        }
    }
}
