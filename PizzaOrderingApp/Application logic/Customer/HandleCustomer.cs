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
			 
			while (string.IsNullOrEmpty(userInputPhoneNr) || !int.TryParse(userInputPhoneNr, out int userInputInt) || (userInputPhoneNr.Length != 8)) {
				Console.WriteLine("Type a phone number with eight digits: ");
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

			customer = crudOperationsCustomer.AddCustomer(customer);

			customer = ConfirmAddCustomer(customer);

			return customer;
		}

		//Method so the user can confirm that the input values are correct
		public Customer ConfirmAddCustomer(Customer customer) {
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
			if(userInput.ToUpper() == "N") {
				EditCustomer(customer.CustomerId);
			}

			return customer;
		}

		//Method to show the user a menu to choose from
		//The method also collects and returns the userinput after validating that the input is correct
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

		//After the user is asked to confirm that the user information is correct, if the user answers 'no', this method is called
		//First the current customer is requested from the database, then the user is asked what information needs to be edited
		//The database is updated and a object of type customer is returned
		public Customer EditCustomer(int id) {
			
			Customer customer = crudOperationsCustomer.GetCustomerById(id);

			switch (EditCustomerMenu()) {

				case 1: {
						
						Console.WriteLine("Type name: ");
						string? name = Console.ReadLine();
						customer.CustomerName = name;
						crudOperationsCustomer.UpdateCustomer(customer);

					}
					break;
				case 2: {
					Console.WriteLine("Type phone number");
					string phoneNumber = string.Empty;

					while (phoneNumber.Length != 8) {
						Console.WriteLine("Type a phone number with eight digits: ");
						phoneNumber = Console.ReadLine();
						int phoneNr = int.Parse(phoneNumber);
						customer.PhoneNr = phoneNr;
						crudOperationsCustomer.UpdateCustomer(customer);
					}
				}
					break;
			}
			return customer;
		}

		//Method to delete the customer from the database
		public void DeleteCustomer(int id) {
			
			Customer customer = crudOperationsCustomer.GetCustomerById(id);

			if (customer != null) {
				crudOperationsCustomer.DeleteCustomer(customer);
			}
		}
	}
}
