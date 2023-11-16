using NUnit.Framework;
using Moq;
using PizzaOrderingApp.Application_logic.MenuHandler;
using PizzaOrderingApp.Application_logic.MenuHandler.Decorators;
using PizzaOrderingApp.Entities;
using System;

namespace PizzaOrderingApp.UnitTests
{
	public class DisplayMenusTests
	{
		private Mock<IPizzaMenuService> _mockPizzaMenuService;
		private DisplayMenus _displayMenus;

		[SetUp]
		public void Setup()
		{
			_mockPizzaMenuService = new Mock<IPizzaMenuService>();
			_displayMenus = new DisplayMenus(new PizzaMenu(_mockPizzaMenuService.Object));
		}

		[Test]
		public void DisplayMenus_UserSelectsPizzaMenu_CallsDisplayPizzaMenu()
		{
			// Arrange
			_mockPizzaMenuService.Setup(m => m.DisplayMenu()).Verifiable();

			// Act
			_displayMenus.PrintMenu();
			// Simulerer at brukeren velger "1" for pizza meny
			_displayMenus.HandleUserInput("1");

			// Assert
			_mockPizzaMenuService.Verify(m => m.DisplayMenu(), Times.Once);
		}
	}
}
