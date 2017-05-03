using Design_Client.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Design_Client
{
	public class Loading : Form
	{
		private IContainer components = null;

		private PictureBox pictureBox1;

		private Timer timer1;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle |= 524288;
				return createParams;
			}
		}

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
			this.pictureBox1 = new PictureBox();
			this.timer1 = new Timer(this.components);
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.pictureBox1.Dock = DockStyle.Fill;
			this.pictureBox1.Location = new Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(50, 50);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.timer1.Enabled = true;
			this.timer1.Interval = 200;
			this.timer1.Tick += new EventHandler(this.timer1_Tick);
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(50, 50);
			base.Controls.Add(this.pictureBox1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "Loading";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Loading";
			base.TopMost = true;
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		public Loading()
		{
			this.InitializeComponent();
			this.pictureBox1.Image = Resources.loading;
			if (Public.Progress > 0)
			{
				this.pictureBox1.Image = Resources.loading_;
			}
			Image image = this.pictureBox1.Image;
			Rectangle workingArea = Screen.GetWorkingArea(this);
			int x = (workingArea.Width - image.Width) / 2;
			int y = (workingArea.Height - image.Height) / 2;
			base.Location = new Point(x, y);
		}

		public void SetBitmap(Bitmap bitmap)
		{
			this.SetBitmap(bitmap, 255);
		}

		public void SetBitmap(Bitmap bitmap, byte opacity)
		{
			if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
			{
				throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");
			}
			IntPtr dC = Win32.GetDC(IntPtr.Zero);
			IntPtr intPtr = Win32.CreateCompatibleDC(dC);
			IntPtr intPtr2 = IntPtr.Zero;
			IntPtr hObj = IntPtr.Zero;
			try
			{
				intPtr2 = bitmap.GetHbitmap(Color.FromArgb(0));
				hObj = Win32.SelectObject(intPtr, intPtr2);
				Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
				Win32.Point point = new Win32.Point(0, 0);
				Win32.Point point2 = new Win32.Point(base.Left, base.Top);
				Win32.BLENDFUNCTION bLENDFUNCTION = default(Win32.BLENDFUNCTION);
				bLENDFUNCTION.BlendOp = 0;
				bLENDFUNCTION.BlendFlags = 0;
				bLENDFUNCTION.SourceConstantAlpha = opacity;
				bLENDFUNCTION.AlphaFormat = 1;
				Win32.UpdateLayeredWindow(base.Handle, dC, ref point2, ref size, intPtr, ref point, 0, ref bLENDFUNCTION, 2);
			}
			finally
			{
				Win32.ReleaseDC(IntPtr.Zero, dC);
				if (intPtr2 != IntPtr.Zero)
				{
					Win32.SelectObject(intPtr, hObj);
					Win32.DeleteObject(intPtr2);
				}
				Win32.DeleteDC(intPtr);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
			this.pictureBox1.Refresh();
			Bitmap bitmap = new Bitmap(this.pictureBox1.Image);
			if (Public.Progress > 0)
			{
				Rectangle r = default(Rectangle);
				r.X = 11;
				r.Y = 12;
				r.Width = 22;
				r.Height = 22;
				Image image = bitmap;
				Graphics graphics = Graphics.FromImage(image);
				Font font = new Font("Arial", 7f);
				graphics.DrawString(Public.Progress.ToString().PadLeft(2, '0'), font, new SolidBrush(Color.Green), r);
			}
			this.SetBitmap(bitmap);
		}
	}
}
