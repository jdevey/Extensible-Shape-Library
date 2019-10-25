using System.Drawing;
using NUnit.Framework;
using ShapeLibrary;
using ShapeLibrary.Shapes;
using Point = ShapeLibrary.Shapes.Point;

namespace UnitTests.Shapes
{
	[TestFixture]
	public class CompositeTests
	{
		[Test]
		public void Main()
		{
			string xmlPath1 = TestConstants.XML_OUTPUT_FULL + TestConstants.COMPOSITE_XML1;
			string xmlPath2 = TestConstants.XML_OUTPUT_FULL + TestConstants.COMPOSITE_XML2;
			
			Point p1 = new Point(13, 22);
			Circle circ1 = new Circle(new Point(40, 50), 11);

			Composite c1 = new Composite();
			c1.addShape(p1);
			c1.addShape(circ1);
			c1.save(xmlPath1);
			Composite c2 = Composite.load(xmlPath1, typeof(Composite)) as Composite;
			Assert.AreEqual(c1.children.Count, 2);
			Assert.AreEqual(c2.children.Count, 2);
			
			Point compPoint1 = c1.children[0] as Point;
			Point compPoint2 = c2.children[0] as Point;
			Assert.AreEqual(compPoint1.x, compPoint2.x);
			Assert.AreEqual(compPoint1.y, compPoint2.y);
			
			Circle compCircle1 = c1.children[1] as Circle;
			Circle compCircle2 = c1.children[1] as Circle;
			Assert.AreEqual(compCircle1.center.x, compCircle2.center.x);
			Assert.AreEqual(compCircle1.center.y, compCircle2.center.y);
			Assert.AreEqual(compCircle1.radius, compCircle2.radius);
			
			Point topLayerPoint = new Point(100, 101);
			Composite topLayerComp = new Composite();
			topLayerComp.addShape(topLayerPoint);
			topLayerComp.addShape(c1);
			topLayerComp.save(xmlPath2);
			Composite tlc2 = Composite.load(xmlPath2, typeof(Composite)) as Composite;
			
			Assert.AreEqual(topLayerPoint.x, (tlc2.children[0] as Point).x);
			Composite bottom1 = tlc2.children[1] as Composite;
			
			Point compPoint3 = (topLayerComp.children[1] as Composite).children[0] as Point;
			Point compPoint4 = bottom1.children[0] as Point;
			Assert.AreEqual(compPoint3.x, compPoint4.x);
			Assert.AreEqual(compPoint3.y, compPoint4.y);
			
			string pngPath = TestConstants.PNG_OUTPUT_FULL + TestConstants.COMPOSITE_PNG;
			GraphicsWrapper gw = new GraphicsWrapper();
			Graphics graphics = gw.graphics;
			c1.render(graphics);
			c1.translate(100, 100);
			c1.scale(1);
			
			Point cp1 = c1.children[0] as Point;
			Assert.AreEqual(cp1.x, 113);
			Assert.AreEqual(cp1.y, 122);
			
			Assert.AreEqual(c1.getArea(), 380.13271108436493);
			c1.render(graphics);
			gw.saveToFile(pngPath);
			
			Assert.AreEqual(topLayerComp.children.Count, 2);
			topLayerComp.eraseShape(c1.getShapeId());
			Assert.AreEqual(topLayerComp.children.Count, 1);
			topLayerComp.eraseAllShapes();
			Assert.AreEqual(topLayerComp.children.Count, 0);
		}
	}
}