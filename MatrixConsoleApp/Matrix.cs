
namespace MatrixConsoleApp
{
    internal class Matrix
    {
        private int[,] _matrix;
        public Matrix(int matrixSize)
        {
            _matrix = new int[matrixSize, matrixSize];
        }

        public void printMatrix()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    Console.Write(_matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void printMainDiagonalSum()
        {
            int sum = 0;
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                sum += _matrix[i, i];
            }
            Console.WriteLine("Main diagonal sum: " + sum);
        }

        public void printRowSum(int row)
        {
            if(row >= _matrix.GetLength(0) || row < 0)
            {
                Console.WriteLine("Invalid row");
                return;
            }

            int sum = 0;
            for (int i = 0; i < _matrix.GetLength(1); i++)
            {
                sum += _matrix[row, i];
            }
            Console.WriteLine("Row " + row + " sum: " + sum);
        }

        public void printColumnSum(int column)
        {
            if(column >= _matrix.GetLength(1) || column < 0)
            {
                Console.WriteLine("Invalid column");
                return;
            }

            int sum = 0;
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                sum += _matrix[i, column];
            }
            Console.WriteLine("Column " + column + " sum: " + sum);
        }

        public int getSize()
        {
            return _matrix.GetLength(0);
        }

        internal void setElement(int i, int j, int v)
        {
            _matrix[i, j] = v;
        }

        internal string getElement(int i, int j)
        {
            return _matrix[i, j].ToString();
        }
    }
}
