using NUnit.Framework;
using ShapeLibrary;

namespace UnitTests
{
	[TestFixture]
	public class UtilsTests
	{
		[Test]
		public void Main()
		{
			Assert.AreEqual(Utils.pythagorean(0.0, 0.0, 3.0, 4.0), 5.0);
		}
	}
}