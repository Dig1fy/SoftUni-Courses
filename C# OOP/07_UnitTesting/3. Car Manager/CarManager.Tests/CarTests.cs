using NUnit.Framework;
using System;

public class CarTests
{
    private Car myCar;

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CheckIfConstructorSetsParametersCorrectly()
    {
        this.myCar = new Car("Mercedes", "CLK", 12, 100);

        Assert.AreEqual("Mercedes", this.myCar.Make);
        Assert.AreEqual("CLK", this.myCar.Model);
        Assert.AreEqual(12, this.myCar.FuelConsumption);
        Assert.AreEqual(100, this.myCar.FuelCapacity);
        Assert.AreEqual(0, this.myCar.FuelAmount);
    }

    [Test]
    [TestCase("", "CLK", 12, 100)]
    [TestCase(null, "CLK", 12, 100)]
    public void Make_NullOrEmptyShouldThrowException(string make, string model, double consumption, double capacity)
    {
        Assert.Throws<ArgumentException>(() => this.myCar = new Car(make, model, consumption, capacity));        
    }

    [Test]
    [TestCase("Mercedes", "", 12, 100)]
    [TestCase("Mercedes", null, 12, 100)]
    public void Model_NullOrEmptyShouldThrowException(string make, string model, double consumption, double capacity)
    {
        Assert.Throws<ArgumentException>(() => this.myCar = new Car(make, model, consumption, capacity));
    }

    [Test]
    [TestCase("Mercedes", "CLK", 0, 100)]
    [TestCase("Mercedes", "CLK", -1, 100)]
    public void FuelConsumption_NullOrNegativeShouldThrowException(string make, string model, double consumption, double capacity)
    {
        Assert.Throws<ArgumentException>(() => this.myCar = new Car(make, model, consumption, capacity));
    }

    [Test]
    [TestCase("Mercedes", "CLK", 12, 0)]
    [TestCase("Mercedes", "CLK", 12, -100)]
    public void FuelCapacity_NullOrNegativeShouldThrowException(string make, string model, double consumption, double capacity)
    {
        Assert.Throws<ArgumentException>(() => this.myCar = new Car(make, model, consumption, capacity));
    }

    [Test]
    [TestCase("Mercedes", "CLK", 12, 110, 0)]
    [TestCase("Mercedes", "CLK", 12, 110, -11)]
    public void Refuel_NullOrNegativeIntegerShouldThrowException(string make, string model, double consumption, double capacity, double amountOfRefuel)
    {
        this.myCar = new Car(make, model, consumption, capacity);

        Assert.Throws<ArgumentException>(() => this.myCar.Refuel(amountOfRefuel));
    }

    [Test]
    public void Refuel_ShouldAdjustTheFuelAmountCorrectly()
    {
        this.myCar = new Car("Mercedes", "CLK", 12, 110);
        var amountOfRefuel = 11;
        this.myCar.Refuel(amountOfRefuel);

        var expected = amountOfRefuel;
        var actual = this.myCar.FuelAmount;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Refuel_RefuelingMoreThanTheFuelCapacityShouldBeCountedProperly()
    {
        this.myCar = new Car("Mercedes", "CLK", 12, 110);
        this.myCar.Refuel(111);

        var expected = this.myCar.FuelCapacity;
        var actual = this.myCar.FuelAmount;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Drive_NeededFuelIsMoreThanOurCurrentAmountAndItShouldThrowException()
    {
        this.myCar = new Car("Mercedes", "CLK", 12, 110);

        Assert.Throws<InvalidOperationException>(() => this.myCar.Drive(11111));
    }

    [Test]
    public void Drive_NeededFuelIsLessThanOurCurrentAmountAndItShouldWorkCorrectly()
    {
        this.myCar = new Car("Mercedes", "CLK", 12, 110);

        this.myCar.Refuel(12);
        this.myCar.Drive(100);

        var expected = 0D;
        var actual =  this.myCar.FuelAmount;
        Assert.AreEqual(expected, actual);
    }
}
