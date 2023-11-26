using PizzaOrderingApp;

namespace PizzaOrderingApp.UnitTesting {
	public class Tests {
		
		[Test]
		public void CustomerInsertAndSelect_OneCustomerRow_ReturnNameOfCustomer() {
			//Arrange
			string expectedName = "Kristian";

			//Act
			using PizzaOrderingDbContext db = new();
			db.Customer.Add(new() { CustomerName = expectedName });
			db.SaveChanges();
			string actualName = db.Customer.Single().CustomerName;

			//Assert
			Assert.That(actualName, Is.EqualTo(expectedName));
		}
	}
}