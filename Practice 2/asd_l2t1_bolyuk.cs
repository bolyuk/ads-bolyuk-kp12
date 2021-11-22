

using System;

class asd_l2t1_bolyuk
{
    static void Main()
    {
        int[,] testArray = { { 11, 12, 13, 14, 15, 16, 17, 18 }, 
                             { 10, 29, 30, 31, 32, 33, 34, 19 },
                             {  9, 28, 39, 38, 37, 36, 35, 20 },
                             {  8, 27, 26, 25, 24, 23, 22, 21 },
                             {  7,  6,  5,  4,  3,  2,  1, 0 }};
        int[,] array;
        int M=5, N=8;
        Console.WriteLine("input type of array (only number) \n 1.test array 2.user input array");
        if (Console.ReadLine() == "1")
        {
            array = testArray;
        }
        else
        {
            Console.Write("input M:"); M = Int32.Parse(Console.ReadLine());
            Console.Write("input N:"); N = Int32.Parse(Console.ReadLine());
            array = generateArray(M, N);
        }
        drawArray(array, M, N);

        int x = M - 1, y = N - 1;
        int[,] arrCopy = (int[,])array.Clone();
        bool d = true; //direction, 0 = x, 1 = y
        bool dx = false; //direction of x, 0 = x--, 1 = x++
        bool dy = false; //direction of y, 0 = y--, 1 = y++
        for (int i = 0; i < N * M; i++)
        {
            Console.Write(arrCopy[x, y] + " ");
            arrCopy[x, y] = int.MinValue;

            if (d && ((y == 0 && !dy) || (y == N - 1 && dy) || arrCopy[x, y + ((dy) ? 1 : -1)] == int.MinValue))
            {
                d = false;
                dy = !dy;
            }
            else if (!d && ((x == 0 && !dx) || (x == M - 1 && dx) || arrCopy[x + ((dx) ? 1 : -1), y] == int.MinValue))
            {
                d = true;
                dx = !dx;
            }
            if (d) y += ((dy) ? 1 : -1); else x += ((dx) ? 1 : -1);
        }
        Console.WriteLine();
        Console.WriteLine("******************");
        int min= int.MaxValue, max= int.MinValue;
        double sum1, sum2;
        for(int i = 0; i<M;i++)
          for(int j=i+1; j < N; j++)
            {
                if (array[i, j] < min || min == int.MaxValue) min = array[i, j];
                if (array[i, j] > max || max == int.MinValue) max = array[i, j];
            }
        sum1 = (max + min) / 2.0;
        min = int.MaxValue;
        max = int.MinValue;
        for (int i = 0; i < M; i++)
            for (int j=N-1-i; j >= 0; j--)
            {
                if (array[i, j] < min || min == int.MaxValue) min = array[i, j];
                if (array[i, j] > max || max == int.MinValue) max = array[i, j];
            }
    
        sum2 = (max + min) / 2.0;
        Console.WriteLine($"sum1={sum1}; sum2={sum2}");

    }

    public static int[,] generateArray(int M, int N)
    {
        int[,] result = new int[M, N];
        for (int i = 0; i < M; i++)
            for (int y = 0; y < N; y++)
                result[i, y] = new Random().Next(-51, 52);
        return result;
    }

    public static void drawArray(int[,] arr, int M, int N)
    {
        Console.WriteLine("******************");
        for (int i = 0; i < M; i++)
        {
            for (int y = 0; y < N; y++)
                Console.Write(arr[i, y] + " ");
            Console.WriteLine();
        }
        Console.WriteLine("******************");
    }
}

