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

    private static int SearchFirstEntry(Node head, int value)
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
    private Node? head;
    private Node? tail;

    public void InsertAtTheEnd(int value)
    {
        var node = new Node(value);

        if (tail != null)
        {
            tail.Next = node;
            node.Previous = tail;
        }

        tail = node;

        if (head == null)
        {
            head = node;
        }
    }

    public int FindFirstElementEntry(int value)
    {
        if (head == null) throw new EmptyListException("List is empty");
        var curr = head;
        int index = 0;
        while (curr != null)
        {
            if (curr.Data == value)
            {
                return index;
            }

            curr = curr.Next;
            index++;
        }

        return index;
    }

    public int FindSumOfOddElements()
    {
        if (head == null) throw new EmptyListException("List is empty");
        var curr = head;
        int index = 0;
        int sum = 0;
        while (curr != null)
        {
            if (index % 2 == 1)
            {
                sum += curr.Data;
            }

            curr = curr.Next;
            index++;
        }

        return sum;
    }

    public DoublyLinkedList GetListOfElementsGreaterThan(int value)
    {
        if (head == null) throw new EmptyListException("List is empty");
        var list = new DoublyLinkedList();
        var curr = head;
        while (curr != null)
        {
            if (curr.Data > value)
            {
                list.InsertAtTheEnd(curr.Data);
            }

            curr = curr.Next;
        }

        return list;
    }
//FIX
    public void DeleteElementsGreaterThanAverage()
    {
        if (head == null) throw new EmptyListException("List is empty");
        var curr = head;
        int sum = 0;
        int count = 0;
        while (curr != null)
        {
            sum += curr.Data;
            count++;
            curr = curr.Next;
        }

        var average = sum / count;
        curr = head;
        while (curr != null)
        {
            if (curr.Data > average)
            {
                curr.Previous!.Next = curr.Next;
                curr.Next!.Previous = curr.Previous;
            }

            curr = curr.Next;
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        var current = head;
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
        var list = Io.InputList("Enter the elements for your list: ");
        Io.PrintList(list);
        var newList = list.GetListOfElementsGreaterThan(5);
        newList.DeleteElementsGreaterThanAverage();
        Io.PrintList(newList);
    }
}

public static class Io
{
    public static DoublyLinkedList InputList(string massage)
    {
        Console.WriteLine(massage);
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNullException(nameof(input));
        }

        int[] array = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => Convert.ToInt32(x))
            .ToArray();
        var list = new DoublyLinkedList();
        foreach (var item in array)
        {
            list.InsertAtTheEnd(item);
        }

        return list;
    }

    public static void PrintList(DoublyLinkedList list)
    {
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
    }
}

class EmptyListException : Exception
{
    public EmptyListException()
    {
    }

    public EmptyListException(string message) : base(message)
    {
    }

    public EmptyListException(string message, Exception inner) : base(message, inner)
    {
    }
}