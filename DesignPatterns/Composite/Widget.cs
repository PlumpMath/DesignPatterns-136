using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Composite
{
	interface IWidget
	{
		void Update();
		void Add(IWidget widget);
		void Remove(IWidget widget);
		IWidget GetChild(int index);
	}

	class Button : IWidget
	{
		public void Add(IWidget widget)
		{
			throw new NotImplementedException();
		}

		public IWidget GetChild(int index)
		{
			throw new NotImplementedException();
		}

		public void Remove(IWidget widget)
		{
			throw new NotImplementedException();
		}

		public void Update()
		{
			//update button itself
		}
	}

	class WidgetContainer : IWidget
	{
		protected List<IWidget> childWidgets = new List<IWidget>();
		
		public void Add(IWidget widget)
		{
			childWidgets.Add(widget);
		}

		public IWidget GetChild(int index)
		{
			return childWidgets.ElementAt(index);
		}

		public void Remove(IWidget widget)
		{
			childWidgets.Remove(widget);
		}

		public void Update()
		{
			foreach (var item in childWidgets)
			{
				item.Update();
			}
		}
	}
}
