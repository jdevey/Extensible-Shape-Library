using System.Drawing;
using NUnit.Framework;
using ShapeLibrary;

namespace UnitTests
{
	[TestFixture]
	public class ImageIntrinsicStateTests
	{
		[Test]
		public void Main()
		{
			string solDir = TestUtils.getSolutionDirectory();
			
			string file1 = solDir + TestConstants.IMAGE_DIR + Constants.defaultImages[1];
			string file2 = solDir + TestConstants.IMAGE_DIR + Constants.defaultImages[2];
			
			GraphicsWrapper gw = new GraphicsWrapper();
			Graphics graphics = gw.graphics;
			Assert.NotNull(graphics);
			
			ImageIntrinsicState imageIntrinsicState1 = new ImageIntrinsicState(file1);
			ImageIntrinsicState imageIntrinsicState2 = new ImageIntrinsicState(file2);
			Assert.IsTrue(imageIntrinsicState1 < imageIntrinsicState2 == imageIntrinsicState1);
			Assert.IsTrue(imageIntrinsicState1 > imageIntrinsicState2 == imageIntrinsicState2);
		}
	}
}