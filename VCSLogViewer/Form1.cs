using System.Diagnostics;
using VCSLogViewer.Controls;
using VCSLogViewer.Models;

namespace VCSLogViewer
{
    public partial class Form1 : Form
    {
        ThemeColor themeColor = ThemeColor.Default;

        public Form1()
        {
            InitializeComponent();

            tabControl.ContextMenuStrip = cmsTapPage;
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
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

        private void lbFiles_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FileModel? fm = lbFiles.SelectedItem as FileModel;

                if (fm != null)
                {
                    Cursor = Cursors.WaitCursor;
                    tabControl.SuspendLayout();

                    LogTabPage tp = new LogTabPage(fm.Name);
                    tp.Init(fm.Path);

                    tabControl.TabPages.Add(tp);
                    tabControl.SelectedTab = tp;
                    tp.SetTheme(themeColor);
                    tabControl.ResumeLayout(false);
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
            tabControl.SelectedTab.Dispose();
        }

        private void tabControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < tabControl.TabCount; i++)
                {
                    if (tabControl.GetTabRect(i).Contains(e.Location))
                        tabControl.SelectedIndex = i;
                }
            }
        }

        private void btnHighlight_Click(object sender, EventArgs e)
        {
            LogTabPage? tp = tabControl.SelectedTab as LogTabPage;
            tp?.Highlight(tbHighlight.Text);
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            LogTabPage? tp = tabControl.SelectedTab as LogTabPage;
            tp?.Log.FindNext(tbFindText.Text);
        }

        private void btnFindPrev_Click(object sender, EventArgs e)
        {
            LogTabPage? tp = tabControl.SelectedTab as LogTabPage;
            tp?.Log.FindPrev(tbFindText.Text);
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
            foreach (LogTabPage c in tabControl.Controls)
            {
                c.SetTheme(themeColor);
            }
        }
    }
}