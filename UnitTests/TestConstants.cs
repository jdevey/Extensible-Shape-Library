namespace UnitTests
{
	public static class TestConstants
	{
		public const string IMAGE_DIR = @"ShapeLibrary\SampleImages\";
		private const string PNG_OUTPUT = @"UnitTests\ImageOutput\";
		private const string XML_OUTPUT = @"UnitTests\XmlOutput\";
		
		public static readonly string PNG_OUTPUT_FULL =
			TestUtils.getSolutionDirectory() + PNG_OUTPUT;
		public static readonly string XML_OUTPUT_FULL =
			TestUtils.getSolutionDirectory() + XML_OUTPUT;
		
		public const string CIRCLE_XML = "circle.xml";
		public const string COMPOSITE_XML1 = "composite1.xml";
		public const string COMPOSITE_XML2 = "composite2.xml";
		public const string LINE_XML = "line.xml";
		public const string PICTURE_XML = "picture.xml";
		public const string POINT_XML = "point.xml";
		public const string RECTANGLE_XML = "rectangle.xml";
		public const string SHAPE_POINT_XML = "shapePoint.xml";
		public const string TRIANGLE_XML = "triangle.xml";
		public const string READ_WRITE_TEST_XML = "readWriteTest.xml";
		public const string FACTORY_TEST_XML = "factoryTest.xml";
		
		public const string CIRCLE_PNG = "circle.png";
		public const string COMPOSITE_PNG = "composite.png";
		public const string LINE_PNG = "line.png";
		public const string PICTURE_PNG = "picture.png";
		public const string POINT_PNG = "point.png";
		public const string RECTANGLE_PNG = "rectangle.png";
		public const string SHAPE_POINT_PNG = "shapePoint.png";
		public const string TRIANGLE_PNG = "triangle.png";
	}
}