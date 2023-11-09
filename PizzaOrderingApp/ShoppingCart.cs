using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaOrderingApp.Entities;
namespace PizzaOrderingApp
{
	public class ShoppingCart
	{
        //database variabel
        private PizzaOrderingDbContext dbContext;

        //Lager en liste for å holde på elementer
        public List<CartItem> pizzaItems = new List<CartItem>();


        //kontruktør for databasen
        public ShoppingCart()
        {
            dbContext = new PizzaOrderingDbContext();
        }


        public void CartInteraction()
        {
            Console.WriteLine("Do you want to 1) add pizza to cart. 2) See cartMenu");
            string Choice = Console.ReadLine();
            if (Choice == "1")
            {
                AddPizzaToCart();
            }
            if (Choice == "2")
            {
                CartMenu();
            }

        }

        public void CartMenu()
        {

            Console.WriteLine("Do you want to 1) continue shopping. 2) view your cart. 3) remove from cart 4) Exit shoppingcart 5) edit cart. Type in option 1, 2, 3, 4 or 5");
            string shoppingChoice = Console.ReadLine();

            if (shoppingChoice == "1")
            {
                AddPizzaToCart();

            }
            if (shoppingChoice == "2")
            {
                ViewCart();

            }
            if (shoppingChoice == "3")
            {
                RemovePizzaFromCart();
            }
            if (shoppingChoice == "4")
            {
                //ExitShoppingCart
            }
            if (shoppingChoice == "5")
            {
                //EditCart();
            }
        }


        //Må legge til størrelse her
        //Lager metode for å legge til pizza i handlekurven
        //Kilde: forelesning EFCoreExample
        //burde kanskje lage en loop istedenfor å kalle på alle metodene?
        public void AddPizzaToCart()
        {
            int selectedPizza;
            while (true)
            {

                Console.Write("Write the Id of the pizza you would like to add to your shoppingcart: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out selectedPizza))
                {
                    Pizza pizzaAddToCart = dbContext.Pizza.FirstOrDefault(item => item.PizzaId == selectedPizza);

                    if (pizzaAddToCart != null)
                    {
                        Console.WriteLine("Enter the quantity of the pizza: ");
                        if (int.TryParse(Console.ReadLine(), out int quantity))
                        {
                            Console.WriteLine("Enter the size of pizza you would like: ");
                            /*if(int.TryParse(Console.ReadLine() size))*/
                            {

                                CartItem cartItem = new CartItem { Pizza = pizzaAddToCart, Quantity = quantity };
                                pizzaItems.Add(cartItem);
                                Console.WriteLine("The pizza was added to your shoppingcart");
                                CartMenu();
                            }
                        }
                        else
                        {
                            Console.WriteLine("error, please try again");
                            AddPizzaToCart();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error, please try again");
                        AddPizzaToCart();
                    }
                }
            }
        }

        //Kilde: forelesning EFCoreExample, writeEduaction metoden
        public void ViewCart()
        {
            Console.WriteLine("Your Shoppingcart:  ");

            foreach (var cartItem in pizzaItems)
            {

                Console.WriteLine($"Pizza id: {cartItem.Pizza.PizzaId}");
                Console.WriteLine($"Quantity: {cartItem.Quantity}");
                //Console.WriteLine($"Size: {pizzaItem.Size}");

            }
            CartMenu();
        }

        public void RemovePizzaFromCart()
        {
            int selectedPizzaId;
            Console.WriteLine("Write the Id of the pizza you would like to remove from your shoppingcart: ");
            string removePizzaInput = Console.ReadLine();

            if (int.TryParse(removePizzaInput, out selectedPizzaId))
            {

                CartItem pizzaToRemove = pizzaItems.FirstOrDefault(item => item.PizzaId == selectedPizzaId);

                if (pizzaToRemove != null)
                {
                    pizzaItems.Remove(pizzaToRemove);
                    Console.WriteLine($"Pizza with id: {selectedPizzaId} is removed from shoppingcart");
                    CartMenu();
                }
                else
                {
                    Console.WriteLine($"Pizza with id: {selectedPizzaId} could not be found/removed from shoppingcart, please try again");
                    RemovePizzaFromCart();
                }
            }
            else
            {
                Console.WriteLine("Error, please try again");
                RemovePizzaFromCart();
            }
            /*
            public void EditCart()
            {

            }
            */
        }

    }
}

	


