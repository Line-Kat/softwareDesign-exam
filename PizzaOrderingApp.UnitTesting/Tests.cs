using Moq;
using NUnit.Framework;
using PizzaOrderingApp.MenuHandler;
using System.Collections.Generic;

namespace PizzaOrderingApp.Tests
{
	[Test]
	public void AddCustomer_AddingCustomerToDb_ReturnsCustomer()
	{
		//Arrange
		CrudOperationsCustomer crudOperationsCustomer = new();
		string expectedName = "Dutleif";

		//Act
		Customer customer = crudOperationsCustomer.AddCustomer(new() { CustomerName = "Dutleif" });
		string actualName = customer.CustomerName;

		//Assert
		Assert.That(actualName, Is.EqualTo(expectedName));
	}
}
