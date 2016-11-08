using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{
	/// <summary>
	/// Attach additional responsibilities to an object dynamically. 
	/// Decorators provide a flexible alternative to subclassing for extending functionality.
	/// </summary>
	abstract class CoffeeDecorator
	{

	}

	interface ICoffee
	{
		double GetCost();
		string GetIngredients();
	}

	class SimpleCoffee : ICoffee
	{
		public double GetCost()
		{
			return 1;
		}

		public string GetIngredients()
		{
			return "Coffee";
		}
	}
}
