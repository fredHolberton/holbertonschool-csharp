namespace MyMath.Tests
{
    // Class for testing Matrix.Divide function.
    [TestFixture]
    public class DivideTests
    {
        // Test when matrix is not null and n not zero.
        [Test]
        public void TestMatrixNonNullEtNNotZero()
        {
            // Arrange
            int[,] maMatrix = new int[3, 3] { { 10, 15, 20 }, { 20, 30, 40 }, { 30, 60, 80 } };
            int n = 5;

            // Act
            int[,] output = Matrix.Divide(maMatrix, n);

            // Assert
            Assert.AreEqual(new int[3, 3] { { 2, 3, 4 }, { 4, 6, 8 }, { 6, 12, 16 } }, output);
        }

        // Test when matrix is null and n not zero.
        [Test]
        public void TestMatrixIsNullEtNNotZero()
        {
            // Arrange
            int[,] maMatrix = null;
            int n = 5;

            // Act
            int[,] output = Matrix.Divide(maMatrix, n);

            // Assert
            Assert.IsNull(output);
        }

        // Test when matrix not null and n is zero.
        [Test]
        public void TestMatrixNotNullEtNIsZero()
        {
            // Arrange
            int[,] maMatrix = new int[3, 3] { { 10, 15, 20 }, { 20, 30, 40 }, { 30, 60, 80 } };
            int n = 0;

            // Act
            int[,] output = Matrix.Divide(maMatrix, n);

            // Assert
            Assert.IsNull(output);
        }

        // Test when matrix is null and n is zero.
        [Test]
        public void TestMatrixIsNullEtNIsZero()
        {
            // Arrange
            int[,] maMatrix = null;
            int n = 0;

            // Act
            int[,] output = Matrix.Divide(maMatrix, n);

            // Assert
           Assert.IsNull(output);
        }

        // Test when matrix is not null and n is negative.
        [Test]
        public void TestMatrixNotNullEtNIsNegative()
        {
            // Arrange
            int[,] maMatrix = new int[3, 3] { { 10, 15, 20 }, { 20, 30, 40 }, { 30, 60, 80 } };
            int n = -5;

            // Act
            int[,] output = Matrix.Divide(maMatrix, n);

            // Assert
           Assert.AreEqual(new int[3, 3] { { -2, -3, -4 }, { -4, -6, -8 }, { -6, -12, -16 } }, output);
        }
    }
}