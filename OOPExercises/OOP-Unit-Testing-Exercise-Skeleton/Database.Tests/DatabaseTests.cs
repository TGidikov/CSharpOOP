using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        private readonly int[] initialData = new[] { 1, 2 };
        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(initialData);
        }

        [Test]
        public void TestIfCOnstructorWorksCorrectly()
        {
            int[] data = new int[] { 1, 2, 3 };
            this.database = new Database.Database(data);

            int expectedCount = data.Length;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void ConstructionShouldThrowExceptionWhenBigger()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database = new Database.Database(data);
            });
        }
        [Test]
        public void AddShouldIncreaseCountWhenAddedSucces()
        {
            this.database.Add(3);
            int expectedCount = 3;
            int actualCount = this.database.Count;
            Assert.AreEqual(expectedCount, actualCount);

        }
        [Test]
        public void AddShouldThrowException()
        {
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() =>
            this.database.Add(17));
        }
        [Test]
        public void RemoveShouldDecreaseCountWhenSuccess()
        {
            this.database.Remove();
            int actualResult = this.database.Count;
            int expectedResult = 1;
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void ThrowExceptionWhenRemovingFromEmptyCollection()
        {
            Database.Database data = new Database.Database();

            Assert.Throws<InvalidOperationException>(() => data.Remove());

        }
       
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldRetturnArray(int[] expectedData)
        {
            this.database = new Database.Database(expectedData);
            //ReturnedCopy
            int[] actualData = this.database.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}