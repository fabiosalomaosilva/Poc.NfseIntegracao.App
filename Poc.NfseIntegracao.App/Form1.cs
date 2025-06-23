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
            txtXml.Controls[0].Text = TemplateXml.XmlExemplo;

            using var form = new FrmEditarDadosEmitentes(txtXml.Controls[0].Text);

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

                txtXmlFinal.Controls[0].Text = xmlAssinado;

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
                    txtApiResponse.Text = JsonSerializer.Serialize(response.Data, new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });

                    var (cnpj, nomeEmitente) = ObterDadosEmitente(txtXml.Controls[0].Text.Trim());
                    var data = JsonSerializer.Deserialize<DfeResponse>(txtApiResponse.Text);
                    DataService.SaveData(data.Lote[0].ChaveAcesso, cnpj, nomeEmitente, data.DataHoraProcessamento);
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

        private (string cadastroNacional, string nomeEmitente) ObterDadosEmitente(string xml)
        {
            var xmlDoc = XDocument.Parse(xml);
            XNamespace ns = "http://www.sped.fazenda.gov.br/nfse";
            var emitente = xmlDoc.Descendants(ns + "emit").FirstOrDefault();
            if (emitente == null) return (string.Empty, string.Empty);
            var cnpj = emitente.Element(ns + "CNPJ")?.Value ?? string.Empty;
            var nome = emitente.Element(ns + "xNome")?.Value ?? string.Empty;
            return (cnpj, nome);
        }

        private void enviadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmNfseList();
            frm.ShowDialog();
        }


    }
}
