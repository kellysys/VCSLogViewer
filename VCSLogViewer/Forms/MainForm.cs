using System.Diagnostics;
using VCSLogViewer.Controls;
using VCSLogViewer.Forms;
using VCSLogViewer.Models;
using WeifenLuo.WinFormsUI.Docking;

namespace VCSLogViewer
{
    public partial class MainForm : Form
    {
        SideNav nav = new SideNav();

        public MainForm()
        {
            InitializeComponent();
            
            posStatusLabel.Text = "";

            LogService.Instance.PsitionChanged += ((sender, index, length, lineNumber) =>
            {
                Invoke(new MethodInvoker(delegate
                {
                    posStatusLabel.Text = $"[Line:{lineNumber}] [Index:{index}] [Length:{length}] [Total:{sender.TextLength}]";
                }));
            });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            nav.Init(dockPanel1);
            nav.Show(dockPanel1, DockState.DockLeft);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //themeColor = ThemeColor.Default;
            UpdateThemeColor();
        }

        private void dark1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //themeColor = ThemeColor.Dark1;
            UpdateThemeColor();
        }

        private void dark2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //themeColor = ThemeColor.Dark2;
            UpdateThemeColor();
        }

        private void UpdateThemeColor()
        {
            //foreach (LogTabPage c in tabControl.Controls)
            //{
            //    c.SetTheme(themeColor);
            //}
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nav.OpenFolder();
        }


    }
}