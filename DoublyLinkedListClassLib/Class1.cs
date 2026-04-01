using System.Diagnostics;

namespace DoublyLinkedListClassLib;

public class Class1
{

}


public interface IDoubleEndedCollection<T>
{

    DLLNode<T>? First { get; }
    DLLNode<T>? Last { get; }
    int Length { get; }
 
    void AddFirstValue(T value);
    void RemoveFirstValue();     
    void InsertValue(T value, int key);
    void AddLastValue(T value); 
    void RemoveLastValue();                
    //void RemoveBynewNodeLocation(T value);
    void ReverseList();
}
public class DoublyLinkedList<T> : IDoubleEndedCollection<T> 
{
    public DLLNode<T>? First { get; set; }
    public DLLNode<T>? Last { get; set; } = null;
    public int Length { get; set; } = 0;

    public DoublyLinkedList()
    {
        First = null;
        Last = null;
    }
    public DoublyLinkedList(T initialValue)
    {
        DLLNode<T> node = new(initialValue);
        First = node;
        Last = node;
        Length = 1;
    }
    
    public void AddFirstValue(T value)
    {
        DLLNode<T> node = new(value);
        if (First == null) 
        {
            MakeFirstAndLast(node);
            Length = 1; //Just in case there is an issue with the Length being incorrectly handled
        }
        else
        {
            node.Next = First;
            First.Previous = node;
            First = node;
            Length ++;
        }
    }

    public void RemoveFirstValue()
    {
        if (First == null) throw new Exception("Cannot remove value from an empty list");
        else if (First.Next != null) 
        {
            First.Next.Previous = null;
            First = First.Next;    
        }
        else
        {
            First = null;
            Last = null;    
        }
        Length --;
    }
    
    public void AddLastValue(T value)
    {
        DLLNode<T> node = new(value);
        if (Last == null || First == null || Length == 0) MakeFirstAndLast(node);
        else
        {
            Last.Next = node;
            node.Previous = Last;
            Last = node;
        }
        Length ++;
    }

    public void RemoveLastValue()
    {
        if (Last == null) throw new Exception("Cannot remove from an empty list");
        else if (Last.Previous == null) MakeFirstAndLast(null);
        else
        {
            Last.Previous.Next = null;
            Last = Last.Previous;
        }
        Length --;
    }

    public void InsertValue(T value, int newNodeLocation)
    {
        if (Length < newNodeLocation || newNodeLocation < 0) AddLastValue(value); //throw new Exception($"Cannot insert outside the length of the list ({Length})"); 
        else if (newNodeLocation == 0 || First == null) MakeFirstAndLast(new DLLNode<T>(value));
        else
        {
            DLLNode<T> node = First;
            for (int i = 0; i < newNodeLocation; i++)
            {
                if (node.Next is not null) node = node.Next;
            }
            if (node.Next is null || newNodeLocation == Length) AddLastValue(value);
            else
            {
                DLLNode<T> newNode = new(value);
                DLLNode<T> nextNode = node.Next;

                newNode.Next = nextNode;
                newNode.Previous = node;

                nextNode.Previous = newNode;
                node.Next = newNode;

                Length ++;
            }
        }
    }

    public void ReverseList()
    {
        if (First != null && Last != null)  
        {
            DLLNode<T> node = First;
            DLLNode<T>? newNode = First;
            newNode.Next = null;

            DLLNode<T>? next;
            Last = newNode;
            while(node.Next != null && newNode != null)
            {
                next = node.Next;
                newNode.Previous = next;
                newNode = newNode.Previous;

                node = next;
                newNode.Previous = null;
            }
            First = newNode;
        }
    }

    private void MakeFirstAndLast(DLLNode<T>? node)
    {
        First = node;
        Last = node;
    }
}
public class DLLNode<T> 
{
    public T Value { get; set; }
    public DLLNode<T>? Previous { get; set; }
    public DLLNode<T>? Next { get; set; }

    public DLLNode(T value)
    {
        Value = value;
    }
}