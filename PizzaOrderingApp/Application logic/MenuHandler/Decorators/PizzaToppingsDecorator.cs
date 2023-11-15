namespace PizzaOrderingApp.Application_logic.Decorators
{
	public class PizzaToppingDecorator : IPizza
	{
		private readonly IPizza _decoratedPizza;
		private readonly List<string> _additionalToppings = new List<string>();
		private const int ToppingPrice = 10;

		public PizzaToppingDecorator(IPizza decoratedPizza)
		{
			_decoratedPizza = decoratedPizza;
		}

		public int PizzaId => _decoratedPizza.PizzaId;
		public string PizzaName => _decoratedPizza.PizzaName;
		public int Price => _decoratedPizza.Price + _additionalToppings.Count * ToppingPrice;
		public string Description => $"{_decoratedPizza.Description}, {string.Join(", ", _additionalToppings)}";

		public void AddTopping(string topping)
		{
			_additionalToppings.Add(topping);
		}
	}
}
