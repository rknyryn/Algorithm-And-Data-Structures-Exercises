using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable
    {
        public DoublyLinkedListNode<T>? Head { get; set; }
        public DoublyLinkedListNode<T>? Tail { get; set; }

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
        }
        public DoublyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddFirst(item);
            }
        }
        public void AddFirst(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);
            if (isHeadNull && isTailNull)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }
            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
        }
        public void AddFirst(DoublyLinkedListNode<T> node)
        {
            if (isHeadNull && isTailNull)
            {
                Head = node;
                Tail = node;
                return;
            }
            node.Next = Head;
            Head.Prev = node;
            Head = node;
        }
        public void AddLast(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);
            if (isHeadNull && isTailNull)
            {
                AddFirst(newNode);
                return;
            }
            newNode.Prev = Tail;
            Tail.Next = newNode;
            Tail = newNode;
        }
        public void AddLast(DoublyLinkedListNode<T> node)
        {
            if (isHeadNull && isTailNull)
            {
                AddFirst(node);
                return;
            }
            node.Prev = Tail;
            Tail.Next = node;
            Tail = node;
        }
        public void AddAfter(DoublyLinkedListNode<T> refNode, T value)
        {
            if (refNode == null)
                throw new ArgumentNullException("Referance node cannot be null");
            if (isHeadNull && isTailNull)
            {
                AddFirst(value);
                return;
            }
            if (Tail.Equals(refNode))
            {
                AddLast(value);
                return;
            }
            var newNode = new DoublyLinkedListNode<T>(value);
            newNode.Prev = refNode;
            newNode.Next = refNode.Next;
            newNode.Next.Prev = newNode;

            refNode.Next = newNode;
        }
        public void AddAfter(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if (refNode == null)
                throw new ArgumentNullException("Node cannot be null");
            if (isHeadNull && isTailNull)
            {
                AddFirst(newNode);
                return;
            }
            if (Tail.Equals(refNode))
            {
                AddLast(newNode);
                return;
            }
            newNode.Prev = refNode;
            newNode.Next = refNode.Next;
            newNode.Next.Prev = newNode;

            refNode.Next = newNode;
        }
        public void AddBefore(DoublyLinkedListNode<T> refNode, T value)
        {
            if (refNode == null)
                throw new ArgumentNullException("Referance node cannot be null");
            if (isHeadNull && isTailNull)
            {
                AddFirst(value);
                return;
            }
            if (Head.Equals(refNode))
            {
                AddFirst(value);
                return;
            }
            var newNode = new DoublyLinkedListNode<T>(value);
            newNode.Next = refNode;
            newNode.Prev = refNode.Prev;
            newNode.Prev.Next = newNode;

            refNode.Prev = newNode;
        }
        public void AddBefore(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if (refNode == null)
                throw new ArgumentNullException("Referance node cannot be null");
            if (isHeadNull && isTailNull)
            {
                AddFirst(newNode);
                return;
            }
            if (Head.Equals(refNode))
            {
                AddFirst(newNode);
                return;
            }

            newNode.Next = refNode;
            newNode.Prev = refNode.Prev;
            newNode.Prev.Next = newNode;

            refNode.Prev = newNode;
        }
        public T RemoveFirst()
        {
            if (isHeadNull)
                throw new Exception();
            var value = Head.Value;
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
            }
            return value;
        }
        public T RemoveLast()
        {
            if (isHeadNull)
                throw new Exception();
            var value = Tail.Value;
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail = Tail.Prev;
                Tail.Next = null;
            }
            return value;
        }
        public T Remove(T value)
        {
            if (isHeadNull)
                throw new Exception("List is empty.");
            if (Head == Tail)
            {
                if (Head.Value.Equals(value))
                {
                    return RemoveFirst();
                }
            }
            var pointer = Head;
            while (pointer != null)
            {
                if (pointer.Value.Equals(value))
                {
                    if (pointer.Equals(Head))
                    {
                        return RemoveFirst();
                    }
                    else if (pointer.Equals(Tail))
                    {
                        return RemoveLast();
                    }
                    else
                    {
                        pointer.Prev.Next = pointer.Next;
                        pointer.Next.Prev = pointer.Prev;
                        return pointer.Value;
                    }
                }
                pointer = pointer.Next;
            }
            throw new Exception("The value to be deleted is not in the list.");
        }
        public T Remove(DoublyLinkedListNode<T> node)
        {
            return Remove(node.Value);
        }
        public IEnumerator GetEnumerator()
        {
            return GetAllNodes().GetEnumerator();
        }

        private bool isHeadNull => Head == null;
        private bool isTailNull => Tail == null;
        private List<DoublyLinkedListNode<T>> GetAllNodes()
        {
            var list = new List<DoublyLinkedListNode<T>>();
            var pointer = Head;
            while (pointer != null)
            {
                list.Add(pointer);
                pointer = pointer.Next;
            }
            return list;
        }
    }
}
