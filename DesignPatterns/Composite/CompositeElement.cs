using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Composite
{
	class CompositeElement : DrawingElement
	{
		private List<DrawingElement> elements = new List<DrawingElement>();

		public CompositeElement(string name) : base(name)
		{
		}

		public override void Add(DrawingElement d)
		{
			elements.Add(d);
		}

		public override void Display(int indent)
		{
			Console.WriteLine(new string('-', indent) +
			"+ " + name);
			
			foreach (DrawingElement d in elements)
			{
				d.Display(indent + 2);
			}
		}
		
		public override void Remove(DrawingElement d)
		{
			elements.Remove(d);
		}
	}

	abstract class DrawingElement
	{
		protected string name;

		public DrawingElement(string name)
		{
			this.name = name;
		}

		public abstract void Add(DrawingElement d);
		public abstract void Remove(DrawingElement d);
		public abstract void Display(int indent);
	}

	class PrimitiveElement : DrawingElement
	{
		public PrimitiveElement(string name) : base(name)
		{
		}

		public override void Add(DrawingElement d)
		{
			Console.WriteLine("Cannot add to a Primitive Element");
			throw new InvalidOperationException();
		}

		public override void Display(int indent)
		{
			Console.WriteLine(new string('-', indent) + " " + name);
		}

		public override void Remove(DrawingElement d)
		{
			Console.WriteLine("Cannot remove from a Primitive Element");
			throw new InvalidOperationException();
		}
	}

	class Test
	{
		public static void Simulate()
		{
			CompositeElement root = new CompositeElement("Picture");
			root.Add(new PrimitiveElement("Red Line"));
			root.Add(new PrimitiveElement("Blue Circle"));
			root.Add(new PrimitiveElement("Green Box"));

			CompositeElement comp =	new CompositeElement("Two Circles");
			comp.Add(new PrimitiveElement("Black Circle"));
			comp.Add(new PrimitiveElement("White Circle"));

			root.Add(comp);
		}
	}
	





















}
