using PizzaOrderingApp.Application_logic.Decorators;
using PizzaOrderingApp.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PizzaOrderingApp.Application_logic.CartHandler
{
	public class ShoppingCart
	{

		//a list to store the pizzas
		public List<CartItem?> Items { get; } = new List<CartItem?>();

		public ShoppingCart()
		{
			Items = new List<CartItem?>();
		}

	

		//method that adds a pizza to the list. Checks if the pizza exist or not.
		//Also checks if the pizza with the same id already exists in the cart, and if so - adds it to the quantity
		public void AddPizzaToCart(IPizza pizza, int numberOfToppings)
		{
			int extraToppingsCost = numberOfToppings * 30;
			if (pizza != null)
			{
				bool pizzaExists = false;

				foreach (CartItem? item in Items)
				{
					if (item?.PizzaId == pizza.PizzaId)
					{
						item.Quantity++;
						item.UpdateExtraToppingsCost(numberOfToppings);
						pizzaExists = true;
						break; 
					}
				}

				if (!pizzaExists)
				{
					CartItem cartItem = new CartItem(pizza.PizzaId, pizza.PizzaName, 1, pizza.Price);
					cartItem.UpdateExtraToppingsCost(numberOfToppings);
					Items.Add(cartItem);
				}

				Console.WriteLine($"{pizza.PizzaName} added to the cart.");
			}
			else
			{
				Console.WriteLine("Error: Could not add pizza to the cart.");
			}
		}


		//method that shows the pizzas in the shoppingCart(list) using a foreach to go through each item in the shoppingCart. 
		public void ViewCart()
		{
			
			Console.WriteLine("Your shoppingCart: ");
			foreach (CartItem? item in Items)
			{
				
				Console.WriteLine(item.ToString());
			}
			int totalCost = Items.Sum(item => (item.Price + item.ExtraToppingsCost * item.Quantity));
			Console.WriteLine($"Total cost: {totalCost} kr");
		}


		//method that removes a pizza from cart using id, it searches through the list of cart items to find the matching pizza. 
		public void RemovePizzaFromCart(int pizzaId)
		{
			CartItem? itemToRemove = null;
			foreach (CartItem? item in Items)
			{
				if (item?.PizzaId == pizzaId)
				{
					itemToRemove = item;
					break;
				}
			}

			if (itemToRemove != null)
			{
				Items.Remove(itemToRemove);
				Console.WriteLine($"Pizza with number {pizzaId} has been removed from the shopping cart.");
			}
			else
			{
				Console.WriteLine($"Could not find a pizza with number {pizzaId} in the shopping cart.");
			}
		}

		//method that modifies the quantity of a pizza using id, and searches through the list to find the matching pizza.
		//if the id matches the quantity is updated
		public void EditCart(int pizzaId, int newQuantity, int numberOfToppings)
		{
			if (newQuantity > 0)
			{
				bool itemFound = false;

				foreach (CartItem? item in Items)
				{
					if (item?.PizzaId == pizzaId)
					{
						item.Quantity = newQuantity;
						item.UpdateExtraToppingsCost(numberOfToppings);
						Console.WriteLine($"Quantity for pizza with number {pizzaId} has been changed to {newQuantity}.");
						itemFound = true;
						break; 
					}
				}

				if (!itemFound)
				{
					Console.WriteLine($"Could not find a pizza with number {pizzaId} to change the quantity.");
				}
			}
			else
			{
				Console.WriteLine("Invalid quantity, please enter a positive number.");
			}
		}

	}
}
