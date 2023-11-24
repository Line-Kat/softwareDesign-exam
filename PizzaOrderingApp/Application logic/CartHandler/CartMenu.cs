using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaOrderingApp.Application_logic.CartHandler;
using PizzaOrderingApp.Application_logic.Decorators;
using PizzaOrderingApp.Application_logic.MenuHandler;
using PizzaOrderingApp.Application_logic.MenuHandler.Decorators;

namespace PizzaOrderingApp.Application_logic.CartHandler
{
	
	public class CartMenu
	{
		private ShoppingCart shoppingCart;
		private DisplayMenus displayMenus;
		private PizzaToppingSelectionHandler toppingHandler;

		public CartMenu(ShoppingCart shoppingCart, DisplayMenus displayMenus, PizzaToppingSelectionHandler toppingHandler)
		{
			this.shoppingCart = shoppingCart;
			this.displayMenus = displayMenus;
			this.toppingHandler = toppingHandler;
		}

		public void ShowMenu()
		{
			bool running = true;
			while (running)
			{
				Console.WriteLine("\nVelg en handling:");
				Console.WriteLine("1. Vis handlekurv");
				Console.WriteLine("2. Legg til ny pizza");
				Console.WriteLine("3. Fjern pizza fra handlekurv");
				Console.WriteLine("4. Endre antall på en pizza i handlekurven");
				Console.WriteLine("5. Avslutt");

				string userInput = Console.ReadLine();
				switch (userInput)
				{
					case "1":
						shoppingCart.ViewCart();
						break;
					case "2":
						displayMenus.PrintMenu();
						IPizza selectedPizza = toppingHandler.GetFinalPizza(); 
						if (selectedPizza != null)
						{
							shoppingCart.AddPizzaToCart(selectedPizza);
						}
						else
						{
							Console.WriteLine("Ingen pizza ble valgt.");
						}
						break;
					case "3":
						shoppingCart.RemovePizzaFromCartInteraction();
						break;
					case "4":
						shoppingCart.EditCartInteraction();
						break;
					case "5":
						Console.WriteLine("Avslutter...");
						running = false;
						break;
					default:
						Console.WriteLine("Ugyldig valg, vennligst prøv igjen.");
						break;
				}
			}
		}
	}
}
