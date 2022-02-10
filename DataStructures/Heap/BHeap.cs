using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public abstract class BHeap<T> : IEnumerable<T>
        where T : IComparable
    {
        protected int _position;
        public T[] Array { get; private set; }
        public int Count { get; private set; }

        public BHeap()
        {
            Count = 0;
            Array = new T[128];
            _position = 0;
        }
        public BHeap(int size)
        {
            Count = 0;
            Array = new T[size];
            _position = 0;
        }
        public BHeap(IEnumerable<T> collection)
        {
            Count = 0;
            Array = new T[collection.Count()];
            _position = 0;
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        protected int GetLeftChildIndex(int i) => (2 * i) + 1;
        protected int GetRightChildIndex(int i) => (2 * i) + 2;
        protected int GetParentIndex(int i) => (i - 1) / 2;

        protected bool HasLeftChild(int i) => GetLeftChildIndex(_position) < i;
        protected bool HasRightChild(int i) => GetRightChildIndex(_position) < i;
        protected bool IsRoot(int i) => i == 0;

        protected T GetLeftChild(int i) => Array[GetLeftChildIndex(i)];
        protected T GetRightChild(int i) => Array[GetRightChildIndex(i)];
        protected T GetParent(int i) => Array[GetParentIndex(i)];

        public bool IsEmpty() => _position == 0;
        public T Peek()
        {
            if (IsEmpty())
                throw new Exception("Empty heap!");
            return Array[0];
        }
        public void Swap(int first, int second)
        {
            var temp = Array[first];
            Array[first] = Array[second];
            Array[second] = temp;
        }
        public void Add(T value)
        {
            if (_position == Array.Length)
                throw new IndexOutOfRangeException("Overflow!");
            Array[_position] = value;
            _position++;
            Count++;
            HeapifyUp();
        }
        public T DeleteMinMax()
        {
            if (_position == 0)
                throw new IndexOutOfRangeException("Underflow");
            var temp = Array[0];
            Array[0] = Array[_position];
            _position--;
            Count--;
            HeapifyDown();
            return temp;
        }

        protected abstract void HeapifyUp();
        protected abstract void HeapifyDown();

        public IEnumerator<T> GetEnumerator()
        {
            return Array.Take(_position).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
