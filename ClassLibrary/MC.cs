using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class MC
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
        /// Returns the ticket price.
        /// </summary>
        /// <returns>double</returns>
        public double Price()
        {
            return 125;
        }

        /// <summary>
        /// Returns the vehicle type.
        /// </summary>
        /// <returns>string</returns>
        public string Vehicle()
        {
            return "M C";
        }



    }
}
