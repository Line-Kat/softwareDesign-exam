using PizzaOrderingApp.Technical_services.CRUD;
using PizzaOrderingApp.Application_logic.MenuHandler.Decorators;
using PizzaOrderingApp.MenuHandler;
using PizzaOrderingApp.Application_logic.Decorators;

namespace PizzaOrderingApp.Entities {
	public class PizzaMenu : Menu {
		private IPizza selectedPizza; // Holds the currently selected pizza

		CrudOperationsMenu crudOperationsMenu = new CrudOperationsMenu(); // Handles CRUD operations for pizzas

		public IPizza GetSelectedPizza() {
			return selectedPizza;
		}

		// Prints the pizza menu and handles the selection process
		public override void PrintMenu() {
			Console.WriteLine($"\n{Divider}\nHere is the pizza menu:\n{Divider}");

			try {
				List<Pizza> pizzas = crudOperationsMenu.GetAllPizzas();

				// Check if there are any pizzas to display
				if (pizzas.Any()) {
					foreach (Pizza pizza in pizzas) {
						Console.WriteLine($"Nr. {pizza.PizzaId}. {pizza.PizzaName} {pizza.Price}kr");
						Console.WriteLine($"Description: {pizza.Description} \n");
					}

					// Prompt user for pizza selection
					Console.WriteLine("Please enter the number of the pizza you want to select:");
					if (int.TryParse(Console.ReadLine(), out int pizzaId)) {
						Pizza tempSelectedPizza = crudOperationsMenu.GetPizzaById(pizzaId);

						// Handles topping selection if valid pizza is selected
						if (tempSelectedPizza != null) {
							this.selectedPizza = tempSelectedPizza;

							PizzaToppingSelectionHandler toppingHandler = new PizzaToppingSelectionHandler();
							toppingHandler.HandleToppingSelection(this.selectedPizza);
						} else {
							Console.WriteLine("\nInvalid pizza number, please try again.");
							PrintMenu();
						}
					} else {
						Console.WriteLine("\nPlease enter a number.");
						PrintMenu();
					}
				} else {
					Console.WriteLine("There is nothing in this menu, sorry!");
				}
			} catch (Exception ex) {
				Console.WriteLine("Error, could not fetch the pizza menu");
				Console.WriteLine(ex.Message);
			}
		}
	}
}