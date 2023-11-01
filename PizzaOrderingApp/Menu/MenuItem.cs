using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Menu
{
	public class MenuItem
	{
		[Key]
		public int ItemID { get; set; }

		[Required]
		[StringLength(255)]
		public string ItemName { get; set; }

		[Required]
		public decimal Price { get; set; }

		[MaxLength(1000)]
		public string Description { get; set; }

		public int CategoryID { get; set; }

		public MenuCategory Category { get; set; }
	}
}
