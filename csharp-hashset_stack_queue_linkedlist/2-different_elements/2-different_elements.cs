using System;
using System.Collections.Generic;

class List
{
    public static List<int> DifferentElements(List<int> list1, List<int> list2)
    {
        List<int> sortedList = new List<int>();

        foreach (int lst in list1)
        {
            if (!list2.Contains(lst))
            {
                sortedList.Add(lst);
            }
        }

        foreach (int lst in list2)
        {
            if (!list1.Contains(lst))
            {
                sortedList.Add(lst);
            }
        }

        sortedList.Sort();
        return sortedList;
    }
}
