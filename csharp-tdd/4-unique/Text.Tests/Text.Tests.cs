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

        /// <summary>Test when no character is unique.</summary>
        [Test]
        public void TestNoCharacterIsUnique()
        {
            // Arrange
            string s = "aaabbbcccc";

            // Act
            int output = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(-1, output);
        }

        /// <summary>Test when first character is unique.</summary>
        [Test]
        public void TestFirstCharactersIsUnique()
        {
            // Arrange
            string s = "abbbbbbbbb";

            // Act
            int output = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(0, output);
        }

        /// <summary>Test when last character is unique.</summary>
        [Test]
        public void TestLastCharactersIsUnique()
        {
            // Arrange
            string s = "aaaaaaaaab";

            // Act
            int output = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(9, output);
        }

        /// <summary>Test when one character in the middle is unique.</summary>
        [Test]
        public void TestOneCharactersInMiddleIsUnique()
        {
            // Arrange
            string s = "aaaabaaaaa";

            // Act
            int output = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(4, output);
        }

        /// <summary>Test when the 2 character are unique.</summary>
        [Test]
        public void TestTwoCharactersAreUnique()
        {
            // Arrange
            string s = "aaabbcdddde";

            // Act
            int output = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(5, output);
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

        /// <summary>Test when the string contains one letter.</summary>
        [Test]
        public void TestStringContainsOneLetter()
        {
            // Arrange
            string s = "a";

            // Act
            int output = Str.UniqueChar(s);

            // Assert
            Assert.AreEqual(0, output);
        }

    }
}