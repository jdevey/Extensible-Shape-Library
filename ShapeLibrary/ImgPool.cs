using System.Collections.Generic;

namespace ShapeLibrary
{
	public static class ImgPool
	{
		private static readonly HashSet<Img> pool = new HashSet<Img>
		{
				new Img(Constants.defaultImages[0]),
				new Img(Constants.defaultImages[1]),
				new Img(Constants.defaultImages[2])
		};

		public static Img getImage(string src)
		{
			foreach (Img img in pool)
			{
				if (img.src == src)
				{
					return img;
				}
			}
			return null;
		}

		public static void addImage(string src)
		{
			pool.Add(new Img(src));
		}
	}
}