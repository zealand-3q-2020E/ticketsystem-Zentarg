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
            Car car = new Car("WA12343", DateTime.Now, false);

            //Act
            double price = car.Price();

            //Assert
            Assert.AreEqual(240, price);
        }

        [TestMethod]
        public void TestCarVehicleType()
        {
            //Arrange
            Car car = new Car("WA12343", DateTime.Now, false);
            //Act
            string vehicleType = car.VehicleType();

            //Assert
            Assert.AreEqual("Car", vehicleType);
        }

        [TestMethod]
        public void TestMCPrice()
        {
            //Arrange
            MC mc = new MC("WA98765", DateTime.Now, false);

            //Act
            double price = mc.Price();

            //Assert
            Assert.AreEqual(125, price);
        }

        [TestMethod]
        public void TestMCVehicle()
        {
            //Arrange
            MC mc = new MC("WA98765", DateTime.Now, false);

            //Act
            string vehicleType = mc.VehicleType();

            //Assert
            Assert.AreEqual("M C", vehicleType);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCarLicensePlateLengthOver7()
        {
            //Arrange
            MC mc = new MC("WA123456", DateTime.Now, false);

            //Act
            string vehicleType = mc.VehicleType();

            //Assert
            Assert.AreEqual("M C", vehicleType);
        }

        [TestMethod]
        public void TestCarLicensePlateLengthAt7()
        {
            //Arrange
            MC mc = new MC("WA12345", DateTime.Now, false);

            //Act
            string vehicleType = mc.VehicleType();

            //Assert
            Assert.AreEqual("M C", vehicleType);
        }

        [TestMethod]
        public void TestCarBrobizzDiscountPresent()
        {
            //Arrange
            Car car = new Car("WA12345", DateTime.Now, true);

            //Act
            double price = car.PriceAfterBrobizzDiscount();

            //Assert
            Assert.AreEqual(240, price, 240*0.95);
        }

        [TestMethod]
        public void TestCarBrobizzDiscountNotPresent()
        {
            //Arrange
            Car car = new Car("WA12345", DateTime.Now, false);

            //Act
            double price = car.PriceAfterBrobizzDiscount();

            //Assert
            Assert.AreEqual(240, price, 0);
        }

        [TestMethod]
        public void TestMCBrobizzDiscountPresent()
        {
            //Arrange
            MC car = new MC("WA12345", DateTime.Now, true);

            //Act
            double price = car.PriceAfterBrobizzDiscount();

            //Assert
            Assert.AreEqual(125, price, 125 * 0.95);
        }

        [TestMethod]
        public void TestMCBrobizzDiscountNotPresent()
        {
            //Arrange
            MC car = new MC("WA12345", DateTime.Now, false);

            //Act
            double price = car.PriceAfterBrobizzDiscount();

            //Assert
            Assert.AreEqual(125, price, 0);
        }


    }
}
