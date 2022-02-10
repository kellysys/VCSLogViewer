using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSLogViewer.Models
{
    public class BackColor
    {
        public Color MyColor { get; set; }

        List<int> Indexs = new List<int>();

        public void SetRange(int index, int length)
        {
            Indexs.InsertIntoSortedList(index);
        }

        public bool SelectedBefore(int index, int length)
        {
            if (Indexs.BinarySearch(index) < 0)
                return false;

            return true;
        }
    }
}
