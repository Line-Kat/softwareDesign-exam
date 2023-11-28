using PizzaOrderingApp.Application_logic.Decorators;
using PizzaOrderingApp.Technical_services.CRUD;

namespace PizzaOrderingApp.Application_logic.MenuHandler.Decorators
{
	public class PizzaToppingSelectionHandler
	{
		private const int MaxToppings = 3;
		private IPizza finalPizza;
		// CRUD
		private readonly CrudOperationsMenu crudOperationsMenu = new CrudOperationsMenu();
		private readonly List<string> _availablePizzaToppings;

		public PizzaToppingSelectionHandler()
		{
			// CRUD
			_availablePizzaToppings = crudOperationsMenu.GetAvailablePizzaToppings();
		}

		public IPizza HandleToppingSelection(IPizza pizza)
		{
			Console.WriteLine("\nDo you want to add extra toppings? Max 3 extra toppings, +10 kr per topping. (y/n)");
			string response = Console.ReadLine().ToLower();

			if (response == "y")
			{
				pizza = ChooseToppings(pizza);
			}
			else if (response != "y" && response != "n")
			{
				Console.WriteLine("\nPlease write y (yes) or n (no).");
				return HandleToppingSelection(pizza); 
			}

			finalPizza = pizza;
			DisplayCurrentPizzaState(finalPizza); 
			return finalPizza;
		}

		public IPizza GetFinalPizza()
		{
			return finalPizza;
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
					toppingChoice > 0 && toppingChoice <= _availablePizzaToppings.Count)
				{
					pizza = AddToppingToPizza(pizza, toppingChoice);
					toppingsCount++;

					if (toppingsCount < MaxToppings)
					{
						Console.WriteLine("\nDo you want to add another topping (+ 10kr)? (y/n)");
						string innerResponse = Console.ReadLine().ToLower();

						if (innerResponse != "y")
						{
							return pizza; 
						}
					}
				}
				else
				{
					Console.WriteLine("\nInvalid choice. Please try again.\n");
				}
			}
			DisplayCurrentPizzaState(pizza);
			return pizza; // Return the updated pizza
		}

		private IPizza AddToppingToPizza(IPizza pizza, int toppingChoice)
		{
			string selectedTopping = _availablePizzaToppings[toppingChoice - 1];
			PizzaToppingDecorator decorator = new PizzaToppingDecorator(pizza);
			decorator.AddTopping(selectedTopping);
			return decorator; // Return the decorated pizza
		}

		private void DisplayAvailableToppings()
		{
			Console.WriteLine("\nAvailable toppings:");
			for (int i = 0; i < _availablePizzaToppings.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {_availablePizzaToppings[i]}");
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