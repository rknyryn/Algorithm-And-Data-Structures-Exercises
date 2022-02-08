using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.BinarySearchTree
{
    public class BST<T> : IEnumerable<T>
        where T : IComparable
    {
        public Node<T>? Root { get; set; }

        public BST()
        {
            Root = null;
        }
        public BST(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Add(item);
        }
        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            var newNode = new Node<T>(value);
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                var pointer = Root;
                while (true)
                {
                    //Left-bottom
                    if (value.CompareTo(pointer.Value) < 0)
                    {
                        if (pointer.Left == null)
                        {
                            pointer.Left = newNode;
                            break;
                        }
                        pointer = pointer.Left;
                    }
                    //Right-bottom
                    else
                    {
                        if (pointer.Right == null)
                        {
                            pointer.Right = newNode;
                            break;
                        }
                        pointer = pointer.Right;
                    }
                }
            }
        }
        public Node<T> FindMinimun(Node<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            var pointer = node;
            while (pointer.Left != null)
                pointer = pointer.Left;
            return pointer;
        }
        public Node<T> FindMaximum(Node<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            var pointer = node;
            while (pointer.Right != null)
                pointer = pointer.Right;
            return pointer;
        }
        public Node<T> Find(Node<T> node, T value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            var pointer = node;
            while (pointer.Value.CompareTo(value) != 0)
            {
                if (pointer == null)
                    throw new Exception("Could not found!");
                else if (pointer.Value.CompareTo(value) < 0)
                    pointer = pointer.Left;
                else
                    pointer = pointer.Right;
            }
            return pointer;
        }
        public Node<T> Remove(Node<T> node, T value)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (node.Value.CompareTo(value) > 0)
                node.Left = Remove(node.Left, value);
            else if (node.Value.CompareTo(value) < 0)
                node.Right = Remove(node.Right, value);
            else
            {
                if (node.Left == null)
                    return node.Right;
                else if (node.Right == null)
                    return node.Left;

                node.Value = FindMinimun(node.Left).Value;
                node.Right = Remove(node.Right, node.Value);
            }
            return node;
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
