using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class StartUp
    {
        private static int[,] matrix;
        private static long sum;
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = dimensions[0];
            int m = dimensions[1];
            FillMatrix(n, m);
            sum = 0;
            string command = Console.ReadLine();
            
            while (command != "Let the Force be with you")
            {
                int[] ivoCordinates = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int[] evilCordinates = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int evilX = evilCordinates[0];
                int evilY = evilCordinates[1];

                while (evilX >= 0 && evilY >= 0)
                {
                    if (evilX >= 0 && evilX < matrix.GetLength(0) && evilY >= 0 && evilY < matrix.GetLength(1))
                    {
                        matrix[evilX, evilY] = 0;
                    }
                    evilX--;
                    evilY--;
                }

                int ivoX = ivoCordinates[0];
                int ivoY = ivoCordinates[1];

                while (ivoX >= 0 && ivoY < matrix.GetLength(1))
                {
                    if (ivoX >= 0 && ivoX < matrix.GetLength(0) && ivoY >= 0 && ivoY < matrix.GetLength(1))
                    {
                        sum += matrix[ivoX, ivoY];
                    }

                    ivoY++;
                    ivoX--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static void FillMatrix(int n, int m)
        {
            matrix = new int[n, m];

            int currentNum = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = currentNum;
                    currentNum++;
                }
            }
        }
    }
}
