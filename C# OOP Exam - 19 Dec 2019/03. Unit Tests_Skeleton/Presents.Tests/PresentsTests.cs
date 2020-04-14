using NUnit.Framework;
using System;
using System.Collections.Generic;



namespace Presents.Tests
{
   

    public class PresentsTests
    {

        private Bag bag;
        private Present present = new Present("Tosho", 10.0);
        private Present secondPresent = new Present("Gosho", 20.0);


        [SetUp]
        public void Setup()
        {


            this.bag = new Bag();



        }

        [Test]
        public void IfPresentConstructorWorksSuccessfully()
        {

            Assert.IsNotNull(present);

        }
        [Test]
        public void IfBagConstructorWorksSuccessfully()
        {
            new Bag();

        }
        [Test]
        public void CreteSouldThrowArgumentNullExcIFValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }
        [Test]
        public void CreteSouldThrowInvalidOperationExeptionIfPresentAlreadyExists()
        {


            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }
        [Test]
        public void RemoveMethodShouldReturnTrue()
        {
            bag.Create(present);
            var actResult = bag.Remove(present);
            var expResult = true;
            Assert.AreEqual(expResult, actResult);

        }
        [Test]
        public void TestIfGetPresentsWithLeastMagicWorks()
        {
            bag.Create(present);
            bag.Create(secondPresent);
            var result = bag.GetPresentWithLeastMagic();
            Assert.AreEqual(present, result);
        }
        [Test]
        public void TestIfGetPresentWorks()
        {
            bag.Create(present);
            bag.Create(secondPresent);
            var result = bag.GetPresent("Gosho");
            Assert.AreEqual(secondPresent, result);
        }





    }
}
