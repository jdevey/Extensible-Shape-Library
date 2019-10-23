namespace ShapeLibrary.Shapes
{
	public class Picture : Rectangle
	{
		// Default constructor for serialization
		public Picture()
		{
			++keyCounter;
		}
		
		// Image, Bitmap, Graphic, Stream
		public Picture(Rectangle rect, string fileName) : base(rect)
		{
			
		}
	}
}