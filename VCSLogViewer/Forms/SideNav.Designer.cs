namespace VCSLogViewer.Forms
{
    partial class SideNav
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.tbFindText = new System.Windows.Forms.TextBox();
            this.btnFindPrev = new System.Windows.Forms.Button();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbFiles, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbFindText, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnFindPrev, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnFindNext, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(184, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbFiles
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lbFiles, 2);
            this.lbFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.ItemHeight = 15;
            this.lbFiles.Location = new System.Drawing.Point(3, 3);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(178, 244);
            this.lbFiles.TabIndex = 3;
            this.lbFiles.DoubleClick += new System.EventHandler(this.lbFiles_DoubleClick);
            // 
            // tbFindText
            // 
            this.tbFindText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.tbFindText, 2);
            this.tbFindText.Location = new System.Drawing.Point(3, 253);
            this.tbFindText.Name = "tbFindText";
            this.tbFindText.Size = new System.Drawing.Size(178, 23);
            this.tbFindText.TabIndex = 4;
            this.tbFindText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbFindText_KeyUp);
            // 
            // btnFindPrev
            // 
            this.btnFindPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindPrev.Location = new System.Drawing.Point(3, 283);
            this.btnFindPrev.Name = "btnFindPrev";
            this.btnFindPrev.Size = new System.Drawing.Size(86, 24);
            this.btnFindPrev.TabIndex = 5;
            this.btnFindPrev.Text = "Find <";
            this.btnFindPrev.UseVisualStyleBackColor = true;
            this.btnFindPrev.Click += new System.EventHandler(this.btnFindPrev_Click);
            // 
            // btnFindNext
            // 
            this.btnFindNext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindNext.Location = new System.Drawing.Point(95, 283);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(86, 24);
            this.btnFindNext.TabIndex = 5;
            this.btnFindNext.Text = "Find >";
            this.btnFindNext.UseVisualStyleBackColor = true;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // SideNav
            // 
            this.AllowEndUserDocking = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 561);
            this.CloseButton = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Name = "SideNav";
            this.Text = "SideNav";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ListBox lbFiles;
        private TextBox tbFindText;
        private Button btnFindPrev;
        private Button btnFindNext;
    }
}