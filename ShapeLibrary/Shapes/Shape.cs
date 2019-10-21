namespace ShapeLibrary.Shapes
{
	public abstract class Shape
	{
		protected static uint keyCounter = 0;
		public readonly uint shapeId = keyCounter;
		
		public abstract void translate(double dx, double dy);
		
		// Scale any shape by a multiplier. For example, giving a value of 3
		// expands a shape in all directions about its center three-fold.
		public abstract void scale(double delta);
		
		public abstract double getArea();
		// void save();
		// void load();
		// void render();
		// void getParentRef(); // ?
	}
}