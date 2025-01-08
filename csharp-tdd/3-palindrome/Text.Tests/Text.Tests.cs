using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Text.Tests
{
    /// <summary>Class for testing Str.IsPalindrome function.</summary>
    [TestFixture]
    public class IsPalindromeTests
    {
        /// <summary>Test when empty string.</summary>
        [Test]
        public void TestEmptyString()
        {
            // Arrange
            string s = String.Empty;

            // Act
            int output = Str.IsPalindrome(s);

            // Assert
            Assert.AreEqual(True, output);
        }

        /// <summary>Test when only lower string.</summary>
        [Test]
        public void TestLowerString()
        {
            // Arrange
            string s = "level";

            // Act
            int output = Str.IsPalindrome(s);

            // Assert
            Assert.AreEqual(True, output);
        }

        /// <summary>Test when lower and Upper string.</summary>
        [Test]
        public void TestLowerAndUpperString()
        {
            // Arrange
            string s = "Racecar";

            // Act
            int output = Str.IsPalindrome(s);

            // Assert
            Assert.AreEqual(True, output);
        }

        /// <summary>Test when string with ponctuation and spaces.</summary>
        [Test]
        public void TestStringWithPonctuationAndSpaces()
        {
            // Arrange
            string s = "A man, a plan, a canal: Panama.";

            // Act
            int output = Str.IsPalindrome(s);

            // Assert
            Assert.AreEqual(True, output);
        }

        /// <summary>Test when string that is not a palindrome.</summary>
        [Test]
        public void TestStringNotAPalindrome()
        {
            // Arrange
            string s = "Bonjour";

            // Act
            int output = Str.IsPalindrome(s);

            // Assert
            Assert.AreEqual(False, output);
        }
    }
}