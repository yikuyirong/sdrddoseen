using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Design_Client
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			bool flag = true;
			Mutex mutex = new Mutex(true, "Design_Client", out flag);
			if (flag)
			{
				mutex.ReleaseMutex();
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Main());
			}
			else if (MessageBox.Show("不能重复开启程序，是否强制关闭之前运行的程序！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Process[] processesByName = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
				Process[] array = processesByName;
				for (int i = 0; i < array.Length; i++)
				{
					Process process = array[i];
					if (process.StartTime != Process.GetCurrentProcess().StartTime)
					{
						process.Kill();
					}
				}
			}
		}

		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			MessageBox.Show(string.Concat(new object[]
			{
				"错误信息：",
				e.Exception.Message,
				e.Exception.TargetSite,
				e.Exception.StackTrace
			}));
		}

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			MessageBox.Show(string.Concat(new object[]
			{
				"未处理异常：",
				((Exception)e.ExceptionObject).Message,
				((Exception)e.ExceptionObject).TargetSite,
				((Exception)e.ExceptionObject).StackTrace
			}));
		}
	}
}
