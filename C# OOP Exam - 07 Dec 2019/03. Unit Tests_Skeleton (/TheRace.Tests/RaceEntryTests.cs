using NUnit.Framework;
using System;

namespace TheRace.Tests
{

    public class RaceEntryTests
    {
    
        private UnitRider rider;
        private UnitMotorcycle unitMotorcycle = new UnitMotorcycle("B", 12, 34);
        new RaceEntry raceEntry;
       

        [SetUp]
        public void Setup()
        {
       
            this.rider = new UnitRider("bob", new UnitMotorcycle("BMW", 100, 2000));
            this.raceEntry = new RaceEntry();
        }
        [Test]
        public void TestConstructor()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitRider(null, unitMotorcycle));
        }
        [Test]
        public void AddRiderAndCounterWorks()
        {
            raceEntry.AddRider(rider);
            Assert.AreEqual(1, raceEntry.Counter);
        }
        [Test]
        public void AddRiderWithNullValueWorks()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(null));
        }
        [Test]
        public void AddRiderWithexistingValueWorks()
        {
            raceEntry.AddRider(rider);
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(rider));
        }
        [Test]
        public void CalculateAverageHorsePowerTHrowsException()
        {
            raceEntry.AddRider(rider);
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }
        [Test]
        public void CalculateAverageHorsePowerWorks()
        {
        
            var newRider = new UnitRider("bb", new UnitMotorcycle("BM", 100, 2000));
            raceEntry.AddRider(rider);
            raceEntry.AddRider(newRider);
            var actualtResult = raceEntry.CalculateAverageHorsePower();
            var expectedResult = 100;
            Assert.AreEqual(expectedResult,actualtResult);
        }





    }
}