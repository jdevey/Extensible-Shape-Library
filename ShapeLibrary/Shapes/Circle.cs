using System;
using System.Xml;
using System.Xml.Serialization;

namespace ShapeLibrary.Shapes
{
	public class Circle : Shape, IXmlSerializable
	{
		public Point center { get; private set; }
		public double radius { get; private set; }

		// Default constructor for serialization
		public Circle()
		{
			++keyCounter;
		}

		public Circle(double x, double y, double radius)
		{
			Validator.validatePositiveDouble(radius,
				Validator.generateInvalidValueMsg("radius", radius));
			center = new Point(x, y);
			this.radius = radius;
			++keyCounter;
		}

		public Circle(Point center, double radius)
		{
			Validator.validatePositiveDouble(radius,
				Validator.generateInvalidValueMsg("radius", radius));
			this.center = center;
			this.radius = radius;
		}

		public override void translate(double dx, double dy)
		{
			Validator.validateTranslate(dx, dy);
			center.translate(dx, dy);
		}

		public override void scale(double delta)
		{
			Validator.validateScale(delta);
			radius *= delta;
		}

		public override double getArea()
		{
			return Math.PI * radius * radius;
		}
		
		public void WriteXml (XmlWriter writer)
		{
			//writer.WriteString(personName);
		}

		public void ReadXml (XmlReader reader)
		{
			//personName = reader.ReadString();
		}
	}
}