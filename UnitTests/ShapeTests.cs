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
			const string path = @"C:\Users\devey\Code\Dump\shitHole\remote_filedump\my_point.xml";
			const string patht = @"C:\Users\devey\Code\Dump\shitHole\remote_filedump\my_tri.xml";
			const string pathc = @"C:\Users\devey\Code\Dump\shitHole\remote_filedump\my_comp.xml";
			const string path2 = @"my_point.xml";
			const string path3 = @"my_tri.xml";
			Point p1 = new Point(13, 22);
			p1.save(path2);
			Point p2 = Shape.load(path2, typeof(Point)) as Point;
			Assert.AreEqual(p1.x, p2.x);
			Assert.AreEqual(p1.y, p2.y);
			
			Triangle t1 = new Triangle(new Point(1, 1), new Point(2, 2), new Point(1, 3));
			t1.save(patht);
			Triangle t2 = Triangle.load(patht, typeof(Triangle)) as Triangle;
			Assert.AreEqual(t1.point1.x, t2.point1.x);
			
			Composite c1 = new Composite();
			c1.addShape(p1);
			c1.addShape(t1);
			c1.save(pathc);
			Composite c2 = Composite.load(pathc, typeof(Composite)) as Composite;
			Assert.AreEqual((c1.children[0] as Point).x, (c2.children[0] as Point).x);
		}
	}
}