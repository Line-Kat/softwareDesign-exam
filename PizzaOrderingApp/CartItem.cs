
using System;
using PizzaOrderingApp.Entities;

namespace PizzaOrderingApp
{
	public class CartItem
	{
		Pizza pizza = new();
        public int PizzaId { get; set; }
        public int Quantity { get; set; }

        public CartItem(Pizza pizza, int quantity)
        {
            this.pizza = pizza;
            Quantity = quantity;
        }

        


       /* public int PizzaId { get; set; }
		
		public string Size { get; set; }*/
	}
}

