namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        Phone phone;

        [SetUp]
        public void TestInitialization()
        {
            this.phone = new Phone("Nokia", "3310");
        }

        [Test]
        public void ConstructorShouldSetParametersCorrectly()
        {
            Assert.AreEqual("Nokia", phone.Make);
            Assert.AreEqual("3310", phone.Model);
        }

        [Test]
        [TestCase("", "3330")]
        //[TestCase(" ", "3330")] Not very smart to allow that....
        [TestCase(null, "3330")]
        public void Make_NullOrEmptyShouldThrowException(string make, string model)
        {
            Phone anotherPhone;

            Assert.Throws<ArgumentException>(() => anotherPhone = new Phone(make, model));
        }

        [Test]
        [TestCase("Sony", "")]
        //[TestCase(" ", "3330")] Not very smart to allow that....
        [TestCase("Sony", null)]
        public void Model_NullOrEmptyShouldThrowException(string make, string model)
        {
            Phone anotherPhone;

            Assert.Throws<ArgumentException>(() => anotherPhone = new Phone(make, model));
        }

        [Test]
        public void AddContactShouldThrowExceptionWhenAddingTheSameContactName()
        {
            phone.AddContact("Gosho", "123");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Gosho", "1234"));
        }

        [Test]
        public void AddContactShouldWorkCorrectlyWithProperParameters()
        {
            phone.AddContact("Gosho", "123");
            var expected = "Calling Gosho - 123...";
            Assert.AreEqual(expected, phone.Call("Gosho"));
        }

        [Test]
        public void AddContactShouldThrowExceptionWhenGivingWrongName()
        {
            phone.AddContact("Gosho", "123");

            Assert.Throws<InvalidOperationException>(() => phone.Call("Ivan"));
        }

    }
}