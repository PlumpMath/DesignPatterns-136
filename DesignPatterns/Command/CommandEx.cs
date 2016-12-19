using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
	/// <summary>
	/// Encapsulate a request as an object, thereby letting you parameterize clients with different requests,
	/// queue or log requests, and support undoable operations.
	/// </summary>
	class CommandEx
	{
		public void Simulate()
		{

		}
	}

	class RemoteControlWithUndo
	{
		ICommand[] _onCommands;
		ICommand[] _offCommands;
		ICommand _undoCommand;

		public RemoteControlWithUndo()
		{
			_onCommands = new ICommand[7];
			_offCommands = new ICommand[7];

			ICommand noCommand = new NoCommand();

			for (int i = 0; i < 7; i++)
			{
				_onCommands[i] = noCommand;
				_offCommands[i] = noCommand;
			}

			_undoCommand = noCommand;
		}

		public void setCommand(int slot, ICommand onCommand, ICommand offCommand)
		{
			_onCommands[slot] = onCommand;
			_offCommands[slot] = offCommand;
		}
		
		public void OnButtonPressed(int slot)
		{
			_onCommands[slot].Execute();
			_undoCommand = _onCommands[slot];
		}

		public void OffButtonPressed(int slot)
		{
			_offCommands[slot].Execute();
			_undoCommand = _offCommands[slot];
		}

		public void UndoButtonPressed()
		{
			_undoCommand.Undo();
		}
	}

	interface ICommand
	{
		void Execute();
		void Undo();
	}
	
	class LightOnCommand : ICommand
	{
		private Light _light;

		public LightOnCommand(Light light)
		{
			_light = light;
		}

		public void Execute()
		{
			_light.On();
		}

		public void Undo()
		{
			_light.Off();
		}
	}

	class GarageDoorOpenCommand : ICommand
	{
		private GarageDoor _garageDoor;

		public GarageDoorOpenCommand(GarageDoor garageDoor)
		{
			_garageDoor = garageDoor;
		}

		public void Execute()
		{
			_garageDoor.Open();
		}

		public void Undo()
		{
			_garageDoor.Close();
		}
	}

	class NoCommand : ICommand
	{
		public void Execute()
		{
			Console.WriteLine("Nothing executed");
		}

		public void Undo()
		{
			Console.WriteLine("Nothing undoed");
		}
	}

	class Light
	{
		public void On()
		{
			Console.WriteLine("Light is ON");
		}

		public void Off()
		{
			Console.WriteLine("Light is OFF");
		}
	}

	class GarageDoor
	{
		public void Open()
		{
			Console.WriteLine("Garage door OPENED");
		}

		public void Close()
		{
			Console.WriteLine("Garage door CLOSED");
		}
	}


}
