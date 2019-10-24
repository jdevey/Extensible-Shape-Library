using System.Drawing;
using NUnit.Framework;
using ShapeLibrary;
using ShapeLibrary.Shapes;
using Point = ShapeLibrary.Shapes.Point;

namespace UnitTests
{
	[TestFixture]
	public class GraphicsWrapperTests
	{
		[Test]
		public void Main()
		{
			string pngPath = TestConstants.PNG_OUTPUT_FULL + TestConstants.POINT_PNG;
			Point p1 = new Point(13, 22);
			GraphicsWrapper gw = new GraphicsWrapper();
			Graphics graphics = gw.graphics;
			p1.render(graphics);
			p1.translate(100, 100);
			Assert.AreEqual(p1.x, 113);
			Assert.AreEqual(p1.y, 122);
			p1.render(graphics);
			gw.saveToFile(pngPath);
		}
	}
}