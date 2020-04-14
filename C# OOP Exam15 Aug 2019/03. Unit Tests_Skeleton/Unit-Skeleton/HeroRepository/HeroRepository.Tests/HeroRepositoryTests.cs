using System;
using System.Collections.Generic;
using NUnit.Framework;


public class HeroRepositoryTests
{
    private HeroRepository heroRepository;
    private Hero hero;
   
    [SetUp]
    public void SetUp()
    {
        this.heroRepository = new HeroRepository();
        hero = new Hero("John", 15);
        

    }

    [Test]
    public void TestIfConstructorWorks()
    {
        heroRepository.Create(hero);
        Assert.AreEqual(1, heroRepository.Heroes.Count);
    }
    [Test]
    public void CreateShouldReturnExceptionIfHeroIsNull()
    {
        Hero heroNull = null;

        Assert.Throws<ArgumentNullException>(()=> heroRepository.Create(heroNull));
    }
    [Test]
    public void CreateShouldReturnExceptionIfHeroExists()
    {
        heroRepository.Create(hero);
        
        Assert.Throws<InvalidOperationException>
            (() => heroRepository.Create(new Hero("John",5)));
    }
    [Test]
    public void RemoveShouldReturnExceptionIfHeroIsNullOrWhiteSpace()
    {
        Hero heroWhiteSpace = new Hero (" ",41);
        Hero heroNull = new Hero(null, 41);
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(heroWhiteSpace.Name));
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(heroNull.Name));

    }
    [Test]
    public void RemoveShouldReturnTrue()
    {
        heroRepository.Create(hero);
        
        Assert.AreEqual(true,heroRepository.Remove(hero.Name));

    }
    [Test]
    public void GetHeroWithHiighestLevelWorks()
    {
        var secondHero = new Hero("Tom", 10);
        heroRepository.Create(hero);
        heroRepository.Create(secondHero);

        var result = heroRepository.GetHeroWithHighestLevel();
        Assert.AreEqual(hero, result);

    }
    [Test]
    public void GetHeroWorks()
    {
        var secondHero = new Hero("Tom", 10);
        heroRepository.Create(hero);
        heroRepository.Create(secondHero);

        var result = heroRepository.GetHero("Tom");
        Assert.AreEqual(secondHero, result);

    }





}