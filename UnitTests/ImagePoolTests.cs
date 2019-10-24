using NUnit.Framework;
using ShapeLibrary;

namespace UnitTests
{
	[TestFixture]
	public class ImagePoolTests
	{
		[Test]
		public void Main()
		{
			string solDir = Utils.getSolutionDirectory();
			string file1 = solDir + TestConstants.IMAGE_DIR + Constants.defaultImages[1];
			ImageIntrinsicState img1 = ImagePool.getImage(file1);
			
			string file2 = solDir + TestConstants.IMAGE_DIR + Constants.defaultImages[2];
			ImageIntrinsicState img2 = ImagePool.getImage(file2);
			
			Assert.AreEqual(img1, ImagePool.getImage(file1));
			Assert.AreEqual(img2, ImagePool.getImage(file2));
		}
	}
}