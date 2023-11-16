using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Entities {

	public class Pizza_Order {
		[Key]
		public int PizzaOrderId { get; set; }
		public int OrderId { get; set; }
		public int PizzaId { get; set; }


		public Order? Order { get; set; }
		public Pizza? Pizza { get; set; }
	}
}
