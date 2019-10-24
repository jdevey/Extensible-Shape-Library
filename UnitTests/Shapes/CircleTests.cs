using System.Drawing;
using NUnit.Framework;
using ShapeLibrary;
using ShapeLibrary.Shapes;
using Point = ShapeLibrary.Shapes.Point;

namespace UnitTests.Shapes
{
	[TestFixture]
	public class CircleTests
	{
		[Test]
		public void Main()
		{
			string xmlPath = TestConstants.XML_OUTPUT_FULL + TestConstants.CIRCLE_XML;
			Circle circ1 = new Circle(new Point(100, 150), 50);
			circ1.save(xmlPath);
			Circle circ2 = Shape.load(xmlPath, typeof(Circle)) as Circle;
			Assert.AreEqual(circ1.center.x, circ2.center.x);
			Assert.AreEqual(circ1.center.y, circ2.center.y);
			Assert.AreEqual(circ1.radius, circ2.radius);
			
			string pngPath = TestConstants.PNG_OUTPUT_FULL + TestConstants.CIRCLE_PNG;
			GraphicsWrapper gw = new GraphicsWrapper();
			Graphics graphics = gw.graphics;
			circ1.render(graphics);
			circ1.translate(100, 100);
			circ1.scale(0.5);
			Assert.AreEqual(circ1.center.x, 200);
			Assert.AreEqual(circ1.center.y, 250);
			Assert.AreEqual(circ1.radius, 25);
			Assert.AreEqual(circ1.getArea(), 1963.4954084936207);
			circ1.render(graphics);
			gw.saveToFile(pngPath);
			
			Circle circ3 = new Circle(1, 2, 3);
			Assert.AreEqual(circ3.center.x, 1);
			Assert.AreEqual(circ3.center.y, 2);
			Assert.AreEqual(circ3.radius, 3);
		}
	}
}