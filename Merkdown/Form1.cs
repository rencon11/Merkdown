using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Merkdown
{
    public partial class Form1 : Form
    {
        private bool isEdited = false;
        private string currentFilePath = string.Empty;
        public Form1()
        {
            InitializeComponent();

            textArea.LanguageOption |= RichTextBoxLanguageOptions.ImeAlwaysSendNotify;
            lineNumberPanel.Paint += (s, e) =>
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
            };
            textArea.TextChanged += (s, e) =>
            {
                lineNumberPanel.Invalidate();
                characterCount.Text = $"Characters: {textArea.Text.Length}";
                if (!isEdited)
                {
                    this.Text += " *";
                    fileNameLabel.Text += " *";
                }
                isEdited = true;
            };
            textArea.ImeCompositionChanged += (s, e) =>
            {
                lineNumberPanel.Invalidate();
                characterCount.Text = $"Characters: {textArea.Text.Length}";
                if (!isEdited)
                {
                    this.Text += " *";
                    fileNameLabel.Text += " *";
                }
                isEdited = true;
            };
            textArea.Resize += (s, e) =>
                lineNumberPanel.Invalidate();
            textArea.KeyDown += (s, e) =>
            {
                if (e.Control && e.KeyCode == Keys.S && ((currentFilePath == string.Empty && isEdited) || (e.Shift && isEdited)))
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Markdown files (*.md)|*.md|All files (*.*)|*.*",
                        Title = "Save Markdown File",
                        DefaultExt = "md",
                        FileName = "新しいメモ.md"
                    };
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string path = saveFileDialog.FileName;
                        currentFilePath = path;
                        string filename = Path.GetFileName(path);
                        fileNameLabel.Text = filename;
                        this.Text = "Merkdown";
                        isEdited = false;
                        File.WriteAllText(path, textArea.Text);

                    }
                    e.SuppressKeyPress = true;
                }
                else if (e.Control && e.KeyCode == Keys.S && !e.Shift && isEdited)
                {
                    File.WriteAllText(currentFilePath, textArea.Text);
                    this.Text = "Merkdown";
                    string filename = Path.GetFileName(currentFilePath);
                    fileNameLabel.Text = filename;
                    isEdited = false;
                    e.SuppressKeyPress = true;
                } else if (e.Control && e.KeyCode == Keys.O && !e.Shift)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        Filter = "Markdown files (*.md)|*.md|All files (*.*)|*.*",
                        Title = "Open Markdown File",
                        DefaultExt = "md"
                    };
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if(isEdited)
                        {
                            DialogResult result = MessageBox.Show("You have unsaved changes. Do you want to save before opening a new file?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {
                                string path = openFileDialog.FileName;
                                currentFilePath = path;
                                string filename = Path.GetFileName(path);
                                fileNameLabel.Text = filename;
                                this.Text = "Merkdown";
                                isEdited = false;
                                textArea.Text = File.ReadAllText(path);
                            }
                        }
                        else
                        {

                            string path = openFileDialog.FileName;
                            currentFilePath = path;
                            string filename = Path.GetFileName(path);
                            fileNameLabel.Text = filename;
                            this.Text = "Merkdown";
                            isEdited = false;
                            textArea.Text = File.ReadAllText(path);
                        }
                    }
                    e.SuppressKeyPress = true;
                }
            };

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isEdited)
            {
                DialogResult result = MessageBox.Show("Closing Merkdown. Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void textArea_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textArea_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
