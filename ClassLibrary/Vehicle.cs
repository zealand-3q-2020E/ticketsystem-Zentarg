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
        /// <param name="brobizzPresent">Whether or not the vehicle has a Brobizz allocated.</param>
        protected Vehicle(string licensePlate, DateTime date, bool brobizzPresent)
        {
            LicensePlate = licensePlate;
            Date = date;
            BrobizzPresent = brobizzPresent;
        }

        /// <summary>
        /// Default constructor for Vehicle. Sets all properties to default values.
        /// </summary>
        protected Vehicle()
        {
            LicensePlate = default;
            Date = default;
            BrobizzPresent = default;
        }


        /// <summary>
        /// License plate of the car.
        /// </summary>
        /// <exception cref="ArgumentException">Throws an argument exception if length is longer than 7.</exception>
        public string LicensePlate
        {
            get { return _licensePlate; }
            set
            {
                if (value.Length > 7)
                    throw new ArgumentOutOfRangeException(nameof(LicensePlate), "LicensePlate cannot be longer than 7 characters.");
                _licensePlate = value;
            }
        }
        private string _licensePlate;

        /// <summary>
        /// Date of the ticket.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Boolean describing whether or not the vehicle has a Brobizz allocated.
        /// </summary>
        public bool BrobizzPresent { get; set; }

        /// <summary>
        /// Returns the ticket price.
        /// </summary>
        /// <returns>The price in type <see cref="System.Double"/>.</returns>
        public abstract double Price();

        /// <summary>
        /// Returns the vehicle type.
        /// </summary>
        /// <returns>The Vehicle Type in type <see cref="System.String"/>.</returns>
        public abstract string VehicleType();

        /// <summary>
        /// Returns the ticket price after BrobizzDiscount.
        /// </summary>
        /// <returns>The ticket price after BrobizzDiscount in type <see cref="System.Double"/>.</returns>
        public virtual double PriceAfterBrobizzDiscount()
        {
            if (BrobizzPresent)
                return Price() * 0.95;
            return Price();
        }
    }
}
