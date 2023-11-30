using PizzaOrderingApp.Application_logic.CartHandler;
using PizzaOrderingApp.Entities;
using PizzaOrderingApp.Technical_services.CRUD;

namespace PizzaOrderingApp {

	public class HandleOrder {

		CrudOperationsOrder crudOperationsOrder = new();

		//Method to print the receipt to the customer
		public void PrintOrder(Customer customer, DateTime dateTime, int totalToPay, List<CartItem> cartItems) {

			Console.WriteLine($"\nThank you for ordering from Pizza Factory! Here is your receipt:\n" +
				$"Name: {customer.CustomerName}\n" +
				"\nYour order:");

			foreach (var item in cartItems) {
				Console.WriteLine($"{item.Quantity} {item.Pizza.PizzaName}");
			}

			Console.WriteLine(
				$"\nTotal sum: {totalToPay} kr\n" +
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
	}
}