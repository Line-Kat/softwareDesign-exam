using PizzaOrderingApp.Entities;

namespace PizzaOrderingApp {
	internal class Program {
		static void Main(string[] args) {
			bool runProgram = true;

			while (runProgram) {
				Console.WriteLine("Welcome to Pizza Factory");
				HandleCustomer handleCustomer = new();
				Customer customer = new();


				Login login = new Login();
				customer = login.userLogin(); //customer holder på den innloggede brukeren

				Console.WriteLine($"Welcome {customer.CustomerName}");


				bool keepRunning = true;
				while (keepRunning) {
					Console.WriteLine("Choose an option:\n1 Order pizza\n2 Delete your user\n3 Log out");
					string userInput = Console.ReadLine();
					if (userInput.Equals("1")) {
						//metodekall til bestilling av pizza
						keepRunning = false;
					}

					if (userInput.Equals("2")) {
						handleCustomer.deleteCustomer(customer.CustomerId);
						keepRunning = false;
					}

					if (userInput.Equals("3")) { 
						Console.WriteLine("Thank you for visiting us. Welcome back!");	
						keepRunning= false;
						runProgram = false;
					}
				}
			}
		}
	}
}