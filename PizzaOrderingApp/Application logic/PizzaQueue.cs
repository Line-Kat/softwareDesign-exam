using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingApp {
	public class PizzaQueue {
		

		public DateTime CheckQueue() {
			DateTime timeNow = DateTime.Now;
			DateTime queueEnd = new DateTime(2023, 11, 9, 07, 00, 00);
			var pizzaCookingTime = new TimeSpan(0, 20, 0);

			if (timeNow < queueEnd) {
				DateTime queueWait = (queueEnd + pizzaCookingTime);
				var queueWaitHours = (queueWait - timeNow);
				return queueWait;
			}
			else if (timeNow > queueEnd) {
				DateTime queueWait = (timeNow + pizzaCookingTime);
				return queueWait;
			}
			return timeNow;
		}
		// method to get number of minutes

		/*
		 * // for å displaye i tid (timer)
				var queueWait = (queueEnd-timeNow);
				// regne ut tid
				var newQueueEnd = timeNow + queueWait;

		public static bool checkQueue(DateTime inQueue, DateTime orderTime) {
			var currentTime = orderTime;
			return currentTime.CompareTo(inQueue) > 0;
		}

		public DateTime pickupTime() {

			checkQueue(orderTime = DateTime.Now);
			if (checkQueue = true){
			}
			return 0;
		}
		get current time and date
		DateTime lastOrderFinished = new DateTime(2023, 11, 9, 14, 45, 20);
		DateTime orderTime = DateTime.Now;
	
			Console.WriteLine("Current date and time: " + orderTime.ToString());

		bool isAfter = lastOrderFinished orderTime; // true
		
		
		if(isAfter){
		}
		
		DateTime newQueueTime = DateTime.Now;
		string dateWithFormat = timeNow.ToLongDateString();
		
		// Console.WriteLine((newQueueTime - timeNow)).TotalHours);

		private double calcQueue() { 

		}
		*/

	}
}
