using MarsRover;
using NUnit.Framework;

namespace MarsRoverUnitTest
{
    public class Tests
    {
        private int _upperRightCornerX;
        private int _upperRightCornerY;

        [SetUp]
        public void Setup()
        {
            _upperRightCornerX = 5;
            _upperRightCornerY = 5;
        }

        [Test]
        public void Test1()
        {
            var rover = new Rover("1 2 N", _upperRightCornerX, _upperRightCornerY);
            rover.Move("LMLMLMLMM");
            Assert.AreEqual("1 3 N", rover.LastPosition);
        }

        [Test]
        public void Test2()
        {
            var rover = new Rover("3 3 E", _upperRightCornerX, _upperRightCornerY);
            rover.Move("MMRMMRMRRM");
            Assert.AreEqual("5 1 E", rover.LastPosition);
        }
    }
}