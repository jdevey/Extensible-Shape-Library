using System.Drawing;
using NUnit.Framework;
using ShapeLibrary;
using ShapeLibrary.Shapes;
using Point = ShapeLibrary.Shapes.Point;

namespace UnitTests.Shapes
{
	[TestFixture]
	public class LineTests
	{
		[Test]
		public void Main()
		{
			string xmlPath = TestConstants.XML_OUTPUT_FULL + TestConstants.LINE_XML;
			Line l1 = new Line(new Point(50, 100), new Point(100, 100));
			l1.save(xmlPath);
			Line l2 = Shape.load(xmlPath, typeof(Line)) as Line;
			Assert.AreEqual(l1.point1.x, l2.point1.x);
			Assert.AreEqual(l1.point2.x, l2.point2.x);
			Assert.AreEqual(l1.point2.y, l2.point2.y);
			Assert.AreEqual(l1.point2.y, l2.point2.y);
			
			string pngPath = TestConstants.PNG_OUTPUT_FULL + TestConstants.LINE_PNG;
			GraphicsWrapper gw = new GraphicsWrapper();
			Graphics graphics = gw.graphics;
			l1.render(graphics);
			l1.translate(100, 100);
			l1.scale(2);
			Assert.AreEqual(l1.point1.x, 125);
			Assert.AreEqual(l1.point1.y, 200);
			Assert.AreEqual(l1.point2.x, 225);
			Assert.AreEqual(l1.point2.y, 200);
			Assert.AreEqual(l1.getArea(), 0);
			l1.render(graphics);
			gw.saveToFile(pngPath);

		}
	}
}