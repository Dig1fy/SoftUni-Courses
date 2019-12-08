using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitMotorcycle motorcycle;
        private UnitRider rider;
        private RaceEntry race;

        [SetUp]
        public void Setup()
        {
            this.motorcycle = new UnitMotorcycle("Honda", 105, 919);
            this.rider = new UnitRider("Ivo", motorcycle);
            this.race = new RaceEntry(); 
        }

        [Test]
        public void RiderShouldBeCreateDCorrectly()
        {
            Assert.AreEqual("Honda", rider.Motorcycle.Model);
            Assert.AreEqual(105, rider.Motorcycle.HorsePower);
            Assert.AreEqual(919, rider.Motorcycle.CubicCentimeters);
            Assert.AreEqual("Ivo", rider.Name);
        }

        //[Test]
        //public void MotorcycleShouldBeSetCorrectly()
        //{
        //    Assert.AreEqual("Honda", motorcycle.Model);
        //    Assert.AreEqual(105, motorcycle.HorsePower);
        //    Assert.AreEqual(919, motorcycle.CubicCentimeters);
        //}

        [Test]
        public void RiderConstructor_ShouldSetMotorcycleUnitCorrectly()
        {
            Assert.AreEqual(this.motorcycle, rider.Motorcycle);
        }

        [Test]
        public void RiderShouldThrowExceptionIfNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(()=> new UnitRider(null, motorcycle));
        }

        [Test]
        public void RaceShouldReturnCorrectRidersCount()
        {
            this.race.AddRider(rider);

            Assert.AreEqual(1, race.Counter);
        }

        [Test]
        public void AddingNullRiderShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => race.AddRider(null));
        }

        [Test]
        public void AddingExistingRiderShoudThrowException()
        {
            race.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => race.AddRider(rider));
        }

        [Test]
        public void AddingNewRIderShouldReturnCorrectOutputMessage()
        {
            var outputMessage = race.AddRider(rider);

            Assert.AreEqual("Rider Ivo added in race.", outputMessage);
        }

        [Test]
        public void CalculatingAverageHorsePowerShouldThrowExceptionNoEnoughtParticipants()
        {
            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }
        
        [Test]
        public void CalculatingAverageHorsePowerShouldWorkCorrectly()
        {
            var secondRider = new UnitRider("Gosho", motorcycle);
            race.AddRider(rider);
            race.AddRider(secondRider);

            Assert.AreEqual(105, race.CalculateAverageHorsePower());
        }
    }
}