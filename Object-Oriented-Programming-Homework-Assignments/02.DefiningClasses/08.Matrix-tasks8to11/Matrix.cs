using System;

namespace _08.Matrix_tasks8to10
{
    class Matrix<T>
    {
        //private T item;
        private T[,] matrix;
        private int rows;
        private int cols;


        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.NumMatrix = new T[this.Rows,this.Cols];
        }

        public Matrix(T[,] existingArray)
        {
            this.NumMatrix = existingArray;
            this.Rows = NumMatrix.GetLength(0);
            this.Cols = NumMatrix.GetLength(1);
        }

        public T[,] NumMatrix { get; set; }

        public int Rows
        {
            get { return this.rows; }
            set
            {
                if (value > 0)
                {
                    this.rows = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Rows must be non-negative");
                }
            }
        }

        public int Cols
        {
            get { return this.cols; }
            set
            {
                if (value > 0)
                {
                    this.cols = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Columns must be non-negative");
                }
            }
        }

        public T this[int row, int col]
        {
            get
            {
                if (row >= this.Rows || row < 0 || col >= this.Cols || col < 0)
                {
                    throw new IndexOutOfRangeException(String.Format("Invalid index: [{0}, {1}]. Must be non-negative and within the limits of the collection", row, col));
                }
                T item = NumMatrix[row, col];

                return item;
            }

            set
            {
                if (row > this.Rows -1 || row < 0 || col > this.Cols - 1 || col < 0)
                {
                    throw new IndexOutOfRangeException(String.Format("Invalid index: [{0}, {1}]. Must be non-negative and within the limits of the collection", row, col));
                }

                this.NumMatrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
            {
                throw new ArgumentException("Matrices must have the same dimensions");
            }
            Matrix<T> resultingMatrix = new Matrix<T>(matrix1.Rows, matrix1.Cols);

            for (int i = 0; i < matrix1.Cols; i++)
            {
                for (int j = 0; j < matrix1.Cols; j++)
                {
                    resultingMatrix[i, j] = (dynamic)matrix1[i, j] + matrix2[i, j];
                }
            }

            return resultingMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
            {
                throw new ArgumentException("Matrices must have the same dimensions");
            }
            Matrix<T> resultingMatrix = new Matrix<T>(matrix1.Rows, matrix1.Cols);

            for (int i = 0; i < matrix1.Cols; i++)
            {
                for (int j = 0; j < matrix1.Cols; j++)
                {
                    resultingMatrix[i, j] = (dynamic)matrix1[i, j] - matrix2[i, j];
                }
            }

            return resultingMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Cols != matrix2.Rows)
            {
                throw new ArgumentException("Matrices with these dimensions cannot be multiplied");
            }
            Matrix<T> resultingMatrix = new Matrix<T>(matrix1.Rows, matrix2.Cols);
            double temp;

            for (int matrixRow = 0; matrixRow < resultingMatrix.Rows; matrixRow++)
            {
                for (int matrixCol = 0; matrixCol < resultingMatrix.Cols; matrixCol++)
                {
                    temp = 0;
                    for (int index = 0; index < resultingMatrix.Cols; index++)
                    {
                        temp += (dynamic)matrix1[matrixRow, index] * matrix2[index, matrixCol];
                    }
                    resultingMatrix[matrixRow, matrixCol] = (dynamic)temp;
                }
            }
            return resultingMatrix;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    if (matrix[i, j] != (dynamic)0)
                        return true;
                }
            }
            return false;   
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    if (matrix[i, j] != (dynamic)0)
                        return true;
                }
            }
            return  false;
        }

    }
}
