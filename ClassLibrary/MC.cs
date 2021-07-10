using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class MC : Vehicle
    {
        /// <inheritdoc />
        public MC(string licensePlate, DateTime date, bool brobizzPresent) : base(licensePlate, date, brobizzPresent) {}

        public override string VehicleType()
        {
            return "MC";
        }

        public override double Price()
        {
            return 125;
        }

    }
}
