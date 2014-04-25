using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_1
{
    /// <summary>
    /// A queue internally implemented as an array
    /// </summary>
    public class ArrayQueue : Queue
    {
        bool isFull;
        object[] queue;
        int head;
        int tail;
        public ArrayQueue()
        {
            tail = 0;
            head = 0;
            queue = new object[32];
        }
        /// <summary>
        /// Add object to end of queue
        /// </summary>
        /// <param name="o">object to add</param>
        public override void Enqueue(object o)
        {
            if (IsFull)
                throw new QueueFullException();
            queue[tail] = o;
            tail = (tail + 1)%queue.Length;
            if (tail == head)
                isFull = true;
        }
       

        /// <summary>
        /// Remove object from beginning of queue.
        /// </summary>
        /// <returns>Object at beginning of queue</returns>
        public override object Dequeue()
        {
            if (IsEmpty)
                throw new QueueEmptyException();
            object o = queue[head];
            head = (head + 1) % queue.Length;
            isFull = false;
            return o;

        }

        /// <summary>
        /// The number of elements in the queue.
        /// </summary>
        public override int Count
        {
            get {
                if (isFull)
                    return queue.Length;
                int diff = tail - head;
                if (diff < 0)
                    return queue.Length + diff;
                return diff;
            }
        }

        /// <summary>
        /// True if the queue is full and enqueuing of new elements is forbidden.
        /// </summary>
        public override bool IsFull
        {
            get { return isFull; }
        }
    }
}
