namespace DoublyLinkedListNunit;

using System.Diagnostics;
using DoublyLinkedListClassLib;

public class LinkedListStartingWithTwoTests
{
    IDoubleEndedCollection<int> list;
    [SetUp]
    public void Setup()
    {
        list = new DoublyLinkedList<int>(2);
        list.AddFirstValue(1);
    }

    [Test]
    public void RemoveFirstThenLast()
    {
        list.RemoveLastValue();
        list.RemoveFirstValue();
        Debug.Assert(list.First == null);
        Debug.Assert(list.Last == null);
    }
}
