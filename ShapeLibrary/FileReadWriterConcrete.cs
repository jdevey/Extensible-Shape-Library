using System.IO;
using System.Text;

namespace ShapeLibrary
{
	public class FileReadWriterConcrete : FileReadWriter
	{
		public Stream read(string shapefileName)
		{
			return File.Exists(shapefileName) ? File.OpenRead(shapefileName) : null;
		}

		public void write(string shapefileName, Stream shapeData)
		{
			if (File.Exists(shapefileName))
			{
				File.Delete(shapefileName);
			}
			FileStream newFile = File.Create(shapefileName);
			byte[] data = new byte[1024];
			shapeData.Read(data, 0, data.Length);
			newFile.Write(data, 0, data.Length);
		}
	}
}