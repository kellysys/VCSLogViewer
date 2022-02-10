using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCSLogViewer.Controls;

namespace VCSLogViewer.Forms
{
    public partial class LogDoc : BaseDockContent
    {
        string Path = "";

        public LogDoc()
        {
            InitializeComponent();
        }

        public void Init(string title, string path)
        {
            Path = path;
            Text = title;
            tbLog.Init(Path);
        }

        public void SetTheme(ThemeColor color)
        {
            switch (color)
            {
                case ThemeColor.Default:
                    tbLog.SetTheme(Color.Black, Color.White);
                    break;
                case ThemeColor.Dark1:
                    tbLog.SetTheme(Color.White, Color.Black);
                    break;
                case ThemeColor.Dark2:
                    tbLog.SetTheme(Color.LightYellow, Color.Black);
                    break;
                default:
                    break;
            }
        }

        public void FindNext(string str)
        {
            tbLog.FindNext(str);
        }

        public void FindPrev(string str)
        {
            tbLog.FindPrev(str);
        }

        private void tbLog_Enter(object sender, EventArgs e)
        {
            LogService.Instance.ActionPsitionChanged(tbLog, tbLog.SelectionStart, tbLog.SelectionLength, 0);
        }
    }
}
