namespace ShapeLibrary
{
	public class Point : Shape
	{
		public double x { get; private set; }
		public double y { get; private set; }

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

		public void save()
		{
		}

		public void load()
		{
		}

		public void render()
		{
		}

		public Point copy()
		{
			return new Point(x, y);
		}
	}
}