using System.Reflection;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            //����ȷ��ֻ��һ��ʵ��������
            string mutexName = "MutexForGetNoticeFromSWJTU";
            Mutex mutex = new Mutex(false, mutexName, out bool isCreateNew);
            if (!isCreateNew)
            {
                MessageBox.Show(null, "�Ѵ���һ������ʵ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}