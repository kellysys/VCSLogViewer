namespace VCSLogViewer
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFindPrev = new System.Windows.Forms.Button();
            this.btnHighlight = new System.Windows.Forms.Button();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.tbHighlight = new System.Windows.Forms.TextBox();
            this.tbFindText = new System.Windows.Forms.TextBox();
            this.cmsTapPage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dark1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dark2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cmsTapPage.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbFiles, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOpen, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1038, 471);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // lbFiles
            // 
            this.lbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.ItemHeight = 15;
            this.lbFiles.Location = new System.Drawing.Point(3, 33);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(194, 289);
            this.lbFiles.TabIndex = 2;
            this.lbFiles.DoubleClick += new System.EventHandler(this.lbFiles_DoubleClick);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(3, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(194, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open Folder";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Location = new System.Drawing.Point(203, 33);
            this.tabControl.Name = "tabControl";
            this.tableLayoutPanel1.SetRowSpan(this.tabControl, 2);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(832, 435);
            this.tabControl.TabIndex = 3;
            this.tabControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFindPrev);
            this.panel1.Controls.Add(this.btnHighlight);
            this.panel1.Controls.Add(this.btnFindNext);
            this.panel1.Controls.Add(this.tbHighlight);
            this.panel1.Controls.Add(this.tbFindText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 333);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 135);
            this.panel1.TabIndex = 4;
            // 
            // btnFindPrev
            // 
            this.btnFindPrev.Location = new System.Drawing.Point(35, 32);
            this.btnFindPrev.Name = "btnFindPrev";
            this.btnFindPrev.Size = new System.Drawing.Size(75, 23);
            this.btnFindPrev.TabIndex = 1;
            this.btnFindPrev.Text = "< Find";
            this.btnFindPrev.UseVisualStyleBackColor = true;
            this.btnFindPrev.Click += new System.EventHandler(this.btnFindPrev_Click);
            // 
            // btnHighlight
            // 
            this.btnHighlight.Location = new System.Drawing.Point(116, 90);
            this.btnHighlight.Name = "btnHighlight";
            this.btnHighlight.Size = new System.Drawing.Size(75, 23);
            this.btnHighlight.TabIndex = 1;
            this.btnHighlight.Text = "Highlight";
            this.btnHighlight.UseVisualStyleBackColor = true;
            this.btnHighlight.Click += new System.EventHandler(this.btnHighlight_Click);
            // 
            // btnFindNext
            // 
            this.btnFindNext.Location = new System.Drawing.Point(116, 32);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(75, 23);
            this.btnFindNext.TabIndex = 1;
            this.btnFindNext.Text = "Find >";
            this.btnFindNext.UseVisualStyleBackColor = true;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // tbHighlight
            // 
            this.tbHighlight.Location = new System.Drawing.Point(3, 61);
            this.tbHighlight.Name = "tbHighlight";
            this.tbHighlight.Size = new System.Drawing.Size(188, 23);
            this.tbHighlight.TabIndex = 0;
            // 
            // tbFindText
            // 
            this.tbFindText.Location = new System.Drawing.Point(3, 3);
            this.tbFindText.Name = "tbFindText";
            this.tbFindText.Size = new System.Drawing.Size(188, 23);
            this.tbFindText.TabIndex = 0;
            // 
            // cmsTapPage
            // 
            this.cmsTapPage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.cmsTapPage.Name = "cmsTapPage";
            this.cmsTapPage.Size = new System.Drawing.Size(104, 26);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 501);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1038, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.colorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1038, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(93, 22);
            this.toolStripMenuItem1.Text = "Exit";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.dark1ToolStripMenuItem,
            this.dark2ToolStripMenuItem});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.defaultToolStripMenuItem.Text = "Default";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // dark1ToolStripMenuItem
            // 
            this.dark1ToolStripMenuItem.Name = "dark1ToolStripMenuItem";
            this.dark1ToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.dark1ToolStripMenuItem.Text = "Dark 1";
            this.dark1ToolStripMenuItem.Click += new System.EventHandler(this.dark1ToolStripMenuItem_Click);
            // 
            // dark2ToolStripMenuItem
            // 
            this.dark2ToolStripMenuItem.Name = "dark2ToolStripMenuItem";
            this.dark2ToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.dark2ToolStripMenuItem.Text = "Dark 2";
            this.dark2ToolStripMenuItem.Click += new System.EventHandler(this.dark2ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 523);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cmsTapPage.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnOpen;
        private ListBox lbFiles;
        private TabControl tabControl;
        private ContextMenuStrip cmsTapPage;
        private ToolStripMenuItem closeToolStripMenuItem;
        private Panel panel1;
        private Button btnFindPrev;
        private Button btnFindNext;
        private TextBox tbFindText;
        private Button btnHighlight;
        private TextBox tbHighlight;
        private StatusStrip statusStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem colorToolStripMenuItem;
        private ToolStripMenuItem defaultToolStripMenuItem;
        private ToolStripMenuItem dark1ToolStripMenuItem;
        private ToolStripMenuItem dark2ToolStripMenuItem;
    }
}