namespace DoublyLinkedListNunit;

using System.Diagnostics;
using DoublyLinkedListClassLib;

public class LinkedListStartingEmptyTests
{
    IDoubleEndedCollection<int> list;
    [SetUp]
    public void Setup()
    {
        list = new DoublyLinkedList<int>();
    }

    [Test]
    public void CorrectLength()
    {
        list.AddFirstValue(6);
        list.AddLastValue(2);
        Debug.Assert(list.Length == 2);
    }

    [Test]
    public void SingleAddLast()
    {
        int val = 6;
        list.AddFirstValue(val);
        Debug.Assert(list.First != null && list.First.Value == val);
    }
    [Test]
    public void SingleAddFirst()
    {
        int val = 6;
        list.AddLastValue(val);
        Debug.Assert(list.First != null && list.First.Value == val);
    }
}
