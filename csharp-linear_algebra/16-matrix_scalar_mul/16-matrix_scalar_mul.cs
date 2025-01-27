using System;

/// <summary>
/// Public class MatrixMath for manipulating matrix.
/// </summary>
public class MatrixMath
{
    /// <summary>
    /// multiplies a matrix and a scalar and returns the resulting matrix.
    /// </summary>
    public static double[,] MultiplyScalar(double[,] matrix, double scalar)
    {
        if (matrix.GetLength(0) < 2 || matrix.GetLength(0) > 3 || matrix.GetLength(1) < 2 || matrix.GetLength(1) > 3
            || matrix.GetLength(0) != matrix.GetLength(1))
            return new double[1, 1]{{-1}};

        double[,] result;
        if (matrix.GetLength(0) == 2)
        {
            result = new double[2, 2]{ {0, 0}, {0, 0} };
        }            
        else
        {
            result = new double[3, 3]{ {0, 0, 0}, {0, 0, 0}, {0, 0, 0} };
        }   

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }

        return result;
    }
}
