using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSLogViewer.Controls;
using VCSLogViewer.Forms;

namespace VCSLogViewer
{
    public class LogService
    {
        #region Singletone

        private static LogService? instance;

        public static LogService Instance
        {
            get
            {
                if (instance == null)
                    instance = new LogService();
                return instance;
            }
        }

        private LogService()
        {
        }

        #endregion Singletone

        public Action<LogTextBox, string>? FindTextSelected;
        public Action<LogTextBox, int, int, int>? PsitionChanged;
        public Action<LogTextBox, string>? DIOSelected;

        public void ActionFindTextSelected(LogTextBox sender, string s) => FindTextSelected?.Invoke(sender, s);

        public void ActionPsitionChanged(LogTextBox sender, int index, int length, int lineNumber) => PsitionChanged?.Invoke(sender, index, length, lineNumber);

        public void ActionDIOSelected(LogTextBox sender, string dio) => DIOSelected?.Invoke(sender, dio);


    }
}
