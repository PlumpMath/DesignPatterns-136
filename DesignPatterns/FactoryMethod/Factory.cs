using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryMethod
{
	/// <summary>
	/// Define an interface for creating an object, but let subclasses decide which class to instantiate. 
	/// Factory Method lets a class defer instantiation to subclasses.
	/// </summary>
	class Factory
	{
		public IPeople GetPeople(PeopleType type)
		{
			switch (type)
			{
				case PeopleType.Rural:
				{
					return new Villagers();
				}
				case PeopleType.Urban:
				{
					return new CityPeople();
				}
				case PeopleType.Cave:
				{
					return new CavePeople();
				}
				default:
				{
					throw new NotSupportedException();
				}
			}
		}
	}



	interface IPeople
	{
		string GetName();
	}

	class CavePeople : IPeople
	{
		public string GetName()
		{
			return "Cave Person";
		}
	}

	class Villagers : IPeople
	{
		public string GetName()
		{
			return "Village Person";
		}
	}

	class CityPeople : IPeople
	{
		public string GetName()
		{
			return "City Person";
		}
	}

	enum PeopleType
	{
		Rural,
		Urban,
		Cave
	}
}
