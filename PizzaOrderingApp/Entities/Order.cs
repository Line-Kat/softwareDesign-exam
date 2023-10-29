using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Entities {
	public class Order {
		public int Id { get; set; }

		//Foreign key
		public int CustomerId { get; set; }

		public Customer? Customer { get; set; }
	}
}
