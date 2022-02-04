using DataStructures.LinkedList.DoublyLinkedList;
using DataStructures.LinkedList.SinglyLinkedList;
using System.Collections;

//ARRAY
#region
//var arr = new DataStructures.Array.Array<int>();
//arr.Add(3);
//arr.Add(4);
//arr.Add(5);
//arr.Add(6);
//arr.Add(7);
//arr.Remove();
//arr.Remove();
//arr.Remove();
//arr.Remove();

//foreach (var item in arr)
//{
//    Console.WriteLine(item);
//    Console.WriteLine($"{arr.Count} / {arr.Capacity}");
//}

//Console.WriteLine("--------------------");

//arr.Remove(3);
//arr.Remove(4);
//arr.Remove(7);

//Console.WriteLine($"{arr.Count} / {arr.Capacity}");
//arr.Where(x => x % 2 == 0).ToList().ForEach(x => Console.WriteLine(x));
#endregion

#region
//var arr2 = new DataStructures.Array.Array<int>(1, 2, 3, 4, 12);
//foreach (var item in arr2)
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine("--------------------");

//var p1 = new DataStructures.Array.Array<int> { 1, 2, 23, 89 };
//var p2 = new int[] { 14, 25, 23, 75 };
//var p3 = new List<int>() { 5, 15, 20, 25 };
//var p4 = new ArrayList() { 98, 97, 96, 95 };

//var arr3 = new DataStructures.Array.Array<int>(p3);
//foreach (var item in arr3)
//    Console.WriteLine(item);

//Console.WriteLine("--------------------");
#endregion

#region
//var arr4 = new DataStructures.Array.Array<int>();
//for (int i = 0; i < 9; i++)
//{
//    arr4.Add(i + 1);
//    Console.WriteLine($"{i + 1} has been added to array");
//    Console.WriteLine($"{arr4.Count}/{arr4.Capacity}");
//}
//Console.WriteLine("---");
//for (int i = arr4.Count - 1; i >= 1; i--)
//{
//    Console.WriteLine($"{arr4.Remove()} has been removed to array");
//    Console.WriteLine($"{arr4.Count}/{arr4.Capacity}");
//}
#endregion


//LINKED LIST
//singly
#region
//var linkedList = new SinglyLinkedList<int>();
//linkedList.AddFirst(1);
//linkedList.AddFirst(2);
//linkedList.AddFirst(3);
//linkedList.AddLast(4);
//linkedList.AddFirst(5);
//linkedList.AddAfter(linkedList.Head.Next, 99);
////linkedList.AddBefore(null, 888);
//linkedList.AddAfter(linkedList.Head.Next, new SinglyLinkedListNode<int>(789));
/////linkedList.AddBefore(linkedList.Head.Next, new SinglyLinkedListNode<int>(789));

//foreach (var item in linkedList)
//{
//    Console.Write(item + " ");
//}

//Console.WriteLine("\nRemoveFirst: " + linkedList.RemoveFirst());
//Console.WriteLine("RemoveLast: " + linkedList.RemoveLast());
//Console.WriteLine("RemoveLast: " + linkedList.RemoveLast());

////var linkedList2 = new SinglyLinkedList<char>(new char[] {'a', 'b', 'c'});
////foreach (var item in linkedList2)
////{
////    Console.WriteLine(item);
////}
#endregion
//doubly
#region
//DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();
//doublyLinkedList.AddFirst(0);
//doublyLinkedList.AddFirst(1);
//doublyLinkedList.AddFirst(2);
//doublyLinkedList.AddFirst(new DoublyLinkedListNode<int>(99));
//doublyLinkedList.AddLast(777);
//doublyLinkedList.AddLast(new DoublyLinkedListNode<int>(666));
//doublyLinkedList.AddAfter(doublyLinkedList.Tail, 44);
//doublyLinkedList.AddAfter(doublyLinkedList.Head, new DoublyLinkedListNode<int>(33));
//doublyLinkedList.AddBefore(doublyLinkedList.Head.Next, 22);

//foreach (var item in doublyLinkedList)
//{
//    Console.Write(item + " ");
//}
//Console.WriteLine();
//Console.WriteLine($"Remove first: {doublyLinkedList.RemoveFirst()}");
//Console.WriteLine($"Remove last: {doublyLinkedList.RemoveLast()}");
//Console.WriteLine($"Remove: {doublyLinkedList.Remove(22)}");
//Console.WriteLine($"Remove: {doublyLinkedList.Remove(666)}");
//Console.WriteLine($"Remove: {doublyLinkedList.Remove(11)}");

//foreach (var item in doublyLinkedList)
//{
//    Console.Write(item + " ");
//}
#endregion


Console.ReadKey();