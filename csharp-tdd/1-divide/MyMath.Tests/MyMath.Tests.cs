namespace MyMath.Tests
{
    /// <summary>Class for testing Matrix.Divide function.</summary>
    [TestFixture]
    public class DivideTests
    {
        /// <summary>Test when matrix is not null and n not zero.</summary>
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

        /// <summary>Test when matrix is null and n not zero.</summary>
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

        /// <summary>Test when matrix not null and n is zero.</summary>
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

        /// <summary>Test when matrix is null and n is zero.</summary>
        [Test]
        public void TestMatrixVideEtNNotZero()
        {
            // Arrange
            int[,] maMatrix = new int[3, 3];
            int n = 5;

            // Act
            int[,] output = Matrix.Divide(maMatrix, n);

            // Assert
            Assert.AreEqual(new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }, output);
        }
    }
}