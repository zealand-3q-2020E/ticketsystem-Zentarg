using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Car vehicle class.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// License plate of the car.
        /// </summary>
        public string Licenseplate { get; set; }

        /// <summary>
        /// Date of the ticket.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Returns the vehicle type.
        /// </summary>
        /// <returns>string</returns>
        public string VehicleType()
        {
            return "Car";
        }

        /// <summary>
        /// Returns the ticket price.
        /// </summary>
        /// <returns>double</returns>
        public double Price()
        {
            return 240;
        }
    }
}
