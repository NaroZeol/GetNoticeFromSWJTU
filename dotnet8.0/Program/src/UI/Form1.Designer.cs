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
            ButtonJWC.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonJWC.Location = new Point(708, 634);
            ButtonJWC.Margin = new Padding(4, 4, 4, 4);
            ButtonJWC.Name = "ButtonJWC";
            ButtonJWC.Size = new Size(150, 80);
            ButtonJWC.TabIndex = 0;
            ButtonJWC.Text = "教务处";
            ButtonJWC.UseVisualStyleBackColor = true;
            ButtonJWC.Click += ButtonJWC_Click;
            // 
            // ButtonSCAI
            // 
            ButtonSCAI.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonSCAI.Location = new Point(914, 634);
            ButtonSCAI.Margin = new Padding(4, 4, 4, 4);
            ButtonSCAI.Name = "ButtonSCAI";
            ButtonSCAI.Size = new Size(150, 80);
            ButtonSCAI.TabIndex = 2;
            ButtonSCAI.Text = "计院";
            ButtonSCAI.UseVisualStyleBackColor = true;
            ButtonSCAI.Click += ButtonSCAI_Click;
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
            // MainRichTextBox
            // 
            MainRichTextBox.BackColor = SystemColors.Control;
            MainRichTextBox.BorderStyle = BorderStyle.None;
            MainRichTextBox.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            MainRichTextBox.Location = new Point(15, 14);
            MainRichTextBox.Margin = new Padding(4, 4, 4, 4);
            MainRichTextBox.Name = "MainRichTextBox";
            MainRichTextBox.ReadOnly = true;
            MainRichTextBox.Size = new Size(1625, 613);
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
            // ButtonXGB
            // 
            ButtonXGB.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonXGB.Location = new Point(501, 634);
            ButtonXGB.Margin = new Padding(4, 4, 4, 4);
            ButtonXGB.Name = "ButtonXGB";
            ButtonXGB.Size = new Size(150, 80);
            ButtonXGB.TabIndex = 4;
            ButtonXGB.Text = "学工部";
            ButtonXGB.UseVisualStyleBackColor = true;
            ButtonXGB.Click += ButtonXGB_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Control;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1656, 728);
            Controls.Add(ButtonXGB);
            Controls.Add(MainRichTextBox);
            Controls.Add(ButtonSCAI);
            Controls.Add(ButtonJWC);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
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