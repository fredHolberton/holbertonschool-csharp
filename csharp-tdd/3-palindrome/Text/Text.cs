using System;
using System.Collections.Generic;
using System.Text;

namespace Text
{
    /// <summary>This is the Str class within Text namespace.</summary>
    public class Str
    {
        /// <summary>Returns True if a string is a palindrome or False if it’s not.</summary>
        public static bool IsPalindrome(string s)
        {
            string tmpString = "";
            string tmpInvertString = "";

            byte[] ASCIIValues = Encoding.ASCII.GetBytes(s.ToLower());
                        
            foreach (Byte b in ASCIIValues)
            {
                if (b >= 97 && b <= 122)
                {
                    tmpString += Convert.ToChar(b);
                    tmpInvertString = Convert.ToChar(b) + tmpInvertString;
                }
            }

            return (tmpString == tmpInvertString);

        }
    }
}
