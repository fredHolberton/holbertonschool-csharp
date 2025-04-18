using NUnit.Framework;
using MyMath;
using System;
using System.Collections.Generic;

namespace MyMath.Tests
{
    /// <summary>Class for testing Operations.Max function.</summary>
    [TestFixture]
    public class MaxTests
    {
        /// <summary>Test when list contains positives values.</summary>
        [Test]
        public void TestListOfPositiveValues()
        {
            // Arrange
            List<int> nums = new List<int>() { 3, 8, 1 };

            // Act
            int output = Operations.Max(nums);

            // Assert
            Assert.AreEqual(8, output);
        }

        /// <summary>Test when the list is empty.</summary>
        [Test]
        public void TestListEmpty()
        {
            // Arrange
            List<int> nums = new List<int>();

            // Act
            int output = Operations.Max(nums);

            // Assert
            Assert.AreEqual(0, output);
        }

        /// <summary>Test when the list contains negative values.</summary>
        [Test]
        public void TestListOfNegativeValues()
        {
            // Arrange
            List<int> nums = new List<int>() { -3, -8, -1};

            // Act
            int output = Operations.Max(nums);

            // Assert
            Assert.AreEqual(-1, output);
        }

        /// <summary>Test when the list contains negative and positive values.</summary>
        [Test]
        public void TestListOfNegativeAndPositiveValues()
        {
            // Arrange
            List<int> nums = new List<int>() { -3, -8, 1};

            // Act
            int output = Operations.Max(nums);

            // Assert
            Assert.AreEqual(1, output);
        }

        /// <summary>Test when the list is null.</summary>
        [Test]
        public void TestListIsNull()
        {
            // Arrange
            List<int> nums = null;

            // Act
            int output = Operations.Max(nums);

            // Assert
            Assert.AreEqual(0, output);
        }
    }
}