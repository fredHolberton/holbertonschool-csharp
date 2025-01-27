using System;

/// <summary>
/// Public class MatrixMath for manipulating matrix.
/// </summary>
public class MatrixMath
{
    /// <summary>
    /// adds two matrices and returns the resulting matrix.
    /// </summary>
    public static double[,] Add(double[,] matrix1, double[,] matrix2)
    {
        if (matrix1.GetLength(0) < 2 || matrix1.GetLength(0) > 3 || matrix1.GetLength(1) < 2 || matrix1.GetLength(1) > 3
            || matrix1.GetLength(0) != matrix1.GetLength(1)
            || matrix2.GetLength(0) < 2 || matrix2.GetLength(0) > 3 || matrix2.GetLength(1) < 2 || matrix2.GetLength(1) > 3
            || matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            return new double[1, 1]{{-1}};

        double[,] result;
        if (matrix1.GetLength(0) == 2)
        {
            result = new double[2, 2]{ {0, 0}, {0, 0} };
        }            
        else
        {
            result = new double[3, 3]{ {0, 0, 0}, {0, 0, 0}, {0, 0, 0} };
        }   

        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix1.GetLength(1); j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }
}
