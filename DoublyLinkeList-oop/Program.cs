using System.Collections;

namespace oop_7;

public class Node
{
    private Node? previous;
    private int data;
    private Node? next;

    public Node? Previous
    {
        get => previous;
        set => previous = value;
    }
    
    public int Data
    {
        get => data;
        set => data = value;
    }
    
    public Node? Next
    {
        get => next;
        set => next = value;
    }

    public Node(int value)
    {
        data = value;
        previous = null;
        next = null;
    }
    

    public static void FromHeadTraversal(Node head)
    {
        Node? curr = head;

        while (curr != null)
        {
            Console.Write(curr.data + " ");

            curr = curr.next;
        }

        Console.WriteLine();
    }

    public static int SearchFirstEntry(Node head, int value)
    {
        Node? curr = head;

        while (curr != null)
        {
            if (curr.data == value)
                return curr.data;

            curr = curr.next;
        }

        return -1;
    }

    public static void FromTailTraversal(Node tail)
    {
        Node? curr = tail;

        while (curr != null)
        {
            Console.Write(curr.data + " ");

            curr = curr.previous;
        }

        Console.WriteLine();
    }
}

public class DoublyLinkedList : IEnumerable<int>
{
    private Node head;
    private Node tail;
    
    public void InsertAtTheEnd(int value)
    {
        Node node = new Node(value);

        if (tail != null)
        {
            tail.Next = node;
            node.Previous = tail;
            tail = node;
        }
    }
    public IEnumerator<int> GetEnumerator()
    {
        Node? current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList list = Input.InputList("Enter the elements for your list: ");
    }
}

public static class Input
{
    public static DoublyLinkedList InputList(string massage)
    {
        Console.WriteLine(massage);
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNullException(nameof(input));
        }

        int[] array = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => Convert.ToInt32(x))
            .ToArray();
        DoublyLinkedList list = new DoublyLinkedList();
        foreach (var item in array)
        {
            list.InsertAtTheEnd(item);
        }

        return list;
    }
}