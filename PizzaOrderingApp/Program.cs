using PizzaOrderingApp.Application_logic.CartHandler;
using PizzaOrderingApp.Application_logic.Decorators;
using PizzaOrderingApp.Application_logic.MenuHandler;
using PizzaOrderingApp.Application_logic.MenuHandler.Decorators;
using PizzaOrderingApp.Entities;
using PizzaOrderingApp.MenuHandler;

namespace PizzaOrderingApp
{
	internal class Program
	{
		static void Main(string[] args)
		{



			// Metode som legger til pizza i pizza tabellen i db (om de ikke finnes fra før av)
			AddMenuItems addMenuItems = new AddMenuItems();
			addMenuItems.AddItems();

			ShoppingCart shoppingCart = new ShoppingCart();
			DisplayMenus displayMenus = new DisplayMenus();
			PizzaToppingSelectionHandler toppingHandler = new PizzaToppingSelectionHandler();
			IPizza finalPizza = toppingHandler.GetFinalPizza();
			CartMenu cartMenu = new CartMenu(shoppingCart, displayMenus, toppingHandler);

			cartMenu.ShowMenu();








			/*
						// Displaye menyene
						DisplayMenus displayMenus = new DisplayMenus();
						ShoppingCart shoppingCart = new ShoppingCart();
						PizzaToppingSelectionHandler toppingHandler = new PizzaToppingSelectionHandler();

						// Anta at SelectPizza er en metode som lar brukeren velge en grunnpizza og returnerer en IPizza
						IPizza basePizza = displayMenus.SelectPizza(); // Denne metoden må implementeres for å la brukeren velge en pizza
						if (basePizza != null)
						{
							// La brukeren tilpasse pizzaen
							IPizza selectedPizza = toppingHandler.HandleToppingSelection(basePizza);
							// Legg den tilpassede pizzaen til i handlekurven
							shoppingCart.AddPizzaToCart(selectedPizza);

							// Vis CartMenu for videre interaksjoner
							CartMenu cartMenu = new CartMenu(shoppingCart, displayMenus, toppingHandler);
							cartMenu.ShowMenu();
						}
						else
						{
							Console.WriteLine("Ingen grunnpizza ble valgt. Avslutter programmet.");
						}
					}*/

			/*		

			Console.WriteLine("Welcome to Pizza Factory");
			HandleCustomer handleCustomer = new();
			Customer customer = new();


			Login login = new Login();
			customer = login.userLogin(); //customer holder på den innloggede brukeren

		Console.WriteLine($"Welcome {customer.CustomerName}");


			bool keepRunning = true;
			while (keepRunning) {
				Console.WriteLine("Choose an option:\n1 Order pizza\n2 Log out\n3 Delete your user");
				string userInput = Console.ReadLine();
				if (userInput.Equals("1")) {
					HandleOrder order = new();
					PizzaQueue queue = new PizzaQueue();

					bool NumInputIsEmpty = true;
					while (NumInputIsEmpty) {


					while (NumInputIsEmpty)
					{

						while (NumInputIsEmpty)
						{

							Console.WriteLine("Skriv antall pizzaer");
							string countAsString = Console.ReadLine();
							int userPizzaCount;

							if (!int.TryParse(countAsString, out userPizzaCount))
							{
								Console.WriteLine("Count needs to be higher than 1");
							}
							else if (userPizzaCount <= 0)
							{
								Console.WriteLine("Count needs to be higher than 1");
							}
							else
							{

								if (!int.TryParse(countAsString, out userPizzaCount))
								{
									Console.WriteLine("Count needs to be higher than 1");
								}
								else if (userPizzaCount <= 0)
								{
									Console.WriteLine("Count needs to be higher than 1");
								}
								else
								{

									DateTime dateTime = queue.CheckQueue(userPizzaCount);
									order.printOrder(customer, dateTime);
									order.addOrder(customer);
									NumInputIsEmpty = false;
								}
							}
							keepRunning = false;

						}

						if (userInput.Equals("2"))
						{
							Console.WriteLine("Thank you for visiting us. Welcome back!");
							keepRunning = false;

						}

						if (userInput.Equals("3"))
						{
							handleCustomer.deleteCustomer(customer.CustomerId);
							Console.WriteLine("You are now deleted from out database. You are welcome to come back another time");
							keepRunning = false;
						}

					}

				}
			}*/
		}
	}
}