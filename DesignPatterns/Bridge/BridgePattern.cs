using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Bridge
{
	/// <summary>
	/// Decouple an abstraction from its implementation so that the two can vary independently.
	/// </summary>
	class BridgePattern
	{
		public static void Simulate()
		{
			Shape[] shapes = new Shape[]
			{
				new CircleShape(1, 2, 3, new NvidiaDrawingAPI()),
				new CircleShape(5, 3, 4, new AMDDrawingAPI())
			};

			foreach (Shape shape in shapes)
			{
				shape.ResizeByPercentage(2.5);
				shape.Draw();
			}
		}
	}

	//implementor
	interface IDrawingAPI
	{
		void DrawCircle(double x, double y, double radius);
	}

	//concrete implementor
	class NvidiaDrawingAPI : IDrawingAPI
	{
		public void DrawCircle(double x, double y, double radius)
		{
			Console.WriteLine("Nvidia graphics card drawing circle at " + x.ToString()
				+ "-" + y.ToString() + " with radius = " + radius.ToString());
		}
	}

	//another concrete implementor
	class AMDDrawingAPI : IDrawingAPI
	{
		public void DrawCircle(double x, double y, double radius)
		{
			Console.WriteLine("AMD graphics card drawing circle at " + x.ToString()
				+ "-" + y.ToString() + " with radius = " + radius.ToString());
		}
	}

	class IntelDrawingAPI : IDrawingAPI
	{
		public void DrawCircle(double x, double y, double radius)
		{
			Console.WriteLine("Intel graphics card drawing circle at " + x.ToString()
				+ "-" + y.ToString() + " with radius = " + radius.ToString());
		}
	}

	class AppleDrawingAPI : IDrawingAPI
	{
		public void DrawCircle(double x, double y, double radius)
		{
			Console.WriteLine("Apple graphics card drawing circle at " + x.ToString()
				+ "-" + y.ToString() + " with radius = " + radius.ToString());
		}
	}

	//abstraction
	abstract class Shape
	{
		protected IDrawingAPI drawingApi;

		protected Shape(IDrawingAPI drawingApi)
		{
			this.drawingApi = drawingApi;
		}

		//low - level
		public abstract void Draw();
		//high - level
		public abstract void ResizeByPercentage(double pct);
	}

	class CircleShape : Shape
	{
		private double x, y, radius;


		public CircleShape(double x, double y, double radius, IDrawingAPI drawingApi) : base(drawingApi)
		{
			this.x = x;
			this.y = y;
			this.radius = radius;
		}

		//low level (implementation specific)
		public override void Draw()
		{
			drawingApi.DrawCircle(x, y, radius);
		}

		//high level (abstraction specific)
		public override void ResizeByPercentage(double pct)
		{
			radius *= (1.0 + pct / 100.0);
		}
	}
	
}
