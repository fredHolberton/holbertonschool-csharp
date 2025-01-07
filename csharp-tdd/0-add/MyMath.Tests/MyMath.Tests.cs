using NUnit.Framework;

namespace MyMath.Tests
{
    /// <summary>Class for testing Operations.Add function.</summary>
    [TestFixture]
    public class AddTests
    {
        /// <summary>Test when a and b are positives.</summary>
        [Test]
        public void TestAetBPositifs()
        {
            // Arrange
            int a = 10;
            int b = 20;

            // Act
            int output = Operations.Add(a, b);

            // Assert
            Assert.AreEqual(30, output);
        }

        /// <summary>Test when a is positive and b is negative.</summary>
        [Test]
        public void TestAPositifetBNegatif()
        {
            // Arrange
            int a = 10;
            int b = -20;

            // Act
            int output = Operations.Add(a, b);

            // Assert
            Assert.AreEqual(-10, output);
        }

        /// <summary>Test when a and b are negatives.</summary>
        [Test]
        public void TestANegatifetBNegatif()
        {
            // Arrange
            int a = -10;
            int b = -20;

            // Act
            int output = Operations.Add(a, b);

            // Assert
            Assert.AreEqual(-30, output);
        }

        /// <summary>Test when a is equal to zero and b is non equal to zero.</summary>
        [Test]
        public void TestANulletBNonNull()
        {
            // Arrange
            int a = 0;
            int b = 20;

            // Act
            int output = Operations.Add(a, b);

            // Assert
            Assert.AreEqual(20, output);
        }
    }
}