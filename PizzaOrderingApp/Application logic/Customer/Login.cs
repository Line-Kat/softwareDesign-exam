﻿using Microsoft.EntityFrameworkCore;
using PizzaOrderingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp {
	public class Login {

		public void startMeny () {


		}

		public Customer userLogin() {
			HandleCustomer handleCustomer = new();
			Customer? customer = new();
			Console.WriteLine("Choose an option\n1 Login\n2 Register a new user");

			string? UserInput = Console.ReadLine();
			if(UserInput.Equals("1")) {
				Console.WriteLine("Please enter your phone number: ");
				int inputNumber = Convert.ToInt32(Console.ReadLine());

				using PizzaOrderingDbContext db = new();
				customer = db.Customer.FirstOrDefault(customer => customer.PhoneNr == inputNumber);

				if (customer == null) {
					Console.WriteLine("You are not registered");
					customer = handleCustomer.AddCustomer();
				}

			}

			if (UserInput.Equals("2")) {
				 customer = handleCustomer.AddCustomer();
			}
			return customer;
		}
		
	}
}