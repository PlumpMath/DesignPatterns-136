namespace DesignPatterns.Singleton
{
	/// <summary>
	/// This class' object is sure to be instantiated for once and for the lifetime of the app, only this instance will be used.
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
