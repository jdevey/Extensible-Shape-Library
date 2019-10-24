using System;
using System.Drawing;

namespace ShapeLibrary
{
	public class Img
	{
		public readonly string src;
		public readonly Image imgStorage;

		public Img(string src)
		{
			this.src = src;
			imgStorage = Image.FromFile(src);
		}

		public static Img operator <(Img a, Img b)
		{
			return string.Compare(a.src, b.src, StringComparison.Ordinal) < 0 ? a : b;
		}
		
		public static Img operator >(Img a, Img b)
		{
			return string.Compare(a.src, b.src, StringComparison.Ordinal) < 0 ? b : a;
		}
	}
}