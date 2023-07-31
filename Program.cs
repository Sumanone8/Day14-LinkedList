using System;

public class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList
{
    public Node Head;

    public LinkedList()
    {
        Head = null;
    }

    public void AddNode(int data)
    {
        Node newNode = new Node(data);

        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            Node current = Head;

            // Find the position to insert the new node
            while (current.Next != null && current.Next.Data < data)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }
    }

    public void DisplayList()
    {
        Node current = Head;
        while (current != null)
        {
            Console.Write(current.Data + "->");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}

public class Program
{
    public static void Main()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddNode(56);
        linkedList.AddNode(70);
        linkedList.AddNode(30);

        Console.WriteLine("Linked List Sequence: ");
        linkedList.DisplayList();
    }
}
