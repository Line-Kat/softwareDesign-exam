using PizzaOrderingApp.Application_logic.CartHandler;
using PizzaOrderingApp.Application_logic.Decorators;
using PizzaOrderingApp.Application_logic.MenuHandler;
using PizzaOrderingApp.Application_logic.MenuHandler.Decorators;
using PizzaOrderingApp.Entities;
using System;

namespace PizzaOrderingApp.Application_logic.CartHandler
{
	public class CartMenu
	{
		private ShoppingCart shoppingCart;
		private DisplayMenus displayMenus;
		private PizzaToppingSelectionHandler toppingHandler;

		//constructor for the CartMenu class
		public CartMenu(ShoppingCart shoppingCart, DisplayMenus displayMenus, PizzaToppingSelectionHandler toppingHandler)
		{
			this.shoppingCart = shoppingCart;
			this.displayMenus = displayMenus;
			this.toppingHandler = toppingHandler;
		}

		//method that displays the menu for interacting with the shoppingCart
		public void ShowMenu()
		{
			bool running = true;
			while (running)
			{
				Console.WriteLine("\nChoose an action:");
				Console.WriteLine("1. View shopping cart");
				Console.WriteLine("2. Add a new pizza");
				Console.WriteLine("3. Remove a pizza from the shopping cart");
				Console.WriteLine("4. Change the quantity of a pizza in the shopping cart");
				Console.WriteLine("5. Exit");

				string userInput = Console.ReadLine();
				switch (userInput)
				{
					case "1":
						shoppingCart.ViewCart();
						break;
					case "2":
						displayMenus.PrintMenu();
						IPizza selectedPizza = displayMenus.GetSelectedPizza();
						Console.WriteLine("Selected pizza: " + (selectedPizza != null ? selectedPizza.PizzaName : "No pizza selected"));

						if (selectedPizza != null)
						{
							toppingHandler.HandleToppingSelection(selectedPizza);
							IPizza finalPizza = toppingHandler.GetFinalPizza();
							Console.WriteLine("Final pizza: " + (finalPizza != null ? finalPizza.PizzaName : "No final pizza"));

							if (finalPizza != null)
							{
								shoppingCart.AddPizzaToCart(finalPizza);
							}
							else
							{
								Console.WriteLine("An error occurred: FinalPizza is null.");
							}
						}
						else
						{
							Console.WriteLine("No pizza was selected.");
						}
						break;
					case "3":
						if (int.TryParse(Console.ReadLine(), out int pizzaId))
						{
						
							shoppingCart.RemovePizzaFromCart(pizzaId);
						}
						else
						{
							Console.WriteLine("Invalid input for pizzaId. Please enter a valid integer.");
						}
						
						break;
					case "4":
						Console.WriteLine("Enter pizzaId:");
						if (int.TryParse(Console.ReadLine(), out pizzaId))
						{
							Console.WriteLine("Enter new quantity:");
							if (int.TryParse(Console.ReadLine(), out int newQuantity))
							{
								// Call the EditCart method with pizzaId and newQuantity arguments
								shoppingCart.EditCart(pizzaId, newQuantity);
							}
							else
							{
								Console.WriteLine("Invalid input for newQuantity. Please enter a valid integer.");
							}
						}
						else
						{
							Console.WriteLine("Invalid input for pizzaId. Please enter a valid integer.");
						}
					
						break;
					case "5":
						Console.WriteLine("Exiting...");
						running = false;
						break;
					default:
						Console.WriteLine("Invalid choice, please try again.");
						break;
				}
			}
		}
	}
}
