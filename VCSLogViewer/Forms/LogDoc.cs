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

namespace VCSLogViewer.Forms
{
    public partial class LogDoc : BaseDockContent
    {
        public LogDoc()
        {
            InitializeComponent();
        }

        public void Init(string title, string path, bool removeDate = true, bool removeTimezone = true)
        {
            StringBuilder sb = new StringBuilder();
            string date = "";
            string timezone = "";

            Text = title;
            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var sr = new StreamReader(fs, Encoding.Default);

            string? line = sr.ReadLine();

            if (line == null)
            {
                throw new Exception($"can't open > {path}");
            }
            else
            {
                string firstLine = line.ToString();
                date = firstLine.Substring(0, 11);
                timezone = firstLine.Substring(24, 13);
            }

            while (line != null)
            {
                sb.AppendLine(line);
                line = sr.ReadLine();
            }

            if (removeDate)
                sb.Replace(date, "");

            if (removeTimezone)
                sb.Replace(timezone, "");

            SuspendLayout();
            tbLog.SuspendLayout();
            tbLog.Text = sb.ToString();
            tbLog.ResumeLayout(false);
            ResumeLayout(false);
            tbLog.Init();
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
    }
}
