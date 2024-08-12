namespace MatrixConsoleApp
{
    internal class UserInterface
    {

        Matrix matrix = null;
        public int matrixInputMenu()
        {
            int choice = 0;

            while (choice != 1 && choice != 2)
            {

                Console.WriteLine("1. Read from console");
                Console.WriteLine("2. Read from file \n");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        UserManager userManager = new();
                        matrix = userManager.readAndCreateMatrix();
                        break;
                    case 2:
                        FileManager fileManager = new();
                        matrix = fileManager.readAndCreateMatrix();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }

            // Failed to read matrix
            if (matrix == null)
            {
                Thread.Sleep(500);
                return -1;
            }

            return 0;
        }

        public void matrixOperationsMenu()
        {
            Console.Clear();
            Console.WriteLine("Matrix created");

            int choice = -1;

            while (choice != 0)
            {
                Console.WriteLine("\n1. Print matrix");
                Console.WriteLine("2. Print main diagonal sum");
                Console.WriteLine("3. Print row sum");
                Console.WriteLine("4. Print column sum");
                Console.WriteLine("5. Save matrix to file");
                Console.WriteLine("0. Exit\n");

                choice = int.Parse(Console.ReadLine());
                //Console.Clear();

                switch (choice)
                {
                    case 1:
                        matrix.printMatrix();
                        break;
                    case 2:
                        matrix.printMainDiagonalSum();
                        break;
                    case 3:
                        Console.WriteLine("Enter row: ");
                        int row = int.Parse(Console.ReadLine());
                        matrix.printRowSum(row);
                        break;
                    case 4:
                        Console.WriteLine("Enter column: ");
                        int column = int.Parse(Console.ReadLine());
                        matrix.printColumnSum(column);
                        break;
                    case 5:
                        FileManager fileManager = new();
                        fileManager.saveMatrixToFile(matrix);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
