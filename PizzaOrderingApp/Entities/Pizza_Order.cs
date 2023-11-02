using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Entities {

	//KOBLINGSTABELL
	public class Pizza_Order {
		//Primary key
		[Key]
		public int PizzaOrderId { get; set; }
		
		
		//Foreign key
		public int OrderId { get; set; }
		public int PizzaId { get; set; }

		//hvilke tabeller denne tabellen har en relasjon til
		public Order? Order { get; set; }
		public Pizza? Pizza { get; set; }

	}
}
