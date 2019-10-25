using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Drawing;

namespace ShapeLibrary.Shapes
{
	public abstract class Shape : IXmlSerializable
	{
		protected static readonly uint[] keyCounter = {0};
		public readonly uint shapeId = initShapeId();
//		public readonly long shapeId = new DateTime().Ticks;

		public bool isChild = false;

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
			ConcreteShapeFactory concreteShapeFactory = new ConcreteShapeFactory();
			return concreteShapeFactory.getShape(fileName, expectedType);
		}

		public abstract void render(Graphics graphics);

		public abstract void WriteXml(XmlWriter writer);

		public abstract void ReadXml(XmlReader reader);

		public XmlSchema GetSchema()
		{
			return null;
		}

//		protected void incrementKey()
//		{
//			lock (keyCounter)
//			{
//				++keyCounter[0];
//			}
//		}

		private static uint initShapeId()
		{
			lock (keyCounter)
			{
				return keyCounter[0]++;
			}
		}
		
		public uint getShapeId()
		{
			return shapeId;
		}
	}
}