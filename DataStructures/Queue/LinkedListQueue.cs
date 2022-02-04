using DataStructures.LinkedList.DoublyLinkedList;

namespace DataStructures.Queue
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        private readonly DoublyLinkedList<T> _list = new DoublyLinkedList<T>();
        public int Count { get; private set; }

        public T Deaqueue()
        {
            if (Count == 0)
                throw new Exception("Empty queue");
            var value = _list.RemoveFirst();
            return value;
        }
        public void EnQueue(T value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            _list.AddLast(value);
            Count++;
        }
        public T Peek() => Count == 0
            ? throw new Exception("Empty queue")
            : _list.Head.Value;
    }
}