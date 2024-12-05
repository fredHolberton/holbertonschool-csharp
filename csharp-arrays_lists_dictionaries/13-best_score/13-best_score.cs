using System;
using System.Collections.Generic;

class Dictionary
{
    public static string BestScore(Dictionary<string, int> myList)
    {
        int maxInt = -1;
        string bestScore = String.Empty;

        foreach (KeyValuePair<string, int> kvp in myList)
        {
            if (kvp.Value > maxInt)
            {
                maxInt = kvp.Value;
                bestScore = kvp.Key;
            }
            
        }
        if (maxInt == -1)
            return "None";
        else
            return bestScore;
    }
}
