using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Entities {
	public class Customer {

		public int CustomerId { get; set; }
		public string CustomerName { get; set; } = string.Empty; 
		public int PhoneNr { get; set; }

		public ICollection<Order>? Order { get; set; }
	}
}
