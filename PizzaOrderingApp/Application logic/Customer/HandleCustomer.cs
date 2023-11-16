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

		internal string AskForUserInput(string typeOfInput) {
			string? userInput = null;

			if (typeOfInput == "name") {
				while (string.IsNullOrEmpty(userInput)) {
					Console.WriteLine("Type name: ");
					userInput = Console.ReadLine();
				}
			} 
			while (string.IsNullOrEmpty(userInput)) {
				Console.WriteLine("Type phone number: ");
				userInput = Console.ReadLine();
			}
			return userInput;
		}

		public Customer AddCustomer() {

			string inputName = AskForUserInput("name");
			int inputPhoneNr = Convert.ToInt32(AskForUserInput(""));

			
			Customer customer = new() {
				CustomerName = inputName,
				PhoneNr = inputPhoneNr
			};

			customer = crudOperationsCustomer.AddCustomer(customer);

			ConfirmAddCustomer(customer);

			return customer;
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
			Console.WriteLine(
				"Type the number of the alternative you need to edit\n" +
				"1 name\n" +
				"2 phone number");

			string? userInput = Console.ReadLine();

			if ( (string.IsNullOrEmpty(userInput)) || (Int32.Parse(userInput) < 1) || (Int32.Parse(userInput) > 3) ) {
				Console.WriteLine("You must select one of the alternatives (number 1 or 2)");
				EditCustomerMenu();
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
