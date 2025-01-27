using System;

/* Public class VectorMath for manipulating vectors.*/
public class VectorMath
{
    /* calculates and returns the length of a given vector.*/
    public static double Magnitude(double[] vector)
    {
        if (vector.Length < 2 || vector.Length > 3)
            return -1;
            
        double result = 0;
        foreach (double v in vector)
        {
            result += v * v;
        }
        result = Math.Sqrt(result);
        return Math.Round(result, 2);
    }
}
