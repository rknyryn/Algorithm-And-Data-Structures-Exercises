using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedListNode<T>
    {
        public T? Value { get; set; }
        public DoublyLinkedListNode<T>? Next { get; set; }
        public DoublyLinkedListNode<T>? Prev { get; set; }

        public DoublyLinkedListNode(T value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
        public DoublyLinkedListNode()
        {
            Next = null;
            Prev = null;
        }
        public override string ToString() => $"{Value}";
    }
}
