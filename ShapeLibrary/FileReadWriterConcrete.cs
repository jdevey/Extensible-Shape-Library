using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using ShapeLibrary.Shapes;

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

			shapeData.Position = 0;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(shapeData);
			xmlDocument.Save(shapefileName);
		}

		public void writeFromShape(string shapeFileName, Shape shape)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(shape.GetType());
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter streamWriter = new StreamWriter(memoryStream);
			xmlSerializer.Serialize(streamWriter, shape);
			write(shapeFileName, memoryStream);
			streamWriter.Close();
		}
	}
}