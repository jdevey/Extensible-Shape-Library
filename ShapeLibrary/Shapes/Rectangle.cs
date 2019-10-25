using System;
using System.Drawing;
using System.Xml;

namespace ShapeLibrary.Shapes
{
	public class Rectangle : Shape
	{
		public Point point1 { get; protected set; }
		public Point point2 { get; protected set; }

		// Default constructor for serialization
		protected Rectangle()
		{
			++keyCounter;
		}
		
		public Rectangle(Point point1, Point point2)
		{
			this.point1 = point1;
			this.point2 = point2;
			++keyCounter;
		}

		public Rectangle(Rectangle other)
		{
			point1 = other.point1.copy();
			point2 = other.point2.copy();
			++keyCounter;
		}

		public override void translate(double dx, double dy)
		{
			Validator.validateTranslate(dx, dy);
			point1.translate(dx, dy);
			point2.translate(dx, dy);
		}

		public override void scale(double delta)
		{
			Validator.validateScale(delta);
			Point center = getCenter();
			double point1dx = point1.x - center.x;
			double point1dy = point1.y - center.y;
			double point2dx = point2.x - center.x;
			double point2dy = point2.y - center.y;
			double newDelta = delta - 1;
			point1.translate(point1dx * newDelta, point1dy * newDelta);
			point2.translate(point2dx * newDelta, point2dy * newDelta);
		}

		public override double getArea()
		{
			return getWidth() * getHeight();
		}

		private Point getCenter()
		{
			return new Point((point1.x + point2.x) / 2, (point1.y + point2.y) / 2);
		}

		protected double getMinX()
		{
			return Math.Min(point1.x, point2.x);
		}

		protected double getMinY()
		{
			return Math.Min(point1.y, point2.y);
		}

		protected double getWidth()
		{
			return Math.Abs(point1.x - point2.x);
		}

		protected double getHeight()
		{
			return Math.Abs(point1.y - point2.y);
		}
		
		public override void render(Graphics graphics)
		{
			graphics.DrawRectangle(Constants.bluePen,
				(int)getMinX(),
				(int)getMinY(),
				(int)getWidth(),
				(int)getHeight());
		}
		
		public override void WriteXml (XmlWriter writer)
		{
			writer.WriteStartElement(nameof(point1));
			point1.WriteXml(writer);
			writer.WriteEndElement();
			
			writer.WriteStartElement(nameof(point2));
			point2.WriteXml(writer);
			writer.WriteEndElement();
		}
		
		public override void ReadXml (XmlReader reader)
		{
			reader.ReadStartElement();
			
			Point p1 = new Point();
			p1.ReadXml(reader);
			point1 = p1;

			Point p2 = new Point();
			p2.ReadXml(reader);
			point2 = p2;
			
			reader.ReadEndElement();
		}
	}
}