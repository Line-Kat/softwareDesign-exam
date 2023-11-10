using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaOrderingApp.Entities;
namespace PizzaOrderingApp
{
    public class ShoppingCart {


        //Lager en liste for å holde på elementer
        public List<CartItem> pizzaItems = new List<CartItem>();


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
            try
            {

                using (var db = new PizzaOrderingDbContext())

                {
                    Console.WriteLine("Enter the id of the pizza you would like to add to cart");
                    int pizzaId = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the quantity of how many pizzas you would like");
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the size of pizza S/L");
                    string size = Console.ReadLine();

                    var selectedPizza = db.Pizza.Find(pizzaId);

                    if (selectedPizza != null)
                    {
                        CartItem? cartItem = new CartItem(selectedPizza, quantity);
                        pizzaItems.Add(cartItem);

                        Console.WriteLine($"Pizza: {selectedPizza} with quantity: {quantity} is added to your cart");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input or spelling mistake, please try again");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error, the pizza could not be added to cart");
                Console.WriteLine(ex.Message);
            }
        }


    
        //Kilde: forelesning EFCoreExample, writeEduaction metoden
        public void ViewCart()
        {
            Console.WriteLine("Your Shoppingcart:  ");

            foreach (var cartItem in pizzaItems)
            {

                Console.WriteLine($"Pizza id: {cartItem.PizzaId}");
                Console.WriteLine($"Quantity: {cartItem.Quantity}");
                //Console.WriteLine($"Size: {pizzaItem.Size}");

            }
            CartMenu();
        }

        public void RemovePizzaFromCart()
        {
            try { 
                Console.WriteLine("Write the Id of the pizza you would like to remove from your shoppingcart: ");
                int selectedPizzaId = Convert.ToInt32(Console.ReadLine());

                CartItem? pizzaToRemove = null;
                foreach(var item in pizzaItems)
                {
                    if(item.PizzaId == selectedPizzaId)
                    {
                        pizzaToRemove = item;
                        break;
                    }
                }

                if (pizzaToRemove != null)
                {
                    pizzaItems.Remove(pizzaToRemove);
                    Console.WriteLine($"Pizza with id: {selectedPizzaId} is removed from shoppingcart");
                }
                else
                {
                    Console.WriteLine($"Pizza with id: {selectedPizzaId} could not be found/removed from shoppingcart, please try again");
                    RemovePizzaFromCart();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error, could not remove pizza");
                Console.WriteLine(ex.Message);
            }
            CartMenu();
                
            }


            /*
            public void EditCart()
            {

            }
            */
        }

    }


	


