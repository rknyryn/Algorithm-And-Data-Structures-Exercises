using DataStructures.LinkedList.SinglyLinkedList;

namespace DataStructures.Stack
{
    public class LinkedListStack<T> : IStack<T>
    {
        public int Count { get; private set; }
        private readonly SinglyLinkedList<T> _stack = new SinglyLinkedList<T>();

        public T Peek()
        {
            if(Count == 0)
                throw new Exception("Empty stack.");
            
            return _stack.Head.Value;
        }
        public T Pop()
        {
            if (Count == 0)
                throw new Exception("Empty stack.");

            var value = _stack.RemoveFirst();
            Count--;
            return value;
        }
        public void Push(T item)
        {
            if(item == null)
                throw new ArgumentNullException("item");
            
            _stack.AddFirst(item);
            Count++;
        }
    }
}