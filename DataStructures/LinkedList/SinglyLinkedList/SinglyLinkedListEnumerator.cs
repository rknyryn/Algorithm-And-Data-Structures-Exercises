
using System.Collections;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    internal class SinglyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private SinglyLinkedListNode<T> _head;
        private SinglyLinkedListNode<T>? _current;

        public SinglyLinkedListEnumerator(SinglyLinkedListNode<T> head)
        {
            _head = head;
            _current = null;
        }
        public T Current => _current.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _head = null;
        }

        public bool MoveNext()
        {
            if (_current == null)
            {
                _current = _head;
                return true;
            }
            else
            {
                _current = _current.Next;
                return _current != null ? true : false;
            }
        }

        public void Reset()
        {
            _current = null;
        }
    }
}