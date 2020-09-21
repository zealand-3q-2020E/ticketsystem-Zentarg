using System;
using System.Collections.Generic;
using System.Text;
using StoreBaeltTicketLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibraryUnitTesting
{
    [TestClass]
    public class StoreBaeltTicketLibraryUnitTesting
    {
        [DataTestMethod]
        [DataRow(2020, 9, 12)]
        [DataRow(2020, 9, 13)]
        public void TestCarPriceWeekendWithoutBrobizz(int year, int month, int day)
        {
            //Arrange
            Car car = new Car("WA12343", new DateTime(year, month, day), false);

            //Act
            double price = car.Price();
            double expected = 192;

            //Assert
            Assert.AreEqual(expected, price, expected / 1000);
        }

        [TestMethod]
        public void TestCarPriceWeekdayWithoutBrobizz()
        {
            //Arrange
            Car car = new Car("WA12343", new DateTime(2020, 9, 11), false);

            //Act
            double price = car.Price();
            double expected = 240;

            //Assert
            Assert.AreEqual(expected, price);
        }


        [DataTestMethod]
        [DataRow(2020, 9, 12)]
        [DataRow(2020, 9, 13)]
        public void TestCarPriceWeekendWithBrobizz(int year, int month, int day)
        {
            //Arrange
            Car car = new Car("WA12343", new DateTime(year, month, day), true);

            //Act
            double price = car.PriceAfterBrobizzDiscount();
            double expected = 182.4;

            //Assert
            Assert.AreEqual(expected, price, expected / 1000);
        }

        [TestMethod]
        public void TestCarPriceWeekdayWithBrobizz()
        {
            //Arrange
            Car car = new Car("WA12343", new DateTime(2020, 9, 11), true);

            //Act
            double price = car.PriceAfterBrobizzDiscount();
            double expected = 228;

            //Assert
            Assert.AreEqual(expected, price, expected / 1000);
        }
    }
}
