using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VCSLogViewer.Forms
{
    public partial class DIONav : BaseDockContent
    {
        BindingList<DIO> din = new BindingList<DIO>();
        BindingList<DIO> dout = new BindingList<DIO>();

        public DIONav()
        {
            InitializeComponent();

            ioList1.DataSource = din;
            ioList2.DataSource = dout;
        }

        private void cbVCSType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVCSType.SelectedIndex == 0)
            {
                UpdateList<CMZ_INPUT_CHJS, CMZ_OUTPUT_CHJS>();
            }
            else if (cbVCSType.SelectedIndex == 1)
            {
                UpdateList<CMZ_INPUT_WUXI, CMZ_OUTPUT_WUXI>();
            }
        }

        private void UpdateList<TI, TO>()
        {
            din.Clear();
            dout.Clear();

            foreach (TI i in Enum.GetValues(typeof(TI)))
            {
                din.Add(new DIO() { Name = i.ToString(), Value = true });
            }

            foreach (TO o in Enum.GetValues(typeof(TO)))
            {
                dout.Add(new DIO() { Name = o.ToString() });
            }
        }

    }

    public record DIO
    {
        public string Name { get; init; }
        public bool Value { get; set; }
    }
}
