using System;

/// <summary>
/// Public class VectorMath for manipulating vectors.
/// </summary>
public class VectorMath
{
    /// <summary>
    /// multiplies a vector and a scalar and returns the resulting vector.
    /// </summary>
    public static double[] Multiply(double[] vector, double scalar)
    {
        if (vector.Length < 2 || vector.Length > 3)
            return new double[1]{-1};

        double[] result;
        if (vector.Length == 2)
        {
            result = new double[2]{0, 0};
        }            
        else
        {
            result = new double[3]{0, 0, 0};
        }   

        for (int i = 0; i < vector.Length; i++)
        {
            result[i] = vector[i]  * scalar;
        }

        return result;
    }
}
