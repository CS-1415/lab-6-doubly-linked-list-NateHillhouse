namespace DoublyLinkedListNunit;

using System.Diagnostics;
using DoublyLinkedListClassLib;

public class LinkedListStartingWithThreeTests
{
    IDoubleEndedCollection<int> list;

    [SetUp]
    public void Setup()
    {
        list = new DoublyLinkedList<int>(2);
        list.AddFirstValue(1);
        list.AddLastValue(3);
    }

    [Test]
    public void CheckReverse()
    {
        IDoubleEndedCollection<int> oldList = list;
        list.ReverseList();
        Debug.Assert(list.First != null && list.Last != null && oldList.First != null && oldList.Last != null);

        Debug.Assert(list.First.Value == oldList.Last.Value, $"FirstList val: {list.First.Value}, LastList val: {oldList.Last.Value}, LastList First val: {oldList.First.Value}");
        Debug.Assert(list.Last.Value == oldList.First.Value, $"FirstList val: {list.Last.Value}, LastList val: {oldList.First.Value}");

        DLLNode<int>? node = list.First;
        DLLNode<int>? nodeTwo = oldList.Last;
        while (node != null && nodeTwo != null)
        {
            Debug.Assert(node.Value == nodeTwo.Value);
            node = node.Next;
            nodeTwo = nodeTwo.Previous;
        }
    }
}
