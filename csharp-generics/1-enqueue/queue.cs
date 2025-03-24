using System;

/// <summary>
/// This class should not inherit from other classes or interfaces.
/// </summary>
public class Queue<T>
{
    private Node? head;
    private Node? tail;
    private int count;

    /// <summary>
    /// Subclass to manage Queue elements.
    /// </summary>
    public class Node
    {
        public T? value;
        public Node? next;

        public Node(T value)
        {
            if (value == null)
            {
                this.value = default(T);
            }
            else
            {
                this.value = value;
            }
            
            this.next = null;
        }

        public Node()
        {
            this.value = default(T);
            this.next = null;
        }
    }

    /// <summary>
    /// Returns the Queue’s type.
    /// </summary>
    public Type CheckType()
    {
        return typeof(T);
    }

    /// <summary>
    /// Creates a new Node and adds it to the end of the queue.
    /// </summary>
    public void Enqueue(T value)
    {
        Node? newNode = new Node(value);
        if (tail == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.next = newNode;
            tail = newNode;
        }

        count++;
    }

    /// <summary>
    /// Returns the number of nodes in the Queue.
    /// </summary>
    public int Count()
    {
        return count;
    }
}
