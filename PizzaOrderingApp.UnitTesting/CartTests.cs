using PizzaOrderingApp.Application_logic.CartHandler;
using PizzaOrderingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaOrderingApp.Technical_services;
using PizzaOrderingApp.Application_logic.Decorators;

namespace PizzaOrderingApp.UnitTesting
{

	//source: lecture 5
	

	internal class CartTests
	{
		[Test]
		public void TestAddPizzaToCart_WithValidPizza_AddsPizza()
		{
			ShoppingCart cart = new ShoppingCart();

			// Manually adding a CartItem to the cart's Items list
			CartItem newItem = new CartItem(1, "Margherita", 1, 100);
			cart.Items.Add(newItem);

			// Assert that the pizza has been added
			Assert.That(cart.Items.Count, Is.EqualTo(1));
			Assert.That(cart.Items[0].PizzaId, Is.EqualTo(newItem.PizzaId));
		}


/*
		[Test]
		public void TestRemovePizzaFromCart_RemovesItemSuccessfully()
		{
			ShoppingCart cart = new ShoppingCart();

			CartItem newItem = new CartItem(1, "Margherita", 1, 100);
			cart.Items.Add(newItem);

			cart.RemovePizzaFromCart(newItem.PizzaId);

			// Assert that the item has been removed
			Assert.That(cart.Items.Any(item => item.PizzaId == newItem.PizzaId), Is.False);
		}

		*/


		[Test]
		public void TestEditCart_WithValidIdAndQuantity_UpdatesQuantity()
		{
			ShoppingCart cart = new ShoppingCart();

			CartItem newItem = new CartItem(1, "Margherita", 1, 100);
			cart.Items.Add(newItem);

			
			cart.EditCart(newItem.PizzaId, 3);

			// Assert
			Assert.That(cart.Items[0].Quantity, Is.EqualTo(3));
		}
	}
}