using System.Threading.Tasks;
using PizzaOrderingApp.Entities;
using PizzaOrderingApp.Technical_services.CRUD;

namespace PizzaOrderingApp {

	public class HandleOrder {

		CrudOperationsOrder crudOperationsOrder = new();

		public void PrintOrder(Customer customer, DateTime dateTime) {

			Console.WriteLine($"\nThank you for ordering from Pizza Factory! Here is your receipt:\n" +
				$"Name: {customer.CustomerName}\n" +
				$"Your order is ready for pick up at {dateTime}\n" +
				"Welcome back another time!");
		}

		public Order AddOrder(Customer customer) {

			Order order = new() {
				CustomerId = customer.CustomerId
			};

			return crudOperationsOrder.AddOrder(order);
		}

		public int GetNumberOfItems() {

			bool numInputIsEmpty = true;
			int userPizzaCount = 0;

			while (numInputIsEmpty) {
				Console.WriteLine("Type the number of pizzas you want");
				string countAsString = Console.ReadLine();

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
	}
}