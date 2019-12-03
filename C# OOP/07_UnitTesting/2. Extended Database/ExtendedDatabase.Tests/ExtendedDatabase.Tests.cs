using NUnit.Framework;
using System;

public class ExtendedDatabaseTests
{
    private Person gosho;
    private Person ivan;

    [SetUp]
    public void Setup()
    {
        gosho = new Person(123, "Gosho");
        ivan = new Person(10, "Ivan");
    }

    [Test]
    [TestCase(1, "")]
    [TestCase(1, " ")]
    [TestCase(1, null)]
    public void PersonWithNullOrEmptyNameShouldBeCreatedSuccessfully_ForSomeReason(long id, string name)
    {
        var tempPerson = new Person(id, name);

        var tempPersonName = tempPerson.UserName;

        Assert.AreEqual(name, tempPersonName);
    }

    [Test]
    [TestCase(0, "")]
    [TestCase(-1, " ")]
    [TestCase(10000, null)]
    public void PersonWithZeroOrNegativeIdShouldBeAddedCorrectly_ForSomeReason(long id, string name)
    {
        var tempPerson = new Person(id, name);

        var tempPersonId = tempPerson.Id;

        Assert.AreEqual(id, tempPersonId);
    }

    [Test]
    public void ConstructorShouldInitializeAPerson()
    {
        long id = 9826192486;
        var userName = "Pesho";
        var person = new Person(id, userName);

        Assert.AreEqual(id, person.Id);
        Assert.AreEqual(userName, person.UserName);
    }

    [Test]
    public void ConstructorShouldInitializeCorrectly()
    {
        var people = new Person[] { gosho, ivan };
        var dataBase = new ExtendedDatabase(people);

        var expectedCount = people.Length;
        var actualCount = dataBase.Count;

        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    public void AddShouldIncrementTheCountProperly()
    {
        var db = new ExtendedDatabase();

        db.Add(ivan);
        db.Add(gosho);
        var expectedCount = 2;

        Assert.AreEqual(expectedCount, db.Count);
    }

    [Test]
    public void AddingMoreThan16PeopleShouldThrowException()
    {
        var tempName = "A";
        var tempId = 0L;
        var db = new ExtendedDatabase();
        var counter = 0;

        for (long i = 0; i < 16; i++)
        {
            counter++;
            tempName += i.ToString();
            tempId += i;
            var person = new Person(tempId, tempName);
            db.Add(person);
        }

        Assert.Throws<InvalidOperationException>(() => db.Add(ivan));
    }

    [Test]
    public void AddingPersonWithTheSameNameShouldThrowException()
    {
        var db = new ExtendedDatabase();
        db.Add(ivan);

        Assert.Throws<InvalidOperationException>(() => db.Add(new Person(1, "Ivan")));
    }

    [Test]
    public void AddShouldIncreaseTheCountOfTheDatabase()
    {
        var db = new ExtendedDatabase();

        db.Add(ivan);
        db.Add(gosho);
        var expectedCount = 2;

        Assert.AreEqual(expectedCount, db.Count);
    }

    [Test]
    public void AddingPersonWithTheSameIdShouldThrowException()
    {
        var db = new ExtendedDatabase();
        db.Add(ivan);

        Assert.Throws<InvalidOperationException>(() => db.Add(new Person(10, "G")));
    }

    [Test]
    public void RemoveFromEmptyDatabaseShouldThrowException()
    {
        var db = new ExtendedDatabase();

        Assert.Throws<InvalidOperationException>(() => db.Remove());
    }

    [Test]
    public void Numbers()
    {
        var persons = new Person[17];
        ExtendedDatabase db;

        Assert.Throws<ArgumentException>(() => db = new ExtendedDatabase(persons));
    }

    [Test]
    public void FindByNameShouldThrowExceptionIfThereIsNoSuchPersonInTheRecord()
    {
        var db = new ExtendedDatabase();
        db.Add(ivan);
        db.Remove();

        Assert.Throws<InvalidOperationException>(() => db.FindByUsername("Ivan"));
    }

    [Test]
    public void ConstructorShouldThrowExceptionIfWeTryToAdd()
    {
        ExtendedDatabase db;

        Assert.Throws<ArgumentException>(() => db = new ExtendedDatabase(ivan, ivan,
            ivan, ivan, ivan, ivan, ivan,
            ivan, ivan, ivan, ivan, ivan,
            ivan, ivan, ivan, ivan, ivan));
    }

    [Test]
    public void FindByNameShouldThrowExceptionIfWeGiveNullAsParameter()
    {
        var db = new ExtendedDatabase();

        Assert.Throws<ArgumentNullException>(() => db.FindByUsername(null));
    }

    [Test]
    public void FindByNameShouldReturnTheWantedNameIfItExistsInTheRecord()
    {
        var db = new ExtendedDatabase();
        db.Add(ivan);

        Assert.AreEqual(ivan, db.FindByUsername("Ivan"));
    }

    [Test]
    public void FindByIdShouldThrowExceptionIfTheGivenIdIsNegativeInteger()
    {
        var db = new ExtendedDatabase();

        Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
    }

    [Test]
    public void FindByIdShouldThrowExceptionIfTheIdIsNotInOurRecords()
    {
        var db = new ExtendedDatabase();
        db.Add(gosho);

        Assert.Throws<InvalidOperationException>(() => db.FindById(5));
    }

    [Test]
    public void FindByIdShouldReturnTheIdIfItExistsInOurRecords()
    {
        var db = new ExtendedDatabase();

        db.Add(ivan);

        Assert.AreEqual(ivan, db.FindById(10));
    }

    [Test]
    public void RemoveShouldDecreaseTheCountOfTheDatabase()
    {
        var db = new ExtendedDatabase();

        db.Add(ivan);
        db.Add(gosho);
        db.Remove();
        var expectedCount = 1;

        Assert.AreEqual(expectedCount, db.Count);
    }
}
