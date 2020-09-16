using System;
using System.Collections.Generic;
using System.Text;

namespace Oresundbron
{
    public class MC : ClassLibrary.MC
    {
        public MC(string licensePlate, DateTime date, bool brobizzPresent) : base(licensePlate, date, brobizzPresent)
        {
        }

        public override double Price()
        {
            return 210;
        }

        public override double PriceAfterBrobizzDiscount()
        {
            if (BrobizzPresent)
                return 73;
            return Price();
        }

        public override string VehicleType()
        {
            return "Oresund M C";
        }
    }
}
