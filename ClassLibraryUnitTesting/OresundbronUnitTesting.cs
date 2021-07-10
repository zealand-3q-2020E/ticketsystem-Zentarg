using System;
using System.Collections.Generic;
using System.Text;
using Oresundbron;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibraryUnitTesting
{
    [TestClass]
    public class OresundbronUnitTesting
    {
        [TestMethod]
        public void TestCarPriceWithoutBrobizz()
        {
            //Arrange
            Car car = new Car("WA12343", DateTime.Now, false);

            //Act
            double price = car.PriceAfterBrobizzDiscount();

            //Assert
            Assert.AreEqual(410, price);
        }

        [TestMethod]
        public void TestCarPriceWithBrobizz()
        {
            //Arrange
            Car car = new Car("WA12343", DateTime.Now, true);

            //Act
            double price = car.PriceAfterBrobizzDiscount();

            //Assert
            Assert.AreEqual(161, price);
        }


        [TestMethod]
        public void TestMCPriceWithoutBrobizz()
        {
            //Arrange
            MC mc = new MC("WA12343", DateTime.Now, false);

            //Act
            double price = mc.PriceAfterBrobizzDiscount();

            //Assert
            Assert.AreEqual(210, price);
        }

        [TestMethod]
        public void TestMCPriceWithBrobizz()
        {
            //Arrange
            MC mc = new MC("WA12343", DateTime.Now, true);

            //Act
            double price = mc.PriceAfterBrobizzDiscount();

            //Assert
            Assert.AreEqual(73, price);
        }



        [TestMethod]
        public void TestCarVehicleType()
        {
            //Arrange
            Car car = new Car("WA12343", DateTime.Now, true);

            //Act
            string vehicleType = car.VehicleType();

            //Assert
            Assert.AreEqual("Oresund car", vehicleType);
        }

        [TestMethod]
        public void TestMCVehicleType()
        {
            //Arrange
            MC mc = new MC("WA12343", DateTime.Now, true);

            //Act
            string vehicleType = mc.VehicleType();

            //Assert
            Assert.AreEqual("Oresund M C", vehicleType);
        }
    }
}