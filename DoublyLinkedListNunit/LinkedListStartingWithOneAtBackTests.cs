namespace DoublyLinkedListNunit;

using System.Diagnostics;
using DoublyLinkedListClassLib;

public class LinkedListStartingWithOneAtBackTests
{
    IDoubleEndedCollection<int> list;
    [SetUp]
    public void Setup()
    {
        list = new DoublyLinkedList<int>();
        list.AddLastValue(5);
        Debug.Assert(list.Length == 1);
    }

    [Test]
    public void AddLast()
    {
       list.AddLastValue(1);
       Debug.Assert(list.First != null && list.Last != null);

       Debug.Assert(list.Length == 2);
       Debug.Assert(list.First.Value == 5);
       Debug.Assert(list.Last.Value == 1);
    }

    [Test]
    public void AddFirst()
    {
       list.AddFirstValue(1);
       Debug.Assert(list.First != null && list.Last != null);

       Debug.Assert(list.Length == 2);
       Debug.Assert(list.First.Value == 1);
       Debug.Assert(list.Last.Value == 5);
    }
    [Test]
    public void RemoveLast()
    {
        list.RemoveLastValue();
        Debug.Assert(list.First == null);
        Debug.Assert(list.Last == null);
        Debug.Assert(list.Length == 0);
    }
    [Test]
    public void RemoveFirst()
    {
        list.RemoveFirstValue();
        Debug.Assert(list.First == null);
        Debug.Assert(list.Last == null);
        Debug.Assert(list.Length == 0);
    }
}
