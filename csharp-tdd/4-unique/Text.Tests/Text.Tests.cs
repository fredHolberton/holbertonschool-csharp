using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Text;

namespace Text.Tests
{
    /// <summary>Class for testing Str.UniqueChar function.</summary>
    [TestFixture]
    public class UniqueCharTests
    {
        /// <summary>Test when empty string.</summary>
        [Test]
        public void TestEmptyString()
        {
            // Arrange
            string s = String.Empty;

            // Act
            int output = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(-1, output);
        }

        /// <summary>Test when all characters are equals.</summary>
        [Test]
        public void TestAllEqualCharacters()
        {
            // Arrange
            string s = "aaaaaaaaaa";

            // Act
            int output = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(-1, output);
        }

        /// <summary>Test when the second character is different.</summary>
        [Test]
        public void TestSecondCharactersIsDifferent()
        {
            // Arrange
            string s = "abaaaaaaaa";

            // Act
            int output = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(1, output);
        }

        /// <summary>Test when the last character is different.</summary>
        [Test]
        public void TestLastCharactersIsDifferent()
        {
            // Arrange
            string s = "aaaaaaaaab";

            // Act
            int output = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(9, output);
        }

        /// <summary>Test when the string is null.</summary>
        [Test]
        public void TestStringIsNull()
        {
            // Arrange
            string s = null;

            // Act
            int output = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(-1, output);
        }
    }
}