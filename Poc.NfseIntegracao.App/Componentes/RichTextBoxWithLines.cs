using System.Runtime.InteropServices;

namespace Poc.NfseIntegracao.App.Componentes
{
    public partial class RichTextBoxWithLines : UserControl
    {
        private readonly RichTextBox txtLineNumbers;
        private readonly RichTextBox txtEditor;

        public RichTextBoxWithLines()
        {
            txtLineNumbers = new RichTextBox
            {
                Font = new Font("Consolas", 10),
                BackColor = Color.White,
                ForeColor = Color.DarkBlue,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                ScrollBars = RichTextBoxScrollBars.None,
                Enabled = false,
                Dock = DockStyle.Left,
                Width = 40
            };

            txtEditor = new RichTextBox
            {
                Font = new Font("Consolas", 10),
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            txtEditor.VScroll += TxtEditor_VScroll;
            txtEditor.TextChanged += TxtEditor_TextChanged;
            txtEditor.Resize += TxtEditor_Resize;

            Controls.Add(txtEditor);
            Controls.Add(txtLineNumbers);
        }

        public RichTextBox Editor => txtEditor;

        private void TxtEditor_Resize(object? sender, EventArgs e) => UpdateLineNumbers();

        private void TxtEditor_TextChanged(object? sender, EventArgs e) => UpdateLineNumbers();

        private void TxtEditor_VScroll(object? sender, EventArgs e)
        {
            int d = GetScrollPos(txtEditor.Handle, SB_VERT);
            SetScrollPos(txtLineNumbers.Handle, SB_VERT, d, true);
            SendMessage(txtLineNumbers.Handle, WM_VSCROLL, (IntPtr)(SB_THUMBPOSITION + 0x10000 * d), IntPtr.Zero);
        }

        private void UpdateLineNumbers()
        {
            int firstIndex = txtEditor.GetCharIndexFromPosition(new Point(0, 0));
            int firstLine = txtEditor.GetLineFromCharIndex(firstIndex);
            int totalLines = txtEditor.Lines.Length;

            var lineNumbers = new System.Text.StringBuilder();
            for (int i = 0; i < totalLines; i++)
                lineNumbers.AppendLine((i + 1).ToString());

            txtLineNumbers.Text = lineNumbers.ToString();
        }

        private const int WM_VSCROLL = 0x0115;
        private const int SB_VERT = 1;
        private const int SB_THUMBPOSITION = 4;

        [DllImport("user32.dll")] private static extern int GetScrollPos(IntPtr hWnd, int nBar);
        [DllImport("user32.dll")] private static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);
        [DllImport("user32.dll")] private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
    }
}
