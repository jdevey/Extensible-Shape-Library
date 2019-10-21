using System.IO;
using ShapeLibrary.Shapes;

namespace ShapeLibrary
{
	public interface FileReadWriter
	{
		Stream read(string shapeFileName);
		
		void write(string shapeFileName, Stream shapeData);
	}
}