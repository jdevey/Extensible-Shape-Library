using System.Drawing;
using NUnit.Framework;
using ShapeLibrary;
using ShapeLibrary.Shapes;
using Point = ShapeLibrary.Shapes.Point;
using Rectangle = ShapeLibrary.Shapes.Rectangle;

namespace UnitTests.Shapes
{
	[TestFixture]
	public class RectangleTests
	{
		[Test]
		public void Main()
		{
			string xmlPath = TestConstants.XML_OUTPUT_FULL + TestConstants.RECTANGLE_XML;
			Rectangle r1 = new Rectangle(new Point(50, 100), new Point(100, 150));
			r1.save(xmlPath);
			Rectangle r2 = Shape.load(xmlPath, typeof(Rectangle)) as Rectangle;
			Assert.AreEqual(r1.point1.x, r2.point1.x);
			Assert.AreEqual(r1.point2.x, r2.point2.x);
			Assert.AreEqual(r1.point2.y, r2.point2.y);
			Assert.AreEqual(r1.point2.y, r2.point2.y);
			
			string pngPath = TestConstants.PNG_OUTPUT_FULL + TestConstants.RECTANGLE_PNG;
			GraphicsWrapper gw = new GraphicsWrapper();
			Graphics graphics = gw.graphics;
			r1.render(graphics);
			r1.translate(100, 100);
			r1.scale(2);
			Assert.AreEqual(r1.point1.x, 125);
			Assert.AreEqual(r1.point1.y, 175);
			Assert.AreEqual(r1.point2.x, 225);
			Assert.AreEqual(r1.point2.y, 275);
			Assert.AreEqual(r1.getArea(), 10000);
			r1.render(graphics);
			gw.saveToFile(pngPath);
		}
	}
}