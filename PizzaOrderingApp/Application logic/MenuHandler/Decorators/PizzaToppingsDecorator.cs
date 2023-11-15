using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PizzaOrderingApp.Application_logic.Decorators
{
	public class ToppingDecorator : IPizza
	{
		private readonly IPizza _decoratedPizza;
		private readonly List<string> _additionalToppings = new List<string>();
		private readonly Dictionary<string, int> _toppingPrices;

		public ToppingDecorator(IPizza decoratedPizza, Dictionary<string, int> toppingPrices)
		{
			_decoratedPizza = decoratedPizza;
			_toppingPrices = toppingPrices;
		}

		public int PizzaId => _decoratedPizza.PizzaId;
		public string PizzaName => _decoratedPizza.PizzaName;
		public int Price => _decoratedPizza.Price + _additionalToppings.Sum(topping => _toppingPrices[topping]);
		public string Description => $"{_decoratedPizza.Description}, {string.Join(", ", _additionalToppings)}";

		public void AddTopping(string topping)
		{
			if (_toppingPrices.ContainsKey(topping))
			{
				_additionalToppings.Add(topping);
			}
			else
			{
				Console.WriteLine($"Topping '{topping}' is not available.");
			}
		}
	}
}
