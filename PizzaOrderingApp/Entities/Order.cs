using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Entities {
	public class Order {
		public int OrderId { get; set; }
		public int CustomerId { get; set; }
		public Customer? Customer { get; set; }

		
		public ICollection<Pizza_Order>? Pizza_Order { get; set; }
	}
}
