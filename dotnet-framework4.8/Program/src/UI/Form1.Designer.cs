using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.NoticeIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NoticeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenWindowMenuBotton = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuBotton = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timerOfFlashingButton = new System.Windows.Forms.Timer(this.components);
            this.timerOfAutoRunning = new System.Windows.Forms.Timer(this.components);
            this.NoticeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F);
            this.button1.Location = new System.Drawing.Point(400, 475);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 68);
            this.button1.TabIndex = 0;
            this.button1.Text = "教务处";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F);
            this.button2.Location = new System.Drawing.Point(641, 475);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 68);
            this.button2.TabIndex = 2;
            this.button2.Text = "计院";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // NoticeIcon
            // 
            this.NoticeIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NoticeIcon.ContextMenuStrip = this.NoticeMenu;
            this.NoticeIcon.Icon = global::Program.Properties.Resources.Normal;
            this.NoticeIcon.Text = "GetNoticeFromSWJTU";
            this.NoticeIcon.Visible = true;
            this.NoticeIcon.BalloonTipClicked += new System.EventHandler(this.NoticeIcon_BalloonTipClicked);
            this.NoticeIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NoticeIcon_MouseClick);
            this.NoticeIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NoticeIcon_Move);
            // 
            // NoticeMenu
            // 
            this.NoticeMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.NoticeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenWindowMenuBotton,
            this.ExitMenuBotton});
            this.NoticeMenu.Name = "contextMenuStrip1";
            this.NoticeMenu.Size = new System.Drawing.Size(101, 48);
            // 
            // OpenWindowMenuBotton
            // 
            this.OpenWindowMenuBotton.Name = "OpenWindowMenuBotton";
            this.OpenWindowMenuBotton.Size = new System.Drawing.Size(100, 22);
            this.OpenWindowMenuBotton.Text = "打开";
            this.OpenWindowMenuBotton.Click += new System.EventHandler(this.OpenWindowMenuBottom_Click);
            // 
            // ExitMenuBotton
            // 
            this.ExitMenuBotton.Name = "ExitMenuBotton";
            this.ExitMenuBotton.Size = new System.Drawing.Size(100, 22);
            this.ExitMenuBotton.Text = "退出";
            this.ExitMenuBotton.Click += new System.EventHandler(this.ExitProgram);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F);
            this.richTextBox1.Location = new System.Drawing.Point(12, 11);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1072, 460);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RichTextBox1_LinkClicked);
            // 
            // timerOfFlashingButton
            // 
            this.timerOfFlashingButton.Interval = 1000;
            this.timerOfFlashingButton.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // timerOfAutoRunning
            // 
            this.timerOfAutoRunning.Enabled = true;
            this.timerOfAutoRunning.Interval = 10000;
            this.timerOfAutoRunning.Tick += new System.EventHandler(this.TimerOfAutoRunning_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1096, 554);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "GetNoticeFromSWJTU";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.NoticeMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button button2;
        private NotifyIcon NoticeIcon;
        private ContextMenuStrip NoticeMenu;
        private ToolStripMenuItem ExitMenuBotton;
        private RichTextBox richTextBox1;
        private ToolStripMenuItem OpenWindowMenuBotton;
        private System.Windows.Forms.Timer timerOfFlashingButton;
        private System.Windows.Forms.Timer timerOfAutoRunning;
    }
}

