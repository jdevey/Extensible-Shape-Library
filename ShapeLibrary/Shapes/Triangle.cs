using System;
using System.Xml;

namespace ShapeLibrary.Shapes
{
	public class Triangle : Shape
	{
		public Point point1 { get; set; }
		public Point point2 { get; set; }
		public Point point3 { get; set; }
		
		// Default constructor for serialization
		public Triangle()
		{
			++keyCounter;
		}
		
		public Triangle(Point point1, Point point2, Point point3)
		{
			this.point1 = point1;
			this.point2 = point2;
			this.point3 = point3;
			++keyCounter;
		}
		
		public override void translate(double dx, double dy)
		{
			Validator.validateTranslate(dx, dy);
			point1.translate(dx, dy);
			point2.translate(dx, dy);
			point3.translate(dx, dy);
		}
		
		public override void scale(double delta)
		{
			Validator.validateScale(delta);
			Point center = getCenter();
			double point1dx = point1.x - center.x;
			double point1dy = point1.y - center.y;
			double point2dx = point2.x - center.x;
			double point2dy = point2.y - center.y;
			double point3dx = point3.x - center.x;
			double point3dy = point3.y - center.y;
			double newDelta = delta - 1;
			point1.translate(point1dx * newDelta, point1dy * newDelta);
			point2.translate(point2dx * newDelta, point2dy * newDelta);
			point3.translate(point3dx * newDelta, point3dy * newDelta);
		}
		
		// Heron's formula
		public override double getArea()
		{
			double a = Utils.pythagorean(point1.x, point1.y, point2.x, point2.y);
			double b = Utils.pythagorean(point2.x, point2.y, point3.x, point3.y);
			double c = Utils.pythagorean(point3.x, point3.y, point1.x, point1.y);
			double s = (a + b + c) / 2;
			return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
		}

		private Point getCenter()
		{
			return new Point((point1.x + point2.x + point3.x) / 3, (point1.y + point2.y + point3.y) / 3);
		}
		
		public override void WriteXml (XmlWriter writer)
		{
			writer.WriteStartElement(nameof(point1));
			point1.WriteXml(writer);
			writer.WriteEndElement();
			
			writer.WriteStartElement(nameof(point2));
			point2.WriteXml(writer);
			writer.WriteEndElement();
			
			writer.WriteStartElement(nameof(point3));
			point3.WriteXml(writer);
			writer.WriteEndElement();
		}

		public override void ReadXml (XmlReader reader)
		{
			reader.Read();
			Point p1 = new Point();
			p1.ReadXml(reader);
			point1 = p1;

			reader.Read();
			Point p2 = new Point();
			p2.ReadXml(reader);
			point2 = p2;
			
			reader.Read();
			Point p3 = new Point();
			p3.ReadXml(reader);
			point3 = p3;
		}
	}
}