namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class RobotsTests
    {
        private RobotManager robotManager;
        private Robot robot;
        private Robot secondRobot;
        [SetUp]
        public void Setup()
        {
            this.robotManager = new RobotManager(2);
            this.robot = new Robot("Gosho", 100);
            this.secondRobot = new Robot("jim", 50);
            
        }
                



        [Test]
        public void ConstructorShouldSetProperValue()
        {
           

            Assert.AreEqual("Gosho", robot.Name);
            Assert.AreEqual(100, robot.Battery);
            Assert.AreEqual(100, robot.MaximumBattery);
        }
        [Test]
        public void RobotManagerConstructorWorks()
        {

            robotManager.Add(robot);
            Assert.AreEqual(1, robotManager.Count);

            
        }

        [Test]
        public void RobotManagerConstructorThrowsExcception()
        {

            Assert.Throws<ArgumentException>(() => new RobotManager(-1));


        }
        [Test]
        public void RobotManagerCapacityWorks()
        {

            var manager = new RobotManager(10);
            Assert.AreEqual(10, manager.Capacity);


        }
        [Test]
        public void AddThrowsExxceptions()
        {
            robotManager.Add(robot);          
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
            
          


        }
        [Test]
        public void AddThrowsExxceptionsIfMoreThanCapacity()
        {
            robotManager.Add(robot);
            robotManager.Add(secondRobot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("BEN", 1000)));



        }
        [Test]
        public void AddWorks()
        {
            robotManager.Add(robot);
            Assert.AreEqual(1,robotManager.Count);

        }

        [Test]
        public void RemoveWorks()
        {
            robotManager.Add(robot);
            robotManager.Remove(robot.Name);
            Assert.AreEqual(0, robotManager.Count);

        }
        [Test]
        public void RemoveThrowsException()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("TRIPIO"));


        }
        [Test]
        public void MethodWorkIsWorkingSuccesfull()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("TRIPIO","B2",5));
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Gosho", "B2",101));
            robotManager.Work("Gosho", "B2", 60);
            Assert.AreEqual(40, robot.Battery);

        }
        [Test]
        public void ChargeMethodWorks()
        {
            robotManager.Add(robot);
            robotManager.Work("Gosho", "B2", 60);
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("Trosho"));
            robotManager.Charge("Gosho");
            Assert.AreEqual(100, robot.Battery);


        }

    } 
}
