using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//composite from decorator
namespace DesignPatterns.Decorator
{

	abstract class Beverage
	{
		public static void Test()
		{

			/*	
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
			*/

			Beverage doubleMilk = new CondimentComposite();

			doubleMilk.Add(new Milk());
			doubleMilk.Add(new Milk());

			Console.WriteLine(doubleMilk.GetDescription());
			Console.WriteLine(doubleMilk.GetCost());

			Beverage doubleHouseBlend = new CondimentComposite();
			doubleHouseBlend.Add(new HouseBlend());
			doubleHouseBlend.Add(new HouseBlend());

			Console.WriteLine(doubleHouseBlend.GetDescription());
			Console.WriteLine(doubleHouseBlend.GetCost());

			Beverage superMix = doubleMilk;
			superMix.Add(doubleHouseBlend);

			Console.WriteLine("Super Mix");
			Console.WriteLine("---------------");
			Console.WriteLine(superMix.GetDescription());
			Console.WriteLine(superMix.GetCost());


		}
		abstract public void Add(Beverage b);
		abstract public void Remove(Beverage b);


		public virtual string GetDescription()
		{
			return "Beverage";
		}

		public abstract int GetCost();
	}

	class HouseBlend : Beverage
	{
		public override void Add(Beverage b)
		{
			throw new NotImplementedException();
		}

		public override int GetCost()
		{
			return 5;
		}

		public override string GetDescription()
		{
			return base.GetDescription() + "House Blend";
		}

		public override void Remove(Beverage b)
		{
			throw new NotImplementedException();
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

		public override void Add(Beverage b)
		{
			throw new NotImplementedException();
		}

		public override void Remove(Beverage b)
		{
			throw new NotImplementedException();
		}
	}

	class CondimentComposite : Beverage
	{
		private List<Beverage> beverages = new List<Beverage>();

		public override int GetCost()
		{
			int total = 0;

			foreach (var item in beverages)
			{
				total += item.GetCost();
			}

			return total;
		}

		public override string GetDescription()
		{
			string ret = "";

			foreach (var item in beverages)
			{
				ret += item.GetDescription() + "-";
			}

			return ret;
		}



		public override void Add(Beverage b)
		{
			beverages.Add(b);
		}

		public override void Remove(Beverage b)
		{
			beverages.Remove(b);
		}
	}

	class Milk : Beverage
	{
		public override void Add(Beverage b)
		{
			throw new NotImplementedException();
		}

		public override int GetCost()
		{
			return 2;
		}

		public override string GetDescription()
		{
			return " Milk";
		}

		public override void Remove(Beverage b)
		{
			throw new NotImplementedException();
		}
	}

	class Mocha : Beverage
	{
		public override void Add(Beverage b)
		{
			throw new NotImplementedException();
		}

		public override int GetCost()
		{
			return 4;
		}

		public override string GetDescription()
		{
			return " Mocha";
		}

		public override void Remove(Beverage b)
		{
			throw new NotImplementedException();
		}
	}
}
