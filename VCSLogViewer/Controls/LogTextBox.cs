using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VCSLogViewer.Controls
{
    internal class LogTextBox : RichTextBox
    {
        Color backColor = Color.White;
        Color foreColor = Color.Black;

        Dictionary<string, Color> ColorDic = new Dictionary<string, Color>();
        ConcurrentQueue<int> IndexQ = new ConcurrentQueue<int>();

        public LogTextBox()
        {
            WordWrap = false;
            Dock = DockStyle.Fill;
            base.DoubleBuffered = true;
            ForeColor = foreColor;
            BackColor = backColor;

            ContextMenuStrip = new ContextMenuStrip();

            ToolStripMenuItem tsRemoveBefore = new ToolStripMenuItem() { Text = "Remove Before" };
            ToolStripMenuItem tsClear = new ToolStripMenuItem() { Text = "Clear Color" };
            ToolStripMenuItem tsSetColor = new ToolStripMenuItem() { Text = "Set Color" };
            ToolStripMenuItem tsSetLine = new ToolStripMenuItem() { Text = "Set Line" };

            ToolStripMenuItem tsColor1 = new ToolStripMenuItem() { Text = "LightPink" };
            ToolStripMenuItem tsColor2 = new ToolStripMenuItem() { Text = "LightGray" };
            ToolStripMenuItem tsColor3 = new ToolStripMenuItem() { Text = "GreenYellow" };
            ToolStripMenuItem tsColor4 = new ToolStripMenuItem() { Text = "SkyBlue" };
            ToolStripMenuItem tsColor5 = new ToolStripMenuItem() { Text = "Yellow" };

            tsSetColor.DropDownItems.Add(tsColor1);
            tsSetColor.DropDownItems.Add(tsColor2);
            tsSetColor.DropDownItems.Add(tsColor3);
            tsSetColor.DropDownItems.Add(tsColor4);
            tsSetColor.DropDownItems.Add(tsColor5);

            ContextMenuStrip?.Items.Add(tsRemoveBefore);
            ContextMenuStrip?.Items.Add(tsClear);
            ContextMenuStrip?.Items.Add(new ToolStripSeparator());
            ContextMenuStrip?.Items.Add(tsSetColor);
            ContextMenuStrip?.Items.Add(tsSetLine);

            tsColor1.Click += (s, e) => NewColor(Color.LightPink);
            tsColor2.Click += (s, e) => NewColor(Color.LightGray);
            tsColor3.Click += (s, e) => NewColor(Color.GreenYellow);
            tsColor4.Click += (s, e) => NewColor(Color.SkyBlue);
            tsColor5.Click += (s, e) => NewColor(Color.Yellow);

            tsRemoveBefore.Click += (s, e) =>
            {
                SuspendLayout();
                Select(SelectionStart, Text.Length);
                Text = SelectedText;
                ResumeLayout(false);
            };

            tsClear.Click += TsClear_Click;

            Selectable = true;

            Task.Run(() =>
            {
                UpdateQ();
            });
        }

        public void SetTheme(Color fore, Color back)
        {
            foreColor = fore;
            backColor = back;
            ForeColor = foreColor;
            BackColor = backColor;
        }

        const int WM_SETFOCUS = 0x0007;
        const int WM_KILLFOCUS = 0x0008;

        [DefaultValue(true)]
        public bool Selectable { get; set; }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETFOCUS && !Selectable)
                m.Msg = WM_KILLFOCUS;

            base.WndProc(ref m);
        }

        public int FirstIndex { get; private set; }
        public int LastIndex { get; private set; }
        public int SavedFirstIndex { get; private set; }
        public int SavedLastIndex { get; private set; }
        public int StartLastSize { get; private set; }

        protected override void OnVScroll(EventArgs e)
        {
            base.OnVScroll(e);
            if (!UpdateLock)
                UpdateIndex();
        }

        public void Init()
        {
            UpdateIndex();
        }

        private void DebugLog(string log)
        {
            Debug.Print($"[{DateTime.Now:HH:MM:ss-fff}] {log}");
        }

        private async void UpdateQ()
        {
            while (true)
            {
                try
                {
                    int min = int.MaxValue;
                    int max = 0;

                    while (IndexQ.TryDequeue(out int index))
                    {
                        min = index < min ? index : min;
                        max = index > max ? index : max;
                    }

                    if (min != int.MaxValue || max != 0)
                    {
                        await Task.Run(() =>
                        {
                            Invoke(new MethodInvoker(delegate
                            {

                                UpdateSelectedColor(min, max);

                            }));
                        });
                    }
                }
                catch (Exception ex)
                {
                    DebugLog(ex.Message);
                }
                finally
                {
                    Thread.Sleep(100);
                }
            }
        }

        private void UpdateIndex()
        {
            (FirstIndex, LastIndex) = GetLayoutIndex();

            if (SavedFirstIndex == FirstIndex)
                return;

            StartLastSize = LastIndex - FirstIndex;

            if (FirstIndex > SavedFirstIndex)
            {
                // DownScroll
                IndexQ.Enqueue(SavedLastIndex);
                IndexQ.Enqueue(LastIndex);

                DebugLog($"Down ({FirstIndex}-{LastIndex}), ({SavedLastIndex}-{LastIndex})");
            }
            else
            {
                // UpScroll
                IndexQ.Enqueue(SavedFirstIndex);
                IndexQ.Enqueue(FirstIndex);

                DebugLog($"Up ({FirstIndex}-{LastIndex}), ({SavedFirstIndex}-{FirstIndex})");
            }

            SavedFirstIndex = FirstIndex;
            SavedLastIndex = LastIndex;
        }

        private void TsClear_Click(object? sender, EventArgs e)
        {
            int saveStart = SelectionStart;

            SelectionStart = 0;
            SelectionLength = Text.Length;

            SelectionColor = foreColor;
            SelectionBackColor = backColor;

            SelectionStart = saveStart;
            SelectionLength = 0;

            ColorDic.Clear();
        }

        private (int first, int last) GetLayoutIndex()
        {
            Point p = Location;
            int firstIndex = GetCharIndexFromPosition(p);
            //int firstLine = GetLineFromCharIndex(firstIndex);
            //Point firstPos = GetPositionFromCharIndex(firstIndex);

            p.Y += Height;

            int lastIndex = GetCharIndexFromPosition(p);
            //int lastLine = GetLineFromCharIndex(lastIndex);
            //Point lastPos = GetPositionFromCharIndex(lastIndex);

            return (firstIndex, lastIndex);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.OemPeriod)
                {
                    FindNext(SelectedText);
                    return;
                }

                if (e.KeyCode == Keys.Oemcomma)
                {
                    FindPrev(SelectedText);
                    return;
                }
            }

            base.OnKeyDown(e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {

            base.OnKeyUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int curPos = GetCharIndexFromPosition(e.Location);

                if (SelectionStart > curPos || SelectionStart + SelectionLength < curPos)
                {
                    SelectionStart = curPos;
                    SelectionLength = 0;
                }
            }

            base.OnMouseDown(e);
        }

        int findStart = 0;
        public void FindNext(string text)
        {
            if (text == null || text.Length < 3)
                return;

            Focus();

            findStart = SelectionStart + 1;
            Find(text, findStart, TextLength, RichTextBoxFinds.None);

            //(int s, int l) = (SelectionStart, SelectionLength);
            //(SelectionStart, SelectionLength) = (s, l);
        }

        public void FindPrev(string text)
        {
            if (text == null || text.Length < 3)
                return;

            Focus();

            findStart = SelectionStart - 1;
            Find(text, 0, findStart, RichTextBoxFinds.Reverse);
        }

        private void NewColor(Color color)
        {
            try
            {
                Regex regex = new Regex(SelectedText);

                if (SelectionLength < 3)
                    return;

                if (ColorDic.ContainsKey(SelectedText))
                    ColorDic.Remove(SelectedText);

                ColorDic.Add(SelectedText, color);

                (SavedFirstIndex, SavedLastIndex) = GetLayoutIndex();
                IndexQ.Enqueue(SavedFirstIndex);
                IndexQ.Enqueue(SavedLastIndex);
            }
            catch (Exception ex)
            {
                DebugLog(ex.Message);
            }
        }

        bool UpdateLock = false;
        private void UpdateSelectedColor(int start, int end)
        {
            try
            {
                SuspendLayout();

                if (ColorDic.Count == 0)
                    return;

                UpdateLock = true;

                Cursor = Cursors.WaitCursor;

                int first = start;
                int last = end;

                if (StartLastSize > 0 && StartLastSize < (last - first))
                {
                    first = FirstIndex;
                    last = LastIndex;
                    DebugLog($"Refreshed Current Display");
                }

                foreach (var dic in ColorDic)
                {
                    Regex regex = new Regex(dic.Key);
                    Match match = regex.Match(Text, first, last - first);

                    while (match.Success)
                    {
                        SelectionStart = match.Index;
                        SelectionLength = match.Length;
                        SelectionBackColor = dic.Value;

                        match = match.NextMatch();
                    }
                }

                DeselectAll();
                DebugLog($"Refreshed ({first}-{last})");
            }
            catch (Exception ex)
            {
                DebugLog(ex.ToString());
            }
            finally
            {
                ResumeLayout();
                Cursor = Cursors.Default;
                UpdateLock = false;
            }
        }
    }
}
