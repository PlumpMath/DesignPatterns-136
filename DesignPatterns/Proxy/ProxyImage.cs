using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Proxy
{
	/// <summary>
	/// Provide a surrogate or placeholder for another object to control access to it.
	/// </summary>
	class ProxyImage : IImage
	{
		private RealImage realImage;
		private string fileName;

		public ProxyImage(string fileName)
		{
			this.fileName = fileName;
		}

		public void Display()
		{
			if(realImage == null)
			{
				realImage = new RealImage(fileName);
			}

			realImage.Display();
		}
	}

	interface IImage
	{
		void Display();
	}

	class RealImage : IImage
	{
		private string fileName;

		public RealImage(string fileName)
		{
			this.fileName = fileName;
		}

		public void Display()
		{
			Console.WriteLine(fileName + " is being displayed");
		}
		
		/// <summary>
		/// Very costly operation
		/// </summary>
		private void LoadImageFromDisk()
		{
			Console.WriteLine(fileName + " is loaded to memory");
		}
	}

	
}
