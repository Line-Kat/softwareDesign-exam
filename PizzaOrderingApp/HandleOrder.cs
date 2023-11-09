using System.Threading.Tasks;
using PizzaOrderingApp.Entities;

namespace PizzaOrderingApp {
	public class HandleOrder {

		public void printOrder(Customer customer, DateTime dateTime) {
			//kundenavn
			//henter bestillingen fra cart klassen (mat/drikke, totalsum
			//tidspunkt fra PizzaQueue
			string name = customer.CustomerName;

			Console.WriteLine($"Thankyou for ordering from Pizza Factory! Here is your receipt:\n" +
				$"Name: {customer.CustomerName}\n" +
				$"Your order is ready for pick up at {dateTime}");

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
