using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.OCPrinciple
{
	class AreaCalculator
	{
		public double Area(Shape[] shapes)
		{
			double area = 0;
			foreach (var a in shapes)
			{
				area += a.Area();
			}

			return area;
		}
	}

	abstract class Shape
	{
		public abstract double Area();
	}

	class Square : Shape
	{
		public double Side { get; set; }

		public override double Area()
		{
			return Side * Side;
		}
	}

	class Rectangle : Shape
	{
		public double Width { get; set; }
		public double Height { get; set; }

		public override double Area()
		{
			return Width * Height;
		}
	}

	class Circle : Shape
	{
		public double Radius { get; set; }
		public override double Area()
		{
			return Radius * Radius * Math.PI;
		}
	}


}
