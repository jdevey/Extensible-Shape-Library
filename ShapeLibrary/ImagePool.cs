using System.Collections.Generic;

namespace ShapeLibrary
{
	public static class ImagePool
	{
		private static readonly HashSet<ImageIntrinsicState> pool = new HashSet<ImageIntrinsicState>();

		public static ImageIntrinsicState getImage(string src)
		{
			foreach (ImageIntrinsicState img in pool)
			{
				if (img.src == src)
				{
					return img;
				}
			}
			addImage(src);
			return getImage(src);
		}

		public static void addImage(string src)
		{
			pool.Add(new ImageIntrinsicState(src));
		}
	}
}