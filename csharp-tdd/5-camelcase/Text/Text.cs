using System;
using System.Collections.Generic;
using System.Text;

namespace Text
{
    /// <summary>This is the Str class within Text namespace.</summary>
    public class Str
    {
        /// <summary>Return how many words are in a string.</summary>
        public static int CamelCase(string s)
        {
            int nbWords = 0;

            if (s.Length > 0)
            {
                nbWords = 1;
                 byte[] ASCIIValues = Encoding.ASCII.GetBytes(s);
                foreach (Byte b in ASCIIValues)
                {
                    if (b >= 65 && b <= 90)
                    {
                        nbWords += 1;
                    }
                }
            }

            return nbWords;

        }
    }
}
