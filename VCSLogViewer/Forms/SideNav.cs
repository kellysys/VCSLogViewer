using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCSLogViewer.Controls;
using VCSLogViewer.Models;
using WeifenLuo.WinFormsUI.Docking;

namespace VCSLogViewer.Forms
{
    public partial class SideNav : BaseDockContent
    {
        DockPanel? dock;

        public SideNav()
        {
            InitializeComponent();

            LogService.Instance.FindTextSelected += ((sender, e) =>
            {
                Invoke(new MethodInvoker(delegate
                {
                    tbFindText.Text = e;
                }));
            });
        }

        public void Init(DockPanel d)
        {
            dock = d;
        }

        public void OpenFolder()
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

        private void btnFindPrev_Click(object sender, EventArgs e)
        {
            var active = dock?.ActiveDocument;

            if (active != null && active is LogDoc)
                (active as LogDoc)?.FindPrev(tbFindText.Text);
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            var active = dock?.ActiveDocument;

            if (active != null && active is LogDoc)
                (active as LogDoc)?.FindNext(tbFindText.Text);
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
                    ld.Init2(fm.Name, fm.Path);
                    ld.SetTheme(ThemeColor.Default);
                    ld.Show(dock, DockState.Document);

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
    }
}
