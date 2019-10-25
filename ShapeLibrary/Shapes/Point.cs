using System.Drawing;
using System.Xml;

namespace ShapeLibrary.Shapes
{
	public class Point : Shape
	{
		public double x { get; private set; }
		public double y { get; private set; }
		
		// Default constructor for serialization
		public Point()
		{
		}

		public Point(double x, double y)
		{
			Validator.validateDouble(x,
				Validator.generateInvalidValueMsg("x", x));
			Validator.validateDouble(y,
				Validator.generateInvalidValueMsg("y", y));
			this.x = x;
			this.y = y;
			++keyCounter;
		}

		public override void translate(double dx, double dy)
		{
			Validator.validateTranslate(dx, dy);
			x += dx;
			y += dy;
		}

		public override void scale(double delta)
		{
		}

		public override double getArea()
		{
			return 0.0;
		}

		public override void render(Graphics graphics)
		{
			const int radius = 7;
			SolidBrush brush = new SolidBrush(Color.Black);
			graphics.FillEllipse(brush, (int)x - radius, (int)y - radius, radius * 2, radius * 2);
		}

		public Point copy()
		{
			return new Point(x, y);
		}
		
		public override void WriteXml (XmlWriter writer)
		{
			writer.WriteStartElement(nameof(x));
			writer.WriteValue(x);
			writer.WriteEndElement();
			
			writer.WriteStartElement(nameof(y));
			writer.WriteValue(y);
			writer.WriteEndElement();
		}

		public override void ReadXml (XmlReader reader)
		{
			reader.ReadStartElement();
			
			x = double.Parse(reader.ReadInnerXml());
			y = double.Parse(reader.ReadInnerXml());
			
			reader.ReadEndElement();
		}
	}
}