using Newtonsoft.Json;
using System.Xml.Linq;

namespace Poc.NfseIntegracao.App.Janelas
{
    public partial class FrmEditarDadosEmitentes : Form
    {
        private readonly string _xmlOriginal;
        private List<CodigoTributacao> _codigosTributacao = [];

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string? XmlAlterado { get; private set; }

        public FrmEditarDadosEmitentes(string xmlString)
        {
            InitializeComponent();
            CarregarCodigosTributacao();
            ConfigurarAutoComplete();
            _xmlOriginal = xmlString;
        }

        private void CarregarCodigosTributacao()
        {
            try
            {
                // Carrega o JSON dos códigos de tributação
                string jsonPath = Path.Combine(Application.StartupPath, "Data/itensServico.json");
                string jsonContent = File.ReadAllText(jsonPath);
                var codigos = JsonConvert.DeserializeObject<List<CodigoTributacao>>(jsonContent);
                _codigosTributacao = codigos ?? new List<CodigoTributacao>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar códigos de tributação: {ex.Message}");
                _codigosTributacao = new List<CodigoTributacao>();
            }
        }

        // MÉTODO 1: AutoCompleteStringCollection (Mais simples)
        private void ConfigurarAutoComplete()
        {
            // Configura o autocomplete básico do TextBox
            var autoCompleteCollection = new AutoCompleteStringCollection();

            foreach (var codigo in _codigosTributacao)
            {
                // Adiciona tanto o código quanto a descrição para busca
                autoCompleteCollection.Add($"{codigo.codigo} - {codigo.descricao}");
                //autoCompleteCollection.Add(codigo.codigo);
                //autoCompleteCollection.Add(codigo.descricao);
            }

            txtCodigoTributoNacional.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCodigoTributoNacional.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCodigoTributoNacional.AutoCompleteCustomSource = autoCompleteCollection;
        }

