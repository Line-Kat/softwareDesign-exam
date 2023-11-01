using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Menu
{
	public class MenuService
	{
		private readonly PizzaOrderingDbContext dbContext;

		public MenuService(PizzaOrderingDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public void AddMenuItem(MenuItem menuItem)
		{
			if (menuItem == null)
			{
				throw new ArgumentNullException("MenuItem cannot be null.");
			}

			dbContext.MenuItems.Add(menuItem);
			dbContext.SaveChanges();
		}

		public List<PizzaMenuItem> GetMenuItemsByCategory(int categoryId)
		{
			// Hent alle pizza-menyer med riktig CategoryID
			return dbContext.MenuItems
				.OfType<PizzaMenuItem>()
				.Where(item => item.CategoryID == categoryId)
				.ToList();
		}

		public void DisplayMenuItems(List<PizzaMenuItem> menuItems)
		{
			int index = 1;
			foreach (var menuItem in menuItems)
			{
				Console.WriteLine($"{index}. {menuItem.ItemName} - {menuItem.Price:C}");
				Console.WriteLine($"   {menuItem.Description}");
				index++;
			}
		}
	}

}