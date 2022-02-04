namespace DataStructures.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        public int Count { get; private set; }
        private readonly List<T> _stack = new List<T>();

        public T Peek()
        {
            if (_stack.Count == 0)
                throw new Exception("Empty stack.");

            return _stack[_stack.Count - 1];
        }
        public T Pop()
        {
            if (_stack.Count == 0)
                throw new Exception("Empty stack.");
            
            var value = _stack[_stack.Count - 1];
            _stack.RemoveAt(Count - 1);
            Count--;
            return value;
        }
        public void Push(T item)
        {
            if(item == null)
                throw new ArgumentNullException("value");

            _stack.Add(item);
            Count++;
        }
    }
}