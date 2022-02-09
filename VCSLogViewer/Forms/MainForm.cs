using System.Diagnostics;
using VCSLogViewer.Controls;
using VCSLogViewer.Forms;
using VCSLogViewer.Models;
using WeifenLuo.WinFormsUI.Docking;

namespace VCSLogViewer
{
    public partial class MainForm : Form
    {
        ThemeColor themeColor = ThemeColor.Default;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {

        }

        private void lbFiles_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FileModel? fm = lbFiles.SelectedItem as FileModel;

                if (fm != null)
                {
                    Cursor = Cursors.WaitCursor;

                    LogDoc ld = new LogDoc();
                    ld.Init(fm.Name, fm.Path);
                    ld.SetTheme(themeColor);
                    ld.Show(dockPanel1, DockState.Document);
                    ld.FindTextSelected += ((e) =>
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            tbFindText.Text = e;
                        }));
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tabControl.SelectedTab.Dispose();
        }

        private void tabControl_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    for (int i = 0; i < tabControl.TabCount; i++)
            //    {
            //        if (tabControl.GetTabRect(i).Contains(e.Location))
            //            tabControl.SelectedIndex = i;
            //    }
            //}
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            if (dockPanel1.ActiveDocument != null)
            {
                LogDoc ld = dockPanel1.ActiveDocument as LogDoc;
                ld?.FindNext(tbFindText.Text);
            }
        }

        private void btnFindPrev_Click(object sender, EventArgs e)
        {
            if (dockPanel1.ActiveDocument != null)
            {
                LogDoc ld = dockPanel1.ActiveDocument as LogDoc;
                ld?.FindPrev(tbFindText.Text);
            }
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeColor = ThemeColor.Default;
            UpdateThemeColor();
        }

        private void dark1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeColor = ThemeColor.Dark1;
            UpdateThemeColor();
        }

        private void dark2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            themeColor = ThemeColor.Dark2;
            UpdateThemeColor();
        }

        private void UpdateThemeColor()
        {
            //foreach (LogTabPage c in tabControl.Controls)
            //{
            //    c.SetTheme(themeColor);
            //}
        }

        private void tbFindText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Shift)
                    btnFindPrev.PerformClick();
                else
                    btnFindNext.PerformClick();
            }
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                List<FileModel> files = new List<FileModel>();

                Text = dialog.SelectedPath;
                foreach (var dir in Directory.GetDirectories(dialog.SelectedPath))
                {
                    foreach (var f in Directory.GetFiles(dir))
                    {
                        files.Add(new FileModel()
                        {
                            Name = Path.GetFileName(f),
                            Path = f
                        });
                    }
                }

                lbFiles.DataSource = null;
                lbFiles.DisplayMember = "Name";
                lbFiles.ValueMember = "Path";
                lbFiles.DataSource = files;
            }
        }
    }
}