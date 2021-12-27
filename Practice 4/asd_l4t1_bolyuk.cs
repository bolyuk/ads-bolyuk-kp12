using System;
    class asd_l4t1_bolyuk
{

     static void  Main()
    {
        SLList list = new SLList(1);
        for (int i = 0; i < 10; i++)
            list.AddLast(new Random().Next(-50, 50));

        list.Print();

        int maxData=list.tail.next.data, max=0;
        SLList.Node buf = list.tail.next;
        for (int i=0; buf != list.tail.next || i==0; i++)
        {
            if (maxData < buf.data)
            {
                max = i;
                maxData = buf.data;
            }
            buf = buf.next;
        }
        Console.WriteLine("max pos is "+max);
        list.AddToPosition(new Random().Next(-50, 50), max);
        list.Print();

    }

    }

