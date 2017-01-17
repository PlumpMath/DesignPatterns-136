using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.MVC
{
	class DuckSimulator
	{
		void Simulate(AbstractDuckFactory duckFactory)
		{
			IQuackable redheadDuck = duckFactory.CreateRedHeadDuck();
			IQuackable greenDuck = duckFactory.CreateGreenDuck();
			IQuackable mallard = duckFactory.CreateMallard();

			Flock flockOfDucks = new Flock();

			flockOfDucks.Add(redheadDuck);
			flockOfDucks.Add(greenDuck);
			flockOfDucks.Add(mallard);

			flockOfDucks.Quack();
		}
	}

	public interface IQuackable
	{
		void Quack();
	}

	class Mallard : IQuackable
	{
		public void Quack()
		{
			Console.WriteLine("Mallard Quacking");
		}
	}

	class RedHeadDuck : IQuackable
	{
		public void Quack()
		{
			Console.WriteLine("Red head duck Quacking");
		}
	}

	class GreenDuck : IQuackable
	{
		public void Quack()
		{
			Console.WriteLine("Green duck Quacking");
		}
	}


	#region Adapter Pattern
	
	class Goose
	{
		public void Honk()
		{
			Console.WriteLine("Goose Honking");
		}
	}

	class GooseAdapter : IQuackable
	{
		private Goose goose;

		public GooseAdapter(Goose goose)
		{
			if(goose != null)
			{
				this.goose = goose;
			}
		}

		public void Quack()
		{
			goose.Honk();
		}
	}
	#endregion

	#region Decorator Pattern

	class QuackCounterDecorator : IQuackable
	{
		private static int _quackCount = 0;
		private IQuackable _quackable;

		public QuackCounterDecorator(IQuackable q)
		{
			if(q != null)
			{
				_quackable = q;
			}
		}
		
		public void Quack()
		{
			_quackable.Quack();
			_quackCount++;
		}

		public static int GetQuackCount()
		{
			return _quackCount;
		}
	}

	#endregion

	#region Abstract Factory Pattern

	public abstract class AbstractDuckFactory
	{
		public abstract IQuackable CreateMallard();
		public abstract IQuackable CreateRedHeadDuck();
		public abstract IQuackable CreateGreenDuck();
	}

	class DuckFactory : AbstractDuckFactory
	{
		public override IQuackable CreateGreenDuck()
		{
			return new GreenDuck();
		}

		public override IQuackable CreateMallard()
		{
			return new Mallard();
		}

		public override IQuackable CreateRedHeadDuck()
		{
			return new RedHeadDuck();
		}
	}

	class CountingDuckFactory : AbstractDuckFactory
	{
		public override IQuackable CreateGreenDuck()
		{
			return new QuackCounterDecorator(new GreenDuck());
		}

		public override IQuackable CreateMallard()
		{
			return new QuackCounterDecorator(new Mallard());
		}

		public override IQuackable CreateRedHeadDuck()
		{
			return new QuackCounterDecorator(new RedHeadDuck());
		}
	}

	#endregion

	#region Composite Pattern

	class Flock : IQuackable
	{
		private List<IQuackable> _quackables = new List<IQuackable>();

		public void Add(IQuackable q)
		{
			if(q != null)
			{
				_quackables.Add(q);
			}
		}

		public void Remove(IQuackable q)
		{
			if(q != null && _quackables.Contains(q))
			{
				_quackables.Remove(q);
			}
		}

		public void Quack()
		{
			foreach (var item in _quackables)
			{
				item.Quack();
			}
		}
	}

	#endregion
}
