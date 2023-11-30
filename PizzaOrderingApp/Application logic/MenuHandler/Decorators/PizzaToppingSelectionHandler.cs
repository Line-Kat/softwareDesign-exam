using PizzaOrderingApp.Application_logic.Decorators;
using PizzaOrderingApp.Technical_services.CRUD;

namespace PizzaOrderingApp.Application_logic.MenuHandler.Decorators {
	public class PizzaToppingSelectionHandler {
		private const int MaxToppings = 3;
		private IPizza finalPizza;
		private readonly CrudOperationsMenu crudOperationsMenu = new CrudOperationsMenu();
		private readonly List<string> _availablePizzaToppings;
		private int ToppingPrice = PizzaToppingDecorator.ToppingPrice;

		// Fetches available toppings from the database
		public PizzaToppingSelectionHandler() {
			_availablePizzaToppings = crudOperationsMenu.GetAvailablePizzaToppings();
		}

		// Handles user interaction for adding toppings
		public IPizza HandleToppingSelection(IPizza pizza) {
			Console.WriteLine($"\nDo you want to add extra toppings? Max 3 extra toppings, + {ToppingPrice}kr per topping. (y/n)");
			string response = Console.ReadLine().ToLower();

			// Prompt and logic for topping selection
			if (response == "y") {
				pizza = ChooseToppings(pizza);
			} else if (response != "y" && response != "n") {
				Console.WriteLine("\nPlease write y (yes) or n (no).");
				return HandleToppingSelection(pizza);
			}

			finalPizza = pizza;
			DisplayCurrentPizzaState(finalPizza);
			return finalPizza;
		}

		// Method that returns the final pizza with toppings selected
		public IPizza GetFinalPizza() {
			return finalPizza;
		}

		// Main loop for topping choice
		private IPizza ChooseToppings(IPizza pizza) {
			int toppingsCount = 0;
			while (toppingsCount < MaxToppings) {
				DisplayAvailableToppings();
				DisplayCurrentPizzaState(pizza);

				Console.WriteLine("\nEnter the number of the topping you want to add:");
				if (int.TryParse(Console.ReadLine(), out int toppingChoice) &&
					toppingChoice > 0 && toppingChoice <= _availablePizzaToppings.Count) {
					pizza = AddToppingToPizza(pizza, toppingChoice);
					toppingsCount++;

					if (toppingsCount < MaxToppings) {
						Console.WriteLine($"\nDo you want to add another topping (+{ToppingPrice}kr)? (y/n)");
						string innerResponse = Console.ReadLine().ToLower();

						if (innerResponse != "y") {
							return pizza; // Returns pizza with user-selected toppings
						}
					}
				} else {
					Console.WriteLine("\nInvalid choice. Please try again.\n");
				}
			}
			DisplayCurrentPizzaState(pizza);
			return pizza; // Return the updated pizza
		}

		// Adds selected topping to pizza
		private IPizza AddToppingToPizza(IPizza pizza, int toppingChoice) {
			string selectedTopping = _availablePizzaToppings[toppingChoice - 1];
			PizzaToppingDecorator decorator = new PizzaToppingDecorator(pizza);
			decorator.AddTopping(selectedTopping);
			return decorator; //returns new pizza object
		}

		// Displays available toppings to user
		private void DisplayAvailableToppings() {
			// Outputs available toppings to the console
			Console.WriteLine("\nAvailable toppings:");
			for (int i = 0; i < _availablePizzaToppings.Count; i++) {
				Console.WriteLine($"{i + 1}. {_availablePizzaToppings[i]}");
			}
		}

		// Shows current state of pizza order
		public void DisplayCurrentPizzaState(IPizza pizza) {
			Console.WriteLine($"\nYour pizza order:");
			Console.WriteLine($"{pizza.PizzaName}, {pizza.Description}");
			Console.WriteLine($"{pizza.Price} kr");
		}
	}
}