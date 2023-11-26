using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PizzaOrderingApp.Entities;
using PizzaOrderingApp.Technical_services;

namespace PizzaOrderingApp {
	public class HandleCustomer {

		CrudOperationsCustomer crudOperationsCustomer = new();

		//Method to print output to the console and collect input from the user
		//The input is validated before creating an object of type Customer that is returned
		internal Customer AskForUserInput() {
			string? userInputName = string.Empty;
			string? userInputPhoneNr = string.Empty;

			while (string.IsNullOrEmpty(userInputName)) {
				Console.WriteLine("Type name: ");
				userInputName = Console.ReadLine();
			}
			 
			while (string.IsNullOrEmpty(userInputPhoneNr) || !int.TryParse(userInputPhoneNr, out int userInputInt)) {
				Console.WriteLine("Type phone number: ");
				userInputPhoneNr = Console.ReadLine();
			}

			int phoneNr = Convert.ToInt32(userInputPhoneNr);

			return new() { CustomerName = userInputName, PhoneNr = phoneNr };
		}

		//Method to add a customer to the database by calling AskForUserInput to get input from the user, and calling AddCustomer
		//to add the customer to the database
		//The method also asks the user to validate the information
		public Customer AddCustomer() {
			Customer customer = AskForUserInput();

			ConfirmAddCustomer(customer);

			return crudOperationsCustomer.AddCustomer(customer);
		}

		internal void ConfirmAddCustomer(Customer customer) {
			Console.WriteLine($"Your information:\nName: {customer.CustomerName}\nPhone number: {customer.PhoneNr}");

			bool inputHasNoValue = true;
			string? userInput = string.Empty;

			while (inputHasNoValue) {
				if ((userInput.ToUpper().Equals("N")) || (userInput.ToUpper().Equals("Y"))) {
					inputHasNoValue = false;
				} else {
					Console.WriteLine("Please confirm if the information correct? (type Y for yes or N for no)");
					userInput = Console.ReadLine();
				}
			}

			if (userInput.ToUpper() == "N") {
				EditCustomer(customer.CustomerId);
			} 
		}

		internal int EditCustomerMenu() {
			bool keepRunning = true;
			string userInput = string.Empty;

			while (keepRunning ) {
				Console.WriteLine(
				"Type the number of the alternative you need to edit\n" +
				"1 name\n" +
				"2 phone number");

				userInput = Console.ReadLine();

				if (!((string.IsNullOrEmpty(userInput)) || (Int32.Parse(userInput) < 1) || (Int32.Parse(userInput) > 2))) {
					keepRunning = false;
				}
			}

			return Int32.Parse(userInput);
		}

		public Customer EditCustomer(int id) {
			
			Customer customer = crudOperationsCustomer.GetCustomerById(id);

			switch (EditCustomerMenu()) {
				case 1: {
						Console.WriteLine("Type name: ");
						string? name = Console.ReadLine();

						if (customer != null) {
							customer.CustomerName = name;
							crudOperationsCustomer.UpdateCustomer(customer);
						}
					}
					break;
				case 2: {
					Console.WriteLine("Type phone number");
					int phoneNumber = int.Parse(Console.ReadLine());

					if (customer != null) {
						customer.PhoneNr = phoneNumber;
						crudOperationsCustomer.UpdateCustomer(customer);
					}
				}
					break;
			}

			return customer;
		}

		public void DeleteCustomer(int id) {
			
			Customer customer = crudOperationsCustomer.GetCustomerById(id);

			if (customer != null) {
				crudOperationsCustomer.DeleteCustomer(customer);
			}
		}
	}
}
