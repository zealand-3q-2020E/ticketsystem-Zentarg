using System;

namespace StoreBaeltTicketLibrary
{
    public class Car : ClassLibrary.Car
    {
        /// <inheritdoc />
        public Car(string licensePlate, DateTime date, bool brobizzPresent) : base(licensePlate, date, brobizzPresent)
        {
        }

        public override double Price()
        {
            if (Date.DayOfWeek == DayOfWeek.Saturday || Date.DayOfWeek == DayOfWeek.Sunday) 
                return base.Price() * 0.8;
            return base.Price();
        }
    }
}
