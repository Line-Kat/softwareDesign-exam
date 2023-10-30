namespace PizzaOrderingApp {
	internal class Program {
		static void Main(string[] args) {
			Console.WriteLine("Welcome to Pizza Factory");
			Customer customer = new();
			customer.AddCustomer();


			// See menu 


			// add to cart
			Console.WriteLine("What do you want to order?");
			String[] pizzaType = Console.ReadLine();
			Console.WriteLine("Countinue to order (Y/N)");
		}
	}
}