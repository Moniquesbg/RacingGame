using NUnit.Framework;
using RacingGame2; // Import the namespace of the source project

namespace RacingGame2_testcases
{
    public class Tests
    {
        Player player = new Player(); // Use the fully qualified name

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
