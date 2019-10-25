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
			string solDir = TestUtils.getSolutionDirectory();
			string file1 = solDir + TestConstants.IMAGE_DIR + Constants.defaultImages[0];
			ImageIntrinsicState img1 = ImagePool.getImage(file1);
			
			string file2 = solDir + TestConstants.IMAGE_DIR + Constants.defaultImages[1];
			ImageIntrinsicState img2 = ImagePool.getImage(file2);
			
			string file3 = solDir + TestConstants.IMAGE_DIR + Constants.defaultImages[2];
			ImageIntrinsicState img3 = new ImageIntrinsicState(file3);
			ImagePool.addImage(file3);
			
			Assert.AreEqual(ImagePool.getImage(file3).src, img3.src);
			
			Assert.AreEqual(img1, ImagePool.getImage(file1));
			Assert.AreEqual(img2, ImagePool.getImage(file2));
		}
	}
}