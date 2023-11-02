using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Entities {
	public class Pizza {
		public int PizzaId { get; set; }
		public string? PizzaName { get; set; }
		public int Price { get; set; }
		public string? Description { get; set; }

		//relasjon til koblingstabellen
		public ICollection<Pizza_Order>? Pizza_Order { get; set; }
	}
}
