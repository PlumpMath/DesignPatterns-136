using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategy
{
	/// <summary>
	/// Define a family of algorithms, encapsulate each one, and make them interchangeable.
	/// Strategy lets the algorithm vary independently from clients that use it.
	/// </summary>
	class CompressionContext
	{
		private ICompressionStrategy compressionStrategy;

		public CompressionContext(ICompressionStrategy compressionStrategy)
		{
			this.compressionStrategy = compressionStrategy;
		}

		public void CreateArchive(List<string> files)
		{
			compressionStrategy.CompressFiles(files);
		}
	}

	interface ICompressionStrategy
	{
		void CompressFiles(List<string> files);
	}

	class ZipCompressionStrategy : ICompressionStrategy
	{
		public void CompressFiles(List<string> files)
		{
			Console.WriteLine("Compressing as ZIP");
		}
	}

	class RarCompressionStrategy : ICompressionStrategy
	{
		public void CompressFiles(List<string> files)
		{
			Console.WriteLine("Compressing as RAR");
		}
	}

	class StrategyTest
	{
		static void Test()
		{
			ZipCompressionStrategy zipctx = new ZipCompressionStrategy();
			CompressionContext ctx = new CompressionContext(zipctx);

			ctx.CreateArchive(new List<string>());
		}
	}
}
