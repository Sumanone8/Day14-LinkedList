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

            while (current.Next != null)
            {
                current = current.Next;
            }

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

    public void InsertAfter(int key, int data)
    {
        Node nodeToInsertAfter = Search(key);
        if (nodeToInsertAfter != null)
        {
            Node newNode = new Node(data);
            newNode.Next = nodeToInsertAfter.Next;
            nodeToInsertAfter.Next = newNode;
        }
    }

    public void DeleteNode(int key)
    {
        if (Head == null)
        {
            return;
        }

        if (Head.Data == key)
        {
            Head = Head.Next;
            return;
        }

        Node current = Head;
        while (current.Next != null)
        {
            if (current.Next.Data == key)
            {
                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
    }

    public int Size()
    {
        int count = 0;
        Node current = Head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
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
    public void TestDeleteNodeAndSize()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddNode(56);
        linkedList.AddNode(30);
        linkedList.AddNode(40);
        linkedList.AddNode(70);

        linkedList.DeleteNode(40);

        Console.WriteLine("Linked List Sequence after Deletion: ");
        linkedList.DisplayList();

        int size = linkedList.Size();
        Assert.AreEqual(3, size);
        Console.WriteLine("Linked List Size: " + size);
    }
}

public class Program
{
    public static void Main()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddNode(56);
        linkedList.AddNode(30);
        linkedList.AddNode(40);
        linkedList.AddNode(70);

        Console.WriteLine("Linked List Sequence: ");
        linkedList.DisplayList();
    }
}