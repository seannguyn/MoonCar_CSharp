using MoonCar;
using NUnit.Framework;

namespace MoonCarTest
{
    public class MonnCarTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_TurnLeft()
        {
            string desirePosition = "0 0 WEST";

            Position position = new Position(5,5,"L");
            string resultPosition = position.execute();

            Assert.AreEqual(desirePosition, resultPosition);
        }

        [Test]
        public void Test_TurnRight()
        {
            string desirePosition = "0 0 EAST";

            Position position = new Position(5, 5, "R");
            string resultPosition = position.execute();

            Assert.AreEqual(desirePosition, resultPosition);
        }

        [Test]
        public void Test_MoveUp()
        {
            string desirePosition = "0 1 NORTH";

            Position position = new Position(5, 5, "M");
            string resultPosition = position.execute();

            Assert.AreEqual(desirePosition, resultPosition);
        }

        [Test]
        public void Test_MoveDown()
        {
            string desirePosition = "2 1 SOUTH";

            Position position = new Position(2, 2, "SOUTH", 5, 5, "M");
            string resultPosition = position.execute();

            Assert.AreEqual(desirePosition, resultPosition);
        }

        [Test]
        public void Test_MoveLeft()
        {
            string desirePosition = "3 2 EAST";

            Position position = new Position(2, 2, "SOUTH", 5, 5, "LM");
            string resultPosition = position.execute();

            Assert.AreEqual(desirePosition, resultPosition);
        }

        [Test]
        public void TestMoveRight()
        {
            string desirePosition = "1 2 WEST";

            Position position = new Position(2, 2, "SOUTH", 5, 5, "RM");
            string resultPosition = position.execute();

            Assert.AreEqual(desirePosition, resultPosition);
        }

        [Test]
        public void Test_Case1()
        {
            string desirePosition = "1 3 NORTH";

            Position position = new Position(1, 2, "NORTH", 5, 5, "LMLMLMLMM");
            string resultPosition = position.execute();

            Assert.AreEqual(desirePosition, resultPosition);
        }

        [Test]
        public void Test_Case2()
        {
            string desirePosition = "5 1 EAST";

            Position position = new Position(3, 3, "EAST", 5, 5, "MMRMMRMRRM");
            string resultPosition = position.execute();

            Assert.AreEqual(desirePosition, resultPosition);
        }

        [Test]
        public void Test_Case3()
        {
            string desirePosition = "3 3 NORTH";

            Position position = new Position(1, 2, "EAST", 4, 4, "MMLM");
            string resultPosition = position.execute();

            Assert.AreEqual(desirePosition, resultPosition);
        }

        [Test]
        public void Test_Case4()
        {
            string desirePosition = "1 2 EAST";

            Position position = new Position(0, 0, "NORTH", 10, 10, "MMLRMMLMRMLLMMMLM");
            string resultPosition = position.execute();

            Assert.AreEqual(desirePosition, resultPosition);
        }

        [Test]
        public void Test_Case5()
        {
            string desirePosition = "4 4 EAST";

            Position position = new Position(0, 0, "NORTH", 10, 10, "MMLRMMLRRMMMM");
            string resultPosition = position.execute();

            Assert.AreEqual(desirePosition, resultPosition);
        }
    }
}