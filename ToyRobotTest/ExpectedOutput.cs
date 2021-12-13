using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ToyRobotTest
{
    [TestClass]
    public class ExpectedOutput
    {
        ToyRobot.ToyRobot toyrobot = new ToyRobot.ToyRobot();
        ToyRobot.Program program = new ToyRobot.Program();

        [TestMethod]
        public void Example1InputForPurple()
        {
            toyrobot.Place(0, 0, "NORTH");
            toyrobot.Move();
            string output = toyrobot.Report();
            string testcheck = "0,1,NORTH";
            Assert.AreEqual(testcheck, output);
        }
        [TestMethod]
        public void Example2InputForPurple()
        {
            toyrobot.Place(0, 0, "NORTH");
            toyrobot.TurnLeft();
            string output = toyrobot.Report();
            string testcheck = "0,0,WEST";
            Assert.AreEqual(testcheck, output);
        }
        [TestMethod]
        public void Example3InputForPurple()
        {
            toyrobot.Place(1, 2, "EAST");
            toyrobot.Move();
            toyrobot.Move();
            toyrobot.TurnLeft();
            toyrobot.Move();
            string output = toyrobot.Report();
            string testcheck = "3,3,NORTH";
            Assert.AreEqual(testcheck, output);
        }
        [TestMethod]
        public void Example4InputForPurple()
        {
            toyrobot.Place(1, 2, "EAST");
            toyrobot.Move();
            toyrobot.TurnLeft();
            toyrobot.Move();
            toyrobot.Place(3, 1, toyrobot.CurrentDirection);
            toyrobot.Move();
            string output = toyrobot.Report();
            string testcheck = "3,2,NORTH";
            Assert.AreEqual(testcheck, output);
        }
        [TestMethod]
        public void PlaceOutsideOfBounds()
        {
            string output = toyrobot.Place(6, 6, "NORTH");
            Assert.AreEqual("Provided X & Y values aren't inside a 6x6 grid", output);
        }
        [TestMethod]
        public void MoveBeforePlace()
        {
            // Testing to ensure you can't move before PLACE is successful
            bool outcome = toyrobot.Move();
            Assert.AreEqual(false, outcome);
        }
        [TestMethod]
        public void MoveAfterPlace()
        {
            // Testing to ensure you can move after PLACE is successful
            toyrobot.Place(1, 2, "EAST");
            bool outcome = toyrobot.Move();
            Assert.AreEqual(true, outcome);
        }
        [TestMethod]
        public void TurnLeft()
        {
            // Testing to ensure turn left provides the correct new direction
            toyrobot.Place(1, 2, "EAST");
            toyrobot.TurnLeft();
            Assert.AreEqual(toyrobot.CurrentDirection, "NORTH");
        }
        [TestMethod]
        public void TurnRight()
        {
            // Testing to ensure turn right provides the correct new direction
            toyrobot.Place(1, 2, "SOUTH");
            toyrobot.TurnRight();
            Assert.AreEqual(toyrobot.CurrentDirection, "WEST");
        }
        [TestMethod]
        public void MoveOutsideOfBounds()
        {
            // Testing to ensure robot can't move outside of the 6x6 grid.
            toyrobot.Place(5, 5, "NORTH");
            toyrobot.Move();
            string output = toyrobot.Report();
            string testcheck = "5,5,NORTH";
            Assert.AreEqual(testcheck, output);
        }
        [TestMethod]
        public void TooManyParameters()
        {
            // Testing to ensure too many paramaters results in a fail message
            string[] input = { "PLACE", "3", "4", "5", "NORTH" };
            toyrobot.PlaceErrors(input);
            foreach (string error in toyrobot.GetPlaceErrors(input))
            {
                Assert.AreEqual("Incorrect format has been supplied.Format must be PLACE X,Y,DIRECTION e.g. PLACE 2,3,NORTH", error);
            }
        }
        [TestMethod]
        public void NonIntProvided()
        {
            // Testing to ensure that non INT characters aren't accepted.
            string[] input = { "PLACE", "A", "4", "NORTH" };
            toyrobot.PlaceErrors(input);
            foreach (string error in toyrobot.GetPlaceErrors(input))
            {
                Assert.AreEqual("X/Y parameters provided weren't valid numbers.Format must be PLACE X,Y,DIRECTION e.g. PLACE 2,3,NORTH", error);
            }
        }
    }
}
