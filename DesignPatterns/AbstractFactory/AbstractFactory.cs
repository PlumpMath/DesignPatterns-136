
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractFactory
{
	/// <summary>
	/// Provide an interface for creating families of related or dependent objects 
	/// without specifying their concrete classes.
	/// </summary>
	class AbstractFactory
	{
		static void Simulate()
		{
			GUIFactory factory;
			string style = "Windows";
			
			if(style.Equals("Windows"))
			{
				factory = new WindowsFactory();
			}
			else
			{
				factory = new MacOSXFactory();
			}

			var button = factory.CreateButton();
			button.Draw();
		}
	}

	interface IButton
	{
		void Draw();
	}

	abstract class GUIFactory
	{
		public abstract IButton CreateButton();

		void DrawButton()
		{
			CreateButton().Draw(); 
		}
	}

	class UbuntuFactory : GUIFactory
	{
		public override IButton CreateButton()
		{
			return new UbuntuButton();
		}
	}

	class WindowsFactory : GUIFactory
	{
		public override IButton CreateButton()
		{
			return new WindowsButton();
		}
	}

	class MacOSXFactory : GUIFactory
	{
		public override IButton CreateButton()
		{
			return new MacOSXButton();
		}
	}
	

	class UbuntuButton : IButton
	{
		public void Draw()
		{
			Console.WriteLine("Im a Ubuntu Button");
		}
	}

	class WindowsButton : IButton
	{
		public void Draw()
		{
			Console.WriteLine("Im a Windows Button");
		}
	}

	class MacOSXButton : IButton
	{
		public void Draw()
		{
			Console.WriteLine("Im a MacOSX Button");
		}
	}
}
