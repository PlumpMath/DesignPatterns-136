using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{

	class ClubbedTroll : TrollDecorator
	{
		public ClubbedTroll(ITroll decorated) : base(decorated)
		{
		}

		public override void Attack()
		{
			base.Attack();
			Console.WriteLine("Troll attacks with a club");
		}

		public override int GetAttackPower()
		{
			return base.GetAttackPower() + 10;
		}
	}

	class TrollDecorator : ITroll
	{
		private ITroll decorated;

		public TrollDecorator(ITroll decorated)
		{
			this.decorated = decorated;
		}
		
		public virtual void Attack()
		{
			decorated.Attack();
		}

		public virtual void FleeBattle()
		{
			decorated.FleeBattle();
		}

		public virtual int GetAttackPower()
		{
			return decorated.GetAttackPower();
		}
	}

	interface ITroll
	{
		void Attack();
		int GetAttackPower();
		void FleeBattle();
	}

	class TrollWarrior : ITroll
	{
		public void Attack()
		{
			Console.WriteLine("Troll warrior attacks");
		}

		public void FleeBattle()
		{
			Console.WriteLine("Troll warrior flees from battle");
		}

		public int GetAttackPower()
		{
			return 20;
		}
	}

	class SimpleTroll : ITroll
	{
		public void Attack()
		{
			Console.WriteLine("Troll attacks");
		}

		public void FleeBattle()
		{
			Console.WriteLine("Troll tries to run away");
		}

		public int GetAttackPower()
		{
			return 10;
		}
	}
}
