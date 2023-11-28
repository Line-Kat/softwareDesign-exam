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
	public class TestPizza : IPizza
	{
		public int PizzaId { get; }
		public string PizzaName { get; }
		public int Price { get; }
		public string Description { get; }

		public TestPizza(int pizzaId, string pizzaName, int price)
		{
			PizzaId = pizzaId;
			PizzaName = pizzaName;
			Price = price;
			Description = "";
		}
	}

	internal class CartTests
	{
		[Test]
		public void TestAddPizzaToCart_WithValidPizza_AddsPizza()
		{
			ShoppingCart cart = new ShoppingCart();
			IPizza pizza = new TestPizza(1, "Margherita", 100);

			cart.AddPizzaToCart(pizza);

			Assert.That(cart.Items.Count, Is.EqualTo(1));
			Assert.That(cart.Items[0]?.PizzaId, Is.EqualTo(pizza.PizzaId));
		}
	

	[Test]
	public void RemovePizzaFromCart_WithValidId_RemovesPizza()
	{
		ShoppingCart cart = new ShoppingCart();
		TestPizza pizza = new TestPizza(1, "Margherita", 100); 

		cart.AddPizzaToCart(pizza);
		cart.RemovePizzaFromCart(pizza.PizzaId);

		Assert.That(cart.Items, Is.Empty);
	}


		[Test]
		public void TestEditCart_WithValidIdAndQuantity_UpdatesQuantity()
		{
			ShoppingCart cart = new ShoppingCart();
			IPizza pizza = new TestPizza(1, "Margherita", 100); // Bruker TestPizza som en implementasjon av IPizza

			cart.AddPizzaToCart(pizza);
			cart.EditCart(pizza.PizzaId, 3);

			Assert.That(cart.Items[0]?.Quantity, Is.EqualTo(3));
		}
	}
}
