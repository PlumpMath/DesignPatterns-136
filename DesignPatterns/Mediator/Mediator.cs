using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Mediator
{
	/// <summary>
	/// Define an object that encapsulates how a set of objects interact.
	/// Mediator promotes loose coupling by keeping objects from referring to each other explicitly,
	/// and it lets you vary their interaction independently.
	/// </summary>
	class Mediator
	{

	}

	abstract class AbstractChatroom
	{
		public abstract void Register(Participant participant);
		public abstract void Send(string from, string to, string message);
	}

	class Chatroom : AbstractChatroom
	{
		private Dictionary<string, Participant> _participants =
	  new Dictionary<string, Participant>();

		public override void Register(Participant participant)
		{
			if (!_participants.ContainsValue(participant))
			{
				_participants[participant.Name] = participant;
			}

			participant.Chatroom = this;
		}

		public override void Send(string from, string to, string message)
		{
			Participant participant = _participants[to];

			if (participant != null)
			{
				participant.Receive(from, message);
			}
		}
	}

	class Participant
	{
		private Chatroom _chatroom;
		private string name;

		public Participant(string name)
		{
			this.name = name;
		}

		public string Name
		{
			get { return name; }
		}

		public Chatroom Chatroom
		{
			set { _chatroom = value; }
			get { return _chatroom; }
		}

		public void Send(string to, string message)
		{
			_chatroom.Send(name, to, message);
		}

		// Receives message from given participant
		public virtual void Receive(
		  string from, string message)
		{
			Console.WriteLine("{0} to {1}: '{2}'",
			  from, Name, message);
		}
	}
}
