using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Menu
{
	public class MenuCategory
	{
		[Key]
		public int CategoryID { get; set; }

		[Required]
		[StringLength(255)]
		public string CategoryName { get; set; }

		public List<MenuItem> MenuItems { get; set; }

	}
}
