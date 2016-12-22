using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.TemplateMethod
{
	/// <summary>
	/// Define the skeleton of an algorithm in an operation, deferring some steps to subclasses
	/// </summary>
	abstract class Game
	{
		protected int _playersCount = 0;

		//hook methods, concrete implementations may differ in each subclass
		public abstract void InitializeGame();
		public abstract void MakePlay(int player);
		public abstract bool EndOfGame();
		public abstract void PrintWinner();

		//template method
		public void PlayOneGame(int playersCount)
		{
			_playersCount = playersCount;
			InitializeGame();
			int i = 0;
			while (!EndOfGame())
			{
				MakePlay(i);
				i = (i + 1) % playersCount;
			}

			PrintWinner();
		}
	}

	class Monopoly : Game
	{
		///end the game according to the monopoly rules
		public override bool EndOfGame()
		{
			return false;
		}

		//initialize players and money
		public override void InitializeGame()
		{
			Console.WriteLine("Monopoly initialized");
		}

		//process one turn of a player
		public override void MakePlay(int player)
		{
			Console.WriteLine("Monopoly is being played");
		}

		//print the winner of the game
		public override void PrintWinner()
		{
			Console.WriteLine("Winner is player 1");
		}
	}

	class Chess : Game
	{
		//end the game if checkmate or draw
		public override bool EndOfGame()
		{
			return true;
		}

		//initialize players and the pieces on the board
		public override void InitializeGame()
		{
			Console.WriteLine("Chess initialized");
		}

		//process one turn of a chess player
		public override void MakePlay(int player)
		{
			Console.WriteLine("Chess is being played");
		}

		//display the winner
		public override void PrintWinner()
		{
			Console.WriteLine("Winner is player 2");
		}
	}

}
