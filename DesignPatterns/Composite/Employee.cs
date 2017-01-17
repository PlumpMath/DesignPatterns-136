using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//composite
namespace DesignPatterns.Composite
{
	public interface IEmployee
	{
		void Add(IEmployee emp);
		void Remove(IEmployee emp);
		IEmployee GetChild(int index);
		string GetName();
		double GetSalary();
		void Print();
	}

	public class ManagerComposite : IEmployee
	{
		private string name;
		private double salary;

		private List<IEmployee> employees = new List<IEmployee>();

		public ManagerComposite(string name, double salary)
		{
			this.name = name;
			this.salary = salary;
		}

		public void Add(IEmployee emp)
		{
			employees.Add(emp);
		}

		public IEmployee GetChild(int index)
		{
			return employees.ElementAt(index);
		}

		public string GetName()
		{
			return name;
		}

		public double GetSalary()
		{
			return salary;
		}

		public void Print()
		{
			Console.WriteLine("Manager Composite");

			foreach (var item in employees)
			{
				item.Print();
			}
		}

		public void Remove(IEmployee emp)
		{
			employees.Remove(emp);
		}
	}

	public class Developer : IEmployee
	{
		private string name;
		private double salary;

		public Developer(string name, double salary)
		{
			this.name = name;
			this.salary = salary;
		}

		public void Add(IEmployee emp)
		{
			//not applicable
		}

		public IEmployee GetChild(int index)
		{
			//not applicable
			return null;
		}

		public string GetName()
		{
			return name;
		}

		public double GetSalary()
		{
			return salary;
		}

		public void Print()
		{
			Console.WriteLine(name + "-" + salary);
		}

		public void Remove(IEmployee emp)
		{
			//not applicable
		}
	}

	public class Sim
	{
		public void Simulate()
		{
			IEmployee e1 = new Developer("Samo", 100000);
			IEmployee e2 = new Developer("Kado", 100000);
			IEmployee e3 = new Developer("Nuro", 100000);

			IEmployee m1 = new ManagerComposite("Daniel", 200000);

			m1.Add(e1);
			m1.Add(e2);
			m1.Add(e3);

			IEmployee generalManager = new ManagerComposite("John", 800000);

			generalManager.Add(m1);

		}
	}

}
