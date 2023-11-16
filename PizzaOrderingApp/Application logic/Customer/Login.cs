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

		public Customer UserLogin() {
			HandleCustomer handleCustomer = new();
			CrudOperationsCustomer crudOperations = new();
			Customer customer = new();

			Console.WriteLine("Choose an option\n1 Login\n2 Register a new user");

			string? userInput = Console.ReadLine();
			if(userInput.Equals("1")) {
				Console.WriteLine("Please enter your phone number: ");
				int inputNumber = Convert.ToInt32(Console.ReadLine());

				customer = crudOperations.GetCustomerByPhoneNr(inputNumber);

				//using PizzaOrderingDbContext db = new();
				//customer = db.Customer.FirstOrDefault(customer => customer.PhoneNr == inputNumber);

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
