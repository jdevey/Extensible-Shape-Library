using System;
using System.IO;
using System.Xml.Serialization;
using ShapeLibrary.Shapes;

namespace ShapeLibrary
{
	public class ShapeFactoryConcrete : ShapeFactory
	{
		public Shape getShape(string fileName, Type expectedType)
		{
			XmlSerializer xmlDeserializer = new XmlSerializer(expectedType);
			FileReadWriterConcrete fileReadWriterConcrete = new FileReadWriterConcrete();
			FileStream reader = fileReadWriterConcrete.read(fileName) as FileStream;
			return xmlDeserializer.Deserialize(reader) as Shape;
		}		
	}
}