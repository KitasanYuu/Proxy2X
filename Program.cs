using System;
using System.Threading;
using System.Windows.Forms;

namespace _2x
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            bool createdNew;
            // 创建一个唯一的 Mutex 名称来确保应用程序只运行一个实例
            using (Mutex mutex = new Mutex(true, "ProxySwitcherMutex", out createdNew))
            {
                if (createdNew)
                {
                    // 如果是新创建的实例，启动应用程序
                    Application.Run(new Form1());
                }
                else
                {
                    // 如果实例已经存在，则显示一个消息框并退出程序
                    MessageBox.Show("应用程序已经在运行中。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
