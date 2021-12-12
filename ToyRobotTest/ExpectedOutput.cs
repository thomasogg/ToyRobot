using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ToyRobotTest
{
    [TestClass]
    public class ExpectedOutput
    {
        ToyRobot.ToyRobot toyrobot = new ToyRobot.ToyRobot();
        [TestMethod]
        public void Example1Input()
        {

            toyrobot.Place(0, 0, "NORTH");
            toyrobot.Move();
            string output = toyrobot.Report();
            string testcheck = "0,1,NORTH";
            Assert.AreEqual(output, testcheck);
        }
        [TestMethod]
        public void Example2Input()
        {

            toyrobot.Place(0, 0, "NORTH");
            toyrobot.TurnLeft();
            string output = toyrobot.Report();
            string testcheck = "0,0,WEST";
            Assert.AreEqual(output, testcheck);
        }
        [TestMethod]
        public void Example3Input()
        {

            toyrobot.Place(1, 2, "EAST");
            toyrobot.Move();
            toyrobot.Move();
            toyrobot.TurnLeft();
            toyrobot.Move();
            string output = toyrobot.Report();
            string testcheck = "3,3,NORTH";
            Assert.AreEqual(output, testcheck);
        }
        [TestMethod]
        public void Example4Input()
        {
            toyrobot.Place(1, 2, "EAST");
            toyrobot.Move();
            toyrobot.TurnLeft();
            toyrobot.Move();
            toyrobot.Place(3, 1, toyrobot.currentdirection);
            toyrobot.Move();
            string output = toyrobot.Report();
            string testcheck = "3,2,NORTH";
            Assert.AreEqual(output, testcheck);
        }

    }
}
