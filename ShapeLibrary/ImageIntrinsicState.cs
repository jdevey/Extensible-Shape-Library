using System;
using System.Drawing;
using System.IO;

namespace ShapeLibrary
{
	public class ImageIntrinsicState
	{
		public readonly string src;
		public readonly Image imgStorage;

		public ImageIntrinsicState(string src)
		{
			this.src = src;
			string xx = Directory.GetCurrentDirectory();
			imgStorage = Image.FromFile(src);
		}

		public static ImageIntrinsicState operator <(ImageIntrinsicState a, ImageIntrinsicState b)
		{
			return string.Compare(a.src, b.src, StringComparison.Ordinal) < 0 ? a : b;
		}
		
		public static ImageIntrinsicState operator >(ImageIntrinsicState a, ImageIntrinsicState b)
		{
			return string.Compare(a.src, b.src, StringComparison.Ordinal) < 0 ? b : a;
		}
	}
}