using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    Hero hero;
    HeroRepository repo;

    [SetUp]
    public void Initial()
    {
        hero = new Hero("Ivo", 29);
        repo = new HeroRepository();
    }

    [Test]
    public void HeroShouldBeSetCorrectly()
    {
        Assert.AreEqual("Ivo", hero.Name);
        Assert.AreEqual(29, hero.Level);
    }

    [Test]
    public void CreateNullHeroShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => this.repo.Create(null));
    }

    [Test]
    public void CreatingExistingHeroShouldThrowException()
    {
        this.repo.Create(hero);

        Assert.Throws<InvalidOperationException>(() => repo.Create(hero));
    }

    [Test]
    public void CreateNewHeroShouldWorkCorrectly()
    {
        Assert.AreEqual($"Successfully added hero {hero.Name} with level {hero.Level}", repo.Create(hero));
    }

    [Test]
    public void RemoveNullHeroShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => this.repo.Remove(null));
    }

    [Test]
    public void RemovingAHeroShouldReturnTrueIfRemoved()
    {
        this.repo.Create(hero);

        Assert.AreEqual(true, repo.Remove("Ivo"));
    }

    [Test]
    public void ReturningHeroWithHighestLevelShouldWorkCorrectly()
    {
        var newHero = new Hero("Ivan", 44);
        var newHero2 = new Hero("Gosho", 45);

        repo.Create(newHero);
        repo.Create(hero);
        repo.Create(newHero2);

        Assert.AreEqual(newHero2, repo.GetHeroWithHighestLevel());
        Assert.AreEqual(hero, repo.GetHero("Ivo"));
    }

    [Test]
    public void ReturningAllCreatedHeroesShouldWorkCorrectly()
    {
        var newHero = new Hero("Ivan", 44);
        var newHero2 = new Hero("Gosho", 45);

        repo.Create(newHero);
        repo.Create(hero);
        repo.Create(newHero2);
        var list = new List<Hero>() { newHero, hero, newHero2 };

        Assert.AreEqual(list, repo.Heroes);
    }
}