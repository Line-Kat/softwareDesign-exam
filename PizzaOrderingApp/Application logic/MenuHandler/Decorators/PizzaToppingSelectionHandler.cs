using PizzaOrderingApp.Application_logic.Decorators;

namespace PizzaOrderingApp.Application_logic.MenuHandler.Decorators
{
	public class PizzaToppingSelectionHandler
	{

		private readonly List<string> _availableToppings = new List<string>();
		private const int MaxToppings = 3;

		public PizzaToppingSelectionHandler()
		{
			LoadToppingsFromDatabase();
		}

		private void LoadToppingsFromDatabase()
		{
			using (var db = new PizzaOrderingDbContext())
			{
				var pizzaDescriptions = db.Pizza.Select(p => p.Description).ToList();
				var allToppings = pizzaDescriptions
					.SelectMany(description => description.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
					.Distinct()
					.Select(topping => topping.Trim())
					.ToList();

				_availableToppings.AddRange(allToppings);
			}
		}

		public IPizza HandleToppingSelection (IPizza pizza)
		{

			Console.WriteLine("\nDo you want to add extra toppings? Max 3 extra topping, +10 kr per topping. (y/n)");
			string response = Console.ReadLine().ToLower();
			int toppingsCount = 0;

			if (response == "y")
			{
				Console.WriteLine("\nAvailable toppings:");
				for (int i = 0; i < _availableToppings.Count; i++)
				{
					Console.WriteLine($"{i + 1}. {_availableToppings[i]}");
				}
			}

			while (response == "y" && toppingsCount < MaxToppings)
			{
				DisplayCurrentPizzaState(pizza);

				Console.WriteLine("\nEnter the number of the topping you want to add:");

				if (int.TryParse(Console.ReadLine(), out int toppingChoice) &&
					toppingChoice > 0 && toppingChoice <= _availableToppings.Count)
				{
					string selectedTopping = _availableToppings[toppingChoice - 1];
					var decorator = new PizzaToppingDecorator(pizza);
					decorator.AddTopping(selectedTopping);
					pizza = decorator;

					toppingsCount++;
					
					if (toppingsCount < MaxToppings)
					{
						DisplayCurrentPizzaState(pizza);
						Console.WriteLine("\nDo you want to add another topping (+ 10kr)? (y/n)");
						response = Console.ReadLine().ToLower();
					}
				}
				else
				{
					Console.WriteLine($"\nTopping '{toppingChoice}' is not available, sry!\n");
				}
			}

			return pizza;
		}


		public void DisplayCurrentPizzaState(IPizza pizza)
		{
			Console.WriteLine($"\nYour pizza order:");
			Console.WriteLine($"{pizza.PizzaName}, {pizza.Description}");
			Console.WriteLine($"{pizza.Price} kr");
		}
	}


}
