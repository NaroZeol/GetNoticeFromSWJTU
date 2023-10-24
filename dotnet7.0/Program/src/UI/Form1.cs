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
            this.WindowState = FormWindowState.Minimized;

            this.ShowInTaskbar = false;

            NoticeIcon.Visible = true;
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
            string diff = FileData.CheckDiff(task.Result, oldText);

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
            string diff = FileData.CheckDiff(task.Result, oldText);

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

        private async void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            this.ActiveControl = null;
            string LoadingSymbol = "⠋⠙⠹⠸⠼⠴⠦⠧⠇⠏";
            int i = 0;
            Task<string> task = GetNotice.GetNoticeFromXGBAsync();

            while (!task.IsCompleted)
            {
                button3.Text = LoadingSymbol[i++ % LoadingSymbol.Length].ToString();
                await Task.Delay(100);
            }
            FileStream file = new("XGB.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            string oldText = FileData.ReadFromFile(file);
            string diff = FileData.CheckDiff(task.Result, oldText);

            richTextBox1.Clear();
            richTextBox1.AppendTextColorful(diff, Color.Red, 2);
            richTextBox1.AppendTextColorful(oldText, Color.Black, 1);
            richTextBox1.SelectionStart = 0;
            richTextBox1.ScrollToCaret();

            FileData.WriteToFile(task.Result, file);
            file.Close();

            button3.Text = "学工部";
            button3.Enabled = true;
            button3.Focus();
        }

        private void ExitProgram(object sender, EventArgs e)
        {
            this.Dispose();
            Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.Hide();

            //this.WindowState = FormWindowState.Minimized;

            //this.ShowInTaskbar = false;

            //NoticeIcon.Visible = true;
        }

        private void NoticeIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                NoticeMenu.Show();
            }
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
        }

        private readonly Icon icon1 = global::Program.Properties.Resources.Normal;
        private readonly Icon icon2 = global::Program.Properties.Resources.OnNotify;
        private bool Timer1flag = true;

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Timer1flag)
            {
                NoticeIcon.Icon = icon2;
                Timer1flag = false;
            }
            else
            {
                NoticeIcon.Icon = icon1;
                Timer1flag = true;
            }
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

        private async void TimerOfAutoRunning_Tick(object sender, EventArgs e)
        {
            if (global::Program.Utilities.CheckNetwork.IsNetworkConnected == false)
            {
                timerOfFlashingButton.Enabled = false;
                NoticeIcon.Icon = icon1;
                return;
            }
            Task<string> task1 = GetNotice.GetNoticeFromJWCAsync();
            Task<string> task2 = GetNotice.GetNoticeFromSCAIAsync();
            Task<string> task3 = GetNotice.GetNoticeFromXGBAsync();

            await Task.WhenAll(task1, task2, task3);

            FileStream file1 = new("JWC.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream file2 = new("SCAI.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream file3 = new("XGB.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            string oldText1 = FileData.ReadFromFile(file1);
            string oldText2 = FileData.ReadFromFile(file2);
            string oldText3 = FileData.ReadFromFile(file3);

            string diff1 = FileData.CheckDiff(task1.Result, oldText1);
            string diff2 = FileData.CheckDiff(task2.Result, oldText2);
            string diff3 = FileData.CheckDiff(task3.Result, oldText3);

            if (diff1.Length > 0 || diff2.Length > 0 || diff3.Length > 0)
            {
                timerOfFlashingButton.Start();
                NoticeSourceIndex = 0;

                if (diff1.Length > 0)
                    NoticeSourceIndex |= 1;
                if (diff2.Length > 0)
                    NoticeSourceIndex |= 2;
                if (diff3.Length > 0)
                    NoticeSourceIndex |= 4;
            }
            else
            { 
                timerOfFlashingButton.Stop();
                NoticeIcon.Icon = icon1;
                NoticeSourceIndex = 0;
            }

            file1.Close();
            file2.Close();
            file3.Close();
        }

        private int NoticeSourceIndex = 0;

        private void NoticeIcon_Move(object sender, MouseEventArgs e)
        {
            if (timerOfFlashingButton.Enabled == true)
            {
                timerOfFlashingButton.Stop();
                NoticeIcon.Icon = icon1;
                string msg = "有新的通知";
                if ((NoticeSourceIndex & 0x01) == 1)
                    msg = "教务网" + msg;
                if ((NoticeSourceIndex & 0x02) == 2)
                    msg = "计院" + msg;
                if ((NoticeSourceIndex & 0x04) == 4)
                    msg = "学工部" + msg;

                NoticeSourceIndex = 0;
                NoticeIcon.ShowBalloonTip(1000, "通知", msg, ToolTipIcon.Info);
            }
        }

        private void NoticeIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            OpenWindowMenuBottom_Click(sender, e);
        }


    }
}