using System;

namespace asdlab6bolyuk
{
    class MainClass
    {
        public static void Main(string[] args)
        {
String c;
            do
            {
                Console.WriteLine(" q - exit \n 1 - example \n 2 - user input");
                c = Console.ReadLine();
                switch (c)
                {
                    case "1":
                        process("abaggaba");
                        break;
                    case "2":
                        process(Console.ReadLine());
                        break;
                }
            }
            while ((c = Console.ReadLine()) != "q");
        }

        public static void process(String s)
        {
            Console.WriteLine(s+":");
            if (s.Length % 2 != 0)
            {
                Console.WriteLine("Кількість символів повинна бути кратна двом");
                return;
            }
            DEQ d = new DEQ();
            d.parseString(s);
            if (d.palindrome())
            {
                Console.WriteLine(s+" - є паліндромом");
            }
            else
            {
                Console.WriteLine(s + " - не є паліндромом");
            }

        }
    }
}
