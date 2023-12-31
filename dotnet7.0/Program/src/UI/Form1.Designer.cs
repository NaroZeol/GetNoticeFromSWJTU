namespace WinFormsApp1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            NoticeIcon = new NotifyIcon(components);
            NoticeMenu = new ContextMenuStrip(components);
            OpenWindowMenuBotton = new ToolStripMenuItem();
            ExitMenuBotton = new ToolStripMenuItem();
            richTextBox1 = new RichTextBox();
            timerOfFlashingButton = new System.Windows.Forms.Timer(components);
            timerOfAutoRunning = new System.Windows.Forms.Timer(components);
            button3 = new Button();
            NoticeMenu.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(708, 634);
            button1.Margin = new Padding(4, 4, 4, 4);
            button1.Name = "button1";
            button1.Size = new Size(150, 80);
            button1.TabIndex = 0;
            button1.Text = "教务处";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(914, 634);
            button2.Margin = new Padding(4, 4, 4, 4);
            button2.Name = "button2";
            button2.Size = new Size(150, 80);
            button2.TabIndex = 2;
            button2.Text = "计院";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // NoticeIcon
            // 
            NoticeIcon.ContextMenuStrip = NoticeMenu;
            NoticeIcon.Icon = global::Program.Properties.Resources.Normal;
            NoticeIcon.Text = "GetNoticeFromSWJTU";
            NoticeIcon.Visible = true;
            NoticeIcon.BalloonTipClicked += NoticeIcon_BalloonTipClicked;
            NoticeIcon.MouseClick += NoticeIcon_MouseClick;
            NoticeIcon.MouseMove += NoticeIcon_Move;
            // 
            // NoticeMenu
            // 
            NoticeMenu.ImageScalingSize = new Size(20, 20);
            NoticeMenu.Items.AddRange(new ToolStripItem[] { OpenWindowMenuBotton, ExitMenuBotton });
            NoticeMenu.Name = "contextMenuStrip1";
            NoticeMenu.Size = new Size(109, 52);
            // 
            // OpenWindowMenuBotton
            // 
            OpenWindowMenuBotton.Name = "OpenWindowMenuBotton";
            OpenWindowMenuBotton.Size = new Size(108, 24);
            OpenWindowMenuBotton.Text = "打开";
            OpenWindowMenuBotton.Click += OpenWindowMenuBottom_Click;
            // 
            // ExitMenuBotton
            // 
            ExitMenuBotton.Name = "ExitMenuBotton";
            ExitMenuBotton.Size = new Size(108, 24);
            ExitMenuBotton.Text = "退出";
            ExitMenuBotton.Click += ExitProgram;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.Control;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(15, 14);
            richTextBox1.Margin = new Padding(4, 4, 4, 4);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(1625, 613);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            richTextBox1.LinkClicked += RichTextBox1_LinkClicked;
            // 
            // timerOfFlashingButton
            // 
            timerOfFlashingButton.Interval = 1000;
            timerOfFlashingButton.Tick += Timer1_Tick;
            // 
            // timerOfAutoRunning
            // 
            timerOfAutoRunning.Enabled = true;
            timerOfAutoRunning.Interval = 30000;
            timerOfAutoRunning.Tick += TimerOfAutoRunning_Tick;
            // 
            // button3
            // 
            button3.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(501, 634);
            button3.Margin = new Padding(4, 4, 4, 4);
            button3.Name = "button3";
            button3.Size = new Size(150, 80);
            button3.TabIndex = 4;
            button3.Text = "学工部";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Control;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1656, 728);
            Controls.Add(button3);
            Controls.Add(richTextBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "GetNoticeFromSWJTU";
            TransparencyKey = Color.Transparent;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            NoticeMenu.ResumeLayout(false);
            ResumeLayout(false);
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
        private Button button3;
    }
}