using System.Threading.Tasks;
using PizzaOrderingApp.Entities;
using PizzaOrderingApp.Technical_services.CRUD;

namespace PizzaOrderingApp {

	public class HandleOrder {

		CrudOperationsOrder crudOperationsOrder = new();

		//Method to print the receipt to the customer
		public void PrintOrder(Customer customer, DateTime dateTime, int numberOfPizzas) {

			Console.WriteLine($"\nThank you for ordering from Pizza Factory! Here is your receipt:\n" +
				$"Name: {customer.CustomerName}\n" +
				$"You ordered {numberOfPizzas} 'name of pizza\n" +
				$"Your order is ready for pick up at {dateTime}\n" +
				"Welcome back another time!");
		}

		//Method to add order to the database
		public Order AddOrder(Customer customer) {

			Order order = new() {
				CustomerId = customer.CustomerId
			};

			return crudOperationsOrder.AddOrder(order);
		}

		//Method to get the number of pizzas the customer wants to order
		//METODEN ER ERSTATTET AV METODEN TOTALNUMBEROFPIZZAS I KLASSEN SHOPPINGCART
		/*public int GetNumberOfItems() {

			bool numInputIsEmpty = true;
			int userPizzaCount = 0;

			while (numInputIsEmpty) {
				Console.WriteLine("Type the number of pizzas you want");
				string? countAsString = Console.ReadLine();

				if (!int.TryParse(countAsString, out userPizzaCount)) {
					Console.WriteLine("Count needs to be higher than 1");
				} else if (userPizzaCount <= 0) {
					Console.WriteLine("Count needs to be higher than 1");
				} else {
					numInputIsEmpty = false;
				}
			}
			return userPizzaCount;
		}
		*/
	}
}