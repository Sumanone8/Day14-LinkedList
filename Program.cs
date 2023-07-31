using System;

public class Node<T> where T : IComparable<T>
{
    public T Data;
    public Node<T> Next;

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class SortedLinkedList<T> where T : IComparable<T>
{
    public Node<T> Head;

    public SortedLinkedList()
    {
        Head = null;
    }

    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (Head == null || data.CompareTo(Head.Data) < 0)
        {
            newNode.Next = Head;
            Head = newNode;
        }
        else
        {
            Node<T> current = Head;
            while (current.Next != null && data.CompareTo(current.Next.Data) >= 0)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }
    }

    public void DisplayList()
    {
        Node<T> current = Head;
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
        SortedLinkedList<int> sortedList = new SortedLinkedList<int>();
        sortedList.Add(56);
        sortedList.Add(30);
        sortedList.Add(40);
        sortedList.Add(70);

        Console.WriteLine("Sorted Linked List Sequence: ");
        sortedList.DisplayList();
    }
}
