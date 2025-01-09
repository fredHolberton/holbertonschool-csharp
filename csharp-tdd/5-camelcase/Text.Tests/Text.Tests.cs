using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Text;

namespace Text.Tests
{
    /// <summary>Class for testing Str.CamelCase function.</summary>
    [TestFixture]
    public class CamelCaseTests
    {
        /// <summary>Test when empty string.</summary>
        [Test]
        public void TestEmptyString()
        {
            // Arrange
            string s = String.Empty;

            // Act
            int output = Str.CamelCase(s);

            // Assert
            Assert.AreEqual(0, output);
        }

        /// <summary>Test when one letter.</summary>
        [Test]
        public void TestOneLetter()
        {
            // Arrange
            string s = "a";

            // Act
            int output = Str.CamelCase(s);

            // Assert
            Assert.AreEqual(1, output);
        }

        /// <summary>Test when several words.</summary>
        [Test]
        public void TestSeveralWords()
        {
            // Arrange
            string s = "abc Defg Hij";

            // Act
            int output = Str.CamelCase(s);

            // Assert
            Assert.AreEqual(3, output);
        }

        /// <summary>Test when 3 block but 2 words.</summary>
        [Test]
        public void Test3BlocksBut2Words()
        {
            // Arrange
            string s = "abc Defg hij";

            // Act
            int output = Str.CamelCase(s);

            // Assert
            Assert.AreEqual(2, output);
        }

    }
}