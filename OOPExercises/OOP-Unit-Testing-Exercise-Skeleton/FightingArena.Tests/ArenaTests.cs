

using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior w1;
        private Warrior attacker;
        private Warrior deffender;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.w1 = new Warrior("Tosho", 50, 100);
            this.attacker =new Warrior ("Gosho", 100, 100);
            this.deffender = new Warrior("Mosho", 100, 100);
        }

        [Test]
        public void TestIfConstructorWorksFine()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }
       [Test]
       public void EnrolIsWorkingSuccesfuly()
        {
            this.arena.Enroll(this.w1);
            Assert.That(this.arena.Warriors, Has.Member(this.w1));
        }
        [Test]
        public void EnrollSamePlayerShouldThrowExcep()
        {
            this.arena.Enroll(this.w1);

            Assert.Throws<InvalidOperationException>(()=> arena.Enroll(this.w1));
        }
        [Test]
        public void CountIsWorkingCorrectly()
        {
            this.arena.Enroll(this.w1);
           var actualRes=arena.Count;
            var expectedRes = 1;

            Assert.AreEqual(expectedRes, actualRes);

        }

        [Test]
        public void TestFightWithMissingAttacker()
        {
            this.arena.Enroll(deffender);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.deffender.Name);
            });
        }
        [Test]
        public void TestFightWithMissingDeffender()
        {
            this.arena.Enroll(attacker);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.deffender.Name);
            });
        }
        [Test]
        public void TestFight()
        {
            var expAHP = this.attacker.HP - this.deffender.Damage;
            var expDHP = this.deffender.HP - attacker.Damage;
            this.arena.Enroll(attacker);
            this.arena.Enroll(deffender);

            this.arena.Fight(this.attacker.Name, this.deffender.Name);

            Assert.AreEqual(expAHP,this.attacker.HP);
            Assert.AreEqual(expDHP,this.deffender.HP);
            


        }

    }
}
