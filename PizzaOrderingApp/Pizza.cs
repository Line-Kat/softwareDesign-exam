using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp {
	public class Pizza {

		public int? Id { get; set; }
		public string? PizzaName { get; set; }
		public int Price { get; set; }

		public Pizza() {
			Id = 0;
			PizzaName = null;
			Price = 0;
		}

		public Pizza(int a, string b, int c) {
			Id = a;
			PizzaName = b;
			Price = c;
		}

	}
}
