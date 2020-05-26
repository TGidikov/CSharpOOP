
using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        private Person[] persons;
        [SetUp]
        public void Setup()
        {
            persons = new Person[]
            {
                new Person(1,"Godji"),
                new Person(2,"Beri")
            };
            this.database = new ExtendedDatabase.ExtendedDatabase(persons);
        }

        [Test]
        public void TestIfCOnstructorWorksCorrectly()
        {

            var expCount = 2;
            Assert.AreEqual(expCount, database.Count);
        }

        [Test]
        public void TestIfThrowsExceptionWhenSameUsernameAdded()
        {
            Assert.Throws<InvalidOperationException>(() =>
            database.Add(new Person(6, "Beri")));

        }
        [Test]
        public void TestIfThrowsExceptionWhenSameIdAdded()
        {
            Assert.Throws<InvalidOperationException>(() =>
            database.Add(new Person(2, "Johnny")));

        }
        [Test]
        public void TestIfThrowsExceptionWhenAddedMoreThanCorrectNumberPeople()
        {

            database.Add(new Person(3, "B"));
            database.Add(new Person(4, "a"));
            database.Add(new Person(5, "c"));
            database.Add(new Person(6, "d"));
            database.Add(new Person(7, "e"));
            database.Add(new Person(8, "f"));
            database.Add(new Person(9, "g"));
            database.Add(new Person(10, "h"));
            database.Add(new Person(11, "j"));
            database.Add(new Person(12, "k"));
            database.Add(new Person(13, "l"));
            database.Add(new Person(14, "p"));
            database.Add(new Person(15, "i"));
            database.Add(new Person(16, "y"));

            Assert.Throws<InvalidOperationException>(() =>
            database.Add(new Person(2, "Johnny")));

        }
        [Test]
        public void TestIfThrowsExceptionWhenInitializedMoreThanCorrectNumberPeople()
        {
            var people = new Person[]
            {
              new Person(1,"Godji"),
              new Person(2,"Beri"),
              new Person(3,"fsad"),
              new Person(4, "a"),
              new Person(5, "c"),
              new Person(6, "d"),
              new Person(7, "e"),
              new Person(8, "f"),
              new Person(9, "g"),
              new Person(10, "h"),
              new Person(11, "j"),
              new Person(12, "k"),
              new Person(13, "l"),
              new Person(14, "p"),
              new Person(15, "i"),
              new Person(16, "y"),
              new Person(17,"asd")
            };

            Assert.Throws<ArgumentException>(() =>
                new ExtendedDatabase.ExtendedDatabase(people));

        }
        [Test]
        public void TestFindByUsernameCommandWithNonExistingValue()
        {
            Assert.Throws<InvalidOperationException>(() =>
            database.FindByUsername("Avram"));
        }
        [Test]
        public void TestFindByUsernameCommandWithWhitespaceValue()
        {

            try
            {
                database.FindByUsername(null);
            }
            catch (ArgumentException ae)
            {
                Assert.That(ae.ParamName, Is.EqualTo("Username parameter is null!"));
            }

        }
        [Test]
        public void TestIfFindByUsernameWorks()
        {
            var actualResult = database.FindByUsername("Godji");

            Assert.AreEqual("Godji", actualResult.UserName);
        }
        [Test]
        public void RemoveShoudRemoveObj()
        {
            database.Remove();
            var actualR = database.Count;
            var expectedR = 1;

            Assert.AreEqual(expectedR, actualR);

        }
        [Test]
        public void RemoveShoudThrowEXceptionIfNonLeftToRemove()
        {
            database.Remove();
            database.Remove();
            Assert.Throws<InvalidOperationException>(() => database.Remove());

        }
        [Test]
        public void FindIDWithNegativeValueShouldThrowExc()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }
        [Test]
        public void FindIDWiithNonExistingValue()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(12354));
        }
        [Test]
        public void TestIfFindIDWorksSuccessfuly()
        {
            var expResult = database.FindById(1);
            var actualR = 1;
            Assert.AreEqual(expResult.Id, actualR);
        }

    }
}