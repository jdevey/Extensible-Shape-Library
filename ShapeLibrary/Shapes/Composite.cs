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
			//incrementKey();
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

		private bool isShapeInSubtree(Shape shape, uint baseId)
		{
			if (shape == null)
			{
				return false;
			}
			
			if (shape.getShapeId() == baseId)
			{
				return true;
			}

			foreach (Shape child in children)
			{
				if (child.getShapeId() == baseId)
				{
					return true;
				}
			}

			return false;
		}

		public void addShape(Shape shape)
		{
			Validator.validateShape(shape,
				Validator.generateInvalidValueMsg("shape", shape));
			
			if (!shape.isChild && !isShapeInSubtree(shape, shapeId))
			{
				shape.isChild = true;
				children.Add(shape);
			}
			else
			{
				throw new ShapeException("ERROR: Attempted to add invalid shape to composite.");
			}
		}

		public void eraseShape(uint id)
		{
			Shape found = children.Single(i => i.shapeId == id);
			found.isChild = false;
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