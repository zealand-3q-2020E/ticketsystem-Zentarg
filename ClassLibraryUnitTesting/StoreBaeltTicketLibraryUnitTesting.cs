using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;
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

            //Assert
            Assert.AreEqual(240, price, 240 * 0.8);
        }

        [TestMethod]
        public void TestCarPriceWeekdayWithoutBrobizz()
        {
            //Arrange
            Car car = new Car("WA12343", new DateTime(2020, 9, 11), false);

            //Act
            double price = car.Price();

            //Assert
            Assert.AreEqual(240, price);
        }


        [DataTestMethod]
        [DataRow(2020, 9, 12)]
        [DataRow(2020, 9, 13)]
        public void TestCarPriceWeekendWithBrobizz(int year, int month, int day)
        {
            //Arrange
            Car car = new Car("WA12343", new DateTime(year, month, day), true);

            //Act
            double price = car.Price();

            //Assert
            Assert.AreEqual(240, price, (240 * 0.8) * 0.95);
        }

        [TestMethod]
        public void TestCarPriceWeekdayWithBrobizz()
        {
            //Arrange
            Car car = new Car("WA12343", new DateTime(2020, 9, 11), true);

            //Act
            double price = car.Price();

            //Assert
            Assert.AreEqual(240, price, 240 * 0.95);
        }
    }
}
