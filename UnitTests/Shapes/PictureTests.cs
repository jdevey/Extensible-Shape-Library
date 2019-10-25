using System.Drawing;
using NUnit.Framework;
using ShapeLibrary;
using ShapeLibrary.Shapes;
using Point = ShapeLibrary.Shapes.Point;
using Rectangle = ShapeLibrary.Shapes.Rectangle;

namespace UnitTests.Shapes
{
	[TestFixture]
	public class PictureTests
	{
		[Test]
		public void Main()
		{
			string solDir = TestUtils.getSolutionDirectory();
			
			string xmlPath = TestConstants.XML_OUTPUT_FULL + TestConstants.PICTURE_XML;
			Rectangle r1 = new Rectangle(new Point( 100, 50), new Point(300, 250));
			Picture p1 = new Picture(r1, solDir + TestConstants.IMAGE_DIR + Constants.defaultImages[0]);
			p1.save(xmlPath);
			Picture p2 = Shape.load(xmlPath, typeof(Picture)) as Picture;
			Assert.AreEqual(p1.intrinsicState.src, p2.intrinsicState.src);
			Assert.AreEqual(p1.point1.x, p2.point1.x);
			Assert.AreEqual(p1.point1.y, p2.point1.y);
			Assert.AreEqual(p1.point2.x, p2.point2.x);
			Assert.AreEqual(p1.point2.y, p2.point2.y);
			
			string pngPath = TestConstants.PNG_OUTPUT_FULL + TestConstants.PICTURE_PNG;
			GraphicsWrapper gw = new GraphicsWrapper();
			Graphics graphics = gw.graphics;
			p1.render(graphics);
			gw.saveToFile(pngPath);
		}	
	}
}