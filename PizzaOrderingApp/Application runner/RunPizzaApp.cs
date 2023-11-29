using PizzaOrderingApp.Application_logic.CartHandler;
using PizzaOrderingApp.Application_logic.Decorators;
using PizzaOrderingApp.Application_logic.MenuHandler;
using PizzaOrderingApp.Application_logic.MenuHandler.Decorators;
using PizzaOrderingApp.Entities;
using PizzaOrderingApp.MenuHandler;

namespace PizzaOrderingApp.Application_runner
{
	public class RunPizzaApp
	{

		public void Run()
		{

			//Metode som legger til pizza i pizza tabellen i db (om de ikke finnes fra før av)
			AddMenuItems addMenuItems = new();
			addMenuItems.AddItems();

			Console.WriteLine("Welcome to Pizza Factory");
			HandleCustomer handleCustomer = new();
			HandleOrder handleOrder = new();
			DisplayMenus displayMenus = new();
			ShoppingCart shoppingCart = new ShoppingCart();
			PizzaToppingSelectionHandler toppingHandler = new PizzaToppingSelectionHandler();
			IPizza finalPizza = toppingHandler.GetFinalPizza();
			CartMenu cartMenu = new CartMenu(shoppingCart, displayMenus, toppingHandler);

			Login login = new Login();
			Customer customer = login.UserLogin();

			Console.WriteLine($"\nWelcome {customer.CustomerName}");

			bool keepRunning = true;
			while (keepRunning)
			{
				Console.WriteLine("\nChoose an option:\n1. Order pizza\n2. Log out\n3. Manage your account");

				string? userInput = Console.ReadLine();
				if (userInput.Equals("1"))
				{
					HandleOrder order = new();
					PizzaQueue queue = new();

					cartMenu.ShowMenu();

					//int numberOfPizzas= handleOrder.GetNumberOfItems();

					int totalNumberOfPizzas = shoppingCart.TotalNumberOfPizzas();
					int totalToPay = shoppingCart.TotalToPay();
					List<CartItem> cartItems = shoppingCart.GetCartItems();

					DateTime dateTime = queue.CheckQueue(totalNumberOfPizzas);
					order.PrintOrder(customer, dateTime, totalToPay, cartItems);
					order.AddOrder(customer);

					keepRunning = false;
				}

				if (userInput.Equals("2"))
				{
					Console.WriteLine("Thank you for visiting us. Welcome back!");
					keepRunning = false;
				}

				if (userInput.Equals("3"))
				{

					bool keepRunning2 = true;
					while (keepRunning2)
					{

						Console.WriteLine("\nManage your account:\n1 Edit your user \n2 Delete user");
						string? userInput2 = Console.ReadLine();
						if (userInput2.Equals("1"))
						{
							customer = handleCustomer.ConfirmCustomerInformation(customer);
							keepRunning2 = false;
						}
						else if (userInput2.Equals("2"))
						{
							handleCustomer.DeleteCustomer(customer.CustomerId);
							Console.WriteLine("You are now deleted from out database. You are welcome to come back another time");
							keepRunning2 = false;
							keepRunning = false;
						}
						else
						{
							Console.WriteLine("\nChoose a number from the menu");
						}
					}
				}
			}
		}
	}
}