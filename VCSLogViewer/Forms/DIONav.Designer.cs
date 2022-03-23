namespace VCSLogViewer.Forms
{
    partial class DIONav
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbVCSType = new System.Windows.Forms.ComboBox();
            this.ioList1 = new VCSLogViewer.Controls.IOList();
            this.ioList2 = new VCSLogViewer.Controls.IOList();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbVCSType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ioList1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ioList2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbTime, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(387, 583);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "VCS Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbVCSType
            // 
            this.cbVCSType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVCSType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVCSType.FormattingEnabled = true;
            this.cbVCSType.Items.AddRange(new object[] {
            "DIO",
            "CHJS",
            "WUXI",
            "SKs"});
            this.cbVCSType.Location = new System.Drawing.Point(196, 3);
            this.cbVCSType.Name = "cbVCSType";
            this.cbVCSType.Size = new System.Drawing.Size(188, 23);
            this.cbVCSType.TabIndex = 2;
            this.cbVCSType.SelectedIndexChanged += new System.EventHandler(this.cbVCSType_SelectedIndexChanged);
            // 
            // ioList1
            // 
            this.ioList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ioList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ioList1.FormattingEnabled = true;
            this.ioList1.ItemHeight = 15;
            this.ioList1.Location = new System.Drawing.Point(3, 63);
            this.ioList1.Name = "ioList1";
            this.ioList1.Size = new System.Drawing.Size(187, 514);
            this.ioList1.TabIndex = 0;
            // 
            // ioList2
            // 
            this.ioList2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ioList2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ioList2.FormattingEnabled = true;
            this.ioList2.ItemHeight = 15;
            this.ioList2.Location = new System.Drawing.Point(196, 63);
            this.ioList2.Name = "ioList2";
            this.ioList2.Size = new System.Drawing.Size(188, 514);
            this.ioList2.TabIndex = 0;
            // 
            // tbTime
            // 
            this.tbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.tbTime, 2);
            this.tbTime.Location = new System.Drawing.Point(3, 33);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(381, 23);
            this.tbTime.TabIndex = 3;
            // 
            // DIONav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 583);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DIONav";
            this.Text = "DIONav";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private ComboBox cbVCSType;
        private Controls.IOList ioList1;
        private Controls.IOList ioList2;
        private TextBox tbTime;
    }
}