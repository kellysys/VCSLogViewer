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

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nav.OpenFolder();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}