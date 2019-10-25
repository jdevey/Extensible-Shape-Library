using NUnit.Framework;
using ShapeLibrary;

namespace UnitTests
{
	[TestFixture]
	public class ShapeExceptionTests
	{
		[Test]
		public void Main()
		{
			string errMsg = "Here's a shape error.";
			try
			{
				throw new ShapeException(errMsg);
			}
			catch (ShapeException se)
			{
				Assert.AreEqual(errMsg, se.Message);
			} 
		}
	}
}