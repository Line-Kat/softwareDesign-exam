using PizzaOrderingApp;
namespace PizzaOrderingApp.UnitTest;

public class Tests
{

    
    [Test]
    public void AddPizzaToCart_ValidInput_AddsFromDbToList()
    {

        //Assign
        var shoppingCart = new ShoppingCart();
        //var dbContext = new PizzaOrderingDbContext();

        //Act

        //paramterene her er pizzaId, quantity og size
        shoppingCart.AddPizzaToCart(1,3, "S");

        //Assert
        Assert.That(shoppingCart.GetCartItems().Count, Is.EqualTo(1));
    }

    [Test]
    public void RemovePizzaFromCart_ValidInput_RemovesPizzaFromList()
    {
        //Assign
        var shoppingCart = new ShoppingCart();
        var pizzaId = 1;
        shoppingCart.AddPizzaToCart(pizzaId, 3, "L");

        //Act
        shoppingCart.RemovePizzaFromCart(pizzaId);

        //Assert
        Assert.That(shoppingCart.pizzaItems.Count, Is.EqualTo(0));
    }

    [Test]
    public void EditCart_ValidInput_EditsPizzaFromList()
    {
        //Assign

        //Act

        //Assert
    }


    [Test]
    public void ViewCart_ValidInput_UserViewsCart()
    {
        //Assign

        //Act

        //Assert
    }
}
