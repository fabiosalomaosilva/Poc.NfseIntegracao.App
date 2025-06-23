namespace Poc.NfseIntegracao.App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            splitContainer1 = new SplitContainer();
            txtXml = new Poc.NfseIntegracao.App.Componentes.RichTextBoxWithLines();
            txtXmlFinal = new Poc.NfseIntegracao.App.Componentes.RichTextBoxWithLines();
            splitContainer2 = new SplitContainer();
            groupBox3 = new GroupBox();
            txtXmlCompactado = new RichTextBox();
            button2 = new Button();
            groupBox2 = new GroupBox();
            txtApiResponse = new RichTextBox();
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            configuraçõesToolStripMenuItem = new ToolStripMenuItem();
            certificadoDigitalToolStripMenuItem = new ToolStripMenuItem();
            editarDadosDoEmitenteToolStripMenuItem = new ToolStripMenuItem();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            enviadasToolStripMenuItem = new ToolStripMenuItem();
            sairToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(splitContainer1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 63);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(800, 573);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "XML";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 19);
            splitContainer1.Margin = new Padding(3, 3, 3, 15);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(txtXml);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtXmlFinal);
            splitContainer1.Size = new Size(794, 551);
            splitContainer1.SplitterDistance = 361;
            splitContainer1.TabIndex = 2;
            // 
            // txtXml
            // 
            txtXml.Dock = DockStyle.Fill;
            txtXml.Location = new Point(0, 0);
            txtXml.Margin = new Padding(15);
            txtXml.Name = "txtXml";
            txtXml.Size = new Size(361, 551);
            txtXml.TabIndex = 0;
            // 
            // txtXmlFinal
            // 
            txtXmlFinal.Dock = DockStyle.Fill;
            txtXmlFinal.Location = new Point(0, 0);
            txtXmlFinal.Margin = new Padding(3, 3, 3, 10);
            txtXmlFinal.Name = "txtXmlFinal";
            txtXmlFinal.Size = new Size(429, 551);
            txtXmlFinal.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 636);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(groupBox3);
            splitContainer2.Panel1MinSize = 50;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(groupBox2);
            splitContainer2.Panel2MinSize = 50;
            splitContainer2.Size = new Size(800, 138);
            splitContainer2.SplitterDistance = 382;
            splitContainer2.TabIndex = 4;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtXmlCompactado);
            groupBox3.Controls.Add(button2);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(382, 138);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Xml Compactado em Base64";
            // 
            // txtXmlCompactado
            // 
            txtXmlCompactado.BackColor = Color.White;
            txtXmlCompactado.BorderStyle = BorderStyle.None;
            txtXmlCompactado.Dock = DockStyle.Fill;
            txtXmlCompactado.Location = new Point(3, 19);
            txtXmlCompactado.Name = "txtXmlCompactado";
            txtXmlCompactado.ReadOnly = true;
            txtXmlCompactado.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            txtXmlCompactado.Size = new Size(376, 116);
            txtXmlCompactado.TabIndex = 2;
            txtXmlCompactado.Text = "";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(2052, 426);
            button2.Name = "button2";
            button2.Size = new Size(127, 34);
            button2.TabIndex = 1;
            button2.Text = "Enviar";
            button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtApiResponse);
            groupBox2.Controls.Add(button1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(414, 138);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Resposta do serviço NFSE";
            // 
            // txtApiResponse
            // 
            txtApiResponse.BackColor = Color.White;
            txtApiResponse.BorderStyle = BorderStyle.None;
            txtApiResponse.Dock = DockStyle.Fill;
            txtApiResponse.Location = new Point(3, 19);
            txtApiResponse.Name = "txtApiResponse";
            txtApiResponse.ReadOnly = true;
            txtApiResponse.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            txtApiResponse.Size = new Size(408, 116);
            txtApiResponse.TabIndex = 2;
            txtApiResponse.Text = "";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(1484, 365);
            button1.Name = "button1";
            button1.Size = new Size(127, 34);
            button1.TabIndex = 1;
            button1.Text = "Enviar";
            button1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.InactiveCaption;
            menuStrip1.Items.AddRange(new ToolStripItem[] { configuraçõesToolStripMenuItem, cadastrosToolStripMenuItem, sairToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // configuraçõesToolStripMenuItem
            // 
            configuraçõesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { certificadoDigitalToolStripMenuItem, editarDadosDoEmitenteToolStripMenuItem });
            configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            configuraçõesToolStripMenuItem.Size = new Size(96, 20);
            configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // certificadoDigitalToolStripMenuItem
            // 
            certificadoDigitalToolStripMenuItem.Name = "certificadoDigitalToolStripMenuItem";
            certificadoDigitalToolStripMenuItem.Size = new Size(206, 22);
            certificadoDigitalToolStripMenuItem.Text = "Certificado digital";
            certificadoDigitalToolStripMenuItem.Click += certificadoDigitalToolStripMenuItem_Click;
            // 
            // editarDadosDoEmitenteToolStripMenuItem
            // 
            editarDadosDoEmitenteToolStripMenuItem.Name = "editarDadosDoEmitenteToolStripMenuItem";
            editarDadosDoEmitenteToolStripMenuItem.Size = new Size(206, 22);
            editarDadosDoEmitenteToolStripMenuItem.Text = "Editar dados do emitente";
            editarDadosDoEmitenteToolStripMenuItem.Click += editarDadosDoEmitenteToolStripMenuItem_Click;
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { enviadasToolStripMenuItem });
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(71, 20);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // enviadasToolStripMenuItem
            // 
            enviadasToolStripMenuItem.Name = "enviadasToolStripMenuItem";
            enviadasToolStripMenuItem.Size = new Size(120, 22);
            enviadasToolStripMenuItem.Text = "Enviadas";
            enviadasToolStripMenuItem.Click += enviadasToolStripMenuItem_Click;
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            sairToolStripMenuItem.Size = new Size(38, 20);
            sairToolStripMenuItem.Text = "Sair";
            sairToolStripMenuItem.Click += sairToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton2, toolStripButton1 });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 39);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.ForeColor = SystemColors.ControlText;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Blue;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(102, 36);
            toolStripButton1.Text = "Enviar XML";
            toolStripButton1.Click += btnEnviar_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(108, 36);
            toolStripButton2.Text = "Editar dados";
            toolStripButton2.Click += editarDadosDoEmitenteToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 774);
            Controls.Add(splitContainer2);
            Controls.Add(groupBox1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private SplitContainer splitContainer1;
        private Componentes.RichTextBoxWithLines txtXml;
        private Componentes.RichTextBoxWithLines txtXmlFinal;
        private SplitContainer splitContainer2;
        private GroupBox groupBox3;
        private RichTextBox txtXmlCompactado;
        private Button button2;
        private GroupBox groupBox2;
        private RichTextBox txtApiResponse;
        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem configuraçõesToolStripMenuItem;
        private ToolStripMenuItem certificadoDigitalToolStripMenuItem;
        private ToolStripMenuItem editarDadosDoEmitenteToolStripMenuItem;
        private ToolStripMenuItem sairToolStripMenuItem;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private ToolStripMenuItem enviadasToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
    }
}
