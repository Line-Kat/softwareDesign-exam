using PizzaOrderingApp.Application_logic.Decorators;
using PizzaOrderingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaOrderingApp.Application_logic.CartHandler
{
	public class ShoppingCart
	{
		private List<CartItem> items;

		public ShoppingCart()
		{
			items = new List<CartItem>();
		}

		public void AddPizzaToCart(IPizza pizza)
		{
			var existingItem = items.FirstOrDefault(i => i.PizzaId == pizza.PizzaId);
			if (existingItem != null)
			{
				existingItem.Quantity++;
			}
			else
			{
				CartItem cartItem = new CartItem(pizza.PizzaId, pizza.PizzaName, 1, pizza.Price);
				items.Add(cartItem);
			}
			Console.WriteLine($"{pizza.PizzaName} med {pizza.Description} til {pizza.Price} kr er lagt til i handlekurven.");
		}

		public void ViewCart()
		{
			Console.WriteLine("Din handlekurv:");
			foreach (var item in items)
			{
				Console.WriteLine($"{item.PizzaName}, Antall: {item.Quantity}, Pris: {item.Price * item.Quantity} kr");
			}
		}

		public void RemovePizzaFromCart(int pizzaId)
		{
			var itemToRemove = items.FirstOrDefault(i => i.PizzaId == pizzaId);
			if (itemToRemove != null)
			{
				items.Remove(itemToRemove);
				Console.WriteLine($"Pizza med ID {pizzaId} er fjernet fra handlekurven.");
			}
			else
			{
				Console.WriteLine($"Kunne ikke finne en pizza med ID {pizzaId} i handlekurven.");
			}
		}

		public void EditCart(int pizzaId, int newQuantity)
		{
			var itemToEdit = items.FirstOrDefault(i => i.PizzaId == pizzaId);
			if (itemToEdit != null)
			{
				itemToEdit.Quantity = newQuantity;
				Console.WriteLine($"Antallet for pizza med ID {pizzaId} er endret til {newQuantity}.");
			}
			else
			{
				Console.WriteLine($"Kunne ikke finne en pizza med ID {pizzaId} for å endre antallet.");
			}
		}

		//..

		public void RemovePizzaFromCartInteraction()
		{
			Console.WriteLine("Skriv inn ID for pizzaen du vil fjerne fra handlekurven:");
			if (int.TryParse(Console.ReadLine(), out int pizzaId))
			{
				var itemToRemove = items.FirstOrDefault(i => i.PizzaId == pizzaId);
				if (itemToRemove != null)
				{
					items.Remove(itemToRemove);
					Console.WriteLine($"Pizza med ID {pizzaId} er fjernet fra handlekurven.");
				}
				else
				{
					Console.WriteLine($"Kunne ikke finne en pizza med ID {pizzaId} i handlekurven.");
				}
			}
			else
			{
				Console.WriteLine("Ugyldig inntasting, vennligst prøv igjen.");
			}
		}

		public void EditCartInteraction()
		{
			Console.WriteLine("Skriv inn ID for pizzaen du vil endre i handlekurven:");
			if (int.TryParse(Console.ReadLine(), out int pizzaId))
			{
				Console.WriteLine("Skriv inn det nye antallet:");
				if (int.TryParse(Console.ReadLine(), out int newQuantity) && newQuantity > 0)
				{
					var itemToEdit = items.FirstOrDefault(i => i.PizzaId == pizzaId);
					if (itemToEdit != null)
					{
						itemToEdit.Quantity = newQuantity;
						Console.WriteLine($"Antallet for pizza med ID {pizzaId} er endret til {newQuantity}.");
					}
					else
					{
						Console.WriteLine($"Kunne ikke finne en pizza med ID {pizzaId} for å endre antallet.");
					}
				}
				else
				{
					Console.WriteLine("Ugyldig antall, vennligst prøv igjen.");
				}
			}
			else
			{
				Console.WriteLine("Ugyldig inntasting, vennligst prøv igjen.");
			}
		}
	}
}
