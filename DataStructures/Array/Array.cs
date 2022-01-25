using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Array
{
    public class Array<T> : IEnumerable<T>, ICloneable
    {
        private T[] InnerList;
        public int Count { get; set; }
        public int Capacity => InnerList.Length;

        public Array()
        {
            InnerList = new T[2];
            Count = 0;
        }
        public Array(params T[] initial)
        {
            InnerList = new T[initial.Length];
            Count = 0;
            foreach (var item in initial)
                Add(item);
        }
        public Array(IEnumerable<T> collection)
        {
            InnerList = new T[collection.Count()];
            Count = 0;
            foreach (var item in collection)
                Add(item);
        }
        public object Clone()
        {
            ///return this.MemberwiseClone();
            var arr = new Array<T>();
            foreach (var item in this)
                arr.Add(item);
            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InnerList.Take(Count).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(T item)
        {
            if (InnerList.Length == Count)
                DoubleArray();
            InnerList[Count] = item;
            Count++;
        }
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Add(item);
        }
        public T Remove()
        {
            if (Count == 0)
                throw new Exception("There is no more item to be removod from the array.");

            var temp = InnerList[Count - 1];
            if (Count > 0)
                Count--;

            if (InnerList.Length / 4 == Count)
                HalfArray();
            return temp;
        }
        public bool Remove(T item)
        {
            if (Count == 0)
                throw new Exception("There is no more item to be removod from the array.");

            for (int i = 0; i < Count; i++)
            {
                if (InnerList[i].Equals(item))
                {
                    Swap(i);
                    Count--;

                    if (InnerList.Length / 4 == Count)
                        HalfArray();
                    return true;
                }
            }
            return false;
        }

        private void Swap(int index)
        {
            for (int i = index; i < Count-1; i++)
            {
                InnerList[i] = InnerList[i+1];
            }
        }

        private void HalfArray()
        {
            if (InnerList.Length > 2)
            {
                var temp = new T[InnerList.Length / 2];
                System.Array.Copy(InnerList, temp, temp.Length);
                InnerList = temp;
            }
        }

        private void DoubleArray()
        {
            var temp = new T[InnerList.Length * 2];
            System.Array.Copy(InnerList, temp, InnerList.Length);
            InnerList = temp;
        }
    }
}
