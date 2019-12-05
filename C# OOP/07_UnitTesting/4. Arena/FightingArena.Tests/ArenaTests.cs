using NUnit.Framework;
using System;
using System.Collections.Generic;


public class ArenaTests
{
    private Arena arena;
    private Warrior firstWarrior;
    private Warrior secondWarrior;

    [SetUp]
    public void Setup()
    {
        this.firstWarrior = new Warrior("Foo", 25, 2000);
        this.secondWarrior = new Warrior("Gosho", 25, 3000);

        this.arena = new Arena();
    }

    [Test]
    public void ConstructorShouldInitializeTheArenaWarriorsCorrectly()
    {
        var list = new List<Warrior>();

        Assert.AreEqual(list, arena.Warriors);
    }

    [Test]
    public void ConstructorShouldInitializeTheArenaCountCorrectly()
    {
        var count = arena.Count;

        Assert.AreEqual(0, count);
    }


    [Test]
    public void EnrollShouldIncreaseTheArenaWarriorsIfTheyHaventBeenEnrolledAlready()
    {
        this.arena.Enroll(firstWarrior);

        var actualCount = 1;

        Assert.AreEqual(actualCount, this.arena.Count);
        //Assert.AreEqual(this.firstWarrior, this.arena.Warriors);
    }

    [Test]
    public void EnrollShouldIncreaseTheListOfWarriorsInTheArena()
    {
        this.arena.Enroll(firstWarrior);
        var listOfWariors = new List<Warrior>();
        listOfWariors.Add(firstWarrior);


        Assert.AreEqual(listOfWariors, this.arena.Warriors);
    }

    [Test]
    public void EnrollShouldIncreaseTheWarriorsOnTheArenaCorrectly()
    {
        this.arena.Enroll(firstWarrior);

        var listOfWarriors = new List<Warrior>();
        listOfWarriors.Add(firstWarrior);

        Assert.AreEqual(listOfWarriors, this.arena.Warriors);
    }

    [Test]
    public void EnrollShouldThrowExceptionWhenWeRollTheSameWarriorTwice()
    {
        this.arena.Enroll(firstWarrior);

        Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(firstWarrior));
    }

    [Test]
    public void FightShouldAdjustDefendersHpAccordingToTheAttackersDamage()
    {
        this.arena.Enroll(firstWarrior);
        this.arena.Enroll(secondWarrior);

        var attacker = firstWarrior.Name;
        var defender = secondWarrior.Name;
        var expectedDefenderHp = secondWarrior.HP - firstWarrior.Damage;
        var expectedAttackerHp = firstWarrior.HP - secondWarrior.Damage;

        this.arena.Fight(attacker, defender);

        Assert.AreEqual(expectedDefenderHp, secondWarrior.HP);
        Assert.AreEqual(expectedAttackerHp, firstWarrior.HP);
    }

    [Test]
    public void FightShouldBeAvailableOnlyForHeroesWhoAreBothEnrolledInTheArena()
    {
        var enemy = new Warrior("Strahil", 25, 2500);
        this.arena.Enroll(firstWarrior);

        Assert.Throws<InvalidOperationException>(() => arena.Fight(firstWarrior.Name, enemy.Name));
    }

    [Test]
    public void FightShouldThrowExceptionIfTheDefenderIsNotEnrolledInTheArena()
    {
        this.arena.Enroll(firstWarrior);

        Assert.Throws<InvalidOperationException>(() => this.arena.Fight(firstWarrior.Name, "Goshooo"));
    }

    [Test]
    public void FightShouldThrowExceptionIfTheAttackerIsNotEnrolledInTheArena()
    {
        this.arena.Enroll(firstWarrior);

        Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Goshooo", firstWarrior.Name));
    }

    [Test]
    public void FightShouldThrowExceptionIfTheAttackerNameIsNull()
    {
        this.arena.Enroll(firstWarrior);

        Assert.Throws<InvalidOperationException>(() => this.arena.Fight(null, firstWarrior.Name));
    }

    [Test]
    public void FightShouldThrowExceptionIfTheDefenderNameIsNull()
    {
        this.arena.Enroll(firstWarrior);

        Assert.Throws<InvalidOperationException>(() => this.arena.Fight(firstWarrior.Name, null));
    }
}

