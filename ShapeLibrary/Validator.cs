namespace ShapeLibrary
{
	public class Validator
	{
		public static double ValidateDouble(double value, string errorMessage)
		{
			if (double.IsInfinity(value) || double.IsNaN(value))
				throw new ShapeException(errorMessage);
			return value;
		}

		public static void ValidatePositiveDouble(double value, string errorMessage)
		{
			value = ValidateDouble(value, errorMessage);
			if (value < 0)
				throw new ShapeException(errorMessage);
		}
	}
}