using System.Xml.Linq;

namespace Poc.NfseIntegracao.App.Janelas
{
    public partial class FrmEditarDadosEmitentes : Form
    {
        private readonly string _xmlOriginal;
        public string XmlAlterado { get; private set; }

        public FrmEditarDadosEmitentes(string xmlString)
        {
            InitializeComponent();
            _xmlOriginal = xmlString;

            var xmlDoc = XDocument.Parse(_xmlOriginal);
            XNamespace ns = "http://www.sped.fazenda.gov.br/nfse";
            var data = xmlDoc.Descendants(ns + "dhProc").FirstOrDefault();

            txtCompetencia.Text = data != null ? DateTime.Parse(data.Value).ToString("yyyy-MM-dd") : string.Empty;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCnpj_TextChanged(object sender, EventArgs e)
        {
            if (sender is not TextBox txtBox) return;

            var selectionStart = txtBox.SelectionStart;
            var originalText = txtBox.Text;
            var digitsOnly = new string(originalText.Where(char.IsDigit).ToArray());

            if (originalText == digitsOnly) return;
            txtBox.Text = digitsOnly;
            txtBox.SelectionStart = Math.Min(selectionStart - (originalText.Length - digitsOnly.Length), digitsOnly.Length);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var emitente = txtEmitente.Text.Trim();
            var cnpj = txtCnpj.Text.Trim();
            var im = txtInscricaoMunicipal.Text.Trim();
            var data = txtCompetencia.Text.Trim();
            var codigoMunicipio = txtCodigoMunicipio.Text.Trim();
            var nomeMunicipio = txtNomeMunicipio.Text.Trim();

            try
            {
                var xmlDoc = XDocument.Parse(_xmlOriginal);
                XNamespace ns = "http://www.sped.fazenda.gov.br/nfse";

                var emit = xmlDoc.Descendants(ns + "emit").FirstOrDefault();
                if (emit != null)
                {
                    if (!string.IsNullOrEmpty(cnpj))
                    {
                        emit.Element(ns + "CNPJ")?.SetValue(cnpj);
                    }
                    if (!string.IsNullOrEmpty(emitente))
                    {
                        emit.Element(ns + "xNome")?.SetValue(emitente);
                    }
                    if (!string.IsNullOrEmpty(emitente))
                    {
                        emit.Element(ns + "xFant")?.SetValue(emitente);
                    }
                    if (!string.IsNullOrEmpty(im))
                    {
                        emit.Element(ns + "IM")?.SetValue(im);
                    }
                }

                var prest = xmlDoc.Descendants(ns + "prest").FirstOrDefault();
                if (prest != null)
                {
                    if (!string.IsNullOrEmpty(cnpj))
                    {
                        prest.Element(ns + "CNPJ")?.SetValue(cnpj);
                    }
                    if (!string.IsNullOrEmpty(emitente))
                    {
                        prest.Element(ns + "xNome")?.SetValue(emitente);
                    }
                    if (!string.IsNullOrEmpty(im))
                    {
                        prest.Element(ns + "IM")?.SetValue(im);
                    }
                }

                if (!string.IsNullOrEmpty(codigoMunicipio))
                {
                    var cLocIncid = xmlDoc.Descendants(ns + "cLocIncid").FirstOrDefault();
                    if (cLocIncid != null) cLocIncid.Value = codigoMunicipio;

                    var cLocEmi = xmlDoc.Descendants(ns + "cLocEmi").FirstOrDefault();
                    if (cLocEmi != null) cLocEmi.Value = codigoMunicipio;
                }

                if (!string.IsNullOrEmpty(nomeMunicipio))
                {
                    var xLocPrestacao = xmlDoc.Descendants(ns + "xLocPrestacao").FirstOrDefault();
                    if (xLocPrestacao != null) xLocPrestacao.Value = nomeMunicipio;

                    var xLocEmi = xmlDoc.Descendants(ns + "xLocEmi").FirstOrDefault();
                    if (xLocEmi != null) xLocEmi.Value = nomeMunicipio;
                }


                var dhProc = xmlDoc.Descendants(ns + "dhProc").FirstOrDefault();
                var dhEmi = xmlDoc.Descendants(ns + "dhEmi").FirstOrDefault();
                if (dhProc != null && DateTime.TryParse(data, out var dataConvertida))
                {
                    dhProc.Value = dataConvertida.ToString("yyyy-MM-ddTHH:mm:sszzz");
                    if (dhEmi != null) dhEmi.Value = dataConvertida.ToString("yyyy-MM-ddTHH:mm:sszzz");
                }

                XmlAlterado = xmlDoc.Declaration?.ToString() + Environment.NewLine + xmlDoc.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar o XML: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
