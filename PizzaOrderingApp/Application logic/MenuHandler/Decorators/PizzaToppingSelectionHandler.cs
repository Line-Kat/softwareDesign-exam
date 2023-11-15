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

		public IPizza HandleToppingSelection(IPizza pizza)
		{
			Console.WriteLine("\nDo you want to add extra toppings? Max 3 extra toppings, +10 kr per topping. (y/n)");
			string response = Console.ReadLine().ToLower();

			if (response == "y")
			{
				pizza = ChooseToppings(pizza);
			}  
			else if (response == "n")
			{
				DisplayCurrentPizzaState(pizza);
			}
			else
			{
				Console.WriteLine("\nPlease write y (yes) or n (no).");
				HandleToppingSelection(pizza);
			}

			return pizza;
		}

		private IPizza ChooseToppings(IPizza pizza)
		{
			int toppingsCount = 0;
			while (toppingsCount < MaxToppings)
			{
				DisplayAvailableToppings();
				DisplayCurrentPizzaState(pizza);

				Console.WriteLine("\nEnter the number of the topping you want to add:");
				if (int.TryParse(Console.ReadLine(), out int toppingChoice) &&
					toppingChoice > 0 && toppingChoice <= _availableToppings.Count)
				{
					pizza = AddToppingToPizza(pizza, toppingChoice); // Oppdaterer pizzaobjektet
					toppingsCount++;

					if (toppingsCount < MaxToppings)
					{
						DisplayCurrentPizzaState(pizza);
						Console.WriteLine("\nDo you want to add another topping (+ 10kr)? (y/n)");
						
						if (Console.ReadLine().ToLower() != "y")
						{
							break;
						}
					} 
				}
				
				else
				{
					Console.WriteLine($"\nInvalid choice. Please try again.\n");
					HandleToppingSelection(pizza);
				}
			}
			DisplayCurrentPizzaState(pizza);
			return pizza; // Returne den oppdaterte pizzaen
		}

		private IPizza AddToppingToPizza(IPizza pizza, int toppingChoice)
		{
			string selectedTopping = _availableToppings[toppingChoice - 1];
			var decorator = new PizzaToppingDecorator(pizza);
			decorator.AddTopping(selectedTopping);
			return decorator; // Returner den dekorerte pizzaen
		}


		private void DisplayAvailableToppings()
		{
			Console.WriteLine("\nAvailable toppings:");
			for (int i = 0; i < _availableToppings.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {_availableToppings[i]}");
			}
		}


		public void DisplayCurrentPizzaState(IPizza pizza)
		{
			Console.WriteLine($"\nYour pizza order:");
			Console.WriteLine($"{pizza.PizzaName}, {pizza.Description}");
			Console.WriteLine($"{pizza.Price} kr");
		}
	}


}
