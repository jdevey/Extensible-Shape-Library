using System;
using System.Reflection;

namespace ShapeLibrary
{
	public static class Utils
	{
		public static double pythagorean(double x1, double y1, double x2, double y2)
		{
			double dx = x1 - x2;
			double dy = y1 - y2;
			return Math.Sqrt(dx * dx + dy * dy);
		}
		
		public static string getAssemblyLocation()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var codebase = new Uri(assembly.CodeBase);
			var path = codebase.LocalPath;
			return path;
		}

		public static string getSolutionDirectory()
		{
			string assemblyDir = getAssemblyLocation();
			const string SOLUTION = "HW3";
			return assemblyDir.Substring(0,
				assemblyDir.IndexOf(SOLUTION, StringComparison.Ordinal) + SOLUTION.Length + 1);
		}
	}
}