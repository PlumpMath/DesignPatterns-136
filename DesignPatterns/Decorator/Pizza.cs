using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Decorator
namespace DesignPatterns.Decorator
{
	public abstract class Pizza
	{
		protected double price;

		public virtual double GetPrice()
		{
			return price;
		}
	}

	public abstract class ToppingsDecorator : Pizza
	{
		protected Pizza pizza;

		public ToppingsDecorator(Pizza pizzaToDecorate)
		{
			pizza = pizzaToDecorate;
		}

		public override double GetPrice()
		{
			return pizza.GetPrice() + price;
		}
	}

	public class Margherita : Pizza
	{
		public Margherita()
		{
			price = 7;
		}
	}

	public class Gourmet : Pizza
	{
		public Gourmet()
		{
			price = 10;
		}
	}

	public class ExtraCheeseTopping : ToppingsDecorator
	{
		public ExtraCheeseTopping(Pizza pizzaToDecorate) : base(pizzaToDecorate)
		{
			price = 1;
		}
	}

	public class JalapenoTopping : ToppingsDecorator
	{
		public JalapenoTopping(Pizza pizzaToDecorate) : base(pizzaToDecorate)
		{
			price = 1.5;
		}
	}

	public class Sim
	{
		public static void Simulate()
		{
			//plain pizza
			Margherita pizza = new Margherita();

			//double extra cheese pizza
			ExtraCheeseTopping moreCheese = new ExtraCheeseTopping(pizza);
			ExtraCheeseTopping someMoreCheese = new ExtraCheeseTopping(moreCheese);

			//double extra jalapeno pizza
			JalapenoTopping moreJalapeno = new JalapenoTopping(someMoreCheese);
			JalapenoTopping someMoreJalapeno = new JalapenoTopping(moreJalapeno);

			Console.WriteLine(someMoreJalapeno.GetPrice());
		}
	}
}
