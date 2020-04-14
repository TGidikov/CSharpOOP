namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;
        [SetUp]
        public void Setup()
        {
            aquarium = new Aquarium("Pool", 1);
            fish = new Fish("ben");
        }



        [Test]
        public void IfFishConstructorWorks()
        {
            aquarium.Add(fish);
            var expectedCount = 1;
            Assert.AreEqual(expectedCount, aquarium.Count);

        }
        [Test]
        public void TestIfAquariumThrowsExceptionWhenNullNameValueSubbmited()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 10));
        }
        [Test]
        public void TestIfAquariumThrowsExceptionWhenNegativeCapacityValueSubbmited()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Pooly", -1));
        }
        [Test]
        public void AddThrowsExceptionWhenCapacityIsFull()
        {
            aquarium.Add(fish);
            var secondFish = new Fish("bob");
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(secondFish));
        }
        [Test]
        public void RemoveFishThrowsExceptionWhenNonExistingName()
        {
            aquarium.Add(fish);
            var secondFish = new Fish("bob");

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(secondFish.Name));
        }
        [Test]
        public void RemoveFishWorks()
        {
            aquarium.Add(fish);
            aquarium.RemoveFish(fish.Name);
            Assert.AreEqual(0,aquarium.Count);
        }
        [Test]
        public void SellFishThrowsExceptionWhenNonExistingName()
        {
            aquarium.Add(fish);
            var secondFish = new Fish("bob");

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(secondFish.Name));
        }
        [Test]
        public void SellFishWorks()
        {
            aquarium.Add(fish);
            var result = aquarium.SellFish(fish.Name);

            Assert.AreEqual(fish,result);
        }
        [Test]
        public void ReportWorks()
        {
            aquarium.Add(fish);
            var result = $"Fish available at Pool: ben";

            Assert.AreEqual(result,aquarium.Report());
        }

    }
}
