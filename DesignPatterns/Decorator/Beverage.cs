using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{

	abstract class Beverage
	{
		public static void Test()
		{
			Beverage beverage1 = new DarkRoast();
			Console.WriteLine(beverage1.GetCost());
			Console.WriteLine(beverage1.GetDescription());

			Beverage beverage2 = new HouseBlend();
			Console.WriteLine(beverage2.GetCost());
			Console.WriteLine(beverage2.GetDescription());
			beverage2 = new Mocha(beverage2);
			Console.WriteLine(beverage2.GetCost());
			Console.WriteLine(beverage2.GetDescription());
			beverage2 = new Milk(beverage2);
			Console.WriteLine(beverage2.GetCost());
			Console.WriteLine(beverage2.GetDescription());
		}

		public virtual string GetDescription()
		{
			return "Beverage";
		}

		public abstract int GetCost();
	}

	class HouseBlend : Beverage
	{
		public override int GetCost()
		{
			return 5;
		}

		public override string GetDescription()
		{
			return base.GetDescription() + "House Blend";
		}
	}

	class DarkRoast : Beverage
	{
		public override string GetDescription()
		{
			return base.GetDescription() + "Dark Roast";
		}

		public override int GetCost()
		{
			return 7;
		}
	}

	abstract class CondimentDecorator : Beverage
	{
		public override abstract string GetDescription();
	}

	class Milk : CondimentDecorator
	{
		private Beverage beverage;

		public Milk(Beverage beverage)
		{
			this.beverage = beverage;
		}

		public override int GetCost()
		{
			return beverage.GetCost() + 2;
		}

		public override string GetDescription()
		{
			return beverage.GetDescription() + " Milk";
		}
	}

	class Mocha : CondimentDecorator
	{
		private Beverage beverage;

		public Mocha(Beverage beverage)
		{
			this.beverage = beverage;
		}

		public override int GetCost()
		{
			return beverage.GetCost() + 4;
		}

		public override string GetDescription()
		{
			return beverage.GetDescription() + " Mocha";
		}
	}
}
