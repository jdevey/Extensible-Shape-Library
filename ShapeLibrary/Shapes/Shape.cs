using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ShapeLibrary.Shapes
{
	public abstract class Shape : IXmlSerializable
	{
		protected static uint keyCounter = 0;
		public readonly uint shapeId = keyCounter;
		
		public abstract void translate(double dx, double dy);
		
		// Scale any shape by a multiplier. For example, giving a value of 3
		// expands a shape in all directions about its center three-fold.
		public abstract void scale(double delta);
		
		public abstract double getArea();

		public void save(string fileName)
		{
			FileReadWriterConcrete fileReadWriterConcrete= new FileReadWriterConcrete();
			fileReadWriterConcrete.writeFromShape(fileName, this);
		}

		public static Shape load(string fileName, Type expectedType)
		{
			ShapeFactoryConcrete shapeFactoryConcrete = new ShapeFactoryConcrete();
			return shapeFactoryConcrete.getShape(fileName, expectedType);
		}
		
		// void render(); // TODO

		public abstract void WriteXml(XmlWriter writer);

		public abstract void ReadXml(XmlReader reader);

		public XmlSchema GetSchema()
		{
			return null;
		}
	}
}