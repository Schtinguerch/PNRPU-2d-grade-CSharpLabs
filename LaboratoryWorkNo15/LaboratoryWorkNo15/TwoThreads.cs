using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace LaboratoryWorkNo15
{
    public class TwoThreads
    {
        public RichTextBox TargetRichTextBox { get; set; }
        public Form1 TargetForm { get; set; }

        public Thread AddTextThread { get; private set; }
        public Thread RemoveTextThread { get; private set; }

        public TwoThreads(Form1 targetForm, RichTextBox targetRichTextBox)
        {
            TargetRichTextBox = targetRichTextBox;
            TargetForm = targetForm;

            targetForm.FormClosing += (s, e) => Stop();
        }

        public void Start()
        {
            AddTextThread = new Thread(() => AddText());
            RemoveTextThread = new Thread(() => RemoveText());

            AddTextThread.Start();
            RemoveTextThread.Start();
        }

        public void Stop()
        {
            if (AddTextThread == null || !AddTextThread.IsAlive)
            {
                return;
            }

            AddTextThread.Abort();
            RemoveTextThread.Abort();
        }

        private void AddText()
        {
            while (true)
            {
                lock (TargetRichTextBox)
                {
                    TargetForm.Invoke(new Action(() =>
                    {
                        var newLineCharacter = TargetRichTextBox.Lines.Length == 0 ? "" : "\n";
                        TargetRichTextBox.AppendText($"{newLineCharacter}{RandomString(12)}");
                    }));
                }

                if (RemoveTextThread.ThreadState == ThreadState.Suspended)
                {
                    RemoveTextThread.Resume();
                }

                Thread.Sleep(RandomTimelapse());
            }
        }

        private void RemoveText()
        {
            while (true)
            {
                var isTextEmpty = true;
                lock (TargetRichTextBox)
                {
                    TargetForm.Invoke(new Action(() =>
                    {
                        if (TargetRichTextBox.Lines.Length != 0)
                        {
                            isTextEmpty = false;
                            var withoutLastLine = TargetRichTextBox.Lines;

                            Array.Resize(ref withoutLastLine, TargetRichTextBox.Lines.Length - 1);
                            TargetRichTextBox.Lines = withoutLastLine;
                        }
                    }));
                }

                if (isTextEmpty)
                {
                    RemoveTextThread.Suspend();
                }
                else
                {
                    Thread.Sleep(RandomTimelapse());
                }
            }
        }

        private readonly Random _random = new Random();
        const string SourceChars = "abcdefghijklmnopqrstuvwxyz0123456789";

        private string RandomString(int length)
        {
            var stringChars = new char[length];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = SourceChars[_random.Next(SourceChars.Length)];
            }

            var finalString = new string(stringChars);
            return finalString;
        }

        private int RandomTimelapse()
        {
            return _random.Next(50, 600);
        }
    }
}
