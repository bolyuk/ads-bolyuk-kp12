using System;
using static System.Console;
using System.Text;
namespace adslab5bolyuk
{
    class Program
    {
        static void Main(string[] args)
        {

            int M, N;

            Write("M: ");
            M = Convert.ToInt32(ReadLine());
            Write("N: ");
            N = Convert.ToInt32(ReadLine());

            int[,] matrix = new int[M, N];

            Write(" 1 - random array \n 2 - control array");

            switch (ReadLine())
            {
                case "1":
                        for (int i = 0; i < M; i++)
                            for (int j = 0; j < N; j++)
                                matrix[i, j] = new Random().Next(1, 100);
                        break;
                case "2":

                        matrix = new int[5, 5];

                        for (int i = 0, c = 10; i < matrix.GetLength(0); i++)
                            for (int j = 0; j < matrix.GetLength(1); j++)
                                matrix[i, j] = c++;
                        break;
                default:
                    Main(null);
                    return;
            }
            Console.WriteLine("Вихідна матриця: ");
            ArrayManipulator.print(matrix);
            ArrayManipulator.sort(matrix);
            Console.WriteLine("Після сортування: ");
            ArrayManipulator.print(matrix);
        }
       
    }
}
