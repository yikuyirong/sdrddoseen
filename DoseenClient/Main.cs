using Design_Client.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_Client
{
	[ComVisible(true)]
	public class Main : Form
	{
		private const int CS_DropSHADOW = 131072;

		private const int GCL_STYLE = -26;

		private IContainer components = null;

		private WebBrowser webBrowser1;

		private System.Windows.Forms.Timer timer1;

		private NotifyIcon notifyIcon;

		private ContextMenuStrip contextMenuStrip;

		private ToolStripMenuItem 退出ToolStripMenuItem;

		private ToolStripMenuItem 关于ToolStripMenuItem;

		private System.Windows.Forms.Timer timer2;

		private PictureBox pictureBox1;

		private System.Windows.Forms.Timer FormLoadTimeOut;

		private ToolStripMenuItem toolStripMenuItem1;

		private ToolStripMenuItem toolStripMenuItem2;

		private int LoadNum = 1;

		private bool AutoReSize = false;

		private bool FormPaint = true;

		private bool FormPaintReady = false;

        //private string SetStr = "http://10.10.12.3:88/,山东省热电设计院,429,312,0,0";
        private string SetStr = "http://localhost:8088/,山东省热电设计院,429,312,0,0";

        private string SiteUrl = "";

		private Loading loadingBox = new Loading();

		//private Border BorderWin = new Border();

		private double OpacityValue = 0.0;

		private bool WebDone = false;

		private bool CancelExit = false;

		private int CursorCorner = 5;

		private int CursorBorder = 2;

		private int CursorTopY = 10;

		private string CurrentBodyStyle = "none";

		private string notifyUrl = "";

		private int DownLoadFileNum = 0;

		private string DownLoadOpenFile = "";

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new Container();
			this.webBrowser1 = new WebBrowser();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.notifyIcon = new NotifyIcon(this.components);
			this.contextMenuStrip = new ContextMenuStrip(this.components);
			this.toolStripMenuItem2 = new ToolStripMenuItem();
			this.toolStripMenuItem1 = new ToolStripMenuItem();
			this.关于ToolStripMenuItem = new ToolStripMenuItem();
			this.退出ToolStripMenuItem = new ToolStripMenuItem();
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.pictureBox1 = new PictureBox();
			this.FormLoadTimeOut = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStrip.SuspendLayout();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.webBrowser1.Dock = DockStyle.Fill;
			this.webBrowser1.Location = new Point(0, 0);
			this.webBrowser1.MinimumSize = new Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.ScriptErrorsSuppressed = true;
			this.webBrowser1.ScrollBarsEnabled = false;
			this.webBrowser1.Size = new Size(300, 250);
			this.webBrowser1.TabIndex = 0;
			this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
			this.webBrowser1.NewWindow += new CancelEventHandler(this.webBrowser1_NewWindow);
			this.webBrowser1.PreviewKeyDown += new PreviewKeyDownEventHandler(this.webBrowser1_PreviewKeyDown);
			this.timer1.Interval = 200;
			this.timer1.Tick += new EventHandler(this.timer1_Tick);
			this.notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
			this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
			this.notifyIcon.Visible = true;
			this.notifyIcon.MouseDoubleClick += new MouseEventHandler(this.notifyIcon_MouseDoubleClick);
			this.contextMenuStrip.AutoSize = false;
			this.contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem2,
				this.toolStripMenuItem1,
				this.关于ToolStripMenuItem,
				this.退出ToolStripMenuItem
			});
            

			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new Size(100, 100);
			this.toolStripMenuItem2.Image = Resources.menu4;
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new Size(152, 22);
			this.toolStripMenuItem2.Text = "本地项目";
			this.toolStripMenuItem2.Click += new EventHandler(this.toolStripMenuItem2_Click);
			this.toolStripMenuItem1.Image = Resources.menu3;
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new Size(152, 22);
			this.toolStripMenuItem1.Text = "安装插件";
			this.toolStripMenuItem1.Click += new EventHandler(this.toolStripMenuItem1_Click);
			this.关于ToolStripMenuItem.Image = Resources.menu2;
			this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
			this.关于ToolStripMenuItem.Size = new Size(152, 22);
			this.关于ToolStripMenuItem.Text = "关于软件";
			this.关于ToolStripMenuItem.Click += new EventHandler(this.关于ToolStripMenuItem_Click);
			this.退出ToolStripMenuItem.Image = Resources.menu1;
			this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
			this.退出ToolStripMenuItem.Size = new Size(152, 22);
			this.退出ToolStripMenuItem.Text = "退出系统";
			this.退出ToolStripMenuItem.Click += new EventHandler(this.退出ToolStripMenuItem_Click);
			this.timer2.Interval = 20;
			this.timer2.Tick += new EventHandler(this.timer2_Tick);
			this.pictureBox1.BackgroundImage = Resources.loading7;
			this.pictureBox1.BackgroundImageLayout = ImageLayout.Center;
			this.pictureBox1.Dock = DockStyle.Bottom;
			this.pictureBox1.Location = new Point(0, 199);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(300, 51);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
			this.FormLoadTimeOut.Enabled = true;
			this.FormLoadTimeOut.Interval = 30000;
			this.FormLoadTimeOut.Tick += new EventHandler(this.FormLoadTimeOut_Tick);
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.Window;
			base.ClientSize = new Size(300, 250);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.webBrowser1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "Main";
			base.ShowInTaskbar = false;
			this.Text = "DoSeen";
			base.Deactivate += new EventHandler(this.Main_Deactivate);
			base.FormClosing += new FormClosingEventHandler(this.Main_FormClosing);
			base.Load += new EventHandler(this.Main_Load);
			base.VisibleChanged += new EventHandler(this.Main_VisibleChanged);
			base.Move += new EventHandler(this.Main_Move);
			base.Resize += new EventHandler(this.Main_Resize);
			this.contextMenuStrip.ResumeLayout(false);
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		public Main()
		{
			this.InitializeComponent();
			this.webBrowser1.ObjectForScripting = this;
			base.Opacity = 0.0;
		}

		private void Main_Load(object sender, EventArgs e)
		{
			try
			{
				Control.CheckForIllegalCrossThreadCalls = false;
				if (this.webBrowser1.Version.Major < 8)
				{
					if (MessageBox.Show("系统运行所依赖的内核版本过低，建议安装新的版本！", "内核升级", MessageBoxButtons.OKCancel) == DialogResult.OK)
					{
						Process.Start(Application.StartupPath + "/plus.exe");
						new Plus().Show();
						base.Hide();
						return;
					}
				}
				this.loadingBox.Show(this);
				this.loadingBox.Activate();
				this.Main_Run();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void Main_Run()
		{
			base.Icon = Resources.icon;
			if (this.LoadNum < 3)
			{
				base.ShowInTaskbar = true;
				if (this.LoadNum == 2)
				{
					this.notifyIcon.Icon = Resources.icon;
				}
			}
			this.notifyIcon.Text = "山东省热电设计院";
			this.FormPaintReady = true;
			this.timer1.Enabled = true;
			string[] array = this.SetStr.Split(new char[]
			{
				','
			});
			string str = this.SiteUrl = array[0];
			string str2 = array[1];
			int num = Convert.ToInt32(array[2]);
			int height = Convert.ToInt32(array[3]);
			int num2 = 0;
			int height2 = 0;
			if (array.Length == 6)
			{
				num2 = Convert.ToInt32(array[4]);
				height2 = Convert.ToInt32(array[5]);
			}
			if (this.LoadNum == 1)
			{
				this.AutoReSize = false;
				if (num == 0)
				{
					this.FormPaint = false;
					this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
					base.WindowState = FormWindowState.Maximized;
				}
				else if (num == 1)
				{
					this.FormPaint = false;
					base.Width = Screen.GetBounds(this).Width;
					base.Height = Screen.GetBounds(this).Height;
				}
				else
				{
					this.FormPaint = true;
					base.Width = num;
					base.Height = height;
				}
				this.Text = str2 + " - " + this.Text;
				string urlString = str + "?mac=" + this.GetMac();
				this.webBrowser1.Navigate(urlString);
			}
			else if (this.LoadNum == 2)
			{
				this.AutoReSize = false;
				if (num2 == 0)
				{
					this.FormPaint = false;
					this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
					base.WindowState = FormWindowState.Maximized;
				}
				else if (num2 == 1)
				{
					this.FormPaint = false;
					base.Width = Screen.GetBounds(this).Width;
					base.Height = Screen.GetBounds(this).Height;
				}
				else
				{
					this.FormPaint = true;
					base.Width = num2;
					base.Height = height2;
				}
			}
			else
			{
				this.AutoReSize = true;
			}
			base.Top = (Screen.GetBounds(this).Height - base.Height) / 2;
			base.Left = (Screen.GetBounds(this).Width - base.Width) / 2;
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetClassLong(IntPtr hwnd, int nIndex);

		private void timer2_Tick(object sender, EventArgs e)
		{
			this.loadingBox.Hide();
			this.OpacityValue += 0.1;
			base.Opacity = this.OpacityValue;
			base.Activate();
			if (this.OpacityValue == 0.5)
			{
				//this.BorderWin.Show(this);
			}
			if (this.OpacityValue > 1.0)
			{
				base.Opacity = 1.0;
				this.timer2.Enabled = false;
				this.OpacityValue = 0.0;
				base.Show();
			}
		}

		private void Main_Move(object sender, EventArgs e)
		{
			//this.BorderWin.Location = new Point(base.Left - 5, base.Top - 5);
		}

		private void Main_Resize(object sender, EventArgs e)
		{
			//this.BorderWin.Size = new Size(base.Width + 10, base.Height + 10);
			//this.BorderWin.Location = new Point(base.Location.X - 5, base.Location.Y - 5);
			//this.BorderWin.SetBits();
			if (this.FormPaintReady && this.FormPaint)
			{
				this.SetWindowRegion();
			}
		}

		private string GetMac()
		{
			string result = "";
			ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection instances = managementClass.GetInstances();
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					if (managementObject["IPEnabled"].ToString() == "True")
					{
						result = managementObject["MacAddress"].ToString();
					}
				}
			}
			return result;
		}

		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			try
			{
				if (this.webBrowser1.ReadyState == WebBrowserReadyState.Complete && !this.WebDone)
				{
					this.WebDone = true;
					base.Name = this.webBrowser1.DocumentTitle;
					string[] array = new string[]
					{
						"不",
						"无法",
						"网页",
						"纠错",
						"中国电信",
						"中国联通",
						"中国移动"
					};
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						string value = array2[i];
						if (this.webBrowser1.DocumentTitle.Contains(value))
						{
							MessageBox.Show("请求错误:" + this.webBrowser1.DocumentTitle);
							base.Close();
							return;
						}
					}
					this.timer2.Enabled = true;
					if (base.Name.Contains("任务窗体"))
					{
						base.Owner.Enabled = false;
					}
					if (this.LoadNum == 2)
					{
						base.Owner.Hide();
						Application.OpenForms[0].Hide();
					}
					string value2 = "window.open=function(url,trg){var newWin = document.createElement('a');var ieOpen = document.createElement('iframe');ieOpen.id='newOpen';ieOpen.height='0px';if(url.indexOf('?')>0){url=url+'&'+new Date()}else{url=url+'?'+new Date()}if(trg!=null){if(trg=='_blank'){document.body.appendChild(ieOpen);newOpen.window.open(url);return;}else{newWin.target=trg}}else{newWin.target='_blank'}newWin.href=url;document.body.appendChild(newWin);newWin.focus();newWin.click();};//document.onselectstart=function(){window.external.alert('系统不能执行该操作')};";
					HtmlElement htmlElement = this.webBrowser1.Document.CreateElement("script");
					htmlElement.SetAttribute("type", "text/javascript");
					htmlElement.SetAttribute("text", value2);
					this.webBrowser1.Document.Body.AppendChild(htmlElement);
					this.webBrowser1.Document.Body.MouseDown += new HtmlElementEventHandler(this.Document_MouseDown);
					this.webBrowser1.Document.Body.MouseMove += new HtmlElementEventHandler(this.Document_MouseMove);
					foreach (HtmlWindow htmlWindow in this.webBrowser1.Document.Window.Frames)
					{
						if (htmlWindow.Name == null)
						{
							break;
						}
						HtmlElement htmlElement2 = htmlWindow.Document.CreateElement("script");
						htmlElement2.SetAttribute("type", "text/javascript");
						htmlElement2.SetAttribute("text", value2);
						htmlWindow.Document.Body.AppendChild(htmlElement2);
						htmlWindow.Document.Body.MouseDown += new HtmlElementEventHandler(this.Document_MouseDown);
						htmlWindow.Document.Body.MouseMove += new HtmlElementEventHandler(this.Document_MouseMove);
						foreach (HtmlWindow htmlWindow2 in htmlWindow.Document.Window.Frames)
						{
							HtmlElement htmlElement3 = htmlWindow2.Document.CreateElement("script");
							htmlElement3.SetAttribute("type", "text/javascript");
							htmlElement3.SetAttribute("text", value2);
							htmlWindow2.Document.Body.AppendChild(htmlElement3);
							htmlWindow2.Document.Body.MouseDown += new HtmlElementEventHandler(this.Document_MouseDown);
							htmlWindow2.Document.Body.MouseMove += new HtmlElementEventHandler(this.Document_MouseMove);
						}
					}
					if (this.AutoReSize)
					{
						base.Width = this.webBrowser1.Document.Body.ScrollRectangle.Width;
						base.Height = this.webBrowser1.Document.Body.ScrollRectangle.Height;
						base.Top = (Screen.GetBounds(this).Height - base.Height) / 2;
						base.Left = (Screen.GetBounds(this).Width - base.Width) / 2;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void Main_VisibleChanged(object sender, EventArgs e)
		{
			if (!base.Visible)
			{
				//this.BorderWin.Visible = false;
			}
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (base.Owner != null)
			{
				base.Owner.Enabled = true;
			}
			if (this.LoadNum == 2)
			{
				if (!base.Enabled)
				{
					MessageBox.Show("有尚未完成的任务窗体存在！");
					e.Cancel = true;
					return;
				}
				if (MessageBox.Show("是否要退出系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
				{
					this.LoadNum = 0;
					this.notifyIcon.Visible = false;
					this.notifyIcon.Dispose();
					Environment.Exit(0);
				}
				else
				{
					e.Cancel = true;
				}
			}
			else if (this.CancelExit)
			{
				e.Cancel = true;
				this.CancelExit = false;
			}

            //this.BorderWin.Close();
		}

		private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
		{
			try
			{
				e.Cancel = true;
				if (this.LoadNum == 1)
				{
					base.Hide();
				}
				WebBrowser webBrowser = (WebBrowser)sender;
				string text = webBrowser.Document.ActiveElement.GetAttribute("href");
				if (text == "")
				{
					foreach (HtmlWindow htmlWindow in webBrowser.Document.Window.Frames)
					{
						foreach (HtmlWindow htmlWindow2 in htmlWindow.Document.Window.Frames)
						{
							text = htmlWindow2.Document.ActiveElement.GetAttribute("href");
							if (text != "")
							{
								break;
							}
						}
						if (text != "")
						{
							break;
						}
						text = htmlWindow.Document.ActiveElement.GetAttribute("href");
						if (text != "")
						{
							break;
						}
					}
				}
				if (text.Length >= 3)
				{
					if (!text.Contains("http"))
					{
						text = this.SiteUrl + "/" + text;
					}
					Main main = new Main();
					main.webBrowser1.Navigate(text);
					main.LoadNum = this.LoadNum + 1;
					main.Show(this);
					main.Activate();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		[DllImport("User32.dll")]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("User32.dll")]
		private static extern void SetWindowText(IntPtr hwnd, string lpWindowName);

		private void timer1_Tick(object sender, EventArgs e)
		{
			IntPtr intPtr = Main.FindWindow(null, "Microsoft Internet Explorer");
			IntPtr intPtr2 = Main.FindWindow(null, "来自网页的消息");
			if (intPtr != (IntPtr)0)
			{
				Main.SetWindowText(intPtr, "提示消息");
			}
			if (intPtr2 != (IntPtr)0)
			{
				Main.SetWindowText(intPtr2, "提示消息");
			}
		}

		protected GraphicsPath SetWindowRegion()
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
			graphicsPath = this.GetRoundedRectPath(rect, 5);
			base.Region = new Region(graphicsPath);
			return graphicsPath;
		}

		private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
		{
			Rectangle rect2 = new Rectangle(rect.Location, new Size(radius, radius));
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddArc(rect2, 180f, 90f);
			rect2.X = rect.Right - radius;
			graphicsPath.AddArc(rect2, 270f, 90f);
			rect2.Y = rect.Bottom - radius;
			graphicsPath.AddArc(rect2, 0f, 90f);
			rect2.X = rect.Left;
			graphicsPath.AddArc(rect2, 90f, 90f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		[DllImport("user32.dll")]
		private static extern bool ReleaseCapture();

		[DllImport("user32.dll")]
		private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		private void Document_MouseMove(object sender, HtmlElementEventArgs e)
		{
			HtmlElement htmlElement = sender as HtmlElement;
			if (this.CurrentBodyStyle == "none")
			{
				this.CurrentBodyStyle = htmlElement.Style;
			}
			if (this.CurrentBodyStyle == null)
			{
				this.CurrentBodyStyle = "";
			}
			int x = e.ClientMousePosition.X;
			int y = e.ClientMousePosition.Y;
			if (x >= base.Width - this.CursorCorner && y >= base.Height - this.CursorCorner)
			{
				htmlElement.Style = this.CurrentBodyStyle + ";cursor:nw-resize;";
			}
			else if (x <= this.CursorCorner && y <= this.CursorCorner)
			{
				htmlElement.Style = this.CurrentBodyStyle + ";cursor:nw-resize;";
			}
			else if (x <= this.CursorCorner && y >= base.Height - this.CursorCorner)
			{
				htmlElement.Style = this.CurrentBodyStyle + ";cursor:ne-resize;";
			}
			else if (x >= base.Width - this.CursorCorner && y <= this.CursorCorner)
			{
				htmlElement.Style = this.CurrentBodyStyle + ";cursor:ne-resize;";
			}
			else if (x >= base.Width - this.CursorBorder)
			{
				htmlElement.Style = this.CurrentBodyStyle + ";cursor:w-resize;";
			}
			else if (y >= base.Height - this.CursorBorder)
			{
				htmlElement.Style = this.CurrentBodyStyle + ";cursor:n-resize;";
			}
			else if (x <= this.CursorBorder)
			{
				htmlElement.Style = this.CurrentBodyStyle + ";cursor:w-resize;";
			}
			else if (y <= this.CursorBorder)
			{
				htmlElement.Style = this.CurrentBodyStyle + ";cursor:n-resize;";
			}
			else if (y < this.CursorTopY)
			{
				htmlElement.Style = this.CurrentBodyStyle + ";cursor:move;";
			}
			else
			{
				htmlElement.Style = this.CurrentBodyStyle + ";cursor:default;";
			}
		}

		private void Document_MouseDown(object sender, HtmlElementEventArgs e)
		{
			int x = e.ClientMousePosition.X;
			int y = e.ClientMousePosition.Y;
			Main.ReleaseCapture();
			if (x >= base.Width - this.CursorCorner && y >= base.Height - this.CursorCorner)
			{
				Main.SendMessage(base.Handle, 274, 61448, 0);
			}
			else if (x <= this.CursorCorner && y <= this.CursorCorner)
			{
				Main.SendMessage(base.Handle, 274, 61444, 0);
			}
			else if (x <= this.CursorCorner && y >= base.Height - this.CursorCorner)
			{
				Main.SendMessage(base.Handle, 274, 61447, 0);
			}
			else if (x >= base.Width - this.CursorCorner && y <= this.CursorCorner)
			{
				Main.SendMessage(base.Handle, 274, 61445, 0);
			}
			else if (x >= base.Width - this.CursorBorder)
			{
				Main.SendMessage(base.Handle, 274, 61442, 0);
			}
			else if (y >= base.Height - this.CursorBorder)
			{
				Main.SendMessage(base.Handle, 274, 61446, 0);
			}
			else if (x <= this.CursorBorder)
			{
				Main.SendMessage(base.Handle, 274, 61441, 0);
			}
			else if (y <= this.CursorBorder)
			{
				Main.SendMessage(base.Handle, 274, 61443, 0);
			}
			else if (y < this.CursorTopY)
			{
				this.Cursor = Cursors.SizeAll;
				Main.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		private void Document_ContextMenuShowing(object sender, HtmlElementEventArgs e)
		{
			this.contextMenuStrip.Show(Control.MousePosition);
			e.ReturnValue = false;
		}

		private bool CheckNetWork()
		{
			bool result;
			try
			{
				WebRequest webRequest = WebRequest.Create(this.SiteUrl);
				WebResponse response = webRequest.GetResponse();
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		private void DownUpdate()
		{
			try
			{
				string address = this.SiteUrl + "/update/update.exe";
				string fileName = Application.StartupPath + "/update.exe";
				WebClient webClient = new WebClient();
				webClient.DownloadFile(address, fileName);
			}
			catch
			{
			}
		}

		private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			base.WindowState = FormWindowState.Normal;
			base.Activate();
			this.loadingBox.Hide();
			this.notifyIcon.Text = "";
			this.notifyIcon.Icon = Resources.icon;
			base.ShowInTaskbar = true;
		}

		private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Powered By DoSeenSoft\r\n\r\n版本 Ver 1.0.1", "关于");
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("CAD插件主要用户图纸的设计校审自动化，如需安装请按如下步骤操作：\r\n<1>打开CAD软件任意打开一张图纸\r\n<2>点击确定后在弹出文件夹中找到并将install.vlx拖入CAD图纸中等待约30秒会提示安装成功\r\n<3>关闭CAD并重新打开CAD即可使用插件\r\n<3>如重启后还不能使用(一般报命令错误)请手动打开-工具-加载-加载应用程序-启动组-内容-添加文件夹内的hasan.lsp即可", "插件安装说明");
			try
			{
				Process.Start(Application.StartupPath + "\\lisp");
			}
			catch
			{
				MessageBox.Show("未能找到插件，请确认您是否正确安装了系统！");
			}
		}

		private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.Alt && e.KeyCode == Keys.F4)
			{
				MessageBox.Show("该恶劣行为已被后台记录！");
				this.CancelExit = true;
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.LoadNum++;
			base.Close();
		}

		private void Main_Deactivate(object sender, EventArgs e)
		{
			try
			{
				if (base.Visible)
				{
					WebBrowser webBrowser = (WebBrowser)base.Controls.Find("webBrowser1", true)[0];
					HtmlWindow htmlWindow = webBrowser.Document.Window.Frames["topFrame"];
					htmlWindow.Document.InvokeScript("oPopuphide");
				}
			}
			catch(Exception ex)
			{
				Debug.Print("未发现top");
			}
		}

		private void FormLoadTimeOut_Tick(object sender, EventArgs e)
		{
			this.FormLoadTimeOut.Enabled = false;
			this.loadingBox.Hide();
			base.Opacity = 1.0;
			base.Activate();
		}

		public void notify(string title, string content, string url, int style)
		{
			ToolTipIcon tipIcon;
			switch (style)
			{
			case 0:
				tipIcon = ToolTipIcon.None;
				break;
			case 1:
				tipIcon = ToolTipIcon.Info;
				break;
			case 2:
				tipIcon = ToolTipIcon.Warning;
				break;
			case 3:
				tipIcon = ToolTipIcon.Error;
				break;
			default:
				tipIcon = ToolTipIcon.Info;
				break;
			}
			this.notifyIcon.ShowBalloonTip(5000, title, content, tipIcon);
			if (url != "")
			{
				this.notifyUrl = url;
				this.notifyIcon.BalloonTipClicked -= new EventHandler(this.notifyIcon_BalloonTipClicked);
				this.notifyIcon.BalloonTipClicked += new EventHandler(this.notifyIcon_BalloonTipClicked);
			}
		}

		private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
		{
			if (this.notifyUrl != "")
			{
				this.open(this.notifyUrl, 0, 0);
			}
		}

		public void alert(string str)
		{
			MessageBox.Show(str, "提示消息");
		}

		public void reload()
		{
			WebBrowser webBrowser = (WebBrowser)base.Owner.Controls.Find("webBrowser1", true)[0];
			HtmlWindow htmlWindow = webBrowser.Document.Window.Frames["mainFrame"].Frames["rightFrame"];
			htmlWindow.Navigate(htmlWindow.Url);
		}

		public void href(string Url)
		{
			WebBrowser webBrowser = (WebBrowser)base.Owner.Controls.Find("webBrowser1", true)[0];
			if (!Url.Contains("http://"))
			{
				Url = this.SiteUrl + "/" + Url;
			}
			webBrowser.Document.Window.Frames["mainFrame"].Frames["rightFrame"].Navigate(Url);
		}

		public void close()
		{
			base.Close();
		}

		public void max()
		{
			this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
			if (base.WindowState == FormWindowState.Maximized)
			{
				base.WindowState = FormWindowState.Normal;
			}
			else
			{
				base.WindowState = FormWindowState.Maximized;
			}
		}

		public void min()
		{
			base.WindowState = FormWindowState.Minimized;
		}

		public void FileOpen(string filename)
		{
			Process.Start(Application.StartupPath + "/" + filename);
		}

		public void open(string Url, int WidthValue, int HeightValue)
		{
			Main main = new Main();
			if (!Url.Contains("http://"))
			{
				Url = this.SiteUrl + "/" + Url;
			}
			else
			{
				main.pictureBox1.Visible = true;
			}
			main.webBrowser1.Navigate(Url);
			main.LoadNum = this.LoadNum + 1;
			if (WidthValue == 0)
			{
				main.AutoReSize = true;
			}
			else
			{
				main.Width = WidthValue;
				main.Height = HeightValue;
			}
			main.Show(this);
			main.Activate();
		}

		public void download(string ServerFile, string ClientFile, bool ReadBuffer)
		{
			try
			{
				this.loadingBox.Show();
				string[] array = ServerFile.Split(new char[]
				{
					'|'
				});
				string[] array2 = ClientFile.Split(new char[]
				{
					'|'
				});
				this.DownLoadOpenFile = Application.StartupPath + array2[array2.Length - 1];
				this.DownLoadFileNum = array.Length;
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i];
					string text2 = array2[i];
					if (!text.Contains("http://"))
					{
						text = this.SiteUrl + text;
					}
					Uri address = new Uri(text);
					text2 = Application.StartupPath + text2;
					if (ReadBuffer && File.Exists(text2))
					{
						this.DownloadFileComplete();
					}
					else
					{
						string path = text2.Substring(0, text2.LastIndexOf('/'));
						if (!Directory.Exists(path))
						{
							Directory.CreateDirectory(path);
						}
						WebClient webClient = new WebClient();
						webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.client_DownloadFileCompleted);
						webClient.DownloadFileAsync(address, text2);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				this.loadingBox.Hide();
				File.Delete(this.DownLoadOpenFile);
				MessageBox.Show(e.Error.Message);
			}
			else
			{
				this.DownloadFileComplete();
			}
		}

		private void DownloadFileComplete()
		{
			this.DownLoadFileNum--;
			if (this.DownLoadFileNum == 0)
			{
				this.loadingBox.Hide();
				DialogResult dialogResult = MessageBox.Show("文件加载完毕，是否立即打开文件？", "提示", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
                    new Thread(new ThreadStart(() =>
                    {
                        try
                        {
                            Process.Start(this.DownLoadOpenFile);
                        }
                        catch { }
                    })).Start();

				}
				else if (dialogResult == DialogResult.No)
				{
					Process.Start(this.DownLoadOpenFile.Substring(0, this.DownLoadOpenFile.LastIndexOf('/')));
				}
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			string text = Application.StartupPath + "/project";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			Process.Start(text);
		}
	}
}
