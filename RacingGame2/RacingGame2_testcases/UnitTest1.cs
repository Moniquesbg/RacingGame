using NUnit.Framework;
using RacingGame2; // Import the namespace of the source project

namespace RacingGame2_testcases
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Player Monique = new Player("Monique", "Orange");
        }

        [Test]
        public void Test1()
        {
            // Arrange
            int a = 1;
            int b = 1;
            int expectedSum = 2;

            // Act
            int actualSum = a + b;

            // Assert
            Assert.AreEqual(expectedSum, actualSum);
        }
    }
}
