using NUnit.Framework;
using ShapeLibrary.Shapes;

namespace UnitTests.Shapes
{
	[TestFixture]
	public class CircleTests
	{
		[Test]
		public void Main()
		{
			string xmlPath = TestConstants.XML_OUTPUT_FULL + TestConstants.POINT_XML;
			Point p1 = new Point(13, 22);
			p1.save(xmlPath);
			Point p2 = Shape.load(xmlPath, typeof(Point)) as Point;
			Assert.AreEqual(p1.x, p2.x);
			Assert.AreEqual(p1.y, p2.y);
		}
	}
}