using Design_Client.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Design_Client
{
	public class Border : Form
	{
		private IContainer components = null;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle |= 524288;
				return createParams;
			}
		}

		public Border()
		{
			try
			{
				this.InitializeComponent();
				this.SetBits();
				this.CanPenetrate();
			}
			catch
			{
			}
		}

		private void CanPenetrate()
		{
			try
			{
				int windowLong = Win32.GetWindowLong(base.Handle, -20);
				int num = Win32.SetWindowLong(base.Handle, -20, 524320);
			}
			catch
			{
			}
		}

		public void SetBits()
		{
			try
			{
				Bitmap bitmap = new Bitmap(base.Width + 10, base.Height + 10);
				Rectangle rectangle = new Rectangle(20, 20, 20, 20);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				ImageDrawRect.DrawRect(graphics, Resources.border, base.ClientRectangle, Rectangle.FromLTRB(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height), 1, 1);
				if (!Image.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Image.IsAlphaPixelFormat(bitmap.PixelFormat))
				{
					throw new ApplicationException("图片必须是32位带Alhpa通道的图片");
				}
				IntPtr hObj = IntPtr.Zero;
				IntPtr dC = Win32.GetDC(IntPtr.Zero);
				IntPtr intPtr = IntPtr.Zero;
				IntPtr intPtr2 = Win32.CreateCompatibleDC(dC);
				try
				{
					Win32.Point point = new Win32.Point(base.Left, base.Top);
					Win32.Size size = new Win32.Size(base.Width, base.Height);
					Win32.BLENDFUNCTION bLENDFUNCTION = default(Win32.BLENDFUNCTION);
					Win32.Point point2 = new Win32.Point(0, 0);
					intPtr = bitmap.GetHbitmap(Color.FromArgb(0));
					hObj = Win32.SelectObject(intPtr2, intPtr);
					bLENDFUNCTION.BlendOp = 0;
					bLENDFUNCTION.SourceConstantAlpha = byte.Parse("255");
					bLENDFUNCTION.AlphaFormat = 1;
					bLENDFUNCTION.BlendFlags = 0;
					Win32.UpdateLayeredWindow(base.Handle, dC, ref point, ref size, intPtr2, ref point2, 0, ref bLENDFUNCTION, 2);
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						Win32.SelectObject(intPtr2, hObj);
						Win32.DeleteObject(intPtr);
					}
					Win32.ReleaseDC(IntPtr.Zero, dC);
					Win32.DeleteDC(intPtr2);
				}
			}
			catch
			{
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
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(284, 262);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "Border";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Border";
			base.ResumeLayout(false);
		}
	}
}
