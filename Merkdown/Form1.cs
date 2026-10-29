using System.Drawing.Text;

namespace Merkdown
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textArea.LanguageOption |= RichTextBoxLanguageOptions.ImeAlwaysSendNotify;

            lineNumberPanel.Paint += lineNumberPanel_Paint;
            textArea.TextChanged += (s, e) =>
            {
                lineNumberPanel.Invalidate();
                characterCount.Text = $"Characters: {textArea.Text.Length}";
            };
            textArea.ImeCompositionChanged += (s, e) =>
            {
                lineNumberPanel.Invalidate();
                characterCount.Text = $"Characters: {textArea.Text.Length}";
            };
            textArea.Resize += (s, e) =>
                lineNumberPanel.Invalidate();


            using InstalledFontCollection fonts = new InstalledFontCollection();
            fontSelector.DropDownItems.Clear();
            fontSelector.Text = textArea.Font.Name;
            foreach (FontFamily font in fonts.Families)
            {
                string fontName = font.Name;
                ToolStripMenuItem menuItem = new ToolStripMenuItem(fontName)
                {
                    Checked = string.Equals(fontName, textArea.Font.Name, StringComparison.Ordinal),
                };
                menuItem.Click += (s, ev) =>
                {
                    textArea.Font = new Font(fontName, textArea.Font.Size);
                    lineNumberPanel.Invalidate();
                    fontSelector.Text = fontName;
                    foreach (ToolStripItem item in fontSelector.DropDownItems)
                    {
                        if (item is ToolStripMenuItem mi)
                        {
                            mi.Checked = ReferenceEquals(mi, menuItem);
                        }
                    }
                };
                fontSelector.DropDownItems.Add(menuItem);
            }
        }

        private void textArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lineNumberPanel_Paint(object sender, PaintEventArgs e)
        {
            int lineCount = textArea.Lines.Length + 1;
            for (int i = 0; i < lineCount; i++)
            {
                int charIndex = textArea.GetFirstCharIndexFromLine(i);
                if (charIndex == -1) continue;
                Point position = textArea.GetPositionFromCharIndex(charIndex);
                e.Graphics.DrawString(
                    (i + 1).ToString(),
                    textArea.Font,
                    Brushes.Black,
                    new PointF(0, position.Y));

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Scroll(object sender, ScrollEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                if (e.NewValue > 0)
                {
                    textArea.ZoomFactor = Math.Min(
                        5.0f,
                        textArea.ZoomFactor + 0.1f);
                    lineNumberPanel.Invalidate();
                }
                else if (e.NewValue < 0)
                {
                    textArea.ZoomFactor = Math.Max(
                        0.1f,
                        textArea.ZoomFactor - 0.1f);
                    lineNumberPanel.Invalidate();
                }
            }
        }

        private void fontSelector_Click(object sender, EventArgs e)
        {
        }
    }
}
