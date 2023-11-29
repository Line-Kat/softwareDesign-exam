using PizzaOrderingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Application_logic.CartHandler
{
	public class CartItem
	{
		public int PizzaId { get; set; }
		public int Quantity { get; set; }
		public string PizzaName { get; set; }
		public int Price { get; set; }

		public string Description { get; set; }
		public int ExtraToppingsCost { get; set; } = 0;
		public int NumberOfToppings { get; set; } = 0;


		public CartItem(int pizzaId, string pizzaName, int quantity, int price)
		{
			PizzaId = pizzaId;
			PizzaName = pizzaName;
			Quantity = quantity;
			Price = price;
		
		}
		public void UpdateExtraToppingsCost(int numberOfToppings)
		{
			ExtraToppingsCost = numberOfToppings * 30;
		}


		public override string ToString()
		{
			int totalItemPrice = Price + ExtraToppingsCost;
			return $"{PizzaName}, Quantity: {Quantity}, Price: {totalItemPrice} kr";
		}
	}
	}

