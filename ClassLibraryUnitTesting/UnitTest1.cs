using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace ClassLibraryUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCarPrice()
        {
            //Arrange
            Car car = new Car("WA12343", DateTime.Now);

            //Act
            double price = car.Price();

            //Assert
            Assert.AreEqual(240, price);
        }

        [TestMethod]
        public void TestCarVehicleType()
        {
            //Arrange
            Car car = new Car("WA12343", DateTime.Now);
            //Act
            string vehicleType = car.VehicleType();

            //Assert
            Assert.AreEqual("Car", vehicleType);
        }

        [TestMethod]
        public void TestMCPrice()
        {
            //Arrange
            MC mc = new MC("WA98765", DateTime.Now);

            //Act
            double price = mc.Price();

            //Assert
            Assert.AreEqual(125, price);
        }

        [TestMethod]
        public void TestMCVehicle()
        {
            //Arrange
            MC mc = new MC("WA98765", DateTime.Now);

            //Act
            string vehicleType = mc.VehicleType();

            //Assert
            Assert.AreEqual("M C", vehicleType);
        }
    }
}
