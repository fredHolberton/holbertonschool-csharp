using System;
using System.Collections.Generic;

class List
{
    public static int Sum(List<int> myList)
    {
        int sumInt = 0;
        List<int> tmpList = new List<int>();

        foreach (int lst in myList)
        {
            if (!tmpList.Contains(lst))
            {
                tmpList.Add(lst);
                sumInt += lst;
            }
        }

        return sumInt;
    }
}