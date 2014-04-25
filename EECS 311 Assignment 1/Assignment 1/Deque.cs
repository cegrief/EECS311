using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_1
{
    /// <summary>
    /// A double-ended queue
    /// Implement this as a doubly-linked list
    /// </summary>
    public class Deque
    {
        class Node
        {
            public Node(object o) { thing = o; }
            public object thing;
            public Node next;
            public Node prev;
        }

        Node head;
        Node tail;
        int count;
        /// <summary>
        /// Add object to end of queue
        /// </summary>
        /// <param name="o">object to add</param>
        public void AddFront(object o)
        {
            Node nextNode = new Node(o);
            if (IsEmpty)
                tail = nextNode;
            else
            {
                nextNode.next = head;
                head.prev = nextNode;
            }
            head = nextNode;
            count++;
        }

        /// <summary>
        /// Remove object from beginning of queue.
        /// </summary>
        /// <returns>Object at beginning of queue</returns>
        public object RemoveFront()
        {
            if(IsEmpty)
                throw new QueueEmptyException();
            object o = head.thing;
            head = head.next;
            count--;
            return o;
        }

        /// <summary>
        /// Add object to end of queue
        /// </summary>
        /// <param name="o">object to add</param>
        public void AddEnd(object o)
        {
            Node nextNode = new Node(o);
            if (IsEmpty)
                head = nextNode;
            else
            {
                nextNode.prev = tail;
                tail.next = nextNode;
            }
            tail = nextNode;
            count++;
        }

        /// <summary>
        /// Remove object from beginning of queue.
        /// </summary>
        /// <returns>Object at beginning of queue</returns>
        public object RemoveEnd()
        {
            if (IsEmpty)
                throw new QueueEmptyException();
            object o = tail.thing;
            tail = tail.prev;
            count--;
            return o;
        }

        /// <summary>
        /// The number of elements in the queue.
        /// </summary>
        public int Count
        {
            get
            {
                return count;
            }
        }

        /// <summary>
        /// True if the queue is empty and dequeuing is forbidden.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return count == 0;
            }
        }
    }
}
