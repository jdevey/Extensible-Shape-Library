using NUnit.Framework;
using ShapeLibrary.Shapes;

namespace UnitTests
{
	[TestFixture]
	public class Tests
	{
		[Test]
		public void Main()
		{
			Circle c = new Circle(new Point(1.0, 1.0), 1.0);
			Assert.AreEqual(c.radius, 1.0);
		}
	}
}