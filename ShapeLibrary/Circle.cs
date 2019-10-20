using System;

namespace ShapeLibrary
{
	public class Circle : Shape
	{
		public Point center { get; private set; }
		public double radius { get; private set; }

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
			return Math.PI * Math.Pow(radius, 2);
		}
	}
}