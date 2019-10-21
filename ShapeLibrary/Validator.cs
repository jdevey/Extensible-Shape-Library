using System;
using ShapeLibrary.Shapes;

namespace ShapeLibrary
{
	public static class Validator
	{
		public static string generateInvalidValueMsg<T>(string variableName, T value)
		{
			return $"ERROR: Invalid {variableName} value: {value}";
		}

		public static void validateShape(Shape shape, string errorMessage)
		{
			if (shape == null)
			{
				throw new ShapeException(errorMessage);
			}
		}

		public static void validateDouble(double value, string errorMessage)
		{
			if (double.IsInfinity(value) || double.IsNaN(value))
			{
				throw new ShapeException(errorMessage);
			}
		}

		public static void validatePositiveDouble(double value, string errorMessage)
		{
			validateDouble(value, errorMessage);
			if (value < 0)
			{
				throw new ShapeException(errorMessage);
			}
		}

		public static void validateTranslate(double dx, double dy)
		{
			validateDouble(dx,
				generateInvalidValueMsg("delta-x", dx));
			validateDouble(dy,
				generateInvalidValueMsg("delta-y", dy));
		}

		public static void validateScale(double delta)
		{
			validatePositiveDouble(delta,
				generateInvalidValueMsg("delta", delta));
		}
	}
}