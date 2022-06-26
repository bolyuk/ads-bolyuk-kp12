using System;
namespace adslab5bolyuk
{
    public static class ArrayManipulator
    {
        public static void print(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }

        }

        public static void sort(int[,] matrix)
        {
            int[] arr = new int[matrix.Length];

            for (int i = 0, k = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    arr[k] = matrix[i, j];
                    k++;
                }

            arr = SortDown(arr);

            for (int i = 0, k = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = arr[k++];

            int count = 0;
            int lengthHelp = matrix.GetLength(0);
            int length = 0;

            if (matrix.GetLength(0) > matrix.GetLength(1))
                lengthHelp = matrix.GetLength(1);

            if (matrix.GetLength(1) > matrix.GetLength(0) || matrix.GetLength(1) % 2 == 0)
                length = lengthHelp * 2;
            else
                length = lengthHelp * 2 - 1;


            arr = new int[length];

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (i == j)
                        arr[count++] = matrix[i, j];


            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (j == matrix.GetLength(1) - 1 - i && i != j)
                        arr[count++] = matrix[i, j];

            arr = SortUp(arr);

            count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (i == j)
                        matrix[i, j] = arr[count++];

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (j == matrix.GetLength(1) - 1 - i && i != j)
                        matrix[i, j] = arr[count++];
        }

        static int[] SortDown(int[] arr)
        {
            int i = 0;
            int eq = 0;
            int j = arr.Length - 1;
            while (i <= j)
            {
                if (arr[i] < arr[0])
                    (arr[i], arr[j]) = (arr[j--], arr[i]);
                else if (arr[i] > arr[0])
                    (arr[i], arr[eq]) = (arr[eq++], arr[i++]);
                else
                    i++;
            }

            int[] arrSorted = new int[j - eq + 1];
            Array.Copy(arr, eq, arrSorted, 0, arrSorted.Length);

            int[] arrLeft = new int[eq];
            if (arrLeft.Length > 0)
            {
                Array.Copy(arr, 0, arrLeft, 0, arrLeft.Length);
                if (arrLeft.Length > 1)
                    arrLeft = SortDown(arrLeft);
            }

            int[] arrRight = new int[arr.Length - j - 1];
            if (arrRight.Length > 0)
            {
                Array.Copy(arr, j + 1, arrRight, 0, arrRight.Length);
                if (arrRight.Length > 1)
                    arrRight = SortDown(arrRight);
            }

            Array.Copy(arrLeft, 0, arr, 0, arrLeft.Length);
            Array.Copy(arrSorted, 0, arr, eq, arrSorted.Length);
            Array.Copy(arrRight, 0, arr, j + 1, arrRight.Length);

            return arr;
        }

        static int[] SortUp(int[] arr)
        {
            int i = 0;
            int eq = 0;
            int j = arr.Length - 1;
            while (i <= j)
            {
                if (arr[i] > arr[0])
                    (arr[i], arr[j]) = (arr[j--], arr[i]);
                else if (arr[i] < arr[0])
                    (arr[i], arr[eq]) = (arr[eq++], arr[i++]);
                else
                    i++;
            }
            int[] arrSorted = new int[j - eq + 1];
            Array.Copy(arr, eq, arrSorted, 0, arrSorted.Length);

            int[] arrLeft = new int[eq];
            if (arrLeft.Length > 0)
            {
                Array.Copy(arr, 0, arrLeft, 0, arrLeft.Length);
                if (arrLeft.Length > 1)
                    arrLeft = SortUp(arrLeft);
            }

            int[] arrRight = new int[arr.Length - j - 1];
            if (arrRight.Length > 0)
            {
                Array.Copy(arr, j + 1, arrRight, 0, arrRight.Length);
                if (arrRight.Length > 1)
                    arrRight = SortUp(arrRight);
            }

            Array.Copy(arrLeft, 0, arr, 0, arrLeft.Length);
            Array.Copy(arrSorted, 0, arr, eq, arrSorted.Length);
            Array.Copy(arrRight, 0, arr, j + 1, arrRight.Length);

            return arr;
        }

    }

}
