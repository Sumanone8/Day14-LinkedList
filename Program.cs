using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

    public Node Search(int key)
    {
        Node current = Head;
        while (current != null)
        {
            if (current.Data == key)
            {
                return current;
            }
            current = current.Next;
        }
        return null;
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

[TestClass]
public class LinkedListTests
{
    [TestMethod]
    public void TestSearchNode()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddNode(56);
        linkedList.AddNode(30);
        linkedList.AddNode(70);

        Node foundNode = linkedList.Search(30);
        Node notFoundNode = linkedList.Search(100);

        Assert.IsNotNull(foundNode);
        Assert.AreEqual(30, foundNode.Data);

        Assert.IsNull(notFoundNode);
    }
}

public class Program
{
    public static void Main()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddNode(56);
        linkedList.AddNode(30);
        linkedList.AddNode(70);

        Console.WriteLine("Linked List Sequence: ");
        linkedList.DisplayList();
    }
}
