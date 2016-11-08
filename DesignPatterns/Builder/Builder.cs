 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
	class Builder
	{
	}

	class Car
	{
		public Car()
		{
		}

		public int Wheels { get; set; }
		public string Color { get; set; }
		public int Year { get; set; }
	}

	interface ICarBuilder
	{
		void SetColor(string color);
		void SetWheels(int count);
		void SetYear(int year);
		Car GetResult();
	}

	class CarBuilder : ICarBuilder
	{
		private Car car;

		public CarBuilder()
		{
			car = new Car();
		}

		public Car GetResult()
		{
			return car;
		}

		public void SetColor(string color)
		{
			car.Color = color;
		}

		public void SetWheels(int count)
		{
			car.Wheels = count;
		}

		public void SetYear(int year)
		{
			throw new NotImplementedException();
		}
	}
	

	class CarBuilderDirector
	{
		public Car Construct()
		{
			CarBuilder builder = new CarBuilder();

			builder.SetColor("Red");
			builder.SetWheels(4);

			return builder.GetResult();
		}
	}
}
