namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class Tests
    {

        private Phone phone;
        private string make = "Ikosh";
        private string model = "Kazan";
       
        //[SetUp]
        //public void Setup()
        //{
        //    
        //
        //}
        [Test]
        public void TestConstructor()
        {
            phone = new Phone(make, model);

            Assert.AreEqual(make, phone.Make);
            Assert.AreEqual(model, phone.Model);

        }
        [Test]
        public void TestConstructorThrowsExceptionWhenMakeIsNUll()
        {

            Assert.Throws<ArgumentException>(() => phone = new Phone(null, model));


        }
        [Test]
        public void TestConstructorThrowsExceptionWhenModelIsNUll()
        {

            Assert.Throws<ArgumentException>(() => phone = new Phone(make, null));

        }
        [Test]
        public void TestIfAddContanctAndCountWorks()
        {
            phone.AddContact("jerry", "08890");
            Assert.AreEqual(1,phone.Count);

        }
        [Test]
        public void TestIfAddContactThrowExc()
        {
            var newphone = new Phone("Nokia", "Beton");
            newphone.AddContact("jerrry", "088897990");

            Assert.Throws<InvalidOperationException>(() => newphone.AddContact("jerrry", "012318890"));

        }
        [Test]
        public void TestIfCallWorks()
        {
            var call = phone.Call("jerry");

            Assert.AreEqual($"Calling jerry - 08890...", call);

        }
        [Test]
        public void TestIfCallTHrowsExceptionWorks()
        {

            Assert.Throws<InvalidOperationException>(() => phone.Call("PisnaMI"));

        }





    }

}