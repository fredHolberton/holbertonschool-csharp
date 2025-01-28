using System;

/// <summary>
/// Public class MatrixMath for manipulating matrix.
/// </summary>
public class MatrixMath
{
    /// <summary>
    ///  transpose a matrix and return the resulting matrix.
    /// </summary>
    public static double[,] Transpose(double[,] matrix)
    {
        double[,] result = new double[matrix.GetLength(1), matrix.GetLength(0)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result[j, i] = matrix[i, j];
            }
        }

        return result;
    }
}

