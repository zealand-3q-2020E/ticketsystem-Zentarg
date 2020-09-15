using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public abstract class Vehicle
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="licensePlate">License plate of vehicle.</param>
        /// <param name="date">Date of ticket.</param>
        protected Vehicle(string licensePlate, DateTime date)
        {
            LicensePlate = licensePlate;
            Date = date;
        }

        /// <summary>
        /// License plate of the car.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Date of the ticket.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Returns the ticket price.
        /// </summary>
        /// <returns>The price in type <see cref="System.Double"/></returns>
        public abstract double Price();

        /// <summary>
        /// Returns the vehicle type.
        /// </summary>
        /// <returns>The Vehicle Type in type <see cref="System.String"/></returns>
        public abstract string VehicleType();
    }
}
