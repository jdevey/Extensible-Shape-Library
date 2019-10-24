using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ShapeLibrary
{
	public class GraphicsWrapper
	{
		public Bitmap bitmap { get; }
		public Graphics graphics { get; }

		public GraphicsWrapper()
		{
//			bitmap = new Bitmap(Convert.ToInt32(1024), Convert.ToInt32(1024), PixelFormat.Format32bppArgb);
//			bitmap = new Bitmap(1024, 1024, PixelFormat.Format32bppArgb);
			bitmap = new Bitmap(512, 512);
			graphics = Graphics.FromImage(bitmap);
		}

		public void saveToFile(string fileName)
		{
			bitmap.Save(fileName, ImageFormat.Png);
		}
	}
}