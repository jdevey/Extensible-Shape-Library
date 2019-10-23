using NUnit.Framework;
using ShapeLibrary.Shapes;

namespace UnitTests
{
	[TestFixture]
	public class ShapeTests
	{
		[Test]
		public void Main()
		{
			const string pathp = @"C:\Users\devey\Code\Dump\shitHole\remote_filedump\my_point.xml";
			const string pathln = @"C:\Users\devey\Code\Dump\shitHole\remote_filedump\my_line.xml";
			const string patht = @"C:\Users\devey\Code\Dump\shitHole\remote_filedump\my_tri.xml";
			const string pathcirc = @"C:\Users\devey\Code\Dump\shitHole\remote_filedump\my_circ.xml";
			const string pathc = @"C:\Users\devey\Code\Dump\shitHole\remote_filedump\my_comp.xml";
			const string topcomp = @"C:\Users\devey\Code\Dump\shitHole\remote_filedump\topcomp.xml";
			const string path2 = @"my_point.xml";
			const string path3 = @"my_tri.xml";
			Point p1 = new Point(13, 22);
			p1.save(pathp);
			Point p2 = Shape.load(pathp, typeof(Point)) as Point;
			Assert.AreEqual(p1.x, p2.x);
			Assert.AreEqual(p1.y, p2.y);
			
			Line l1 = new Line(new Point(3, 4), new Point(5, 6));
			l1.save(pathln);
			Line l2 = Shape.load(pathln, typeof(Line)) as Line;
			Assert.AreEqual(l1.point1.x, l2.point1.x);
			Assert.AreEqual(l1.point2.x, l2.point2.x);
			Assert.AreEqual(l1.point2.y, l2.point2.y);
			Assert.AreEqual(l1.point2.y, l2.point2.y);

			Circle circ1 = new Circle(new Point(4, 5), 11);
			circ1.save(pathcirc);
			Circle circ2 = Shape.load(pathcirc, typeof(Circle)) as Circle;
			Assert.AreEqual(circ1.center.x, circ2.center.x);
			Assert.AreEqual(circ1.center.y, circ2.center.y);
			Assert.AreEqual(circ1.radius, circ2.radius);

			Triangle t1 = new Triangle(new Point(1, 1), new Point(2, 2), new Point(1, 3));
			t1.save(patht);
			Triangle t2 = Triangle.load(patht, typeof(Triangle)) as Triangle;
			Assert.AreEqual(t1.point1.x, t2.point1.x);
			Assert.AreEqual(t1.point1.y, t2.point1.y);
			Assert.AreEqual(t1.point2.x, t2.point2.x);
			Assert.AreEqual(t1.point2.y, t2.point2.y);
			Assert.AreEqual(t1.point3.x, t2.point3.x);
			Assert.AreEqual(t1.point3.y, t2.point3.y);
			
			Composite c1 = new Composite();
			c1.addShape(p1);
			c1.addShape(circ1);
			c1.save(pathc);
			Composite c2 = Composite.load(pathc, typeof(Composite)) as Composite;
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
			topLayerComp.save(topcomp);
			Composite tlc2 = Composite.load(topcomp, typeof(Composite)) as Composite;
			
			Assert.AreEqual(topLayerPoint.x, (tlc2.children[0] as Point).x);
			Composite bottom1 = tlc2.children[1] as Composite;
			
			Point compPoint3 = (topLayerComp.children[1] as Composite).children[0] as Point;
			Point compPoint4 = bottom1.children[0] as Point;
			Assert.AreEqual(compPoint3.x, compPoint4.x);
			Assert.AreEqual(compPoint3.y, compPoint4.y);
		}
	}
}