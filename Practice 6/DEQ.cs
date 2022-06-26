using System;
namespace asdlab6bolyuk
{

    public class DEQ
    {
        public Node Head;
        public Node Tail;

        public DEQ()
        {
            Head = null;
            Tail = null;
        }

        public bool isEmpty()
        {
            return (Head == null);
        }

        public void insertHead(char c)
        {
            Node node = new Node(c);
            node.next = Head;
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Head.prev = node;
                Head = node;
            }
            print();
        }

        public void insertTail(char c)
        {
            Node node = new Node(c);
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.prev = Tail;
                Tail.next = node;
                Tail = node;
            }
            this.print();
        }

        public DEQ Copy()
        {
            DEQ result = new DEQ();
            Node node = Head;
            while (node != null)
            {
                result.insertTail(node.data);
                node = node.next;
            }
            return result;
        }

        public void removeTail()
        {
            if (isEmpty()) return;

            Tail = Tail.prev;

            if (Tail == null)
                Head = null;
            else
                Tail.next = null;

            print();
        }
        public void removeHead()
        {
            if (isEmpty()) return;

            Head = Head.next;
            if (Head == null)
                Tail = null;
            else
                Head.prev = null;

            print();
        }

        public void print()
        {
            Console.WriteLine("DEQ: "+getSring());
        }

        public String getSring(){
            string result = "";
            Node node = Head;

            while(node != null)
            {
                result += node.data;
                node = node.next;
            }
            return result;
        }

        public bool palindrome()
        {
            DEQ copy = Copy();

            if (copy.isEmpty()) return false;

                do {
                    if (copy.Head.data == copy.Tail.data)
                    {
                    copy.removeTail();
                    copy.removeHead();
                    }
                    else
                        return false;
                }
                while (!copy.isEmpty());
                return true;
        }
        public void half()
        {

            DEQ copy = Copy();
            Console.WriteLine();
            while (!copy.isEmpty())
            {
                Console.Write( copy.Tail.data);

                copy.removeHead();
                copy.removeTail();
            }
        }
        public void parseString(String s)
        {
            foreach (char c in s)
                insertTail(c);
        }
        public void transp()
        {
            int size = 1;
            Node node = Head;

            for(;node != null; size++) { node = node.next; }

          
            for (int i = 0; i < size / 2f; i++)
            {
                this.insertHead(this.Tail.data);
                this.removeTail();
            }
            print();
        }
    }
}
