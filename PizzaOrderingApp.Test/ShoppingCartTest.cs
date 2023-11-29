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
namespace PizzaOrderingApp.Test {

	public class ShoppingCartTest {

		[Test]
		public void TestAddPizzaToCart_WithValidPizza_AddsPizza() {
			// Arrange
			ShoppingCart shoppingCart = new();


			Pizza pizza = new() {
				PizzaName = "Chicken",
				Price = 100,
				Description = "Chicken, cheese"
			};

			// Act
			shoppingCart.AddPizzaToCart(pizza);

			// Assert
			Assert.That(shoppingCart.Items.Count, Is.EqualTo(1));
			Assert.That(shoppingCart.Items[0]?.PizzaId, Is.EqualTo(pizza.PizzaId));
		}


		[Test]
		public void TestRemovePizzaFromCart_WithValidId_RemovesPizza() {
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
		public void TestEditCart_WithValidIdAndQuantity_UpdatesQuantity() {
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