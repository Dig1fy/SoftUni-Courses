using NUnit.Framework;
using System;
using System.Linq;

public class DatabaseTests
{
    private int[] array;

    [SetUp]
    public void TestInit()
    {
        this.array = Enumerable.Range(1, 5).ToArray();
    }

    [Test]
    public void ConstructorShouldInitializeArrayAccurately()
    {
        var db = new Database(array);

        int[] actual = db.Fetch();

        Assert.That(actual, Is.EqualTo(array));
    }

    [Test]
    public void RemoveAnItemFromEmptyDatabaseShouldThrowAnException()
    {
        var database = new Database();

        Assert.Throws<InvalidOperationException>(() => database.Remove());
    }

    [Test]
    public void RemoveShouldRemoveOnlyTheLastElementIfThereIsSuch()
    {
        var database = new Database(1);

        database.Remove();

        Assert.AreEqual(0, database.Count);
    }


    [Test]
    public void ConstructorShouldSetTheCorrectAmountOfParameters()
    {
        var array = new int[16];
        var database = new Database(array);

        var expectedSize = 16;
        var actualSize = database.Count;

        Assert.AreEqual(expectedSize, actualSize);
    }

    [Test]
    public void ConstructorShouldThrowExceptionIfMoreThan17ElementsAreGivenThrough()
    {
        var array = new int[17];

        Database database;
        Assert.Throws<InvalidOperationException>(() => database = new Database(array));
    }

    [Test]
    public void DatabaseShouldThrowExceptionIfWeAdd17thElement()
    {
        var database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7);

        Assert.Throws<InvalidOperationException>(() => database.Add(1));
    }
}