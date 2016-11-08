namespace DesignPatterns.Singleton
{
	/// <summary>
	/// Ensure a class only has one instance, and provide a global point of access to it.
	/// </summary>
	public class SingletonClass
	{
		private static SingletonClass instance;

		private SingletonClass()
		{
		}

		public static SingletonClass GetInstance()
		{
			if(instance == null)
			{
				instance = new SingletonClass();
			}

			return instance;
		}

	}
}
