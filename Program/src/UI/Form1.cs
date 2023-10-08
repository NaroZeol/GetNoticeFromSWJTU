﻿using System.Xml;
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
            string LoadingSymbol = "⠋⠙⠹⠸⠼⠴⠦⠧⠇⠏";
            int i = 0;
            Task<string> task = GetNotice.GetNoticeFromJWCAsync();

            while (!task.IsCompleted)
            {
                button1.Text = LoadingSymbol[i++ % LoadingSymbol.Length].ToString();
                await Task.Delay(100);
            }

            button1.Text = "教务处";
            richTextBox1.Text = task.Result;
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            string LoadingSymbol = "⠋⠙⠹⠸⠼⠴⠦⠧⠇⠏";
            int i = 0;
            Task<string> task = GetNotice.GetNoticeFromSCAIAsync();

            while (!task.IsCompleted)
            {
                button2.Text = LoadingSymbol[i++ % LoadingSymbol.Length].ToString();
                await Task.Delay(100);
            }

            button2.Text = "计院";
            richTextBox1.Text = task.Result;
        }

        private void ExitProgram(object sender, EventArgs e)
        {
            this.Dispose();
            Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 取消关闭窗体
            e.Cancel = true;
            // 将窗体变为最小化
            this.WindowState = FormWindowState.Minimized;

            //隐藏任务栏区图标
            this.ShowInTaskbar = false;
            //图标显示在托盘区
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

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (e.LinkText is not null)
            {
                string url = e.LinkText;
                ProcessStartInfo info = new ProcessStartInfo()
                {
                    FileName = url,
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(info);
            }
        }
    }
}