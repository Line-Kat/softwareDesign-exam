using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaOrderingApp.Entities;
using PizzaOrderingApp.Technical_services;

namespace PizzaOrderingApp.UnitTesting {
	public class UnitTests {

		[Test]
		public void AddCustomer_AddingCustomerToDb_ReturnsCustomer() {
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
}
