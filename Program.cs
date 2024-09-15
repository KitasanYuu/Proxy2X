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
            // ����һ��Ψһ�� Mutex ������ȷ��Ӧ�ó���ֻ����һ��ʵ��
            using (Mutex mutex = new Mutex(true, "ProxySwitcherMutex", out createdNew))
            {
                if (createdNew)
                {
                    // ������´�����ʵ��������Ӧ�ó���
                    Application.Run(new Form1());
                }
                else
                {
                    // ���ʵ���Ѿ����ڣ�����ʾһ����Ϣ���˳�����
                    MessageBox.Show("Ӧ�ó����Ѿ��������С�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
