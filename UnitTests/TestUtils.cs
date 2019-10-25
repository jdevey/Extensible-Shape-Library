using System;
using System.Reflection;

namespace UnitTests
{
	public static class TestUtils
	{
		private static string getAssemblyLocation()
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