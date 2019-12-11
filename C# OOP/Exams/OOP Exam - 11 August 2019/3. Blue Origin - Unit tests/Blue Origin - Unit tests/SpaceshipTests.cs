namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SpaceshipTests
    {
        private Astronaut astronaut;
        private Spaceship ship;

        [SetUp]
        public void Initial()
        {
            this.astronaut = new Astronaut("Ivo", 100);
            this.ship = new Spaceship("Mayka", 2);
        }

        [Test]
        public void AstronautConstructorShouldWorkProperly()
        {
            Assert.AreEqual("Ivo", astronaut.Name);
            Assert.AreEqual(100, astronaut.OxygenInPercentage);
        }

        [Test]
        public void SpaceshipContructorShouldWorkCorrectly()
        {
            Assert.AreEqual("Mayka", ship.Name);
            Assert.AreEqual(2, ship.Capacity);
            Assert.AreEqual(0, ship.Count);
        }

        [Test]
        public void CreatingShipWithNullNameShouldThrowException()
        {
            Spaceship newShip;

            Assert.Throws<ArgumentNullException>(() => newShip = new Spaceship(null, 5));
        }

        [Test]
        public void CreatingShipWithNegativeCapacityShouldThrowException()
        {
            Spaceship newShip;

            Assert.Throws<ArgumentException>(() => newShip = new Spaceship("gaga", -2));
        }

        [Test]
        public void AddingTheSameAstronautShouldThrowException()
        {
            this.ship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => ship.Add(astronaut));
        }

        [Test]
        public void ExeedingTheShipCapacityShouldThrowException()
        {
            ship.Add(astronaut);
            ship.Add(new Astronaut("Ivan", 50));

            Assert.Throws<InvalidOperationException>(() => ship.Add(new Astronaut("OG", 55)));
        }

        [Test]
        public void RemovingAstronautShouldWorkProperly()
        {
            ship.Add(astronaut);

            Assert.AreEqual(false, ship.Remove("gaga"));
            Assert.AreEqual(true, ship.Remove("Ivo"));
        }
    }
}