using System;

class Program
{
    static void Main(string[] args)
    {
        Random rndm = new Random();
        int number = rndm.Next(-10000, 10000);
        int lastDigit = Math.Abs(number) % 10;
        if (number < 0 ) 
        {
            lastDigit = lastDigit * -1;
        }
        Console.Write("The last digit of {0} is {1} ", number, lastDigit);

        if (lastDigit > 5)
        {
            Console.Write("and is greater than 5");
        }
        else if (lastDigit == 0)
        {
            Console.Write("and is 0");
        }
        else
        {
            Console.Write("and is less than 6 and not 0");
        }
    }
}