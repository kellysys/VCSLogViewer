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
using VCSLogViewer.Models;

namespace VCSLogViewer.Controls
{
    public class LogTextBox : RichTextBox
    {
        private Color backColor = Color.White;
        private Color foreColor = Color.Black;

        private Dictionary<string, BackColor> ColorDic = new Dictionary<string, BackColor>();
        private ConcurrentQueue<int> IndexQ = new ConcurrentQueue<int>();

        private const int MaxFindLength = 3;
        private string FindText = "";
        private int FindIndex = 0;
        private int FindLength = 0;
        private bool UpdateLock = false;

        private int FirstIndex;
        private int LastIndex;
        private int SavedFirstIndex;
        private int SavedLastIndex;
        private int StartLastSize;

        public LogTextBox()
        {
            WordWrap = false;
            Dock = DockStyle.Fill;
            base.DoubleBuffered = true;
            ForeColor = foreColor;
            BackColor = backColor;

            ContextMenuStrip = new ContextMenuStrip();

            ToolStripMenuItem tsFind = new ToolStripMenuItem() { Text = "Find" };
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

            ContextMenuStrip?.Items.Add(tsFind);
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

            tsFind.Click += (s, e) =>
            {
                if (SelectionLength > MaxFindLength)
                {
                    FindText = SelectedText;
                    LogService.Instance.ActionFindTextSelected(this, FindText);
                }
                else
                {
                    FindText = string.Empty;
                }
            };

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
                SelectMinMax();
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

        protected override void OnVScroll(EventArgs e)
        {
            base.OnVScroll(e);
            if (!UpdateLock)
                UpdateIndex();
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            LogService.Instance.ActionPsitionChanged(this, SelectionStart, SelectionLength, GetLineFromCharIndex(SelectionStart));
            base.OnSelectionChanged(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control && !string.IsNullOrEmpty(FindText))
            {
                if (e.KeyCode == Keys.OemPeriod)
                {
                    FindNext(FindText);
                    return;
                }

                if (e.KeyCode == Keys.Oemcomma)
                {
                    FindPrev(FindText);
                    return;
                }
            }

            base.OnKeyDown(e);
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

        public async void Init(string path)
        {
            await Task.Delay(100);
            Cursor = Cursors.WaitCursor;
            DebugLog("Start Init");

            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var bs = new BufferedStream(fs);
            using var sr = new StreamReader(bs, Encoding.Default);

            string? line;
            StringBuilder sb = new StringBuilder();

            while ((line = sr.ReadLine()) != null)
            {
                sb.AppendLine(line);
            }

            Text = sb.ToString();

            Cursor = Cursors.Default;
            DebugLog("End Init");
            UpdateIndex();
        }

        private void DebugLog(string log)
        {
            Debug.Print($"[{DateTime.Now:HH:MM:ss-fff}] {log}");
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

        bool isFind = false;
        int findStart = 0;
        public void FindNext(string text)
        {
            if (text == null || text.Length < MaxFindLength)
                return;

            Focus();

            findStart = SelectionStart + 1;
            FindIndex = Find(text, findStart, TextLength, RichTextBoxFinds.None);
            FindLength = text.Length;

            SelectionColor = Color.Red;
            //(int s, int l) = (SelectionStart, SelectionLength);
            //(SelectionStart, SelectionLength) = (s, l);
            isFind = true;
        }

        public void FindPrev(string text)
        {
            if (text == null || text.Length < MaxFindLength)
                return;

            Focus();

            findStart = SelectionStart - 1;
            FindIndex = Find(text, 0, findStart, RichTextBoxFinds.Reverse);
            FindLength = text.Length;

            SelectionColor = Color.Red;
            isFind = true;
        }

        private void NewColor(Color color)
        {
            try
            {
                Regex regex = new Regex(SelectedText);

                if (SelectionLength < MaxFindLength)
                    return;

                if (ColorDic.ContainsKey(SelectedText))
                    ColorDic.Remove(SelectedText);

                ColorDic.Add(SelectedText, new BackColor() { MyColor = color });

                (SavedFirstIndex, SavedLastIndex) = GetLayoutIndex();
                IndexQ.Enqueue(SavedFirstIndex);
                IndexQ.Enqueue(SavedLastIndex);
            }
            catch (Exception ex)
            {
                DebugLog(ex.Message);
            }
        }

        private async void SelectMinMax()
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
                        if (!dic.Value.SelectedBefore(match.Index, match.Length))
                        {
                            SelectionStart = match.Index;
                            SelectionLength = match.Length;
                            SelectionBackColor = dic.Value.MyColor;
                            dic.Value.SetRange(match.Index, match.Length);
                        }

                        match = match.NextMatch();
                    }
                }

                if (isFind)
                {
                    SelectionStart = FindIndex;
                    SelectionLength = FindLength;
                    isFind = false;
                }
                else
                {
                    SelectionLength = 0;
                }

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
