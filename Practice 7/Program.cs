using System;
using System.Collections.Generic;

using adsbolyuklab7.MainTable;
using adsbolyuklab7.TicketTable;

namespace adsbolyuklab7
{
    class MainClass
    {
        static public List<String> names = new List<String> { "Перший", "Гамма", "Вільнус", "ВІП" };
        static public List<int> halls = new List<int> { 20, 60, 120, 80 };

        static CinemaTable table = new CinemaTable();
        static SecondTable table1 = new SecondTable();

        public static void Main(string[] args)
        {

            String c="";
            do
            {
                switch (c)
                {
                    case "1":
                        String hname, mname;
                        Date d;
                        int se;

                        Console.WriteLine("write hall name from list: \n");
                        foreach (String s in names) Console.WriteLine(" "+s+";");
                        hname = Console.ReadLine();
                        Console.WriteLine("write cinema name: \n");
                        mname = Console.ReadLine();
                        Console.WriteLine("write date in format dd.mm.yyyy: \n");
                        String[] a = Console.ReadLine().Split('.');
                        d = new Date(Int32.Parse(a[2]), Int32.Parse(a[1]), Int32.Parse(a[0]));
                        Console.WriteLine("write seat num: \n");
                        se = Int32.Parse(Console.ReadLine());
                        addTicket(hname, mname, d, se);
                        break;
                    case "2":
                        Console.WriteLine("write id of ticket: \n");
                        table.showEntry(new MainTable.Key(Int32.Parse(Console.ReadLine())));
                        break;
                    case "3":
                        Console.WriteLine("write id of ticket: \n");
                        table.removeEntry(new MainTable.Key(Int32.Parse(Console.ReadLine())));
                        break;
                    case "4":
                        table.showData();
                        break;
                    case "5":
                        addTicket(names[0], "GODZILLA", new Date(2022, 12, 1), 50);
                        break;
                    default:
                        Console.WriteLine("1 - add ticket\n" +
                            "2 - find ticket\n" +
                            "3 - remove ticket\n" +
                            "4 - show all\n" +
                            "5 - control example\n");
                        break;
                }
            }
            while ((c = Console.ReadLine()) != "q");
        }

        public static void addTicket(String hallName, String movieName, Date date, int seat)
        {
            int id = new Random().Next(221000, 999999);
            if (!names.Contains(hallName))
            {
                Console.WriteLine("hall is not exist!");
                return;
            }
            if(date.year > 2025 || date.year < 2000)
            {
                Console.WriteLine("year must be > 2000 and < 2025");
                return;
            }
            if(date.month > 12 || date.month < 1)
            {
                Console.WriteLine("incorrect month!");
                return;
            }
            if (date.day > 30 || date.day < 1)
            {
                Console.WriteLine("incorrect day!");
                return;
            }
            if(halls[names.IndexOf(hallName)] < seat || seat < 0)
            {
                Console.WriteLine("incorrect seat!");
                return;
            }

            TicketTable.Key tk = new TicketTable.Key(hallName, movieName);
            TicketTable.Value tv = new TicketTable.Value(date, seat);

            MainTable.Key mk = new MainTable.Key(id);
            MainTable.Value mv = new MainTable.Value(movieName, hallName, date, seat);

            List<TicketTable.Value> list = table1.getAllTicketsForDate(tk, date);

            if (list != null)
            {
                if (halls[names.IndexOf(hallName)] / 2 > list.Count)
                {
                    Console.WriteLine("seats in full in half, you can not create ticket here!");
                    return;
                }

                foreach (TicketTable.Value t in list)
                {
                    if (t.seat == seat)
                    {
                        Console.WriteLine("this seat is busy!");
                        return;
                    }
                    if (t.seat == (seat - 1) || t.seat == (seat + 1))
                    {
                        Console.WriteLine("you can not take a seat near another busy seat!");
                        return;
                    }
                }
            }
            table.insertEntry(mk, mv);
            table1.insertEntry(tk, tv);
        }
    }
}
