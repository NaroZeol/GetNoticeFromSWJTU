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
            string LoadingSymbol = "⠋⠙⠹⠸⠼⠴⠦⠧⠇⠏";
            int i = 0;
            Task<string> task = Notice.GetNoticeFromJWCAsync();

            while (!task.IsCompleted)
            {
                button1.Text = LoadingSymbol[i++ % LoadingSymbol.Length].ToString();
                await Task.Delay(100);
            }

            button1.Text = "教务处";
            textBox1.Text = task.Result;
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            string LoadingSymbol = "⠋⠙⠹⠸⠼⠴⠦⠧⠇⠏";
            int i = 0;
            Task<string> task = Notice.GetNoticeFromSCAIAsync();

            while (!task.IsCompleted)
            {
                button2.Text = LoadingSymbol[i++ % LoadingSymbol.Length].ToString();
                await Task.Delay(100);
            }

            button2.Text = "计院";
            textBox1.Text = task.Result;
        }
    }
}