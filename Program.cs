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
    public void TestInsertAfterNode()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.AddNode(56);
        linkedList.AddNode(30);
        linkedList.AddNode(70);

        Node nodeWithKey30 = linkedList.Search(30);
        Assert.IsNotNull(nodeWithKey30);
        Assert.AreEqual(30, nodeWithKey30.Data);

        linkedList.InsertAfter(30, 40);

        Console.WriteLine("Linked List Sequence after Insertion: ");
        linkedList.DisplayList();
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

