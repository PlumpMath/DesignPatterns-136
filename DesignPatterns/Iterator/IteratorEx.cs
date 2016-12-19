using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Iterator
{
	/// <summary>
	/// Provide a way to access the elements of an aggregate object sequentially 
	/// without exposing its underlying representation.
	/// </summary>
	class IteratorEx
	{

	}

	interface IIterator
	{
		bool HasNext();
		object Next();
	}

	interface IContainer
	{
		IIterator GetItarator();
	}

	class NameRepository : IContainer
	{
		private string[] names = { "samo", "buse", "ilknur", "mehmet" };

		public IIterator GetItarator()
		{
			return new NameRepositoryIterator(this);
		}

		public string[] GetNames()
		{
			return names;
		}
	}

	class NameRepositoryIterator : IIterator
	{
		private string[] _names;
		private int index = 0;

		public NameRepositoryIterator(NameRepository nameRepository)
		{
			_names = nameRepository.GetNames();
		}

		public bool HasNext()
		{
			return index < _names.Length;
		}

		public object Next()
		{
			if (HasNext())
			{
				return _names[index++];
			}
			return null;
		}
	}
}
