using NUnit.Framework;
using System;

public class WarriorTests
{
    private Warrior warrior;

    [SetUp]
    public void Setup()
    {
        this.warrior = new Warrior("Ivo", 20, 25);
    }

    [Test]
    public void Constructor_CheckIfParametersAreSetCorrectly()
    {
        Assert.AreEqual("Ivo", this.warrior.Name);
        Assert.AreEqual(20, this.warrior.Damage);
        Assert.AreEqual(25, this.warrior.HP);
    }

    [Test]
    [TestCase(null, 20, 33)]
    [TestCase(" ", 20, 33)]
    [TestCase("", 20, 33)]
    public void Name_ShouldThrowExceptionIfNullOrWhiteSpace(string name, int damage, int hp)
    {
        Warrior tempWarrior;

        Assert.Throws<ArgumentException>(() => tempWarrior = new Warrior(name, damage, hp));
    }

    [Test]
    [TestCase("Foo", 0, 33)]
    [TestCase("Boo", -10, 33)]
    public void Damage_ShouldThrowExceptionIfZeroOrNegativeInteger(string name, int damage, int hp)
    {
        Warrior tempWarrior;

        Assert.Throws<ArgumentException>(() => tempWarrior = new Warrior(name, damage, hp));
    }

    [Test]
    public void HeathCannotBeNegativeInteger()
    {
        Warrior tempWarrior;

        Assert.Throws<ArgumentException>(() => tempWarrior = new Warrior("Foo", 20, -1));
    }

    [Test]
    public void Attack_CannotAttackEnemiesWhenYourHpIsBelowTheMinimumHpLevel()
    {
        var secondWarrior = new Warrior("Boo", 20, 200);

        Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(secondWarrior));
    }

    [Test]
    public void Attack_CannotAttackOtherWarriorWhichHpIslessThanTheMinimumHpLevel()
    {
        var firstWarrior = new Warrior("Go", 22, 222);
        var secondWarrior = new Warrior("Boo", 20, 29);

        Assert.Throws<InvalidOperationException>(() => firstWarrior.Attack(secondWarrior));
    }

    [Test]
    public void Attack_CannotAttackStrongerEnemies()
    {
        var hero = new Warrior("ggg", 25, 100);
        var enemy = new Warrior("Boo", 200, 2000);

        Assert.Throws<InvalidOperationException>(() => hero.Attack(enemy));
    }

    [Test]
    public void AttackShouldAdjustTheHpAccordinglyWhenAllValidationsPass()
    {
        var currentWarrior = new Warrior("Jose", 25, 2000);
        var enemy = new Warrior("Boo", 12, 200);
       var warriorHp = currentWarrior.HP - enemy.Damage;

        currentWarrior.Attack(enemy);

        Assert.AreEqual(warriorHp, currentWarrior.HP);
    }

    [Test]
    public void AttackOnWarriorWithLessHpThanOurDamageShouldLeaveTheWarriorWithZeroHp()
    {
        var hero = new Warrior("Jan", 200, 2000);
        var enemy = new Warrior("Bongo", 140, 190);

        hero.Attack(enemy);

        Assert.AreEqual(0, enemy.HP);
    }

    [Test]
    public void AttackShouldReduceEnemysHealthWithTheSameValue()
    {
        var enemy = new Warrior("Foo", 25, 200);
        var hero = new Warrior("Jo", 25, 200);

        hero.Attack(enemy);

        Assert.AreEqual(175, enemy.HP);
        Assert.AreEqual(175, hero.HP);
    }
}