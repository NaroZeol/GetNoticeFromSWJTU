using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        public static void Main()
        {
            string? proGramName = Assembly.GetExecutingAssembly().GetName().Name;

            using Mutex mutex = new Mutex(false, proGramName, out bool createdNew);
            if (!createdNew)
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}