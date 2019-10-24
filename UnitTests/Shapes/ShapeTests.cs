using System.Drawing;
using NUnit.Framework;
using ShapeLibrary;
using ShapeLibrary.Shapes;
using Point = ShapeLibrary.Shapes.Point;

namespace UnitTests.Shapes
{
	[TestFixture]
	public class ShapeTests
	{
		[Test]
		public void Main()
		{
			string xmlPath = TestConstants.XML_OUTPUT_FULL + TestConstants.SHAPE_POINT_XML;
			Point p1 = new Point(13, 22);
			p1.save(xmlPath);
			Point p2 = Shape.load(xmlPath, typeof(Point)) as Point;
			Assert.AreEqual(p1.x, p2.x);
			Assert.AreEqual(p1.y, p2.y);

			string pngPath = TestConstants.PNG_OUTPUT_FULL + TestConstants.SHAPE_POINT_PNG;
			GraphicsWrapper gw = new GraphicsWrapper();
			Graphics graphics = gw.graphics;
			p1.render(graphics);
			p1.translate(100, 100);
			Assert.AreEqual(p1.x, 113);
			Assert.AreEqual(p1.y, 122);
			p1.render(graphics);
			gw.saveToFile(pngPath);

			Point p3 = p1.copy();
			p3.scale(100);
			Assert.AreEqual(p1.x, p3.x);
			Assert.AreEqual(p1.y, p3.y);
			Assert.AreEqual(p3.getArea(), 0);
			
			Assert.IsNull(p1.GetSchema());
		}
	}
}