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
            OpenWindowMenuBottom = new ToolStripMenuItem();
            ExitMenuBotton = new ToolStripMenuItem();
            richTextBox1 = new RichTextBox();
            NoticeMenu.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(461, 539);
            button1.Name = "button1";
            button1.Size = new Size(117, 68);
            button1.TabIndex = 0;
            button1.Text = "教务处";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(657, 539);
            button2.Name = "button2";
            button2.Size = new Size(117, 68);
            button2.TabIndex = 2;
            button2.Text = "计院";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // NoticeIcon
            // 
            NoticeIcon.ContextMenuStrip = NoticeMenu;
            NoticeIcon.Icon = (Icon)resources.GetObject("NoticeIcon.Icon");
            NoticeIcon.Text = "Notice";
            NoticeIcon.Visible = true;
            NoticeIcon.Click += NoticeIconSingleClick;
            NoticeIcon.MouseDoubleClick += NoticeIconDoubleClick;
            // 
            // NoticeMenu
            // 
            NoticeMenu.ImageScalingSize = new Size(20, 20);
            NoticeMenu.Items.AddRange(new ToolStripItem[] { OpenWindowMenuBottom, ExitMenuBotton });
            NoticeMenu.Name = "contextMenuStrip1";
            NoticeMenu.Size = new Size(101, 48);
            // 
            // OpenWindowMenuBottom
            // 
            OpenWindowMenuBottom.Name = "OpenWindowMenuBottom";
            OpenWindowMenuBottom.Size = new Size(100, 22);
            OpenWindowMenuBottom.Text = "打开";
            OpenWindowMenuBottom.Click += OpenWindowMenuBottom_Click;
            // 
            // ExitMenuBotton
            // 
            ExitMenuBotton.Name = "ExitMenuBotton";
            ExitMenuBotton.Size = new Size(100, 22);
            ExitMenuBotton.Text = "退出";
            ExitMenuBotton.Click += ExitProgram;
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(6, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(1270, 521);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            richTextBox1.LinkClicked += RichTextBox1_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1288, 619);
            Controls.Add(richTextBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            TransparencyKey = Color.White;
            FormClosing += Form1_FormClosing;
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
        private ToolStripMenuItem OpenWindowMenuBottom;
    }
}