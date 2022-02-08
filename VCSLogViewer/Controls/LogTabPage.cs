using System.Diagnostics;
using System.Text;

namespace VCSLogViewer.Controls
{
    internal class LogTabPage : TabPage
    {
        public LogTextBox Log { get; private set; } = new LogTextBox();

        public LogTabPage(string name) : base(name)
        {
            Controls.Add(Log);
        }

        public void Init(string path, bool removeDate = true, bool removeTimezone = true)
        {
            StringBuilder sb = new StringBuilder();
            string date = "";
            string timezone = "";

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
            Log.SuspendLayout();
            Log.Text = sb.ToString();
            Log.ResumeLayout(false);
            ResumeLayout(false);
            Log.Init();
        }

        public void Highlight(string text)
        {
            
            //Log.ChangeSelectedTextColor(text, Color.Red);
        }

        public void SetTheme(ThemeColor color)
        {
            switch (color)
            {
                case ThemeColor.Default:
                    Log.SetTheme(Color.Black, Color.White);
                    break;
                case ThemeColor.Dark1:
                    Log.SetTheme(Color.White, Color.Black);
                    break;
                case ThemeColor.Dark2:
                    Log.SetTheme(Color.LightYellow, Color.Black);
                    break;
                default:
                    break;
            }
        }
    }

    public enum ThemeColor
    {
        Default,
        Dark1,
        Dark2
    }
}
