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
			bitmap = new Bitmap(512, 512);
			graphics = Graphics.FromImage(bitmap);
		}

		public void saveToFile(string fileName)
		{
			bitmap.Save(fileName, ImageFormat.Png);
		}
	}
}