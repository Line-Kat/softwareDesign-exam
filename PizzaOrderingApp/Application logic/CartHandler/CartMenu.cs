using PizzaOrderingApp.Application_logic.Decorators;
using PizzaOrderingApp.Application_logic.MenuHandler;
using PizzaOrderingApp.Application_logic.MenuHandler.Decorators;

namespace PizzaOrderingApp.Application_logic.CartHandler {
	public class CartMenu {
		private ShoppingCart shoppingCart;
		private DisplayMenus displayMenus;
		private PizzaToppingSelectionHandler toppingHandler;

		//constructor for the CartMenu class
		public CartMenu(ShoppingCart shoppingCart, DisplayMenus displayMenus, PizzaToppingSelectionHandler toppingHandler) {
			this.shoppingCart = shoppingCart;
			this.displayMenus = displayMenus;
			this.toppingHandler = toppingHandler;
		}

		//method that displays the menu for interacting with the shoppingCart
		public void ShowMenu() {
			bool running = true;
			while (running) {
				Console.WriteLine("\nChoose an action:");
				Console.WriteLine("1. View shopping cart");
				Console.WriteLine("2. Add a new pizza");
				Console.WriteLine("3. Remove a pizza from the shopping cart");
				Console.WriteLine("4. Change the quantity of a pizza in the shopping cart");
				Console.WriteLine("5. Send order");
				Console.WriteLine("6. Exit");

				string? userInput = Console.ReadLine();
				switch (userInput) {
					case "1":
						shoppingCart.ViewCart();
						break;
					case "2":
						displayMenus.PrintMenu();
						IPizza selectedPizza = displayMenus.GetSelectedPizza();

						if (selectedPizza != null) {
							shoppingCart.AddPizzaToCart(selectedPizza);
						} else {
							Console.WriteLine("No pizza was selected.");
						}
						break;
					case "3":
						Console.WriteLine("Enter the number of the pizza you want to remove from the shopping cart:");
						if (int.TryParse(Console.ReadLine(), out int pizzaId)) {
							shoppingCart.RemovePizzaFromCart(pizzaId);
						} else {
							Console.WriteLine("Invalid input. Please enter a valid pizza number.");
						}

						break;
					case "4":
						Console.WriteLine("Enter the number of the pizza:");
						if (int.TryParse(Console.ReadLine(), out pizzaId)) {
							Console.WriteLine("Enter new quantity:");
							if (int.TryParse(Console.ReadLine(), out int newQuantity)) {
								// Call the EditCart method with pizzaId and newQuantity arguments
								shoppingCart.EditCart(pizzaId, newQuantity);
							} else {
								Console.WriteLine("Invalid input. Please enter a valid pizza number.");
							}
						} else {
							Console.WriteLine("Invalid input. Please enter a valid number.");
						}

						break;
					case "5":
						running = false;
						break;
					case "6":
						Console.WriteLine("Exiting...");
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Invalid choice, please try again.");
						break;
				}
			}
		}
	}
}