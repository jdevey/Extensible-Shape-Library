using System;
using System.Runtime.Serialization;

namespace ShapeLibrary.Shapes
{
	public class Line : Shape
	{
		public Point point1 { get; set; }
		public Point point2 { get; set; }

		// Default constructor for serialization
		public Line()
		{
			++keyCounter;
		}

		public Line(double x1, double y1, double x2, double y2)
		{
			point1 = new Point(x1, y1);
			point2 = new Point(x2, y2);
			++keyCounter;
		}

		public Line(Point point1, Point point2)
		{
			this.point1 = point1;
			this.point2 = point2;
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
			return 0.0;
		}

		private Point getCenter()
		{
			return new Point((point1.x + point2.x) / 2, (point1.y + point2.y) / 2);
		}

//        // Computing slope is dangerous
//        public double computeSlope()
//        {
//            return (point2.y - point1.y) / (point2.x - point1.x);
//        }
	}
}