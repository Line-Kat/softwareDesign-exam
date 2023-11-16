
using NUnit.Framework;
using PizzaOrderingApp.Entities;
using Microsoft.EntityFrameworkCore;
using PizzaOrderingApp;


namespace PizzaOrderingApp.IntegrationTest
{

    //kilde: forelesning 11 IntegrationTest, slide 18. 

    public class ShoppingCartIntegrationTests
    {
        const string _connectionString = @"Data Source = Resources\PizzaOrderingDbContext.db";

        [Test]
        public void AddPizzaToCart_ValidInput_PizzaAddedToListFromDb()
        {
            //Arrange

            //Here we write what we expect to find
            int expectedPizzaId = 2;

            int expectedQuantity = 2;

            string expectedSize = "S";

            //Act
            using (PizzaOrderingDbContext db = new()) { 
            db.Pizza.Add(new() { PizzaId = expectedPizzaId, Quantity = expectedQuantity, Size = expectedSize });
            db.SaveChanges();

            int actualPizzaId = db.Pizza.Single().PizzaId;
            int actualQuantity = db.Pizza.Single().Quantity;
            string actualSize = db.Pizza.Single().Size;

            //Assert
            Assert.That(actualPizzaId, Is.EqualTo(expectedPizzaId));
            Assert.That(actualQuantity, Is.EqualTo(expectedQuantity));
            Assert.That(actualSize, Is.EqualTo(expectedSize));

            
        }
    }

        [Test]
        
}