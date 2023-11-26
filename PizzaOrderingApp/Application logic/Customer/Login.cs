using Microsoft.EntityFrameworkCore;
using PizzaOrderingApp.Entities;
using PizzaOrderingApp.Technical_services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp {
	public class Login {
		//This method is called by the method UserLogin
		//Writes messages to the console and gets input from the user
		//The input is returned to UserLogin
		//The method validates that userinput is correct by using whileloops with a bool condition that is set to false when the input is correct
		internal string LoginMenu(string type) {
			bool keepRunning = true;
			string returnString = string.Empty;

			if (type.Equals("login")) {
				while(keepRunning) {
					Console.WriteLine("Choose an option\n1 Login\n2 Register a new user");

					returnString = Console.ReadLine();

					if (returnString.Equals("1") || returnString.Equals("2")) {
						keepRunning = false;
					}
				}
			}

			if (type.Equals("phoneNr")) {
				while(keepRunning) {
					Console.WriteLine("Please enter your phone number: ");

					returnString = Console.ReadLine();
					int userInput = 0;

					if (!int.TryParse(returnString, out userInput)) {
						Console.WriteLine("You must type a phone number");
					} else {
						keepRunning = false;
					}
				}
			}
		
			return returnString;
		}


		//This method asks if the user wants to log in or register a new user
		//To get input from the user, the method LoginMenu is called
		
		//The user logs in with phone number
		//To check if the user is registered, the the method GetCustomerByPhoneNumber is called
		//If the phone number is registered, the user gets logged in
		//If the phone number is not registered, the user is asked to registered and the method AddCustomer is called

		//If the user chooses to register from the menu presented, the the method AddCustomer is called
		public Customer UserLogin() {
			HandleCustomer handleCustomer = new();
			CrudOperationsCustomer crudOperations = new();
			Customer customer = new();

			
			//string? userInput = string.Empty;

			string userInput = LoginMenu("login");

			if(userInput.Equals("1")) {
				int inputNumber = Convert.ToInt32(LoginMenu("phoneNr"));
				customer = crudOperations.GetCustomerByPhoneNr(inputNumber);

				if (customer == null) {
					Console.WriteLine("You are not registered");
					customer = handleCustomer.AddCustomer();
				}
			}

			if (userInput.Equals("2")) {
				 customer = handleCustomer.AddCustomer();
			}

			return customer;
		}
		
	}
}
