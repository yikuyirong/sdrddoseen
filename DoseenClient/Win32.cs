using System;
using System.Runtime.InteropServices;

public class Win32
{
	public struct Size
	{
		public int cx;

		public int cy;

		public Size(int x, int y)
		{
			this.cx = x;
			this.cy = y;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct BLENDFUNCTION
	{
		public byte BlendOp;

		public byte BlendFlags;

		public byte SourceConstantAlpha;

		public byte AlphaFormat;
	}

	public struct Point
	{
		public int x;

		public int y;

		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public const int GWL_EXSTYLE = -20;

	public const int WS_EX_TRANSPARENT = 32;

	public const int WS_EX_LAYERED = 524288;

	public const byte AC_SRC_OVER = 0;

	public const int ULW_ALPHA = 2;

	public const byte AC_SRC_ALPHA = 1;

	public const int AW_HOR_POSITIVE = 1;

	public const int AW_HOR_NEGATIVE = 2;

	public const int AW_VER_POSITIVE = 4;

	public const int AW_VER_NEGATIVE = 8;

	public const int AW_CENTER = 16;

	public const int AW_HIDE = 65536;

	public const int AW_ACTIVATE = 131072;

	public const int AW_SLIDE = 262144;

	public const int AW_BLEND = 524288;

	[DllImport("user32")]
	public static extern bool AnimateWindow(IntPtr whnd, int dwtime, int dwflag);

	[DllImport("User32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessageA")]
	public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

	[DllImport("user32.dll")]
	public static extern bool ReleaseCapture();

	[DllImport("user32")]
	public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

	[DllImport("gdi32.dll")]
	public static extern int CreateRoundRectRgn(int x1, int y1, int x2, int y2, int x3, int y3);

	[DllImport("user32.dll")]
	public static extern int SetWindowRgn(IntPtr hwnd, int hRgn, bool bRedraw);

	[DllImport("user32")]
	public static extern int GetWindowLong(IntPtr hwnd, int nIndex);

	[DllImport("user32.dll")]
	public static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

	[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

	[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr GetDC(IntPtr hWnd);

	[DllImport("gdi32.dll", ExactSpelling = true)]
	public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObj);

	[DllImport("user32.dll", ExactSpelling = true)]
	public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

	[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern int DeleteDC(IntPtr hDC);

	[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern int DeleteObject(IntPtr hObj);

	[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern int UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Win32.Point pptDst, ref Win32.Size psize, IntPtr hdcSrc, ref Win32.Point pptSrc, int crKey, ref Win32.BLENDFUNCTION pblend, int dwFlags);

	[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr ExtCreateRegion(IntPtr lpXform, uint nCount, IntPtr rgnData);
}
