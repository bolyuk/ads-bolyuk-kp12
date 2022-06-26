using System;

public class Node : Object
{
    public Node next;
    public Node prev;
    public char data;

        public Node(char data)
        {
            this.data = data;
        }     
}

