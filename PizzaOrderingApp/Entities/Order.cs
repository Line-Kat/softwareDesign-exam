using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Entities {
	public class Order {
		public int OrderId { get; set; }

		//Foreign key
		public int CustomerId { get; set; }

		//Order has a customer
		public Customer? Customer { get; set; }

		//har en relasjon til tabellen Pizza_Order
		public ICollection<Pizza_Order>? Pizza_Order { get; set; }
	}
}
