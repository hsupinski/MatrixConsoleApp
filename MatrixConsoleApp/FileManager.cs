namespace MatrixConsoleApp
{
    internal class FileManager
    {
        private Matrix _matrix;

        public Matrix readAndCreateMatrix() 
        {

            string filePath = null;
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            while (filePath == null || !File.Exists(filePath))
            {
                Console.WriteLine("Enter file path: ");

                filePath = Console.ReadLine();
                filePath = Path.Combine(projectDirectory, filePath);

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File does not exist");
                }
            }

            string[] lines = File.ReadAllLines(filePath);

            List<int> values = new List<int>();

            while(values.Count < lines.Length * lines.Length + 1)
            {
                foreach (string line in lines)
                {
                    string[] lineValues = line.Split(' ', '\n');
                    foreach (string value in lineValues)
                    {
                        // Check if value is a number
                        if(!int.TryParse(value, out _))
                        {
                            continue;
                        }


                        values.Add(int.Parse(value));
                    }
                }
            }

            if(values.Count < 1)
            {
                Console.WriteLine("Invalid matrix");
                return null;
            }

            // First element is matrix size
            int matrixSize = values[0];

            if(values.Count < matrixSize * matrixSize + 1)
            {
                Console.WriteLine("Invalid matrix");
                Console.WriteLine("Expected " + (matrixSize * matrixSize + 1) + " elements, got " + values.Count);
                return null;
            }

            _matrix = new Matrix(matrixSize);

            // Matrix elements start from index 1
            int index = 1;

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

        public void saveMatrixToFile(Matrix matrix)
        {
            Console.WriteLine("Enter file name (with extension): ");
            string fileName = Console.ReadLine();

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, fileName);

            if (File.Exists(filePath)) {
                Console.WriteLine("File already exists");
                return;
            }

            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine(matrix.getSize());

                for (int i = 0; i < matrix.getSize(); i++)
                {
                    for (int j = 0; j < matrix.getSize(); j++)
                    {
                        sw.Write(matrix.getElement(i, j) + " ");
                    }
                    sw.WriteLine();
                }
            }

            Console.WriteLine("Matrix saved to file");
        }
    }
}
