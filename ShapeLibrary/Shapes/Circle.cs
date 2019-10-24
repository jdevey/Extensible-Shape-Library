using System;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;

namespace ShapeLibrary.Shapes
{
	public class Circle : Shape
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
		
		public override void render(Graphics graphics)
		{
			graphics.DrawEllipse(Constants.bluePen,
				(int)(center.x - radius), 
				(int)(center.y - radius), 
				(int)radius * 2, 
				(int)radius * 2);
		}
		
		public override void WriteXml (XmlWriter writer)
		{
			writer.WriteStartElement(nameof(center));
			center.WriteXml(writer);
			writer.WriteEndElement();
			
			writer.WriteStartElement(nameof(radius));
			writer.WriteValue(radius);
			writer.WriteEndElement();
		}

		public override void ReadXml (XmlReader reader)
		{
			reader.ReadStartElement();
			
			Point ctr = new Point();
			ctr.ReadXml(reader);
			center = ctr;

			radius = double.Parse(reader.ReadInnerXml());
			
			reader.ReadEndElement();
		}
	}
}