using System.Reflection;
using System.Xml;
using MainFunction;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        //global variables start
        private int NoticeSourceIndex = 0;
        private readonly Icon iconNormal = global::Program.Properties.Resources.Normal;
        private readonly Icon iconOnNotify = global::Program.Properties.Resources.OnNotify;
        private bool FlickerIconFlag = true;
        //global variables end

        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;

            this.ShowInTaskbar = false;

            NoticeIcon.Visible = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void ButtonJWC_Click(object sender, EventArgs e)
        {
            ButtonJWC.Enabled = false;
            this.ActiveControl = null;
            string LoadingSymbol = "⠋⠙⠹⠸⠼⠴⠦⠧⠇⠏";
            int i = 0;
            Task<(bool success, string text)> task = GetNotice.GetNoticeFromJWCAsync(save: true);

            while (!task.IsCompleted)
            {
                ButtonJWC.Text = LoadingSymbol[i++ % LoadingSymbol.Length].ToString();
                await Task.Delay(100);
            }

            FileStream file = new("JWC.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            string oldText = FileData.ReadFromFile(file);
            string diff = FileData.CheckDiff(task.Result.text, oldText);

            MainRichTextBox.Clear();
            MainRichTextBox.AppendTextColorful(diff, Color.Red, 2);
            MainRichTextBox.AppendTextColorful(oldText, Color.Black, 1);
            MainRichTextBox.SelectionStart = 0;
            MainRichTextBox.ScrollToCaret();

            if (task.Result.success == true)
                FileData.WriteToFile(task.Result.text, file);
            file.Close();

            ButtonJWC.Text = "教务处";
            ButtonJWC.Enabled = true;
            ButtonJWC.Focus();
        }

        private async void ButtonSCAI_Click(object sender, EventArgs e)
        {
            ButtonSCAI.Enabled = false;
            this.ActiveControl = null;
            string LoadingSymbol = "⠋⠙⠹⠸⠼⠴⠦⠧⠇⠏";
            int i = 0;
            Task<(bool success, string text)> task = GetNotice.GetNoticeFromSCAIAsync(save: true);

            while (!task.IsCompleted)
            {
                ButtonSCAI.Text = LoadingSymbol[i++ % LoadingSymbol.Length].ToString();
                await Task.Delay(100);
            }
            FileStream file = new("SCAI.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            string oldText = FileData.ReadFromFile(file);
            string diff = FileData.CheckDiff(task.Result.text, oldText);

            MainRichTextBox.Clear();
            MainRichTextBox.AppendTextColorful(diff, Color.Red, 2);
            MainRichTextBox.AppendTextColorful(oldText, Color.Black, 1);
            MainRichTextBox.SelectionStart = 0;
            MainRichTextBox.ScrollToCaret();

            if (task.Result.success == true)
                FileData.WriteToFile(task.Result.text, file);
            file.Close();

            ButtonSCAI.Text = "计院";
            ButtonSCAI.Enabled = true;
            ButtonSCAI.Focus();
        }

        private async void ButtonXGB_Click(object sender, EventArgs e)
        {
            ButtonXGB.Enabled = false;
            this.ActiveControl = null;
            string LoadingSymbol = "⠋⠙⠹⠸⠼⠴⠦⠧⠇⠏";
            int i = 0;
            Task<(bool success, string text)> task = GetNotice.GetNoticeFromXGBAsync(save: true);

            while (!task.IsCompleted)
            {
                ButtonXGB.Text = LoadingSymbol[i++ % LoadingSymbol.Length].ToString();
                await Task.Delay(100);
            }
            FileStream file = new("XGB.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            string oldText = FileData.ReadFromFile(file);
            string diff = FileData.CheckDiff(task.Result.text, oldText);

            MainRichTextBox.Clear();
            MainRichTextBox.AppendTextColorful(diff, Color.Red, 2);
            MainRichTextBox.AppendTextColorful(oldText, Color.Black, 1);
            MainRichTextBox.SelectionStart = 0;
            MainRichTextBox.ScrollToCaret();

            if (task.Result.success == true)
                FileData.WriteToFile(task.Result.text, file);
            file.Close();

            ButtonXGB.Text = "学工部";
            ButtonXGB.Enabled = true;
            ButtonXGB.Focus();
        }

        private void ExitProgram(object sender, EventArgs e)
        {
            this.Dispose();
            Environment.Exit(0);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void FlickerIconTimer_Tick(object sender, EventArgs e)
        {
            if (FlickerIconFlag)
            {
                NoticeIcon.Icon = iconOnNotify;
                FlickerIconFlag = false;
            }
            else
            {
                NoticeIcon.Icon = iconNormal;
                FlickerIconFlag = true;
            }
        }

        private void MainRichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
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
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private async void AutoRunTimer_Tick(object sender, EventArgs e)
        {
            Task<(bool success, string text)> taskJWC = GetNotice.GetNoticeFromJWCAsync(save: false);
            Task<(bool success, string text)> taskSCAI = GetNotice.GetNoticeFromSCAIAsync(save: false);
            Task<(bool success, string text)> taskXGB = GetNotice.GetNoticeFromXGBAsync(save: false);

            await Task.WhenAll(taskJWC, taskSCAI, taskXGB);

            if (taskJWC.Result.success == false || taskSCAI.Result.success == false || taskXGB.Result.success == false)
            {
                FlickerIconTimer.Enabled = false;
                NoticeIcon.Icon = iconNormal;
                return;
            }

            FileStream fileJWC = new("JWC.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream fileSCAI = new("SCAI.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream fileXGB = new("XGB.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            string oldTextJWC = FileData.ReadFromFile(fileJWC);
            string oldTextSCAI = FileData.ReadFromFile(fileSCAI);
            string oldTextXGB = FileData.ReadFromFile(fileXGB);

            string diffJWC = FileData.CheckDiff(taskJWC.Result.text, oldTextJWC);
            string diffSCAI = FileData.CheckDiff(taskSCAI.Result.text, oldTextSCAI);
            string diffXGB = FileData.CheckDiff(taskXGB.Result.text, oldTextXGB);

            if (diffJWC.Length > 0 || diffSCAI.Length > 0 || diffXGB.Length > 0)
            {
                FlickerIconTimer.Start();
                NoticeSourceIndex = 0;

                if (diffJWC.Length > 0)
                    NoticeSourceIndex |= 1;
                if (diffSCAI.Length > 0)
                    NoticeSourceIndex |= 2;
                if (diffXGB.Length > 0)
                    NoticeSourceIndex |= 4;
            }
            else
            {
                FlickerIconTimer.Stop();
                NoticeIcon.Icon = iconNormal;
                NoticeSourceIndex = 0;
            }

            fileJWC.Close();
            fileSCAI.Close();
            fileXGB.Close();
        }

        private void NoticeIcon_Move(object sender, MouseEventArgs e)
        {
            if (FlickerIconTimer.Enabled == true)
            {
                FlickerIconTimer.Stop();
                NoticeIcon.Icon = iconNormal;
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