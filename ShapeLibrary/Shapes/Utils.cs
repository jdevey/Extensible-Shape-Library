using System;

namespace ShapeLibrary.Shapes
{
	public static class Utils
	{
		public static double pythagorean(double x1, double y1, double x2, double y2)
		{
			double dx = x1 - x2;
			double dy = y1 - y2;
			return Math.Sqrt(dx * dx + dy * dy);
		}
	}
}