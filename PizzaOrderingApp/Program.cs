using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace PizzaOrderingApp {
	internal class Program {
		static void Main(string[] args) {
			Console.WriteLine("Welcome to Pizza Factory");
			Customer customer = new();
			customer.AddCustomer();


			// See menu 


			// add to cart
			//switchcase
			// case 1:
			Int customer = customerMenuOptions();
			while (customer != 0) {
				switch (customer) {

					case 1:
						Console.WriteLine("Order a pizza");
						//printPizzaMenu(x);
						
						Console.WriteLine("pizza (number)");
							int pizzaNumber = int.Parse(Console.ReadLine());
						Console.WriteLine("num");
							int pizzaCount = int.Parse(Console.ReadLine());
						Console.WriteLine("size");
							string pizzaSize = Console.ReadLine();

						c.Cart.Add(c.PizzaMenu[pizzaNumber + pizzaCount + pizzaSize]);
						printCart(c);

						Console.WriteLine("Countinue to order (Y/N)");
						break;
				}
			}
		}

		private static void printCart(object c) {
			throw new NotImplementedException();
		}

		private static void printMenu(object c) {
			for (int i = 0; i < p.pizzaMenu.Count; i++) {
				Console.WriteLine(p.pizzaMenu[i]);
			}
		}

		public static int customerMenuOptions(){
			int menuOption = 0;
			Console.WriteLine("Choose an option: \n(1) Buy pizza \n(2) Something else..");
			menuOption = int.Parse(Console.ReadLine());
			return menuOption;
		}
	}
}