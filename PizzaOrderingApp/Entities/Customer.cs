using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Entities {
	//1:* relationship to order
	public class Customer {
		//Properties
		public int CustomerId { get; set; }
		public string CustomerName { get; set; } = string.Empty; //is it OK for string variables here to be empty?
		public int PhoneNr { get; set; }

		
		//Customer has a list of orders
		public ICollection<Order>? Order { get; set; }
	}
}
