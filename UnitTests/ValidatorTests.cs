using System;
using NUnit.Framework;
using ShapeLibrary;
using ShapeLibrary.Shapes;

namespace UnitTests
{
	[TestFixture]
	public class ValidatorTests
	{
		[Test]
		public void Main()
		{
			string variableName = "foo";
			string value = "bar";
			string expected = $"ERROR: Invalid {variableName} value: {value}";
			Assert.AreEqual(Validator.generateInvalidValueMsg(variableName, value), expected);

			string errorMsg = "Error encountered!";
			Point p = new Point(1, 2);
			Validator.validateShape(p, errorMsg);
			Assert.Catch <ShapeException> (() => Validator.validateShape(null, errorMsg));

			Validator.validateDouble(1.0, errorMsg);
			Assert.Catch <ShapeException> (() => Validator.validateDouble(Double.NaN, errorMsg));
			Assert.Catch <ShapeException> (() => Validator.validateDouble(Double.PositiveInfinity, errorMsg));

			Validator.validatePositiveDouble(1.0, errorMsg);
			Assert.Catch <ShapeException> (() => Validator.validatePositiveDouble(-1.0, errorMsg));

			Validator.validateTranslate(1.0, 1.0);
			Assert.Catch <ShapeException> (() => Validator.validateTranslate(double.NaN, 1.0));
			Assert.Catch <ShapeException> (() => Validator.validateTranslate(1.0, double.NaN));

			Validator.validateScale(1.0);
			Assert.Catch <ShapeException> (() => Validator.validateScale(-1));
		}
	}
}