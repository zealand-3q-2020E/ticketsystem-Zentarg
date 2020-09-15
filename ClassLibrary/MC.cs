using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class MC : Vehicle
    {
        /// <inheritdoc />
        public MC(string licensePlate, DateTime date) : base(licensePlate, date){}

        public override string VehicleType()
        {
            return "M C";
        }

        public override double Price()
        {
            return 125;
        }

    }
}
