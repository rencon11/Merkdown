using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Merkdown
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
            lineNumberPanel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            textArea = new ImeRichTextBox();
            statusStrip1 = new StatusStrip();
            characterCount = new ToolStripStatusLabel();
            fontSelector = new ToolStripDropDownButton();
            fileNameLabel = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // lineNumberPanel
            // 
            lineNumberPanel.Dock = DockStyle.Fill;
            lineNumberPanel.Location = new Point(3, 3);
            lineNumberPanel.Name = "lineNumberPanel";
            lineNumberPanel.Size = new Size(14, 392);
            lineNumberPanel.TabIndex = 0;
            lineNumberPanel.Paint += lineNumberPanel_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lineNumberPanel, 0, 0);
            tableLayoutPanel1.Controls.Add(textArea, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 27);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(794, 398);
            tableLayoutPanel1.TabIndex = 1;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // textArea
            // 
            textArea.Dock = DockStyle.Fill;
            textArea.Font = new Font("Yu Gothic UI", 9F);
            textArea.Location = new Point(23, 3);
            textArea.Name = "textArea";
            textArea.Size = new Size(768, 392);
            textArea.TabIndex = 1;
            textArea.Text = "";
            textArea.WordWrap = false;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { characterCount, fontSelector });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.ItemClicked += statusStrip1_ItemClicked;
            // 
            // characterCount
            // 
            characterCount.Name = "characterCount";
            characterCount.Size = new Size(74, 17);
            characterCount.Text = "Characters: 0";
            // 
            // fontSelector
            // 
            fontSelector.DisplayStyle = ToolStripItemDisplayStyle.Text;
            fontSelector.Name = "fontSelector";
            fontSelector.Size = new Size(67, 20);
            fontSelector.Text = "游ゴシック";
            fontSelector.Click += fontSelector_Click;
            // 
            // fileNameLabel
            // 
            fileNameLabel.AutoSize = true;
            fileNameLabel.Dock = DockStyle.Fill;
            fileNameLabel.Font = new Font("Yu Gothic UI", 12F);
            fileNameLabel.Location = new Point(3, 0);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new Size(794, 24);
            fileNameLabel.TabIndex = 4;
            fileNameLabel.Text = "<NoName>.md";
            fileNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 0, 1);
            tableLayoutPanel2.Controls.Add(fileNameLabel, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(800, 428);
            tableLayoutPanel2.TabIndex = 5;
            tableLayoutPanel2.Scroll += tableLayoutPanel2_Scroll;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(statusStrip1);
            Name = "Form1";
            Text = "Merkdown";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private Panel lineNumberPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel characterCount;
        private Label fileNameLabel;
        private TableLayoutPanel tableLayoutPanel2;
        private ImeRichTextBox textArea;
        private ToolStripDropDownButton fontSelector;
    }
}
