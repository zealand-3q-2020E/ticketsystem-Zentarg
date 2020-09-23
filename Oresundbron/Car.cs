using System;
using System.Collections.Generic;
using System.Text;

namespace Oresundbron
{
    public class Car : ClassLibrary.Vehicle
    {
        public Car(string licensePlate, DateTime date, bool brobizzPresent) : base(licensePlate, date, brobizzPresent)
        {
        }

        public override double Price()
        {
            return 410;
        }

        public override double PriceAfterBrobizzDiscount()
        {
            if (BrobizzPresent)
                return 161;
            return Price();
        }

        public override string VehicleType()
        {
            return "Oresund car";
        }
    }
}
