namespace MatrixConsoleApp
{
    internal class UserManager
    {
        private Matrix _matrix;
        public Matrix readAndCreateMatrix()
        {
            Console.WriteLine("Enter matrix size: ");
            int matrixSize = int.Parse(Console.ReadLine());

            if(matrixSize < 1)
            {
                Console.WriteLine("Invalid matrix size");
                return null;
            }
            _matrix = new Matrix(matrixSize);

            // Parse elements separated by space or newline
            Console.WriteLine("Enter matrix elements: ");

            List<int> values = new List<int>();

            while(values.Count < matrixSize * matrixSize)
            {
                string[] line = Console.ReadLine().Split(' ', '\n');
                foreach (string value in line)
                {
                    values.Add(int.Parse(value));
                }
            }

            int index = 0;
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    _matrix.setElement(i, j, values[index]);
                    index++;
                }
            }

            return _matrix;

        }
    }
}
