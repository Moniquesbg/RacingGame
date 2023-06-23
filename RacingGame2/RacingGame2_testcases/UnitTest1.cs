namespace RacingGame2_testcases
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
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