using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Menu
{
	internal class MenuCategories
	{
		public int CathegoryId { get; set; }
		public string CathegoryName { get; set; }


		public List<MenuCategory> GetMenuCategories()
		{
			using (var db = new PizzaOrderingDbContext())
			{
				return db.MenuCategories.ToList();
			}
		}

	}




}
