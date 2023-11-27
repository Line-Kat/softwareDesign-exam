using PizzaOrderingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Technical_services {
	public class CrudOperationsCustomer {

		public Customer GetCustomerByPhoneNr(int phoneNumber) {
			using PizzaOrderingDbContext db = new();
			Customer? customer = db.Customer.Where(customer => customer.PhoneNr == phoneNumber).FirstOrDefault();

			return customer;
		}

		public Customer GetCustomerById(int id) {
			using PizzaOrderingDbContext db = new();
			Customer? customer = db.Customer.Where(customer => customer.CustomerId == id).FirstOrDefault();

			return customer;
		}

		public Customer AddCustomer(Customer customer) {
			using PizzaOrderingDbContext db = new();
			db.Customer.Add(customer);
			db.SaveChanges();

			return customer;
		}

		public Customer UpdateCustomer(Customer customer) {
			using PizzaOrderingDbContext db = new();
			db.Update(customer);
			db.SaveChanges();

			return customer;
		}

		public void DeleteCustomer(Customer customer) {
			using PizzaOrderingDbContext db = new();
			db.Customer.Remove(customer);
			db.SaveChanges();
		}
	}
}
