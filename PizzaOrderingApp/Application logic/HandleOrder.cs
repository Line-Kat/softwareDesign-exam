using System.Threading.Tasks;
using PizzaOrderingApp.Entities;

namespace PizzaOrderingApp {
	public class HandleOrder {

		public void printOrder(Customer customer, DateTime dateTime) {
			//henter bestillingen fra cart klassen (mat/drikke, totalsum)
			string name = customer.CustomerName;

			Console.WriteLine($"Thank you for ordering from Pizza Factory! Here is your receipt:\n" +
				$"Name: {customer.CustomerName}\n" +
				$"Your order is ready for pick up at {dateTime}\n" +
				"Welcome back another time!");
		}

		public Order addOrder(Customer customer) {

			Order order = new() {
				CustomerId = customer.CustomerId
			};
		
			using PizzaOrderingDbContext db = new ();

			db.Order.Add(order);
			db.SaveChanges();
		

			return order;
		}
	}
}
