using System;
using ShapeLibrary.Shapes;

namespace ShapeLibrary
{
	public interface ShapeFactory
	{
		Shape getShape(string fileName, Type expectedType);
	}
}