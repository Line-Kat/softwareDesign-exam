using NUnit.Framework;
using System.Collections.Generic;
using PizzaOrderingApp.Application_logic.Decorators;
using PizzaOrderingApp.Application_logic.MenuHandler;
using PizzaOrderingApp.Application_logic.MenuHandler.Decorators;
using PizzaOrderingApp.Entities;
using PizzaOrderingApp.Technical_services.CRUD;
using Moq;
using System.Linq;

namespace PizzaOrderingApp.UnitTests
{
	//Tests for menu part of the program
	public class MenuHandlerTest
	{
		private DisplayMenus _displayMenus;
		private PizzaToppingSelectionHandler _toppingHandler;
		private IPizza _pizza;
		private PizzaToppingDecorator _decorator;
		private IPizza _basePizza;
		private PizzaMenu _pizzaMenu;
		private Mock<CrudOperationsMenu> _mockCrudOperations;

		[SetUp]
		public void Setup()
		{
			_displayMenus = new DisplayMenus();
			_toppingHandler = new PizzaToppingSelectionHandler();
			_pizza = new Pizza { PizzaName = "Margherita", Price = 100, Description = "Tomato sauce, cheese" };
			_basePizza = new Pizza { PizzaName = "Basic Pizza", Price = 100, Description = "Base pizza" };
			_decorator = new PizzaToppingDecorator(_basePizza);
			_pizzaMenu = new PizzaMenu();

		/*	_mockCrudOperations = new Mock<CrudOperationsMenu>();
			_mockCrudOperations.Setup(c => c.GetAllPizzas()).Returns(new List<Pizza>
			{
				new Pizza { PizzaId = 1, PizzaName = "Margherita", Price = 100, Description = "Tomato sauce, cheese" },
            });

			*/
		}

		//Test: after creating a DisplayMenus object, calling the GetSelectedPizza method returns null, indicating no pizza has been selected yet
		[Test]
		public void GetSelectedPizza_Initially_ReturnsNull()
		{
			Assert.That(_displayMenus.GetSelectedPizza(), Is.Null);
		}

		//Test: checks that before any topping selection occurs, the GetFinalPizza method returns null
		[Test]
		public void GetFinalPizza_BeforeHandlingSelection_ReturnsNull()
		{
			IPizza finalPizza = _toppingHandler.GetFinalPizza();
			Assert.That(finalPizza, Is.Null);
		}

		//Test: checks if the topping is correctly added to the pizza's description
		[Test]
		public void AddTopping_IncreasesToppingCount()
		{
			_decorator.AddTopping("Cheese");
			Assert.That(_decorator.Description, Does.Contain("Cheese"));
		}

		//Test: ensures that the price is correctly calculated when a topping is added
		[Test]
		public void AddTopping_UpdatesPrice()
		{
			_decorator.AddTopping("Cheese");
			int expectedPrice = 100 + 30; // Base price + 1 topping
			Assert.That(_decorator.Price, Is.EqualTo(expectedPrice));
		}

		//Test: verifies both the description and price are updated correctly when multiple toppings are added
		[Test]
		public void AddMultipleToppings_UpdatesDescriptionAndPrice()
		{
			_decorator.AddTopping("Cheese");
			_decorator.AddTopping("Tomato sauce");
			int expectedPrice = 100 + 30 * 2; // Base price + 2 toppings

			Assert.Multiple(() =>
			{
				Assert.That(_decorator.Description, Does.Contain("Cheese"));
				Assert.That(_decorator.Description, Does.Contain("Tomato sauce"));
				Assert.That(_decorator.Price, Is.EqualTo(expectedPrice));
			});
		}

		
	}
}