using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Adapter
{
	class FrenchPersonAdapter : IPerson
	{
		private readonly IFrenchPerson frenchPerson;

		public FrenchPersonAdapter(IFrenchPerson frenchPerson)
		{
			this.frenchPerson = frenchPerson;
		}

		public string GetName()
		{
			return frenchPerson.GetNom();
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
