using System;
using System.Collections.Generic;

class List
{
    public static List<int> Divide(List<int> list1, List<int> list2, int listLength)
    {
        List<int> resultList = new List<int>();

        try
        {
            for (int i = 0; i < listLength; i++)
            {
                if (list2[i] == 0)
                {
                    Console.WriteLine("Cannot divide by zero");
                    resultList.Add(0);
                }
                else
                {
                    resultList.Add(list1[i] / list2[i]);
                }
            }
        }
        catch(DivideByZeroException)
        {  

        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Out of range");
        }
        
        return resultList;
    }
}
