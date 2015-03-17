using System;

namespace _08.Matrix_tasks8to10
{
    class MatricesTest
    {
        static void Main(string[] args)
        {
            Matrix<int> testMatrix = new Matrix<int>(5, 5); //initializing the matrix
            Matrix<int> testMatrix2 = new Matrix<int>(5, 5);

            for (int i = 0; i < testMatrix.Rows; i++)
            {
                for (int j = 0; j < testMatrix.Cols; j++)
                {
                    testMatrix[i, j] = i + j + 1;
                    testMatrix2[i, j] = (i + 1) * j;
                }
            }
            Console.WriteLine("\nMatrix 1:");
            PrintMatrix(testMatrix);
            Console.WriteLine("\nMatrix 2:");
            PrintMatrix(testMatrix2);

            Matrix<int> matricesAdditionMatrix = testMatrix + testMatrix2; //result of the addition of the two matrices
            Matrix<int> matricesSubstractionMatrix = testMatrix - testMatrix2; //result of the substraction of the two matrices

            Console.WriteLine("\nAddition");
            PrintMatrix(matricesAdditionMatrix);

            Console.WriteLine("\nSubstraction");
            PrintMatrix(matricesSubstractionMatrix);


        }

        private static void PrintMatrix<T>(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
