class SLList
{
    public Node tail;
    public class Node
    {
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
        }
        public Node(int data, Node next)
        {
            this.data = data;
            this.next = next;
        }
    }
    public SLList(int data)
    {
        tail = new Node(data);
        tail.next = tail;
    }

public void AddFirst(int data) 
    { 
        tail.next = new Node(data, tail.next); 
    }

    public void AddToPosition(int data, int position) {
        Node buf = tail.next;
        for (int i=0; i < position; i++)
            buf = buf.next;
        buf.next = new Node(data,buf.next);
    }
    public void AddLast(int data)
    {
        Node buf = tail.next;
        tail.next = new Node(data, buf);
    }

    public void DeleteFirst() {
        tail.next = tail.next.next;
    }
    public void DeleteFromPosition(int position) {
        int i = -1;
        Node buf = tail;
        while (i < position)
            buf = buf.next;
        buf.next = buf.next.next;
    }
    public void DeleteLast()
    {
        Node current = tail.next;
        while (current.next != tail.next)
        {
            current = current.next;
        }
        current.next = tail.next;
    }

    public void Print() {
        string result = "";
        Node buf = tail.next;
        for(int i=0;  buf != tail.next || i==0; i++)
        {
            result +="("+i+") "+ buf.data + " ";
            buf = buf.next;
        }
        System.Console.WriteLine(result);
    }

    public int Get(int i)
    {
        int j = -1;
        Node buf = tail;
        while (j < i)
            buf = buf.next;
        return buf.data;
    }
}