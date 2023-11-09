using PizzaOrderingApp.Entities;

namespace PizzaOrderingApp {
	internal class Program {
		static void Main(string[] args) {
			Console.WriteLine("Welcome to Pizza Factory");

			/*
			HandleCustomer handleCustomer = new();
			handleCustomer.deleteCustomer(3);

			Customer customer = new();
			Login login = new Login();
			customer = login.userLogin(); //customer holder på den innloggede brukeren

			Console.WriteLine($"Welcome {customer.CustomerName}");

			*/
			PizzaQueue pizzaQueue1 = new PizzaQueue();
			Console.WriteLine(pizzaQueue1.CheckQueue());
		}
	}
}