namespace Poc.NfseIntegracao.App.Janelas
{
    partial class FrmEditarDadosEmitentes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            txtEmitente = new TextBox();
            txtValorRetido = new TextBox();
            label2 = new Label();
            txtCnpj = new TextBox();
            label3 = new Label();
            txtInscricaoMunicipal = new TextBox();
            label4 = new Label();
            txtCompetencia = new DateTimePicker();
            label5 = new Label();
            txtCodigoMunicipio = new TextBox();
            label6 = new Label();
            txtNomeMunicipio = new TextBox();
            panel1 = new Panel();
            btnCancelar = new Button();
            btnSalvar = new Button();
            label10 = new Label();
            label8 = new Label();
            label12 = new Label();
            label14 = new Label();
            txtValorBaseCalculo = new TextBox();
            txtValorLiquido = new TextBox();
            txtCodigoObra = new TextBox();
            label7 = new Label();
            txtValorAliquota = new TextBox();
            label11 = new Label();
            txtValorIssqn = new TextBox();
            label9 = new Label();
            txtCodigoTributoNacional = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(txtEmitente, 1, 1);
            tableLayoutPanel1.Controls.Add(txtValorRetido, 1, 6);
            tableLayoutPanel1.Controls.Add(label2, 2, 1);
            tableLayoutPanel1.Controls.Add(txtCnpj, 3, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(txtInscricaoMunicipal, 1, 2);
            tableLayoutPanel1.Controls.Add(label4, 2, 2);
            tableLayoutPanel1.Controls.Add(txtCompetencia, 3, 2);
            tableLayoutPanel1.Controls.Add(label5, 0, 3);
            tableLayoutPanel1.Controls.Add(txtCodigoMunicipio, 1, 3);
            tableLayoutPanel1.Controls.Add(label6, 2, 3);
            tableLayoutPanel1.Controls.Add(txtNomeMunicipio, 3, 3);
            tableLayoutPanel1.Controls.Add(panel1, 3, 8);
            tableLayoutPanel1.Controls.Add(label10, 2, 5);
            tableLayoutPanel1.Controls.Add(label8, 0, 4);
            tableLayoutPanel1.Controls.Add(label12, 0, 7);
            tableLayoutPanel1.Controls.Add(label14, 2, 6);
            tableLayoutPanel1.Controls.Add(txtValorBaseCalculo, 1, 4);
            tableLayoutPanel1.Controls.Add(txtValorLiquido, 3, 5);
            tableLayoutPanel1.Controls.Add(txtCodigoObra, 1, 7);
            tableLayoutPanel1.Controls.Add(label7, 2, 4);
            tableLayoutPanel1.Controls.Add(txtValorAliquota, 3, 4);
            tableLayoutPanel1.Controls.Add(label11, 0, 5);
            tableLayoutPanel1.Controls.Add(txtValorIssqn, 1, 5);
            tableLayoutPanel1.Controls.Add(label9, 0, 6);
            tableLayoutPanel1.Controls.Add(txtCodigoTributoNacional, 3, 6);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 9;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.Size = new Size(1096, 391);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 55);
            label1.Margin = new Padding(15, 5, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 1;
            label1.Text = "Emitente:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEmitente
            // 
            txtEmitente.Dock = DockStyle.Fill;
            txtEmitente.Location = new Point(167, 53);
            txtEmitente.Margin = new Padding(3, 3, 15, 3);
            txtEmitente.Name = "txtEmitente";
            txtEmitente.Size = new Size(365, 23);
            txtEmitente.TabIndex = 5;
            // 
            // txtValorRetido
            // 
            txtValorRetido.Location = new Point(167, 203);
            txtValorRetido.Margin = new Padding(3, 3, 15, 3);
            txtValorRetido.MaxLength = 14;
            txtValorRetido.Name = "txtValorRetido";
            txtValorRetido.Size = new Size(365, 23);
            txtValorRetido.TabIndex = 50;
            txtValorRetido.KeyPress += txtValorRetido_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(562, 55);
            label2.Margin = new Padding(15, 5, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 2;
            label2.Text = "CNPJ:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCnpj
            // 
            txtCnpj.Dock = DockStyle.Fill;
            txtCnpj.Location = new Point(714, 53);
            txtCnpj.Margin = new Padding(3, 3, 15, 3);
            txtCnpj.MaxLength = 14;
            txtCnpj.Name = "txtCnpj";
            txtCnpj.Size = new Size(367, 23);
            txtCnpj.TabIndex = 6;
            txtCnpj.TextChanged += txtCnpj_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 85);
            label3.Margin = new Padding(15, 5, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(113, 15);
            label3.TabIndex = 3;
            label3.Text = "Inscrição municipal:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtInscricaoMunicipal
            // 
            txtInscricaoMunicipal.Dock = DockStyle.Fill;
            txtInscricaoMunicipal.Location = new Point(167, 83);
            txtInscricaoMunicipal.Margin = new Padding(3, 3, 15, 3);
            txtInscricaoMunicipal.MaxLength = 14;
            txtInscricaoMunicipal.Name = "txtInscricaoMunicipal";
            txtInscricaoMunicipal.Size = new Size(365, 23);
            txtInscricaoMunicipal.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(562, 85);
            label4.Margin = new Padding(15, 5, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(122, 15);
            label4.TabIndex = 4;
            label4.Text = "Data da competência:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCompetencia
            // 
            txtCompetencia.Dock = DockStyle.Fill;
            txtCompetencia.Format = DateTimePickerFormat.Short;
            txtCompetencia.Location = new Point(714, 83);
            txtCompetencia.Margin = new Padding(3, 3, 15, 3);
            txtCompetencia.Name = "txtCompetencia";
            txtCompetencia.Size = new Size(367, 23);
            txtCompetencia.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 115);
            label5.Margin = new Padding(15, 5, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(123, 15);
            label5.TabIndex = 12;
            label5.Text = "Código do município:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCodigoMunicipio
            // 
            txtCodigoMunicipio.Dock = DockStyle.Fill;
            txtCodigoMunicipio.Location = new Point(167, 113);
            txtCodigoMunicipio.Margin = new Padding(3, 3, 15, 3);
            txtCodigoMunicipio.MaxLength = 14;
            txtCodigoMunicipio.Name = "txtCodigoMunicipio";
            txtCodigoMunicipio.Size = new Size(365, 23);
            txtCodigoMunicipio.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(562, 115);
            label6.Margin = new Padding(15, 5, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(117, 15);
            label6.TabIndex = 14;
            label6.Text = "Nome do município:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtNomeMunicipio
            // 
            txtNomeMunicipio.Dock = DockStyle.Fill;
            txtNomeMunicipio.Location = new Point(714, 113);
            txtNomeMunicipio.Margin = new Padding(3, 3, 15, 3);
            txtNomeMunicipio.Name = "txtNomeMunicipio";
            txtNomeMunicipio.Size = new Size(367, 23);
            txtNomeMunicipio.TabIndex = 25;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnSalvar);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(714, 263);
            panel1.Name = "panel1";
            panel1.Size = new Size(379, 125);
            panel1.TabIndex = 9;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9.75F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(252, 13);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(115, 32);
            btnCancelar.TabIndex = 70;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.Green;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Font = new Font("Segoe UI", 9.75F);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(131, 13);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(115, 32);
            btnSalvar.TabIndex = 65;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(562, 175);
            label10.Margin = new Padding(15, 5, 3, 0);
            label10.Name = "label10";
            label10.Size = new Size(79, 15);
            label10.TabIndex = 18;
            label10.Text = "Valor Líquido:";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 145);
            label8.Margin = new Padding(15, 5, 3, 0);
            label8.Name = "label8";
            label8.Size = new Size(122, 15);
            label8.TabIndex = 16;
            label8.Text = "Valor Base de Cálculo:";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(15, 235);
            label12.Margin = new Padding(15, 5, 3, 0);
            label12.Name = "label12";
            label12.Size = new Size(76, 15);
            label12.TabIndex = 20;
            label12.Text = "Código obra:";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(562, 205);
            label14.Margin = new Padding(15, 5, 3, 0);
            label14.Name = "label14";
            label14.Size = new Size(139, 15);
            label14.TabIndex = 22;
            label14.Text = "Código Tributo Nacional:";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtValorBaseCalculo
            // 
            txtValorBaseCalculo.Dock = DockStyle.Fill;
            txtValorBaseCalculo.Location = new Point(167, 143);
            txtValorBaseCalculo.Margin = new Padding(3, 3, 15, 3);
            txtValorBaseCalculo.MaxLength = 14;
            txtValorBaseCalculo.Name = "txtValorBaseCalculo";
            txtValorBaseCalculo.Size = new Size(365, 23);
            txtValorBaseCalculo.TabIndex = 30;
            txtValorBaseCalculo.KeyPress += txtValorBaseCalculo_KeyPress;
            txtValorBaseCalculo.Leave += txtValorBaseCalculo_Leave;
            // 
            // txtValorLiquido
            // 
            txtValorLiquido.Dock = DockStyle.Fill;
            txtValorLiquido.Location = new Point(714, 173);
            txtValorLiquido.Margin = new Padding(3, 3, 15, 3);
            txtValorLiquido.MaxLength = 14;
            txtValorLiquido.Name = "txtValorLiquido";
            txtValorLiquido.ReadOnly = true;
            txtValorLiquido.Size = new Size(367, 23);
            txtValorLiquido.TabIndex = 45;
            txtValorLiquido.KeyPress += txtValorLiquido_KeyPress;
            // 
            // txtCodigoObra
            // 
            txtCodigoObra.Dock = DockStyle.Fill;
            txtCodigoObra.Location = new Point(167, 233);
            txtCodigoObra.Margin = new Padding(3, 3, 15, 3);
            txtCodigoObra.MaxLength = 14;
            txtCodigoObra.Name = "txtCodigoObra";
            txtCodigoObra.Size = new Size(365, 23);
            txtCodigoObra.TabIndex = 60;
            txtCodigoObra.TextChanged += txtCodigoObra_TextChanged;
            txtCodigoObra.KeyPress += txtCodigoObra_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(562, 145);
            label7.Margin = new Padding(15, 5, 3, 0);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 15;
            label7.Text = "Alíquota:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtValorAliquota
            // 
            txtValorAliquota.Location = new Point(714, 143);
            txtValorAliquota.Margin = new Padding(3, 3, 15, 3);
            txtValorAliquota.MaxLength = 14;
            txtValorAliquota.Name = "txtValorAliquota";
            txtValorAliquota.Size = new Size(367, 23);
            txtValorAliquota.TabIndex = 35;
            txtValorAliquota.TextChanged += txtValorAliquota_TextChanged;
            txtValorAliquota.KeyPress += txtValorAliquota_KeyPress;
            txtValorAliquota.Leave += txtValorAliquota_Leave;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(15, 175);
            label11.Margin = new Padding(15, 5, 3, 0);
            label11.Name = "label11";
            label11.Size = new Size(72, 15);
            label11.TabIndex = 19;
            label11.Text = "Valor ISSQN:";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtValorIssqn
            // 
            txtValorIssqn.Location = new Point(167, 173);
            txtValorIssqn.Margin = new Padding(3, 3, 15, 3);
            txtValorIssqn.MaxLength = 14;
            txtValorIssqn.Name = "txtValorIssqn";
            txtValorIssqn.ReadOnly = true;
            txtValorIssqn.Size = new Size(365, 23);
            txtValorIssqn.TabIndex = 40;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(15, 205);
            label9.Margin = new Padding(15, 5, 3, 0);
            label9.Name = "label9";
            label9.Size = new Size(70, 15);
            label9.TabIndex = 17;
            label9.Text = "Valor retido:";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCodigoTributoNacional
            // 
            txtCodigoTributoNacional.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtCodigoTributoNacional.Dock = DockStyle.Fill;
            txtCodigoTributoNacional.Location = new Point(714, 203);
            txtCodigoTributoNacional.Margin = new Padding(3, 3, 15, 3);
            txtCodigoTributoNacional.MaxLength = 14;
            txtCodigoTributoNacional.Name = "txtCodigoTributoNacional";
            txtCodigoTributoNacional.Size = new Size(367, 23);
            txtCodigoTributoNacional.TabIndex = 61;
            // 
            // FrmEditarDadosEmitentes
            // 
            AcceptButton = btnSalvar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(1096, 391);
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmEditarDadosEmitentes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar dados do XML";
            Load += FrmEditarDadosEmitentes_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtEmitente;
        private TextBox txtCnpj;
        private TextBox txtInscricaoMunicipal;
        private Panel panel1;
        private Button btnCancelar;
        private Button btnSalvar;
        private DateTimePicker txtCompetencia;
        private TextBox txtCodigoMunicipio;
        private Label label5;
        private TextBox txtNomeMunicipio;
        private Label label6;
        private Label label8;
        private Label label7;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label14;
        private TextBox txtValorBaseCalculo;
        private TextBox txtValorAliquota;
        private TextBox txtValorRetido;
        private TextBox txtValorLiquido;
        private TextBox txtValorIssqn;
        private TextBox txtCodigoObra;
        private TextBox txtCodigoTributoNacional;
    }
}