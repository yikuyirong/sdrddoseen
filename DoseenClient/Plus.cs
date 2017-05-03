using Design_Client.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Design_Client
{
	public class Plus : Form
	{
		private IContainer components = null;

		private PictureBox pictureBox1;

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
			this.pictureBox1 = new PictureBox();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.pictureBox1.Dock = DockStyle.Fill;
			this.pictureBox1.Image = Resources.plus;
			this.pictureBox1.Location = new Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(562, 129);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(562, 129);
			base.Controls.Add(this.pictureBox1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Plus";
			this.Text = "注意事项";
			base.FormClosed += new FormClosedEventHandler(this.Plus_FormClosed);
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		public Plus()
		{
			this.InitializeComponent();
		}

		private void Plus_FormClosed(object sender, FormClosedEventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
