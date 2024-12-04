using System;

class Number
{
    public static int PrintLastDigit(int number)
    {
        int lastDigit = Math.Abs(number) % 10;
        if (number < 0 ) 
        {
            lastDigit = lastDigit * -1;
        }
        return lastDigit;
    }
}
