using DataStructures.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public class BinaryHeap<T> : IEnumerable<T>
        where T : IComparable
    {
        private int _position;
        private readonly bool _isMax;
        private readonly IComparer<T> _comparer;

        public T[] Array { get; private set; }
        public int Count { get; private set; }

        public BinaryHeap()
        {
            Count = 0;
            Array = new T[128];
            _position = 0;
        }
        public BinaryHeap(int size)
        {
            Count = 0;
            Array = new T[size];
            _position = 0;
        }
        public BinaryHeap(IEnumerable<T> collection)
        {
            Count = 0;
            Array = new T[collection.Count()];
            _position = 0;
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        public BinaryHeap(SortDirection sortDirection = SortDirection.Ascending)
            : this(sortDirection, null, null)
        { }
        public BinaryHeap(SortDirection sortDirection, IEnumerable<T> initial)
            : this(sortDirection, initial, null)
        { }
        public BinaryHeap(SortDirection sortDirection, IComparer<T> comparer)
            : this(sortDirection, null, comparer)
        { }
        public BinaryHeap(SortDirection sortDirection, IEnumerable<T> initial, IComparer<T> comparer)
        {
            _position = 0;
            Count = 0;
            _isMax = sortDirection == SortDirection.Descending;

            if (comparer != null)
                _comparer = new CustomComparer<T>(sortDirection, comparer);
            else
                _comparer = new CustomComparer<T>(sortDirection, Comparer<T>.Default);

            if (initial != null)
            {
                var items = initial as T[] ?? initial.ToArray();
                Array = new T[items.Count()];
                foreach (var item in items)
                    Add(item);
            }
            else
                Array = new T[128];
        }

        private int GetLeftChildIndex(int i) => (2 * i) + 1;
        private int GetRightChildIndex(int i) => (2 * i) + 2;
        private int GetParentIndex(int i) => (i - 1) / 2;

        private bool HasLeftChild(int i) => GetLeftChildIndex(_position) < i;
        private bool HasRightChild(int i) => GetRightChildIndex(_position) < i;
        private bool IsRoot(int i) => i == 0;

        private T GetLeftChild(int i) => Array[GetLeftChildIndex(i)];
        private T GetRightChild(int i) => Array[GetRightChildIndex(i)];
        private T GetParent(int i) => Array[GetParentIndex(i)];

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

        private void HeapifyUp()
        {
            var index = _position - 1;
            while (!IsRoot(index) && _comparer.Compare(Array[index], GetParent(index)) < 0)
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }
        private void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && _comparer.Compare(GetRightChild(index), GetLeftChild(index)) < 0)
                    smallerIndex = GetRightChildIndex(index);
                if (_comparer.Compare(Array[smallerIndex], Array[index]) >= 0)
                    break;
            }
        }

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
