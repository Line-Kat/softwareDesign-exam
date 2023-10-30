using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace PizzaOrderingApp {
	internal class Program {
		static void Main(string[] args) {

			Console.WriteLine("Welcome to Pizza Factory");
			Customer customer = new();
			customer.AddCustomer();

			//Test (will be removed).
			Console.WriteLine("\nPizza test: ");
			Pizza p1 = new(1, "hamPizza", 100);
			Console.WriteLine($"{p1.Id}. {p1.PizzaName} {p1.Price},- ");

			Console.WriteLine("\nPizza test: ");
			Pizza p2 = new(2, "test2name", 500);
			Console.WriteLine($"{p2.Id}. {p2.PizzaName} {p2.Price},- ");

			Console.WriteLine("\nEmpty pizza: ");
			Pizza p3 = new();
			Console.WriteLine($"{p3.Id}. {p3.PizzaName} {p3.Price},- ");
			// ------END-----------

			// Creating a new cart with test items(p1 + p2):
			Console.WriteLine("\nCreated a new cart and added p1 + p2");
			Cart cart = new();
			cart.InCart.Add(p1);
			cart.InCart.Add(p2);
		// ----CART TEST END-----

		
		// Pay() method (+ list items on bil?)
			Console.WriteLine("\nReceipt: (items + total)");
			/* 
			string cartItemsList = cart.BillItems();
			Console.WriteLine($"\n {cartItemsList}");
			Console.WriteLine($"In cart: {}");
			*/

			int totalCartValue = cart.Pay();
			Console.WriteLine($"{totalCartValue}");
			// ------ END --------

			/* MENU REMOVED (while working on code)

				User actionMenu
				int userMenuCase = userMenuOptions();
				while (userMenuCase != 0) {
					switch (userMenuCase) {

						case 1:
							Console.WriteLine("Order a pizza");
							//printPizzaMenu;
							Menu menu = new Menu();

							Console.WriteLine("pizza (number)");
								int pizzaNumber = int.Parse(Console.ReadLine());
							Console.WriteLine("num");
								int pizzaCount = int.Parse(Console.ReadLine());
							Console.WriteLine("size");
								string pizzaSize = Console.ReadLine();


							Cart cart = new Cart();
							c.Cart.Add(c.PizzaMenu[pizzaNumber + pizzaCount + pizzaSize]);


							printCart(c);


							Console.WriteLine("Countinue to order (Y/N)");
							break;
					}
				}
			}

			private static void printCart(Menu menu) {
				Console.WriteLine("In cart: ");
				for (int i = 0; i < p.InCart.Count; i++) {
					Console.WriteLine(p.InCart[i]);
				}
			}

			private static void printMenu(Pizza p) {
				for (int i = 0; i < p.PizzaMenu.Count; i++) {
					Console.WriteLine(p.PizzaMenu[i]);
				}
			}

			public static int userMenuOptions(){
				// user login?
				int menuOption = 0;
				Console.WriteLine("Choose an option: \n(1) Buy pizza \n(2) Something else..");
				menuOption = int.Parse(Console.ReadLine());
				return menuOption;
			}

			*/
		}
	}
}