using PizzaOrderingApp.Entities;

namespace PizzaOrderingApp {
	internal class Program {
		static void Main(string[] args) {

			Console.WriteLine("Welcome to Pizza Factory");
			HandleCustomer handleCustomer = new();
			Customer customer = new();


			Login login = new Login();
			customer = login.userLogin(); //customer holder på den innloggede brukeren

			Console.WriteLine($"Welcome {customer.CustomerName}");

			bool runProgram = true;

			while (runProgram) {
			
				bool keepRunning = true;
				while (keepRunning) {
					Console.WriteLine("Choose an option:\n1 Order pizza\n2 Log out\n3 Delete your user");
					string userInput = Console.ReadLine();
					if (userInput.Equals("1")) {
						HandleOrder order = new();
						PizzaQueue queue = new PizzaQueue();
						DateTime dateTime = queue.CheckQueue();
						order.printOrder(customer, dateTime);
						order.addOrder(customer);
						keepRunning = false;
						runProgram = false;
					}

					if (userInput.Equals("2")) { 
						Console.WriteLine("Thank you for visiting us. Welcome back!");	
						keepRunning= false;
						runProgram = false;
					}

					if (userInput.Equals("3")) {
						handleCustomer.deleteCustomer(customer.CustomerId);
						keepRunning = false;
					}
				}
			}
		}
	}
}