        private void FrmEditarDadosEmitentes_Load(object sender, EventArgs e)
        {
            var xmlDoc = XDocument.Parse(_xmlOriginal);
            XNamespace ns = "http://www.sped.fazenda.gov.br/nfse";

            // Data de Competência
            var data = xmlDoc.Descendants(ns + "dhProc").FirstOrDefault();
            txtCompetencia.Text = data != null && DateTime.TryParse(data.Value, out var dt) ? dt.ToString("yyyy-MM-dd") : string.Empty;

            // Emitente
            var emit = xmlDoc.Descendants(ns + "emit").FirstOrDefault();
            txtEmitente.Text = emit?.Element(ns + "xNome")?.Value ?? string.Empty;
            txtCnpj.Text = emit?.Element(ns + "CNPJ")?.Value ?? string.Empty;
            txtInscricaoMunicipal.Text = emit?.Element(ns + "IM")?.Value ?? string.Empty;

            // Prestador (caso queira preencher igual ao emitente, pode ser removido)
            // var prest = xmlDoc.Descendants(ns + "prest").FirstOrDefault();

            // Código e Nome do Município
            txtCodigoMunicipio.Text = xmlDoc.Descendants(ns + "cLocIncid").FirstOrDefault()?.Value
                ?? xmlDoc.Descendants(ns + "cLocEmi").FirstOrDefault()?.Value
                ?? string.Empty;
            txtNomeMunicipio.Text = xmlDoc.Descendants(ns + "xLocPrestacao").FirstOrDefault()?.Value
                ?? xmlDoc.Descendants(ns + "xLocEmi").FirstOrDefault()?.Value
                ?? string.Empty;

            // Valores
            txtValorBaseCalculo.Text = xmlDoc.Descendants(ns + "vBC").FirstOrDefault()?.Value ?? string.Empty;
            txtValorAliquota.Text = xmlDoc.Descendants(ns + "pAliqAplic").FirstOrDefault()?.Value ?? string.Empty;
            txtValorIssqn.Text = xmlDoc.Descendants(ns + "vISSQN").FirstOrDefault()?.Value ?? string.Empty;
            txtValorLiquido.Text = xmlDoc.Descendants(ns + "vLiq").FirstOrDefault()?.Value ?? string.Empty;
            txtValorRetido.Text = xmlDoc.Descendants(ns + "vTotalRet").FirstOrDefault()?.Value ?? string.Empty;

            // Código de Tributação Nacional
            txtCodigoTributoNacional.Text = xmlDoc.Descendants(ns + "cServ").FirstOrDefault()?.Element(ns + "cTribNac")?.Value ?? string.Empty;

            // Código de Obra
            txtCodigoObra.Text = xmlDoc.Descendants(ns + "serv").FirstOrDefault()?.Element(ns + "obra")?.Element(ns + "cObra")?.Value ?? string.Empty;

            // Endereço da Obra
            var obra = xmlDoc.Descendants(ns + "serv").FirstOrDefault()?.Element(ns + "obra");
            var endObra = obra?.Element(ns + "end");
            //ckbEnderecoObra.Checked = endObra != null;
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
            txtBox.SelectionStart =
                Math.Min(selectionStart - (originalText.Length - digitsOnly.Length), digitsOnly.Length);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var emitente = txtEmitente.Text.Trim();
            var cnpj = txtCnpj.Text.Trim();
            var im = txtInscricaoMunicipal.Text.Trim();
            var data = txtCompetencia.Text.Trim();
            var codigoMunicipio = txtCodigoMunicipio.Text.Trim();
            var nomeMunicipio = txtNomeMunicipio.Text.Trim();
            var valorBaseCalculo = txtValorBaseCalculo.Text.Trim();
            var valorAliquota = txtValorAliquota.Text.Trim();
            var valorIssqn = txtValorIssqn.Text.Trim();
            var valorLiquido = txtValorLiquido.Text.Trim();
            var valorRetido = txtValorRetido.Text.Trim();
            var codigoObra = txtCodigoObra.Text.Trim();

            var codigoTributoNacional = txtCodigoTributoNacional.Text.Split('-')[0].Trim();
            var codigoTributoNacionalTexto = txtCodigoTributoNacional.Text.Split('-').Length > 1
                ? txtCodigoTributoNacional.Text.Split('-')[1].Trim().Replace(".", "")
                : string.Empty;

            //var mostrarEnderecoObra = ckbEnderecoObra.Checked;

            var xmlDoc = XDocument.Parse(_xmlOriginal);
            XNamespace ns = "http://www.sped.fazenda.gov.br/nfse";

            if (codigoTributoNacional.StartsWith("07") && string.IsNullOrEmpty(txtCodigoObra.Text))
            {
                MessageBox.Show(@"O ""Código de Obra"" é obrigatório quando o Código de Tributação Nacional pertencer ao item 07 da lista de serviços");
                txtCodigoObra.BackColor = Color.LightYellow;
                txtCodigoObra.Focus();
                return;
            }

            if (codigoTributoNacional.StartsWith("12"))
            {
                //MessageBox.Show(@"O ""Código de Obra"" é obrigatório quando o Código de Tributação Nacional pertencer ao item 12 da lista de serviços");
                EditarAtividadeEvento(xmlDoc, ns);
            }

            try
            {

                EditarEmitente(xmlDoc, ns, emitente, cnpj, im);
                EditarPrestador(xmlDoc, ns, emitente, cnpj, im);
                EditarCodigoMunicipio(xmlDoc, ns, codigoMunicipio);
                EditarNomeMunicipio(xmlDoc, ns, nomeMunicipio);
                EditarDatas(xmlDoc, ns, data);
                EditarCodigoTributoNacional(xmlDoc, ns, codigoTributoNacional, codigoTributoNacionalTexto);
                EditarCodigoObra(xmlDoc, ns, codigoObra);
                EditarValorBaseCalculo(xmlDoc, ns, valorBaseCalculo);
                EditarValorAliquota(xmlDoc, ns, valorAliquota);
                EditarValorIssqn(xmlDoc, ns, valorIssqn);
                EditarValorLiquido(xmlDoc, ns, valorLiquido);
                EditarValorRetido(xmlDoc, ns, valorRetido);
                //EditarEnderecoObra(xmlDoc, ns, mostrarEnderecoObra);

                XmlAlterado = xmlDoc.Declaration + Environment.NewLine + xmlDoc;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Erro ao processar o XML: {ex.Message}", @"Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void EditarCodigoTributoNacional(XDocument xmlDoc, XNamespace ns, string codigoTributoNacional, string descricao)
        {
            if (string.IsNullOrEmpty(codigoTributoNacional)) return;
            if (string.IsNullOrEmpty(descricao)) return;

            var emit = xmlDoc.Descendants(ns + "cServ").FirstOrDefault();
            var infNFSe = xmlDoc.Descendants(ns + "infNFSe").FirstOrDefault();

            if (emit == null) return;

            var obra = emit.Element(ns + "cTribNac");
            if (obra == null) return;

            var xDescServ = emit.Element(ns + "xDescServ");
            if (xDescServ == null) return;

            var xTribMun = infNFSe?.Element(ns + "xTribMun");
            if (xTribMun == null) return;

            var xTribNac = infNFSe.Element(ns + "xTribNac");
            if (xTribNac == null) return;

            obra.SetValue(codigoTributoNacional);
            xDescServ.SetValue(descricao);
            xTribNac.SetValue(descricao);
            xTribMun.SetValue(descricao);
        }

        private void EditarCodigoObra(XDocument xmlDoc, XNamespace ns, string codigoObra)
        {
            if (string.IsNullOrEmpty(codigoObra)) return;

            var serv = xmlDoc.Descendants(ns + "serv").FirstOrDefault();
            if (serv == null) return;

            var obra = serv.Element(ns + "obra");
            if (obra == null)
            {
                obra = new XElement(ns + "obra");
                serv.Add(obra);
            }

            var cObra = obra.Element(ns + "cObra");
            if (cObra == null)
            {
                cObra = new XElement(ns + "cObra");
                obra.Add(cObra);
            }

            cObra.SetValue(codigoObra);
        }

        private void EditarEmitente(XDocument xmlDoc, XNamespace ns, string emitente, string cnpj, string im)
        {
            var emit = xmlDoc.Descendants(ns + "emit").FirstOrDefault();
            if (emit == null) return;

            if (!string.IsNullOrEmpty(cnpj))
            {
                emit.Element(ns + "CNPJ")?.SetValue(cnpj);
            }

            if (!string.IsNullOrEmpty(emitente))
            {
                emit.Element(ns + "xNome")?.SetValue(emitente);
                emit.Element(ns + "xFant")?.SetValue(emitente);
            }

            if (!string.IsNullOrEmpty(im))
            {
                emit.Element(ns + "IM")?.SetValue(im);
            }
        }

        private void EditarPrestador(XDocument xmlDoc, XNamespace ns, string emitente, string cnpj, string im)
        {
            var prest = xmlDoc.Descendants(ns + "prest").FirstOrDefault();
            if (prest == null) return;

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

        private void EditarCodigoMunicipio(XDocument xmlDoc, XNamespace ns, string codigoMunicipio)
        {
            if (string.IsNullOrEmpty(codigoMunicipio)) return;

            var cLocIncid = xmlDoc.Descendants(ns + "cLocIncid").FirstOrDefault();
            if (cLocIncid != null) cLocIncid.Value = codigoMunicipio;

            var cLocEmi = xmlDoc.Descendants(ns + "cLocEmi").FirstOrDefault();
            if (cLocEmi != null) cLocEmi.Value = codigoMunicipio;
        }

        private void EditarNomeMunicipio(XDocument xmlDoc, XNamespace ns, string nomeMunicipio)
        {
            if (string.IsNullOrEmpty(nomeMunicipio)) return;

            var xLocPrestacao = xmlDoc.Descendants(ns + "xLocPrestacao").FirstOrDefault();
            if (xLocPrestacao != null) xLocPrestacao.Value = nomeMunicipio;

            var xLocEmi = xmlDoc.Descendants(ns + "xLocEmi").FirstOrDefault();
            if (xLocEmi != null) xLocEmi.Value = nomeMunicipio;
        }

        private void EditarDatas(XDocument xmlDoc, XNamespace ns, string data)
        {
            var dhProc = xmlDoc.Descendants(ns + "dhProc").FirstOrDefault();
            var dhEmi = xmlDoc.Descendants(ns + "dhEmi").FirstOrDefault();
            if (dhProc == null || !DateTime.TryParse(data, out var dataConvertida)) return;

            dhProc.Value = dataConvertida.ToString("yyyy-MM-ddTHH:mm:sszzz");
            if (dhEmi != null) dhEmi.Value = dataConvertida.ToString("yyyy-MM-ddTHH:mm:sszzz");
        }

        private void EditarValorBaseCalculo(XDocument xmlDoc, XNamespace ns, string valorBaseCalculo)
        {
            var vBc = xmlDoc.Descendants(ns + "vBC").FirstOrDefault();
            if (vBc != null && !string.IsNullOrEmpty(valorBaseCalculo))
            {
                vBc.Value = valorBaseCalculo;
            }
        }

        private void EditarValorAliquota(XDocument xmlDoc, XNamespace ns, string valorAliquota)
        {
            var vAliq = xmlDoc.Descendants(ns + "pAliqAplic").FirstOrDefault();
            if (vAliq != null && !string.IsNullOrEmpty(valorAliquota))
            {
                vAliq.Value = valorAliquota;
            }

            var pAliq = xmlDoc.Descendants(ns + "pAliq").FirstOrDefault();
            if (pAliq != null && !string.IsNullOrEmpty(valorAliquota))
            {
                pAliq.Value = valorAliquota;
            }
        }

        private void EditarValorIssqn(XDocument xmlDoc, XNamespace ns, string valorIssqn)
        {
            var vIssqn = xmlDoc.Descendants(ns + "vISSQN").FirstOrDefault();
            if (vIssqn != null && !string.IsNullOrEmpty(valorIssqn))
            {
                vIssqn.Value = valorIssqn;
            }
        }

        private void EditarValorLiquido(XDocument xmlDoc, XNamespace ns, string valorLiquido)
        {
            var vNf = xmlDoc.Descendants(ns + "vLiq").FirstOrDefault();
            if (vNf != null && !string.IsNullOrEmpty(valorLiquido))
            {
                vNf.Value = valorLiquido;
            }

            var vServ = xmlDoc.Descendants(ns + "vServ").FirstOrDefault();
            if (vServ != null && !string.IsNullOrEmpty(valorLiquido))
            {
                vServ.Value = valorLiquido;
            }
        }

        private void EditarValorRetido(XDocument xmlDoc, XNamespace ns, string valorRetido)
        {
            var vRet = xmlDoc.Descendants(ns + "vTotalRet").FirstOrDefault();
            if (vRet != null && !string.IsNullOrEmpty(valorRetido))
            {
                vRet.Value = valorRetido;
            }
        }

        private void EditarEnderecoObra(XDocument xmlDoc, XNamespace ns, bool mostrarEnderecoObra)
        {
            var serv = xmlDoc.Descendants(ns + "serv").FirstOrDefault();
            if (serv == null) return;

            var obra = serv.Element(ns + "obra");

            if (obra == null)
            {
                obra = new XElement(ns + "obra");
            }

            if (mostrarEnderecoObra)
            {
                var end = new XElement(ns + "end",
                    new XElement(ns + "endNac",
                        new XElement(ns + "cMun", txtCodigoMunicipio.Text.Trim() ?? "3542404"),
                        new XElement(ns + "CEP", "19570000")
                    ),
                    new XElement(ns + "xLgr", "AV. Teste de Obra"),
                    new XElement(ns + "nro", "100"),
                    new XElement(ns + "xCpl", "S/N - PARTE"),
                    new XElement(ns + "xBairro", "Bairro de Teste")
                );
                obra.Add(end);
                serv.Add(obra);
            }
            else
            {
                var end = serv.Element(ns + "end");
                end?.Remove();
            }
        }
        private void EditarAtividadeEvento(XDocument xmlDoc, XNamespace ns)
        {
            var serv = xmlDoc.Descendants(ns + "serv").FirstOrDefault();
            if (serv == null)
                return;

            var atvEvento = serv.Element(ns + "atvEvento");
            if (atvEvento != null)
                return;

            atvEvento = new XElement(ns + "atvEvento",
                new XElement(ns + "desc", "Atividade de teste 01"),
                new XElement(ns + "dtIni", DateTime.Now.ToString("yyyy-MM-dd")),
                new XElement(ns + "dtFim", DateTime.Now.AddDays(30).ToString("yyyy-MM-dd")),
                new XElement(ns + "id", "123")
            );

            serv.Add(atvEvento);
        }

        private void txtCodigoObra_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoObra.Text))
                txtCodigoObra.BackColor = Color.White;
        }

