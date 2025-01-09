using System;
using System.Collections.Generic;
using System.Text;

namespace Text
{
    /// <summary>This is the Str class within Text namespace.</summary>
    public class Str
    {
        /// <summary>Returns True if a string is a palindrome or False if it’s not.</summary>
        public static int UniqueChar(string s)
        {
            int index = -1;
            char c;

            if (s == null)
            {
                return -1;
            }

            if (s.Length > 0)
            {
                c = s[0];

                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i] != c)
                    {
                        index = i;
                        break;
                    }    
                }
            }        

            return index;

        }
    }
}
