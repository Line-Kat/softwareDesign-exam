using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Application_logic.Decorators
{
	public class PizzaToppingsDecorator : IPizza
	{
		private readonly IPizza _basePizza;
		private readonly List<string> _toppings;

		public PizzaToppingsDecorator(IPizza basePizza, List<string> toppings)
		{
			_basePizza = basePizza;
			_toppings = toppings;
		}

		public string Description
		{
			get
			{
				return $"{_basePizza.Description}, {string.Join(", ", _toppings)}";
			}
		}

		public int Price
		{
			get
			{
				return _basePizza.Price + _toppings.Count * 15;
			}
		}
	}
}
