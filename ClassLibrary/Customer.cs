using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Customer
    {
        public Customer(List<Vehicle> trips)
        {
            Trips = trips;
        }

        /// <summary>
        /// List of all trips.
        /// </summary>
        public List<Vehicle> Trips { get; set; }

        /// <summary>
        /// Gets total price for all trips.
        /// </summary>
        /// <returns>Returns total price for all trips.</returns>
        public double TotalPriceForTrips()
        {
            double price = 0;
            foreach (Vehicle vehicle in Trips)
            {
                price += vehicle.PriceAfterBrobizzDiscount();
            }

            return price;
        }

    }
}
