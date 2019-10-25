using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace ShapeLibrary.Shapes
{
	public class Composite : Shape
	{
		public List<Shape> children { get; }

		public Composite()
		{
			++keyCounter;
			children = new List<Shape>();
		}

		public override void translate(double dx, double dy)
		{
			foreach (Shape child in children)
			{
				child.translate(dx, dy);
			}
		}

		public override void scale(double delta)
		{
			foreach (Shape child in children)
			{
				child.scale(delta);
			}
		}

		public override double getArea()
		{
			double childSum = 0.0;
			foreach (Shape child in children)
			{
				childSum += child.getArea();
			}

			return childSum;
		}

		public void addShape(Shape shape)
		{
			Validator.validateShape(shape,
				Validator.generateInvalidValueMsg("shape", shape));
			children.Add(shape);
		}

		public void eraseShape(uint id)
		{
			Shape found = children.Single(i => i.shapeId == id);
			children.Remove(found);
		}

		public void eraseAllShapes()
		{
			children.Clear();
		}
		
		public override void render(Graphics graphics)
		{
			foreach (Shape child in children)
			{
				child.render(graphics);
			}
		}

		public override void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement(nameof(children));
			foreach (Shape child in children)
			{
				writer.WriteStartElement(child.GetType().ToString());
				child.WriteXml(writer);
				writer.WriteEndElement();
			}

			writer.WriteEndElement();
		}

		public override void ReadXml(XmlReader reader)
		{
			reader.ReadStartElement();
			reader.ReadStartElement();
			
			while (reader.NodeType != XmlNodeType.EndElement)
			{
				Shape shape = Assembly.GetExecutingAssembly().CreateInstance(reader.Name) as Shape;
				shape.ReadXml(reader);
				children.Add(shape);
			}
			
			reader.ReadEndElement();
			reader.ReadEndElement();
		}
	}
}