using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSLogViewer.Forms;

namespace VCSLogViewer.Controls
{
    public class IOList : ListBox
    {
        public IOList()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
        }

        Pen p = new Pen(Brushes.Silver);
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            if (Items[e.Index] != null)
            {
                e.DrawBackground();
                DIO dio = (DIO)Items[e.Index];
                Brush ioBrush = dio.Value ? Brushes.GreenYellow : Brushes.LightGray;

                e.Graphics.FillRectangle(ioBrush, e.Bounds);

                e.Graphics.DrawString(dio.Name,
                                e.Font,
                                Brushes.Black,
                                e.Bounds,
                                StringFormat.GenericDefault);

                e.Graphics.DrawRectangle(p, e.Bounds);
            }
            //e.DrawFocusRectangle();
        }
    }
}
