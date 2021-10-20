using System;
class asd_l1t2_bolyuk
{
    static void Main()
    {
        int count = 0;
        for (int Y = 1582; Y <= 4902; Y++)
        {
            int y = Y % 1000;
            int c = Y / 1000;
            for (int m = 1; m <= 12; m++)
            {
                if ((Math.Round(2.6 * m - 0.2) + 13 + y + Math.Round(y / 4.0) + Math.Round(c / 4.0) - 2 * c) % 7 == 5) count++;
            }
        }
        Console.WriteLine("Кількість п'ятниць 13: " + count.ToString());
    }

}