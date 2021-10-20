using System;
using static System.Math;
class asd_l1t1_bolyuk
{
    static void Main()
    {
        double a, b, x, y, z;
        Console.WriteLine("input x:"); x = Double.Parse(Console.ReadLine());
        Console.WriteLine("input y:"); y = Double.Parse(Console.ReadLine());
        Console.WriteLine("input z:"); z = Double.Parse(Console.ReadLine());
        if(x * x + x * y * y + x * x * z > 0)
        {
            a = 1.0 + (Sin(x) / Sqrt(x * x + x * y * y + x * x * z));
            if(y + z / a > 0 && x + (a / (y + z / a)) > 0)
            {
                b = Log(a * a * a + x * x) / (x + (a / (y + z / a)));
                Console.WriteLine("a=" + a.ToString() + "\nb=" + b.ToString());
            } else
            {
                Console.WriteLine("Incorect value!");
            }
        } else
        {
            Console.WriteLine("Incorect value!");
        }

            
    }

}