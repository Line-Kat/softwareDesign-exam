using PizzaOrderingApp.Application_logic.CartHandler;
using PizzaOrderingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaOrderingApp.Technical_services;
using PizzaOrderingApp.Application_logic.Decorators;

//source: lecture 5
namespace PizzaOrderingApp.UnitTesting
{

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

	[TestFixture]
	public class CartTests
	{

		[Test]
		public void TestAddPizzaToCart_WithValidPizza_AddsPizza()
		{
			// Arrange
			var shoppingCart = new ShoppingCart();
			var pizza = new MockPizza { PizzaId = 1, PizzaName = "TestPizza", Price = 100 };

			// Act
			shoppingCart.AddPizzaToCart(pizza);

			// Assert
			Assert.That(shoppingCart.Items.Count, Is.EqualTo(1));
			Assert.That(shoppingCart.Items[0].Pizza.PizzaId, Is.EqualTo(pizza.PizzaId));
			Assert.That(shoppingCart.Items[0].Pizza.PizzaName, Is.EqualTo(pizza.PizzaName));
		}

		// A mock-class for IPizza
		private class MockPizza : IPizza
		{
			public int PizzaId { get; set; }
			public string PizzaName { get; set; }
			public int Price { get; set; }
			public string Description { get; set; }
		}


		[Test]
		public void TestRemovePizzaFromCart_WithValidId_RemovesPizza()
		{
			// Arrange
			ShoppingCart shoppingCart = new();
			Pizza pizza = new();
			shoppingCart.AddPizzaToCart(pizza);

			// Act
			shoppingCart.RemovePizzaFromCart(pizza.PizzaId);

			// Assert
			Assert.That(shoppingCart.Items, Is.Empty);
		}

		[Test]
		public void TestEditCart_WithValidIdAndQuantity_UpdatesQuantity()
		{
			// Arrange
			ShoppingCart shoppingCart = new();
			Pizza pizza = new();
			shoppingCart.AddPizzaToCart(pizza);

			// Act
			shoppingCart.EditCart(pizza.PizzaId, 3);

			// Assert
			Assert.That(shoppingCart.Items[0]?.Quantity, Is.EqualTo(3));
		}
	}
}