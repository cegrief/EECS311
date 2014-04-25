using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_1
{
    /// <summary>
    /// A queue internally implemented as a linked list of objects
    /// </summary>
    public class LinkedListQueue : Queue
    {
        class Node
        {
            public Node(object o){thing = o;}
            public object thing;
            public Node next;
        }

        Node head;
        Node tail;
        int count;
        /// <summary>
        /// Add object to end of queue
        /// </summary>
        /// <param name="o">object to add</param>
        public override void Enqueue(object o)
        {
            Node nextNode = new Node(o);
            if (IsEmpty)
                head = tail = nextNode;
            else
            {
                tail.next = nextNode;
                tail = nextNode;
            }
            count++;
        }

        /// <summary>
        /// Remove object from beginning of queue.
        /// </summary>
        /// <returns>Object at beginning of queue</returns>
        public override object Dequeue()
        {
            if(IsEmpty)
                throw new QueueEmptyException();
            object o = head.thing;
            head = head.next;
            count--;
            return o;
        }

        /// <summary>
        /// The number of elements in the queue.
        /// </summary>
        public override int Count
        {
            get
            {
                return count;
            }
        }

        /// <summary>
        /// True if the queue is full and enqueuing of new elements is forbidden.
        /// Note: LinkedListQueues can be grown to arbitrary length, and so can
        /// never fill.
        /// </summary>
        public override bool IsFull
        {
            get
            {
                return false;
            }
        }
    }
}
