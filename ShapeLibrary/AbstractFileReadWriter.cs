using System.IO;
using ShapeLibrary.Shapes;

namespace ShapeLibrary
{
	public interface AbstractFileReadWriter
	{
		Stream read(string shapeFileName);
		
		void write(string shapeFileName, Stream shapeData);
	}
}