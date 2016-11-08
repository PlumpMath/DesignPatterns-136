using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Facade
{
	/// <summary>
	/// Provide a unified interface to a set of interfaces in a subsystem. 
	/// Facade defines a higher-level interface that makes the subsystem easier to use.
	/// </summary>
	class ShapeFacade
	{
		private IShape rectangle;
		private IShape triangle;

		public ShapeFacade()
		{
			rectangle = new Rectangle();
			triangle = new Triangle();
		}

		public void DrawRectangle()
		{
			rectangle.Draw();
		}

		public void DrawTriangle()
		{
			triangle.Draw();
		}
	}

	interface IShape
	{
		void Draw();
	}

	class Rectangle : IShape
	{
		public void Draw()
		{
			Console.WriteLine("Im a Rectangle");
		}
	}

	class Triangle : IShape
	{
		public void Draw()
		{
			Console.WriteLine("Im a Triangle");
		}
	}
}
