using System.Drawing;
using NUnit.Framework;
using ShapeLibrary;
using ShapeLibrary.Shapes;
using Point = ShapeLibrary.Shapes.Point;
using Rectangle = ShapeLibrary.Shapes.Rectangle;

namespace UnitTests
{
	[TestFixture]
	public class ImageIntrinsicStateTests
	{
		[Test]
		public void Main()
		{
			string solDir = Utils.getSolutionDirectory();
			
			Rectangle r1 = new Rectangle(new Point( 100, 50), new Point(300, 250));
			string file1 = solDir + TestConstants.IMAGE_DIR + Constants.defaultImages[1];
			string file2 = solDir + TestConstants.IMAGE_DIR + Constants.defaultImages[2];
			Picture p1 = new Picture(r1, file1);
			
			GraphicsWrapper gw = new GraphicsWrapper();
			Graphics graphics = gw.graphics;
			
			ImageIntrinsicState imageIntrinsicState1 = new ImageIntrinsicState(file1);
			ImageIntrinsicState imageIntrinsicState2 = new ImageIntrinsicState(file2);
			Assert.IsTrue(imageIntrinsicState1 < imageIntrinsicState2 == imageIntrinsicState1);
			Assert.IsTrue(imageIntrinsicState1 > imageIntrinsicState2 == imageIntrinsicState2);
		}
	}
}