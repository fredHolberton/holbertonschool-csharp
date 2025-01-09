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
            Dictionary<char, int> dic = new Dictionary<char, int>(); 

            if (s.Length > 0)
            {
                // Remplir le dictionnaire avec pour comptabiliser le nombre de caractères qui se répètent
                foreach (char c in s)
                {
                    if (dic.ContainsKey(c))
                    {
                        dic[c] += 1;
                    }
                    else
                    {
                        dic.Add(c, 1);
                    }    
                }

                foreach (KeyValuePair<char, int> entry in dic)
                Console.WriteLine("{0}: {1}", entry.Key, entry.Value);

                // rechercher le premier caractère unique dans le dictionnaire
                foreach ( KeyValuePair<char, int> kvp in dic)
                {
                    if (kvp.Value == 1)
                    {
                        
                        // trouver l'index du caractère
                        int i = 0;
                        foreach (char c in s)
                        {
                            if (c == kvp.Key)
                            {
                                index = i;
                                break;
                            }
                            i++;
                        }

                        break;
                        
                    }
                }
            }

            Console.WriteLine("index = {0}", index);
            return index;

        }
    }
}
