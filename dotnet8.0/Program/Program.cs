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
            //用于确保只有一个实例在运行
            string mutexName = "MutexForGetNoticeFromSWJTU";
            Mutex mutex = new Mutex(false, mutexName, out bool isCreateNew);
            if (!isCreateNew)
            {
                MessageBox.Show(null, "已存在一个运行实例", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}