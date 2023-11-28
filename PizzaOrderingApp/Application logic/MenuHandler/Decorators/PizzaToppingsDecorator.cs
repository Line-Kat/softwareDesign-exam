namespace PizzaOrderingApp.Application_logic.Decorators
{

	// PizzaToppingDecorator enhances an IPizza object with additional toppings
	public class PizzaToppingDecorator : IPizza
	{
		private readonly IPizza _decoratedPizza; 
		private readonly List<string> _additionalToppings = new List<string>(); // // List to hold extra toppings
		private const int ToppingPrice = 30; // price pr topping

		public PizzaToppingDecorator(IPizza decoratedPizza)
		{
			_decoratedPizza = decoratedPizza;
		}

		// Properties, add additional logic for toppings
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
