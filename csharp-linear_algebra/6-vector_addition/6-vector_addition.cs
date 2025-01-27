using System;

/// <summary>
/// Public class VectorMath for manipulating vectors.
/// </summary>
public class VectorMath
{
    /// <summary>
    /// adds two vectors and returns the resulting vector..
    /// </summary>
    public static double[] Add(double[] vector1, double[] vector2)
    {
        if ((vector1.Length < 2 || vector1.Length > 3 || vector2.Length < 2 || vector2.Length > 3) || (vector1.Length != vector2.Length))
            return new double[1]{-1};

        double[] result;
        if (vector1.Length == 2)
        {
            result = new double[2]{0, 0};
        }            
        else
        {
            result = new double[3]{0, 0, 0};
        }   

        for (int i = 0; i < vector1.Length; i++)
        {
            result[i] = vector1[i] + vector2[i];
        }

        return result;
    }
}
