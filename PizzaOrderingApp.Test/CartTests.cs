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
namespace PizzaOrderingApp.Test

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

		//Denne testen funker
		[Test]
		public void TestAddPizzaToCart_WithValidPizza_AddsPizza()
		{
			// Arrange
			ShoppingCart cart = new ShoppingCart();
			TestPizza pizza = new TestPizza(1, "Margherita", 100);

			// Act
			cart.AddPizzaToCart(pizza);

			// Assert
			Assert.That(cart.Items.Count, Is.EqualTo(1));
			Assert.That(cart.Items[0]?.PizzaId, Is.EqualTo(pizza.PizzaId));
		}


		//Denne testen bare står å loeader
		[Test]
		public void TestRemovePizzaFromCart_WithValidId_RemovesPizza()
		{
			// Arrange
			ShoppingCart cart = new ShoppingCart();
			TestPizza pizza = new TestPizza(1, "Margherita", 100);
			cart.AddPizzaToCart(pizza);

			// Act
			cart.RemovePizzaFromCart(pizza.PizzaId);

			// Assert
			Assert.That(cart.Items, Is.Empty);
		}

		//står bare å loader

		[Test]
		public void TestEditCart_WithValidIdAndQuantity_UpdatesQuantity()
		{
			// Arrange
			ShoppingCart cart = new ShoppingCart();
			TestPizza pizza = new TestPizza(1, "Margherita", 100);
			cart.AddPizzaToCart(pizza);

			// Act
			cart.EditCart(pizza.PizzaId, 3);

			// Assert
			Assert.That(cart.Items[0]?.Quantity, Is.EqualTo(3));
		}
	}
}

		//Denne testen funket, men den tester bare om noe blir lagt til i listen,
		//men bruker ingentin fra IPizza

		/*[Test]
		public void TestAddPizzaToCart_WithValidPizza_AddsPizza()
		{
			ShoppingCart cart = new ShoppingCart();

			// Manually adding a CartItem to the cart's Items list
			CartItem newItem = new CartItem(1, "Margherita", 1, 100);
			cart.Items.Add(newItem);

			// Assert that the pizza has been added
			Assert.That(cart.Items.Count, Is.EqualTo(1));
			Assert.That(cart.Items[0].PizzaId, Is.EqualTo(newItem.PizzaId));
		}*/
	