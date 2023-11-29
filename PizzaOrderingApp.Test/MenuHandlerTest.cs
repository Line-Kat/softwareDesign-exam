using PizzaOrderingApp.Application_logic.Decorators;
using PizzaOrderingApp.Application_logic.MenuHandler;
using PizzaOrderingApp.Application_logic.MenuHandler.Decorators;
using PizzaOrderingApp.Entities;
using PizzaOrderingApp.Technical_services.CRUD;
using Moq;

namespace PizzaOrderingApp.UnitTests
{
	//Tests for menu part of the program
	public class MenuHandlerTest
	{
		private DisplayMenus _displayMenus;
		private PizzaToppingSelectionHandler _toppingHandler;
		private PizzaToppingDecorator _decorator;
		private IPizza _basePizza;
		private PizzaMenu _pizzaMenu;

		[SetUp]
		public void Setup()
		{
			_displayMenus = new DisplayMenus();
			_toppingHandler = new PizzaToppingSelectionHandler();
			_basePizza = new Pizza { PizzaName = "Basic Pizza", Price = 100, Description = "Base pizza" };
			_decorator = new PizzaToppingDecorator(_basePizza);
			_pizzaMenu = new PizzaMenu();

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

		[Test]
		public void AddPizzas_AddsNewPizzasToDatabase()
		{
			// Arrange
			var crudOperations = new CrudOperationsMenu();
					var newPizzas = new List<Pizza>
			{
				new Pizza { PizzaName = "Margarita", Price = 99, Description = "Tomato sauce, cheese" },
				new Pizza { PizzaName = "Pepperoni", Price = 149, Description = "Tomato sauce, cheese, pepperoni" },
				new Pizza { PizzaName = "Vegan deluxe", Price = 129, Description = "Tomato sauce, vegan cheese, peppers, olives"},
				new Pizza { PizzaName = "Hawaiian dream", Price = 149, Description = "Tomato sauce, cheese, pineapple, ham"}
			};

			// Act
			crudOperations.AddPizzas(newPizzas);

			// Assert
			using var db = new PizzaOrderingDbContext();
			foreach (var pizza in newPizzas)
			{
				var dbPizza = db.Pizza.FirstOrDefault(p => p.PizzaName == pizza.PizzaName);
				Assert.That(dbPizza, Is.Not.Null); // Check each pizza was added
			}
		}

	}
}