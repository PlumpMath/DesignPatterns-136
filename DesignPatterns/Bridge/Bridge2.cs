using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Bridge
{
	class Bridge2
	{
	}

	//abstractions
	abstract class Color
	{
		public abstract string GetColor();
	}

	class Red : Color
	{
		public override string GetColor()
		{
			return "Red";
		}
	}

	class Blue : Color
	{
		public override string GetColor()
		{
			return "Blue";
		}
	}

	class Purple : Color
	{
		public override string GetColor()
		{
			return "Purple";
		}
	}

	//implementations
	abstract class DrawingShape
	{
		protected Color color;

		public DrawingShape(Color color)
		{
			this.color = color;
		}

		public abstract Color GetColor();
		public abstract string GetShape();
	}

	class Rectangle : DrawingShape
	{
		public Rectangle(Color color) : base(color)
		{
		}

		public override Color GetColor()
		{
			return color;
		}

		public override string GetShape()
		{
			return "Rectangle";
		}
	}

	class Triangle : DrawingShape
	{
		public Triangle(Color color) : base(color)
		{
		}

		public override Color GetColor()
		{
			return color;
		}

		public override string GetShape()
		{
			return "Triangle";
		}
	}

	class Circle : DrawingShape
	{
		public Circle(Color color) : base(color)
		{
		}

		public override Color GetColor()
		{
			return color;
		}

		public override string GetShape()
		{
			throw new NotImplementedException();
		}
	}


}
