// https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.json.jsonreaderwriterfactory?view=netframework-4.8
// https://stackoverflow.com/questions/6620165/how-can-i-parse-json-with-c

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using ShapeLibrary.Shapes;

namespace ShapeLibrary
{
	public interface ShapeFactory
	{
		Shape getShape(string fileName, Type expectedType);
	}
}