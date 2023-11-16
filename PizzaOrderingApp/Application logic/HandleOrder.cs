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
	}
}
