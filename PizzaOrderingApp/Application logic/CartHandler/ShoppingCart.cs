using PizzaOrderingApp.Application_logic.Decorators;
using PizzaOrderingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaOrderingApp.Application_logic.CartHandler
{
	public class ShoppingCart
	{
		public List<CartItem> Items { get; } = new List<CartItem>();

		//method that adds a pizza to the list. Checks if the pizza exist or not.
		//Also checks if the pizza with the same id already exists in the cart, and if so - adds it to the quantity
		public void AddPizzaToCart(IPizza pizza, int quantity = 1)
		{
			var existingItem = Items.FirstOrDefault(item => item.Pizza.PizzaId == pizza.PizzaId);

			if (existingItem != null)
			{
				existingItem.Quantity += quantity;
			}
			else
			{
				Items.Add(new CartItem(pizza, quantity));
			}

			Console.WriteLine($"{pizza.PizzaName} added to the cart.");
		}

		//method that shows the pizzas in the shoppingCart(list) 
		public void ViewCart()
		{
			Console.WriteLine("Your shoppingCart: ");
			foreach (CartItem item in Items)
			{
				Console.WriteLine($"{item.Pizza.PizzaName}, Quantity: {item.Quantity}, Total Price: {item.TotalPrice} kr");
			}
		}

		//Method that calculates and returns the total number of pizzas ordered
		public int TotalNumberOfPizzas()
		{
			return Items.Sum(item => item.Quantity);
		}

		//Method that calculates and returns the total sum of the order
		public int TotalToPay()
		{
			return Items.Sum(item => item.TotalPrice);
		}

		public List<CartItem> GetCartItems()
		{
			return Items;
		}

		//method that removes a pizza from cart using id
		public void RemovePizzaFromCart(int pizzaId)
		{
			var itemToRemove = Items.FirstOrDefault(item => item.Pizza.PizzaId == pizzaId);

			if (itemToRemove != null)
			{
				Items.Remove(itemToRemove);
				Console.WriteLine($"Pizza number {pizzaId} has been removed from the shopping cart.");
			}
			else
			{
				Console.WriteLine($"Could not find a pizza with number {pizzaId} in the shopping cart.");
			}
		}

		//method that modifies the quantity of a pizza using id
		public void EditCart(int pizzaId, int newQuantity)
		{
			if (newQuantity > 0)
			{
				var itemToEdit = Items.FirstOrDefault(item => item.Pizza.PizzaId == pizzaId);

				if (itemToEdit != null)
				{
					itemToEdit.Quantity = newQuantity;
					Console.WriteLine($"Quantity for pizza number {pizzaId} has been changed to {newQuantity}.");
				}
				else
				{
					Console.WriteLine($"Could not find pizza number {pizzaId} to change the quantity.");
				}
			}
			else
			{
				Console.WriteLine("Invalid quantity, please enter a number.");
			}
		}
	}
}
