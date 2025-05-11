using DoublyLinkedListLibrary;

namespace DoublyLinkedList_oop;

class Program
{
    static void Main(string[] args)
    {
        var list = new DoublyLinkedList();
        list.InsertAtTheEnd(1);
        list.InsertAtTheEnd(2);
        list.InsertAtTheEnd(5);
        list.InsertAtTheEnd(12);
        list.InsertAtTheEnd(2);
        list.InsertAtTheEnd(5);
        list.InsertAtTheEnd(7);
        list.InsertAtTheEnd(1);
        Console.WriteLine("Your List:");
        PrintList(list);
        Console.WriteLine("Enter element you want to search: ");
        var elementToSearch = Convert.ToInt32(Console.ReadLine());
        //
        Console.WriteLine($"First entry of element {elementToSearch} at index: " +
                          list.FindFirstElementEntry(elementToSearch));

        Console.WriteLine("Sum of odd elements: " + list.FindSumOfOddElements());

        Console.WriteLine("Enter value to get list of elements greater than: ");
        var element = Convert.ToInt32(Console.ReadLine());
        var newList = list.GetListOfElementsGreaterThan(element);
        Console.WriteLine($"List of elements greater than {element}: ");
        PrintList(newList);

        list.DeleteElementsGreaterThanAverage();
        Console.WriteLine("List after deleting elements greater than average: ");
        PrintList(list);
    }

    static void PrintList(DoublyLinkedList list)
    {
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }
}