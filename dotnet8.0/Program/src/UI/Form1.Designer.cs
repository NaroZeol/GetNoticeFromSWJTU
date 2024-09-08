namespace WinFormsApp1
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ButtonJWC = new Button();
            ButtonSCAI = new Button();
            ButtonXGB = new Button();
            NoticeIcon = new NotifyIcon(components);
            NoticeMenu = new ContextMenuStrip(components);
            OpenWindowMenuBotton = new ToolStripMenuItem();
            ExitMenuBotton = new ToolStripMenuItem();
            MainRichTextBox = new RichTextBox();
            FlickerIconTimer = new System.Windows.Forms.Timer(components);
            AutoRunTimer = new System.Windows.Forms.Timer(components);
            NoticeMenu.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonJWC
            // 
            ButtonJWC.Font = new Font("Microsoft YaHei UI", 20F);
            ButtonJWC.Location = new Point(551, 539);
            ButtonJWC.Name = "ButtonJWC";
            ButtonJWC.Size = new Size(117, 68);
            ButtonJWC.TabIndex = 0;
            ButtonJWC.Text = "教务处";
            ButtonJWC.UseVisualStyleBackColor = true;
            ButtonJWC.Click += ButtonJWC_Click;
            // 
            // ButtonSCAI
            // 
            ButtonSCAI.Font = new Font("Microsoft YaHei UI", 20F);
            ButtonSCAI.Location = new Point(711, 539);
            ButtonSCAI.Name = "ButtonSCAI";
            ButtonSCAI.Size = new Size(117, 68);
            ButtonSCAI.TabIndex = 2;
            ButtonSCAI.Text = "计院";
            ButtonSCAI.UseVisualStyleBackColor = true;
            ButtonSCAI.Click += ButtonSCAI_Click;
            // 
            // ButtonXGB
            // 
            ButtonXGB.Font = new Font("Microsoft YaHei UI", 20F);
            ButtonXGB.Location = new Point(390, 539);
            ButtonXGB.Name = "ButtonXGB";
            ButtonXGB.Size = new Size(117, 68);
            ButtonXGB.TabIndex = 4;
            ButtonXGB.Text = "学工部";
            ButtonXGB.UseVisualStyleBackColor = true;
            ButtonXGB.Click += ButtonXGB_Click;
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
            NoticeMenu.Size = new Size(101, 48);
            // 
            // OpenWindowMenuBotton
            // 
            OpenWindowMenuBotton.Name = "OpenWindowMenuBotton";
            OpenWindowMenuBotton.Size = new Size(100, 22);
            OpenWindowMenuBotton.Text = "打开";
            OpenWindowMenuBotton.Click += OpenWindowMenuBottom_Click;
            // 
            // ExitMenuBotton
            // 
            ExitMenuBotton.Name = "ExitMenuBotton";
            ExitMenuBotton.Size = new Size(100, 22);
            ExitMenuBotton.Text = "退出";
            ExitMenuBotton.Click += ExitProgram;
            // 
            // MainRichTextBox
            // 
            MainRichTextBox.BackColor = SystemColors.Control;
            MainRichTextBox.BorderStyle = BorderStyle.None;
            MainRichTextBox.Font = new Font("Microsoft YaHei UI", 15F);
            MainRichTextBox.Location = new Point(12, 12);
            MainRichTextBox.Name = "MainRichTextBox";
            MainRichTextBox.ReadOnly = true;
            MainRichTextBox.Size = new Size(1264, 521);
            MainRichTextBox.TabIndex = 3;
            MainRichTextBox.Text = "";
            MainRichTextBox.LinkClicked += MainRichTextBox_LinkClicked;
            // 
            // FlickerIconTimer
            // 
            FlickerIconTimer.Interval = 1000;
            FlickerIconTimer.Tick += FlickerIconTimer_Tick;
            // 
            // AutoRunTimer
            // 
            AutoRunTimer.Enabled = true;
            AutoRunTimer.Interval = 30000;
            AutoRunTimer.Tick += AutoRunTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = SystemColors.Control;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1288, 619);
            Controls.Add(ButtonXGB);
            Controls.Add(MainRichTextBox);
            Controls.Add(ButtonSCAI);
            Controls.Add(ButtonJWC);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "GetNoticeFromSWJTU";
            TransparencyKey = Color.Transparent;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            NoticeMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button ButtonJWC;
        private Button ButtonSCAI;
        private NotifyIcon NoticeIcon;
        private ContextMenuStrip NoticeMenu;
        private ToolStripMenuItem ExitMenuBotton;
        private RichTextBox MainRichTextBox;
        private ToolStripMenuItem OpenWindowMenuBotton;
        private System.Windows.Forms.Timer FlickerIconTimer;
        private System.Windows.Forms.Timer AutoRunTimer;
        private Button ButtonXGB;
    }
}