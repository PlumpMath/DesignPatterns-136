using System;

namespace DesignPatterns.State
{
	class StateContext
	{
		private IWordState myState;

		public StateContext()
		{
			SetState(new StateLowerCase());
		}

		public void SetState(IWordState newState)
		{
			myState = newState;
		}

		public void WriteName(string name)
		{
			myState.WriteName(this, name);
		}

	}

	interface IWordState
	{
		void WriteName(StateContext context, string name);	
	}

	class StateLowerCase : IWordState
	{
		public void WriteName(StateContext context, string name)
		{
			Console.WriteLine(name.ToLower());
			context.SetState(new StateUpperCase());
		}
	}

	class StateUpperCase : IWordState
	{
		public void WriteName(StateContext context, string name)
		{
			Console.WriteLine(name.ToUpper());
			context.SetState(new StateLowerCase());
		}
	}
}
