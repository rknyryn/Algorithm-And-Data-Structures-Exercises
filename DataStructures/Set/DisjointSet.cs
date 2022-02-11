using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Set
{
    public class DisjointSet<T> : IEnumerable<T>
    {
        private Dictionary<T, DisjointSetNode<T>> _set
            = new Dictionary<T, DisjointSetNode<T>>();

        public int Count { get; set; }

        public DisjointSet()
        {

        }
        public DisjointSet(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                MakeSet(item);
        }

        public void MakeSet(T value)
        {
            if (_set.ContainsKey(value))
                throw new Exception("The value has already been defined.");
            var newSet = new DisjointSetNode<T>(value, 0);
            newSet.Parent = newSet;
            _set.Add(value, newSet);
            Count++;
        }
        public T FindSet(T value)
        {
            if (!_set.ContainsKey(value))
                throw new Exception("The value is not in this set!");
            return findSet(_set[value]).Value;

        }
        public void Union(T valueA, T valueB)
        {
            if (valueA == null || valueB == null)
                throw new ArgumentNullException();

            var rootA = FindSet(valueA);
            var rootB = FindSet(valueB);

            if (rootA.Equals(rootB))
                return;

            var nodeA = _set[rootA];
            var nodeB = _set[rootB];

            if (nodeA.Rank == nodeB.Rank)
            {
                nodeB.Parent = nodeA;
                nodeA.Rank++;
            }
            else if (nodeA.Rank < nodeB.Rank)
                nodeA.Parent = nodeB;
            else
                nodeB.Parent = nodeA;
        }

        private DisjointSetNode<T> findSet(DisjointSetNode<T> node)
        {
            var parent = node.Parent;
            if (node != parent)
            {
                node.Parent = findSet(node.Parent);
                return node.Parent;
            }
            return parent;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _set.Values.Select(x => x.Value).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
