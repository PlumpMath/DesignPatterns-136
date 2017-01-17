using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.State
{
	/// <summary>
	/// Allow an object to alter its behavior when its internal state changes.
	/// </summary>
	class StateEx
	{
	}

	interface IState
	{
		void DoAction(Context context);
	}

	class StartState : IState
	{
		public void DoAction(Context context)
		{
			Console.WriteLine("Player in the Start State");
			context.SetState(this);
		}
	}

	class StopState : IState
	{
		public void DoAction(Context context)
		{
			Console.WriteLine("Player in the Stop State");
			context.SetState(this);
		}
	}

	class Context
	{
		private IState currentState;

		public Context()
		{
			currentState = new StartState();
		}

		public void SetState(IState state)
		{
			currentState = state;
		}

		public IState GetState()
		{
			return currentState;
		}
	}
}
