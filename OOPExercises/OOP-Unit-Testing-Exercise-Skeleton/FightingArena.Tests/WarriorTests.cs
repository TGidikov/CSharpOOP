


using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructorWorksFine()
        {
            string expectedName = "Tosho";
            int expectedDMG = 100;
            int expHP = 1000;

            Warrior warrior = new Warrior(expectedName, expectedDMG, expHP);

            string actualName = warrior.Name;
            int actualDmg = warrior.Damage;
            int actualHP = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDMG, actualDmg);
            Assert.AreEqual(expHP, actualHP);

        }

        //[TestCase(null)]
        //[TestCase(" ")]
        //[TestCase("")]
        //public void NameShoulThrowException(string name)
        //{
        //
        //    int dmg = 50;
        //    int hp = 100;
        //
        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        Warrior warrior = new Warrior(name, dmg, hp);
        //    });
        //}
        [Test]
        public void NameShoulThrowExceptionIfNull()
        {
            string name = null;
            int dmg = 50;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }
        [Test]
        public void NameShoulThrowExceptionIfWhitSpace()
        {
            string name = " ";
            int dmg = 50;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }
        [Test]
        public void NameShoulThrowExceptionIfEmpty()
        {
            string name = "";
            int dmg = 50;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }


        [TestCase(0)]
        [TestCase(-1)]
       
        public void DamageShoulThrowException(int dmg)
        {
            string name = "Tosho";
            
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }

        
        [Test]
        public void HPShoulNotBeNegative()

        { 
            string name = "Tosho";
            int dmg = 100;
            int hp = -1;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }
        [Test]
        public void WarriorCannotAttackWithLowHP()

        {
            string name = "Tosho";
            int dmg = 100;
            int hp = 30;

            string secondName = "Pesho";
            int secondDMG = 100;
            int secondHp = 100;

            Warrior warrior = new Warrior(name, dmg, hp);
            Warrior secondWarrior = new Warrior(secondName, secondDMG, secondHp);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(secondWarrior);
            });
        }

        [Test]
        public void WarriorCannotAttackAnotherWarriorWithLowHP()

        {
            string name = "Tosho";
            int dmg = 100;
            int hp = 100;

            string secondName = "Pesho";
            int secondDMG = 100;
            int secondHp = 30;

            Warrior warrior = new Warrior(name, dmg, hp);
            Warrior secondWarrior = new Warrior(secondName, secondDMG, secondHp);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(secondWarrior);
            });
        }
        [Test]
        public void WarriorWithLessHPThanTakenDMGshoudBeZero()

        {
            string name = "Tosho";
            int dmg = 100;
            int hp = 100;

            string secondName = "Pesho";
            int secondDMG = 100;
            int secondHp = 50;
            int expectedHP = 0;
            Warrior warrior = new Warrior(name, dmg, hp);
            Warrior secondWarrior = new Warrior(secondName, secondDMG, secondHp);
            warrior.Attack(secondWarrior);
            Assert.AreEqual(expectedHP, secondWarrior.HP);
        }

        [Test]
        public void WarriorCannotAttackAnotherStrongerWarriorWithMoreDMG()

        {
            string name = "Tosho";
            int dmg = 100;
            int hp = 100;

            string secondName = "Pesho";
            int secondDMG = 150;
            int secondHp = 100;

            Warrior warrior = new Warrior(name, dmg, hp);
            Warrior secondWarrior = new Warrior(secondName, secondDMG, secondHp);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(secondWarrior);
            });
        }


    }
}