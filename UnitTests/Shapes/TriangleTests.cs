using System.Drawing;
using NUnit.Framework;
using ShapeLibrary;
using ShapeLibrary.Shapes;
using Point = ShapeLibrary.Shapes.Point;

namespace UnitTests.Shapes
{
	[TestFixture]
	public class TriangleTests
	{
		[Test]
		public void Main()
		{
			string xmlPath = TestConstants.XML_OUTPUT_FULL + TestConstants.TRIANGLE_XML;
			Triangle t1 = new Triangle(
				new Point(50, 100),
				new Point(100, 100),
				new Point(100, 50));
			t1.save(xmlPath);
			
			Triangle t2 = Shape.load(xmlPath, typeof(Triangle)) as Triangle;
			Assert.AreEqual(t1.point1.x, t2.point1.x);
			Assert.AreEqual(t1.point2.x, t2.point2.x);
			Assert.AreEqual(t1.point2.y, t2.point2.y);
			Assert.AreEqual(t1.point2.y, t2.point2.y);
			Assert.AreEqual(t1.point3.y, t2.point3.y);
			Assert.AreEqual(t1.point3.y, t2.point3.y);
			
			string pngPath = TestConstants.PNG_OUTPUT_FULL + TestConstants.TRIANGLE_PNG;
			GraphicsWrapper gw = new GraphicsWrapper();
			Graphics graphics = gw.graphics;
			t1.render(graphics);
			t1.translate(100, 100);
			t1.scale(2);
			Assert.AreEqual(t1.point1.x, 116.66666666666666d);
			Assert.AreEqual(t1.point1.y, 216.66666666666666d);
			Assert.AreEqual(t1.point2.x, 216.66666666666666d);
			Assert.AreEqual(t1.point2.y, 216.66666666666666d);
			Assert.AreEqual(t1.point3.x, 216.66666666666666d);
			Assert.AreEqual(t1.point3.y, 116.66666666666666d);
			Assert.AreEqual(t1.getArea(), 5000);
			t1.render(graphics);
			gw.saveToFile(pngPath);
		}
	}
}