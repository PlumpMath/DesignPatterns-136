using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryMethod
{
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
		Urban
	}
}
