using System.Drawing;
using System.Xml;

namespace ShapeLibrary.Shapes
{
	public class Picture : Rectangle
	{
		private Img img;
		// Default constructor for serialization
		public Picture()
		{
			++keyCounter;
		}
		
		// Image, Bitmap, Graphic, Stream
		public Picture(Rectangle rect, string fileName) : base(rect)
		{
			img = ImgPool.getImage(fileName);
			++keyCounter;
		}

		public override void render(Graphics graphics)
		{
			graphics.DrawImage(img.imgStorage, (int)getMinX(), (int)getMinY(), (int)getWidth(), (int)getHeight());
		}
		
		public override void WriteXml (XmlWriter writer)
		{
			writer.WriteStartElement(nameof(img));
			writer.WriteValue(img.src);
			writer.WriteEndElement();
			
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

			string src = reader.ReadInnerXml();
			img = new Img(src);
			
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