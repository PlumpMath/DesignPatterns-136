using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.InheritingAdapter
{
	class FrenchPersonAdapter : Person, IFrenchPerson
	{
		public string GetNom()
		{
			return base.GetName();
		}
	}

	interface IPerson
	{
		string GetName();
	}

	interface IFrenchPerson
	{
		string GetNom();
	}

	class FrenchPerson : IFrenchPerson
	{
		public string GetNom()
		{
			return "Nom";
		}
	}

	class Person : IPerson
	{
		public string GetName()
		{
			return "Name";
		}
	}

	class PersonService
	{
		public static void PrintName(IPerson person)
		{
			Console.WriteLine(person.GetName());
		}
	}
}
