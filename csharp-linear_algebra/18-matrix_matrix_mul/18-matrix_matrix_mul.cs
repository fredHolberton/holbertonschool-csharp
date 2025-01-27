using System;

/// <summary>
/// Public class MatrixMath for manipulating matrix.
/// </summary>
public class MatrixMath
{
    /// <summary>
    /// multiplies two matrices and returns the resulting matrix.
    /// </summary>
    public static double[,] Multiply(double[,] matrix1, double[,] matrix2)
    {
        int rowsMatrix1 = matrix1.GetLength(0);
        int colsMatrix1 = matrix1.GetLength(1);
        int rowsMatrix2 = matrix2.GetLength(0);
        int colsMatrix2 = matrix2.GetLength(1);

        if (colsMatrix1 != rowsMatrix2)
            return new double[1, 1]{{-1}};

        double[,] result;
        if  (rowsMatrix1 <= rowsMatrix2)
            result = new double[rowsMatrix1, colsMatrix2];
        else
            result = new double[rowsMatrix2, colsMatrix1];


        // Multiplication des matrices
        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < colsMatrix1; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        return result;
    }
}

