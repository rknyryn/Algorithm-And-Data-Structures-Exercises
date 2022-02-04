using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    public class Queue<T>
    {
        private readonly IQueue<T> _queue;
        public int Count => _queue.Count;

        public Queue(QueueType queueType = QueueType.Array)
        {
            if (queueType == QueueType.Array)
                _queue = new ArrayQueue<T>();
            else
                _queue = new LinkedListQueue<T>();
        }
        public void EnQueue(T value)
        {
            _queue.EnQueue(value);
        }
        public T Dequeue()
        {
            return _queue.Deaqueue();
        }
        public T Peek()
        {
            return _queue.Peek();
        }
    }
    public enum QueueType
    {
        Array = 0,          // List<T>
        Linkedlist = 1,     // DoublyLinkedList<T>
    }
    public interface IQueue<T>
    {
        int Count { get; }
        void EnQueue(T value);
        T Deaqueue();
        T Peek();
    }
}
