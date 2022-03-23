using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        public void OpenFolder2()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                List<FileModel> files = new List<FileModel>();

                Text = dialog.SelectedPath;

                foreach (var f in Directory.GetFiles(dialog.SelectedPath))
                {
                    files.Add(new FileModel()
                    {
                        Name = Path.GetFileName(f),
                        Path = f
                    });
                }

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

        public void OpenFolder()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                List<FileModel> files = new List<FileModel>();

                Text = dialog.SelectedPath;

                foreach (var f in Directory.GetFiles(dialog.SelectedPath))
                {
                    files.Add(new FileModel()
                    {
                        Name = Path.GetFileName(f),
                        Path = f
                    });
                }

                foreach (var dir in Directory.GetDirectories(dialog.SelectedPath))
                {
                    DirFileSearch(files, dir);
                }

                lbFiles.DataSource = null;
                lbFiles.DisplayMember = "Name";
                lbFiles.ValueMember = "Path";
                lbFiles.DataSource = files;
            }
        }

        void DirFileSearch(List<FileModel> totalFiles, string path)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path, $"*.log");

                foreach (string f in files)
                {
                    totalFiles.Add(new FileModel()
                    {
                        Name = Path.GetFileName(f),
                        Path = f
                    });
                }

                if (dirs.Length > 0)
                {
                    foreach (string dir in dirs)
                    {
                        DirFileSearch(totalFiles, dir);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    LogDoc ld = new LogDoc();
                    ld.Show(dock, DockState.Document);
                    ld.SetTheme(ThemeColor.Default);
                    ld.Init(fm.Name, fm.Path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
