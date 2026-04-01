namespace DoublyLinkedListNunit;

using System.Diagnostics;
using DoublyLinkedListClassLib;

public class LinkedListStartingWithOneAtFrontTests
{
    IDoubleEndedCollection<int> list;
    [SetUp]
    public void Setup()
    {
        list = new DoublyLinkedList<int>();
    }

    [Test]
    public void AddLast()
    {
       list.AddLastValue(1);
       Debug.Assert(list.First != null && list.Last != null);
       Debug.Assert(list.First.Value == 1 && list.Last.Value == 1);
       Debug.Assert(list.First == list.Last);
    }

    [Test]
    public void AddFirst()
    {
       list.AddFirstValue(1);
       Debug.Assert(list.First != null && list.Last != null);
       Debug.Assert(list.First.Value == 1 && list.Last.Value == 1);
       Debug.Assert(list.First == list.Last);
    }
    [Test]
    public void RemoveLast()
    {
        list.AddFirstValue(1);
        list.RemoveLastValue();
        Debug.Assert(list.First == null && list.Last == null);
    }
    [Test]
    public void RemoveFirst()
    {
        list.AddFirstValue(1);
        list.RemoveFirstValue();
        Debug.Assert(list.First == null && list.Last == null);
    }
}
