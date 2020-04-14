namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private SoftPark softPark;
       
        [SetUp]
        public void Setup()
        {
            softPark = new SoftPark();
        }
        [Test]
        public void TestIfCarConstructor()
        {
            Car car = new Car("VW", "BA2020PA");

        }
        [Test]
        public void TestIfParkCarThrowsExceptionWhenParkspaceNotExists()
        {
            Car car = null;
            Assert.Throws<ArgumentException>(() => softPark.ParkCar("asjhd", car));

        }
        [Test]
        public void TestIfParkCarThrowsExceptionWhenParkspaceAlreadyExist()
        {
            Car car = new Car("VW","BA202");
            softPark.ParkCar("A1",car);

            Assert.Throws<ArgumentException>(() => softPark.ParkCar("A1", null));

        }
        [Test]
        public void TestIfParkCarThrowsExceptionWhenCarAlreadyExist()
        {
            Car car = new Car("VW", "BA202");
           
            softPark.ParkCar("A1", car);

            Assert.Throws<InvalidOperationException>(() => softPark.ParkCar("A2", car));

        }
        [Test]
        public void TestIfRemoveCarWorks()
        {
            Car car = new Car("VW", "BA202");

            softPark.ParkCar("A1", car);

            var result = softPark.RemoveCar("A1", car);
            var expResult = $"Remove car:{car.RegistrationNumber} successfully!";
            Assert.AreEqual(expResult, result);                
        }
        [Test]
        public void TestIfRemoveCarThrowsExceptionIfParkingSpotDoesntExist ()
        {
           
            Assert.Throws<ArgumentException>(() => softPark.RemoveCar("asdasdasdaasd", null));

        }
        [Test]
        public void TestIfRemoveCarThrowsExceptionIfCarDoesntExist()
        {
            Car car = new Car("VW", "BA202");
            softPark.ParkCar("B1", car);
            Assert.Throws<ArgumentException>(() => softPark.RemoveCar("A1", car));

        }


    }
}