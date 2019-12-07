
using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
    public class SoftParkTest
    {
        private Car carAudi;
        private Car carHonda;
        private SoftPark parking;

        [SetUp]
        public void Setup()
        {
            this.carAudi = new Car("Audi", "123");
            this.carHonda = new Car("Honda", "1234");
            this.parking = new SoftPark();
        }

        [Test]
        public void CarConstructor_ShouldCreateCarsWithProperParametersCorrectly()
        {
            Assert.AreEqual("Audi", this.carAudi.Make);
            Assert.AreEqual("123", this.carAudi.RegistrationNumber);
        }

        [Test]
        public void SoftParkConstructor_ShouldSetTheParkingCorrectly()
        {
            var parkingSpots = new Dictionary<string, Car>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            Assert.AreEqual(parkingSpots, parking.Parking);
        }

        [Test]
        public void ParkCar_ShouldWorkCorrectlyWithAppropriateInputParameters()
        {

        }

        [Test]
        public void ParkCar_ShoudlThrowExceptionWhenParkingSportDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => this.parking.ParkCar("A5", this.carAudi));
        }

        [Test]
        public void ParkCar_ShoudlThrowExceptionWhenTheProvidedParkingSpotIsUnavailable()
        {
            this.parking.ParkCar("A1", this.carAudi);

            Assert.Throws<ArgumentException>(() => this.parking.ParkCar("A1", this.carAudi));
        }

        [Test]
        public void ParkCar_ShoudlThrowExceptionWhenTheProvidedRegistrationNumberAlreadyExistsInTheSystem()
        {
            this.parking.ParkCar("A2", this.carAudi);

            Assert.Throws<InvalidOperationException>(() => this.parking.ParkCar("A1", this.carAudi));
        }

        [Test]
        public void RemoveCar_ShouldThrowExceptionIfCarDoesNotExistInTheSystem()
        {
            this.parking.ParkCar("A1", this.carHonda);

            Assert.Throws<ArgumentException>(() => this.parking.RemoveCar("A1", this.carAudi));
        }

        [Test]
        public void RemoveCar_ShouldThrowExceptionIfSuchParkingSpotDoesNotExistInTheSystem()
        {
            Assert.Throws<ArgumentException>(() => this.parking.RemoveCar("A5", this.carAudi));
        }

        [Test]
        public void RemoveCar_ShoudRemoveCarCorrectlyIfTheInputIsAppropriate()
        {
            this.parking.ParkCar("A1", this.carHonda);

            Assert.AreEqual("Remove car:1234 successfully!", this.parking.RemoveCar("A1", this.carHonda));
        }

        //[Test]
        //public void RemoveCar_TheParkingSpotShouldBecomeNullAfterWeRemoveACarFromIt()
        //{
        //    var parkSpot = "A1";
        //    this.parking.ParkCar("A1", this.carHonda);
        //    this.parking.RemoveCar("A1", this.carHonda);

        //    Assert.AreEqual(null, this.parking[parkSpot]);
        //}
    }

