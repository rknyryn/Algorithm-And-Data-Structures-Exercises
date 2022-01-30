using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedListNode<T>? Head { get; set; }

        public SinglyLinkedList()
        {

        }
        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                this.AddLast(item);
        }
        private bool isHeadNull => Head == null;
        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            if (!isHeadNull)
                newNode.Next = Head;
            Head = newNode;
        }
        public void AddLast(T value)
        {
            if (isHeadNull)
            {
                AddFirst(value);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(value);
            var pointer = Head;
            while (pointer.Next != null)
                pointer = pointer.Next;
            pointer.Next = newNode;
        }
        public void AddAfter(SinglyLinkedListNode<T> node, T value)
        {
            if (node == null)
                throw new ArgumentNullException("Node cannot be null.");

            if (isHeadNull)
            {
                AddFirst(value);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(value);
            var pointer = Head;
            while (pointer != null)
            {
                if (pointer.Equals(node))
                {
                    newNode.Next = pointer.Next;
                    pointer.Next = newNode;
                    return;
                }
                pointer = pointer.Next;
            }
            throw new ArgumentException("Thre referance node is not in this list.");
        }
        public void AddAfter(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            if (refNode == null || newNode == null)
                throw new ArgumentNullException("Arguments cannot be null.");

            if (isHeadNull)
            {
                AddFirst(newNode.Value);
                return;
            }

            var pointer = Head;
            while (pointer != null)
            {
                if (pointer.Equals(refNode))
                {
                    newNode.Next = pointer.Next;
                    pointer.Next = newNode;
                    return;
                }
                pointer = pointer.Next;
            }
            throw new ArgumentException("Thre referance node is not in this list.");
        }
        public void AddBefore(SinglyLinkedListNode<T> node, T value)
        {
            if (node == null)
                throw new ArgumentNullException("Node cannot be null.");

            if (isHeadNull)
            {
                AddFirst(value);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(value);
            var pointer = Head;
            while (pointer != null)
            {
                if (pointer.Next != null && pointer.Next.Equals(node))
                {
                    newNode.Next = pointer.Next;
                    pointer.Next = newNode;
                    return;
                }
                pointer = pointer.Next;
            }
            throw new ArgumentException("Thre referance node is not in this list.");
        }
        public void AddBefore(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            if (refNode == null || newNode == null)
                throw new ArgumentNullException("Arguments cannot be null.");

            if (isHeadNull)
            {
                AddFirst(newNode.Value);
                return;
            }

            var pointer = Head;
            while (pointer != null)
            {
                if (pointer.Next != null && pointer.Next.Equals(refNode))
                {
                    newNode.Next = pointer.Next;
                    pointer.Next = newNode;
                    return;
                }
                pointer = pointer.Next;
            }
            throw new ArgumentException("Thre referance node is not in this list.");
        }
        public T RemoveFirst()
        {
            if (isHeadNull)
                throw new ArgumentNullException("Underflow nothing to remove.");
            var firstValue = Head.Value;
            Head = Head.Next;
            return firstValue;
        }
        public T RemoveLast()
        {
            if (isHeadNull)
                throw new ArgumentNullException("Underflow nothing to remove.");
            var pointer = Head;
            SinglyLinkedListNode<T> prevNode = null;
            while (pointer.Next != null)
            {
                prevNode = pointer;
                pointer = pointer.Next;
            }
            prevNode.Next = null;
            return pointer.Value;
        }
        public void Remove(T value)
        {
            if (isHeadNull)
                throw new ArgumentNullException("Underflow nothing to remove.");
            if (value == null)
                throw new ArgumentNullException("Value cannot be null.");

            var pointer = Head;
            SinglyLinkedListNode<T> prev = null;
            do
            {
                if (pointer.Value.Equals(value))
                {
                    if (pointer.Next == null)
                    {
                        if (prev == null)
                        {
                            Head = null;
                            return;
                        }
                        else
                        {
                            prev.Next = null;
                            return;
                        }
                    }
                    else
                    {
                        if (prev == null)
                        {
                            Head = Head.Next;
                            return;
                        }
                        else
                        {
                            prev.Next = pointer.Next;
                            return;
                        }
                    }
                }
                prev = pointer;
                pointer = pointer.Next;
            } while (value != null);
            throw new ArgumentException("The value could not be found in the list!");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
