using System.Reflection;
using System.Xml;
using MainFunction;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            this.ActiveControl = null;
            string LoadingSymbol = "⠋⠙⠹⠸⠼⠴⠦⠧⠇⠏";
            int i = 0;
            Task<string> task = GetNotice.GetNoticeFromJWCAsync();

            while (!task.IsCompleted)
            {
                button1.Text = LoadingSymbol[i++ % LoadingSymbol.Length].ToString();
                await Task.Delay(100);
            }

            FileStream file = new("JWC.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            string oldText = FileData.ReadFromFile(file);
            string diff = FileData.CheckDiff(task.Result, file);

            richTextBox1.Clear();
            richTextBox1.AppendTextColorful(diff, Color.Red, 2);
            richTextBox1.AppendTextColorful(oldText, Color.Black, 1);
            richTextBox1.SelectionStart = 0;
            richTextBox1.ScrollToCaret();

            FileData.WriteToFile(task.Result, file);
            file.Close();

            button1.Text = "教务处";
            button1.Enabled = true;
            button1.Focus();
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            this.ActiveControl = null;
            string LoadingSymbol = "⠋⠙⠹⠸⠼⠴⠦⠧⠇⠏";
            int i = 0;
            Task<string> task = GetNotice.GetNoticeFromSCAIAsync();

            while (!task.IsCompleted)
            {
                button2.Text = LoadingSymbol[i++ % LoadingSymbol.Length].ToString();
                await Task.Delay(100);
            }
            FileStream file = new("SCAI.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            string oldText = FileData.ReadFromFile(file);
            string diff = FileData.CheckDiff(task.Result, file);

            richTextBox1.Clear();
            richTextBox1.AppendTextColorful(diff, Color.Red, 2);
            richTextBox1.AppendTextColorful(oldText, Color.Black, 1);
            richTextBox1.SelectionStart = 0;
            richTextBox1.ScrollToCaret();

            FileData.WriteToFile(task.Result, file);
            file.Close();

            button2.Text = "计院";
            button2.Enabled = true;
            button2.Focus();
        }

        private void ExitProgram(object sender, EventArgs e)
        {
            this.Dispose();
            Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.WindowState = FormWindowState.Minimized;

            this.ShowInTaskbar = false;

            NoticeIcon.Visible = true;
        }

        private void NoticeIconDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void NoticeIconSingleClick(object sender, EventArgs e)
        {
        }

        private void RichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (e.LinkText is not null)
            {
                string url = e.LinkText;
                System.Diagnostics.ProcessStartInfo info = new()
                {
                    FileName = url,
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(info);
            }
        }

        private void OpenWindowMenuBottom_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
    }
}