        private void txtValorAliquota_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtValorAliquota_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',')
            {
                e.KeyChar = '.';
            }

            if (e.KeyChar == '.' && (sender as TextBox)?.Text?.Contains(".") == true)
            {
                e.Handled = true;
            }
        }

        private void txtValorBaseCalculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',')
            {
                e.KeyChar = '.';
            }

            if (e.KeyChar == '.' && (sender as TextBox)?.Text?.Contains(".") == true)
            {
                e.Handled = true;
            }
        }

        private void txtValorRetido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',')
            {
                e.KeyChar = '.';
            }

            if (e.KeyChar == '.' && (sender as TextBox)?.Text?.Contains(".") == true)
            {
                e.Handled = true;
            }
        }

        private void txtValorLiquido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',')
            {
                e.KeyChar = '.';
            }

            if (e.KeyChar == '.' && (sender as TextBox)?.Text?.Contains(".") == true)
            {
                e.Handled = true;
            }
        }

        private void txtCodigoObra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',')
            {
                e.KeyChar = '.';
            }

            if (e.KeyChar == '.' && (sender as TextBox)?.Text?.Contains(".") == true)
            {
                e.Handled = true;
            }
        }

        private void txtValorAliquota_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtValorAliquota.Text.Trim()) || string.IsNullOrEmpty(txtValorBaseCalculo.Text.Trim()))
            {
                txtValorIssqn.Text = string.Empty;
                return;
            }
            var valorBaseCalculo = Convert.ToDecimal(txtValorBaseCalculo.Text.Trim().Replace(".", ","));
            var valorAliquota = Convert.ToDecimal(txtValorAliquota.Text.Trim().Replace(".", ",")) / 100;
            var valorIssqn = valorAliquota * valorBaseCalculo;
            txtValorIssqn.Text = valorIssqn.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
            txtValorLiquido.Text = valorBaseCalculo.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
            txtValorBaseCalculo.Text = valorBaseCalculo.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
        }

        private void txtValorBaseCalculo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtValorAliquota.Text.Trim()) || string.IsNullOrEmpty(txtValorBaseCalculo.Text.Trim()))
            {
                txtValorIssqn.Text = string.Empty;
                return;
            }
            var valorBaseCalculo = Convert.ToDecimal(txtValorBaseCalculo.Text.Trim().Replace(".", ","));
            var valorAliquota = Convert.ToDecimal(txtValorAliquota.Text.Trim().Replace(".", ",")) / 100;
            var valorIssqn = valorAliquota * valorBaseCalculo;
            txtValorIssqn.Text = valorIssqn.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
            txtValorLiquido.Text = valorBaseCalculo.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
            txtValorBaseCalculo.Text = valorBaseCalculo.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
        }

        private void txtCodigoTributoNacional_Leave(object sender, EventArgs e)
        {

        }
    }

    public class CodigoTributacao
    {
        public string codigo { get; set; }
        public string descricao { get; set; }

        // Para exibir no autocomplete
        public override string ToString()
        {
            return $"{codigo} - {descricao}";
        }
    }
}
