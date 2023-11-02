using PizzaOrderingApp.Entities;

namespace PizzaOrderingApp {
	internal class Program {
		static void Main(string[] args) {
			Console.WriteLine("Welcome to Pizza Factory");
			HandleCustomer handleCustomer = new();
			handleCustomer.AddCustomer();

			Customer customer = new();
			Login login = new Login();
			customer = login.userLogin(); //customer skal holde på den innloggede brukere

			Console.WriteLine($"Welcome {customer.CustomerName}");
		}
	}
}