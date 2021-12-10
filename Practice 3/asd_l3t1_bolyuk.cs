using System;
class asd_l3t1_bolyuk
{

    static void Main()
    {
        int N, K, M;
        Console.Write("input N:"); N = Int32.Parse(Console.ReadLine());
        Console.Write("input M:"); M = Int32.Parse(Console.ReadLine());
        Console.Write("input K:"); K = Int32.Parse(Console.ReadLine());
        int[,] arr = generate(N,M);
        int[,] copy = (int[,])arr.Clone();
        sort(copy, N, M, K);
        draw(copy, arr, N, M);
        draw(arr, copy,N,M);
    }

    public static  void sort(int[,] arr, int N, int M, int K)
    {
        Console.WriteLine();
        for (int j=0; j<M; j++)
        {
            Console.WriteLine($"nok of {j} and {K} = {nok(j, K)}");
            if (nok(j, K) % 2 != 0)
            {            
                for (int f = 0; f < N; f++)
                {
                    bool flag = true;
                    for (int i = N - 1; i > 0; i--)
                        if (arr[i, j] > arr[i - 1, j])
                        {
                            int buf = arr[i, j];
                            arr[i, j] = arr[i - 1, j];
                            arr[i - 1, j] = buf;
                            flag = false;
                        }
                    if (flag) break;
                }
            }
        }

    }

    public static void draw(int[,] arr1, int[,] arr2, int N, int M)
    {
        Console.WriteLine();

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if (arr1[i, j] == arr2[i, j])
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                char[] buf = $"{arr2[i, j],3}".ToCharArray();
                for (int x = 0; x < buf.Length; x++)
                    Console.Write(buf[x]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("|");

            }
            Console.WriteLine();
        }

    }

    public static int[,] generate(int N, int M)
    {
        int[,] result = new int[N, M];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                result[i, j] = r(-51, 52);
            }
        }
        return result;
    }

    public static int r(int s, int e)
    {
        return new Random().Next(s, e);
    }

    public static int nok(int a, int b)
    {
        int i = 1;
        if (a == 0 || b == 0) return 3; //нуль кратне будь-якому числу. в нашому випадку я повертаю 3
        while(true)                     //щоб умова (ділення націло на два не дорівнєю 0) виконувалася
        {
            if ((i % a == 0) && (i % b == 0))
            {
                return i;
            }
            i++;
        }
        return -1;
    }

}