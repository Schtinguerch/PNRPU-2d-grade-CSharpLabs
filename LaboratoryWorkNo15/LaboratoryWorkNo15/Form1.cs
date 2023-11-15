using System;
using System.Windows.Forms;

namespace LaboratoryWorkNo15
{
    public partial class Form1 : Form
    {
        private readonly TwoThreads twoThreads;

        public Form1()
        {
            InitializeComponent();
            twoThreads = new TwoThreads(this, TestingRichTextBox);
        }

        private void StartWorkingButton_Click(object sender, EventArgs e)
        {
            twoThreads.Start();
        }

        private void StopWorkingButton_Click(object sender, EventArgs e)
        {
            twoThreads.Stop();
        }

        private void TestingRichTextBox_TextChanged(object sender, EventArgs e)
        {
            LineCountLabel.Text = $"Строк: {TestingRichTextBox.Lines.Length}";
        }
    }
}
