using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp {
	public class Cart {

		public List<Pizza> PizzaMenu { get; set; }
		public List<Pizza> InCart { get; set; }
		

		public Cart() {
			InCart = new List<Pizza>();
			PizzaMenu = new List<Pizza>();
		}

		/*
		method for listing items (+ pay?)(or combine in "order" class)
		*/

		public int Pay() {
			int total = 0;

			foreach (var c in InCart) {
				total += c.Price;
			}

			InCart.Clear();
			return total;
		}
		
	}
}
