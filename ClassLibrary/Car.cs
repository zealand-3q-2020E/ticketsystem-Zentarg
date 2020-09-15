using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Car : Vehicle
    {
        /// <inheritdoc />
        public Car(string licensePlate, DateTime date) : base(licensePlate, date){}

        public override string VehicleType()
        {
            return "Car";
        }

        public override double Price()
        {
            return 240;
        }
    }
}
