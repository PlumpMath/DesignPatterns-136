using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer
{
	/// <summary>
	/// Define a one-to-many dependency between objects so that when one object changes state, 
	/// all its dependents are notified and updated automatically.
	/// </summary>
	class Observer
	{
		private WeatherType currentWeather;
		private List<IWeatherObserver> observers;

		public Observer()
		{
			observers = new List<IWeatherObserver>();
			currentWeather = WeatherType.Sunny;
		}

		public void AddObserver(IWeatherObserver weatherObserver)
		{
			observers.Add(weatherObserver);
		}

		public void RemoveObserver(IWeatherObserver weatherObserver)
		{
			observers.Remove(weatherObserver);
		}

		private void NotifyObservers()
		{
			foreach (var observer in observers)
			{
				observer.Update(currentWeather);
			}
		}

		private void ChangeWeatherByTime()
		{
			foreach (WeatherType value in Enum.GetValues(typeof(WeatherType)))
			{
				//after 3 seconds, weather changes
				currentWeather = value;
				NotifyObservers();

			}
		}
	}

	interface IWeatherObserver
	{
		void Update(WeatherType currentWeather);
	}

	class EuropeanPerson : IWeatherObserver
	{
		public void Update(WeatherType currentWeather)
		{
			switch (currentWeather)
			{
				case WeatherType.Sunny:
					Console.WriteLine("What a sunny day");
					break;
				case WeatherType.Rainy:
					Console.WriteLine("It always rains here");
					break;
				case WeatherType.Windy:
					Console.WriteLine("Where this wind comes from?");
					break;
				case WeatherType.Cold:
					Console.WriteLine("Im freeeeeezing");
					break;
				default:
					break;
			}
		}
	}

	class CanadianPeople : IWeatherObserver
	{
		public void Update(WeatherType currentWeather)
		{
			switch (currentWeather)
			{
				case WeatherType.Sunny:
					Console.WriteLine("Ages past from last time I saw sun");
					break;
				case WeatherType.Rainy:
					Console.WriteLine("It doesn't rain a lot here");
					break;
				case WeatherType.Windy:
					Console.WriteLine("It winds very fast");
					break;
				case WeatherType.Cold:
					Console.WriteLine("Yeah I can go to swim now.");
					break;
				default:
					break;
			}
		}
	}

	enum WeatherType
	{
		Sunny,
		Rainy,
		Windy,
		Cold
	}


}
