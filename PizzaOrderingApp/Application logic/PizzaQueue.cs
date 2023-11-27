using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp {
	public class PizzaQueue {

		//Method that returns the calculated time for when the pizzas are ready for pick up
		public DateTime CheckQueue(int userPizzaCount) {
			int totalPizzaNumber = 0;
			totalPizzaNumber += userPizzaCount;

			// update queueWait with queueEnd and add userPizzaCount to totalPizzaNumber
			DateTime queueEnd = new DateTime();

			DateTime timeNow = DateTime.Now;
			TimeSpan pizzaCookingTime = new TimeSpan(0, (userPizzaCount * 10), 0);

			if (timeNow < queueEnd) {
				DateTime queueWait = (queueEnd + pizzaCookingTime);
				Console.WriteLine(totalPizzaNumber);
				return queueWait;
			}
			else if (timeNow >= queueEnd) {
				DateTime queueWait = (timeNow + pizzaCookingTime);
				return queueWait;
			}
			return timeNow;

		}

	}
}
