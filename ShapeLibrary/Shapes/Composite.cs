using System.Collections.Generic;
using System.Linq;

namespace ShapeLibrary.Shapes
{
	public class Composite : Shape
	{
		public readonly List<Shape> children = new List<Shape>();

		public Composite()
		{
			++keyCounter;
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

//		private Shape getShapeById(uint id)
//		{
//			foreach (Shape child in children)
//			{
//				if (child.shapeId == id)
//				{
//					return child;
//				}
//			}
//
//			return null;
//		}
	}
}