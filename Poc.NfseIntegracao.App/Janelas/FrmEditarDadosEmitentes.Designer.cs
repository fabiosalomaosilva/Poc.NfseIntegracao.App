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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtEmitente = new TextBox();
            txtCnpj = new TextBox();
            txtInscricaoMunicipal = new TextBox();
            panel1 = new Panel();
            btnCancelar = new Button();
            btnSalvar = new Button();
            txtCompetencia = new DateTimePicker();
            txtCodigoMunicipio = new TextBox();
            label5 = new Label();
            txtNomeMunicipio = new TextBox();
            label6 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.27273F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72.72727F));
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(label3, 0, 3);
            tableLayoutPanel1.Controls.Add(label4, 0, 4);
            tableLayoutPanel1.Controls.Add(txtEmitente, 1, 1);
            tableLayoutPanel1.Controls.Add(txtCnpj, 1, 2);
            tableLayoutPanel1.Controls.Add(txtInscricaoMunicipal, 1, 3);
            tableLayoutPanel1.Controls.Add(panel1, 1, 7);
            tableLayoutPanel1.Controls.Add(txtCompetencia, 1, 4);
            tableLayoutPanel1.Controls.Add(txtCodigoMunicipio, 1, 5);
            tableLayoutPanel1.Controls.Add(label5, 0, 5);
            tableLayoutPanel1.Controls.Add(txtNomeMunicipio, 1, 6);
            tableLayoutPanel1.Controls.Add(label6, 0, 6);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.Size = new Size(550, 299);
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 85);
            label2.Margin = new Padding(15, 5, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 2;
            label2.Text = "CNPJ:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 115);
            label3.Margin = new Padding(15, 5, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(113, 15);
            label3.TabIndex = 3;
            label3.Text = "Inscrição municipal:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 145);
            label4.Margin = new Padding(15, 5, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(122, 15);
            label4.TabIndex = 4;
            label4.Text = "Data da competência:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEmitente
            // 
            txtEmitente.Dock = DockStyle.Fill;
            txtEmitente.Location = new Point(153, 53);
            txtEmitente.Margin = new Padding(3, 3, 15, 3);
            txtEmitente.Name = "txtEmitente";
            txtEmitente.Size = new Size(382, 23);
            txtEmitente.TabIndex = 5;
            // 
            // txtCnpj
            // 
            txtCnpj.Location = new Point(153, 83);
            txtCnpj.Margin = new Padding(3, 3, 15, 3);
            txtCnpj.MaxLength = 14;
            txtCnpj.Name = "txtCnpj";
            txtCnpj.Size = new Size(382, 23);
            txtCnpj.TabIndex = 6;
            txtCnpj.TextChanged += txtCnpj_TextChanged;
            // 
            // txtInscricaoMunicipal
            // 
            txtInscricaoMunicipal.Location = new Point(153, 113);
            txtInscricaoMunicipal.Margin = new Padding(3, 3, 15, 3);
            txtInscricaoMunicipal.MaxLength = 14;
            txtInscricaoMunicipal.Name = "txtInscricaoMunicipal";
            txtInscricaoMunicipal.Size = new Size(382, 23);
            txtInscricaoMunicipal.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnSalvar);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(153, 233);
            panel1.Name = "panel1";
            panel1.Size = new Size(394, 63);
            panel1.TabIndex = 9;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(206, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 36);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(297, 3);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(85, 36);
            btnSalvar.TabIndex = 0;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // txtCompetencia
            // 
            txtCompetencia.Dock = DockStyle.Fill;
            txtCompetencia.Format = DateTimePickerFormat.Short;
            txtCompetencia.Location = new Point(153, 143);
            txtCompetencia.Margin = new Padding(3, 3, 15, 3);
            txtCompetencia.Name = "txtCompetencia";
            txtCompetencia.Size = new Size(382, 23);
            txtCompetencia.TabIndex = 10;
            // 
            // txtCodigoMunicipio
            // 
            txtCodigoMunicipio.Location = new Point(153, 173);
            txtCodigoMunicipio.Margin = new Padding(3, 3, 15, 3);
            txtCodigoMunicipio.MaxLength = 14;
            txtCodigoMunicipio.Name = "txtCodigoMunicipio";
            txtCodigoMunicipio.Size = new Size(382, 23);
            txtCodigoMunicipio.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 175);
            label5.Margin = new Padding(15, 5, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(123, 15);
            label5.TabIndex = 12;
            label5.Text = "Código do município:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtNomeMunicipio
            // 
            txtNomeMunicipio.Location = new Point(153, 203);
            txtNomeMunicipio.Margin = new Padding(3, 3, 15, 3);
            txtNomeMunicipio.Name = "txtNomeMunicipio";
            txtNomeMunicipio.Size = new Size(382, 23);
            txtNomeMunicipio.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 205);
            label6.Margin = new Padding(15, 5, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(117, 15);
            label6.TabIndex = 14;
            label6.Text = "Nome do município:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmEditarDadosEmitentes
            // 
            AcceptButton = btnSalvar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(550, 299);
            Controls.Add(tableLayoutPanel1);
            Name = "FrmEditarDadosEmitentes";
            Text = "Editar dados do XML";
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
    }
}