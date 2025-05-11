namespace DoublyLinkedListLibrary;

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
}