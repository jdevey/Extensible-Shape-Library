using System.Collections.Generic;

namespace ShapeLibrary
{
	public class ImagePool
	{
		private static readonly HashSet<ImageIntrinsicState> pool = new HashSet<ImageIntrinsicState>();
//		{
//				new ImageIntrinsicState(Constants.defaultImages[0]),
//				new ImageIntrinsicState(Constants.defaultImages[1]),
//				new ImageIntrinsicState(Constants.defaultImages[2])
//		};

		public static ImageIntrinsicState getImage(string src)
		{
			// return new ImageIntrinsicState(@"C:\Users\devey\Code\School\CS5700\hw3\HW3\ShapeLibrary\SampleImages\tree1.png");
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