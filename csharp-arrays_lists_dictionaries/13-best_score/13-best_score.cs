using System;
using System.Collections.Generic;

class Dictionary
{
    public static string BestScore(Dictionary<string, int> myList)
    {
        int maxInt = -1;

        foreach (KeyValuePair<string, int> kvp in myList)
        {
            if (kvp.Value > maxInt)
            maxInt = kvp.Value;
        }
        if (maxInt == -1)
            return "None";
        else
            return maxInt.ToString();
    }
}
