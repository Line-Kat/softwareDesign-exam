using PizzaOrderingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp.Application_logic.Decorators
{
	public interface IPizza
	{
		int PizzaId { get; }
		string PizzaName { get; }
		int Price { get; }
		string Description { get; }
	}

}
