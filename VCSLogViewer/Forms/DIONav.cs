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

namespace VCSLogViewer.Forms
{
    public partial class DIONav : BaseDockContent
    {
        BindingList<DIO> din = new BindingList<DIO>();
        BindingList<DIO> dout = new BindingList<DIO>();

        const int IOCount = 96;

        public DIONav()
        {
            InitializeComponent();

            ioList1.DataSource = din;
            ioList2.DataSource = dout;
            cbVCSType.SelectedIndex = 0;

            LogService.Instance.DIOSelected += ((s, dio) =>
            {
                try
                {
                    var inputIndex = dio.IndexOf("DI:");
                    var dis = dio.AsSpan(inputIndex + 3, IOCount);

                    var outputIndex = dio.IndexOf("DO:");
                    var dos = dio.AsSpan(outputIndex + 3, IOCount);

                    tbTime.Text = dio.AsSpan(0, inputIndex).ToString();

                    ioList1.BeginUpdate();
                    ioList2.BeginUpdate();

                    for (int i = 0; i < IOCount; i++)
                    {
                        if (din.Count > i)
                            din[i].Value = dis[i] == 49;

                        if (dout.Count > i)
                            dout[i].Value = dos[i] == 49;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ioList1.EndUpdate();
                    ioList2.EndUpdate();
                }
            });
        }

        private void cbVCSType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVCSType.SelectedIndex == 0)
            {
                UpdateList<DI96, DO96>();
            }
            else if (cbVCSType.SelectedIndex == 1)
            {
                UpdateList<CMZ_INPUT_CHJS, CMZ_OUTPUT_CHJS>();
            }
            else if (cbVCSType.SelectedIndex == 2)
            {
                UpdateList<CMZ_INPUT_WUXI, CMZ_OUTPUT_WUXI>();
            }
            else if (cbVCSType.SelectedIndex == 3)
            {
                UpdateList<CMZ_INPUT_SKS, CMZ_OUTPUT_SKS>();
            }
        }

        private void UpdateList<TI, TO>()
        {
            din.Clear();
            dout.Clear();

            foreach (TI i in Enum.GetValues(typeof(TI)))
            {
                din.Add(new DIO() { Name = i.ToString() });
            }

            foreach (TO o in Enum.GetValues(typeof(TO)))
            {
                dout.Add(new DIO() { Name = o.ToString() });
            }
        }
    }

    public record DIO
    {
        public string? Name { get; init; }
        public bool Value { get; set; }
    }
}
