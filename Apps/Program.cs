using DataStructures.Heap;
using DataStructures.LinkedList.DoublyLinkedList;
using DataStructures.LinkedList.SinglyLinkedList;
using DataStructures.Set;
using DataStructures.Shared;
using DataStructures.Tree.BinarySearchTree;
using DataStructures.Tree.BinaryTree;
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
#region Singly
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
#region Doubly
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

#region BST
//var bst = new BST<int>();
//bst.Add(20);
//bst.Add(10);
//bst.Add(22);
//bst.Add(25);
//bst.Add(21);

//Console.WriteLine("InOrder");
//new BinaryTree<int>().InOrder(bst.Root).ForEach(item => Console.Write(item + " "));
//Console.WriteLine("\nPreOrder");
//new BinaryTree<int>().PreOrder(bst.Root).ForEach(item => Console.Write(item + " "));
//Console.WriteLine("\nPostOrder");
//new BinaryTree<int>().PostOrder(bst.Root).ForEach(item => Console.Write(item + " "));

//BST<int> BST = new BST<int>(new List<int>() { 60, 40, 70, 20, 45, 65, 85 });
//var bt = new BinaryTree<int>();
//bt.InOrder(BST.Root).ForEach(x => global::System.Console.Write(x + " "));
//BST.Remove(BST.Root, 20);
//bt.ClearList();
//Console.WriteLine();
//bt.InOrder(BST.Root).ForEach(x => global::System.Console.Write(x + " "));
//Console.WriteLine();
//Console.WriteLine("Depth: " + BinaryTree<int>.MaxDepth(BST.Root));
#endregion

#region HEAP
//var heap = new MinHeap<int>(new int[] { 4, 1, 10, 8, 7, 5, 9, 3, 2 });

//foreach (int i in heap)
//    Console.Write(i + " ");

//Console.WriteLine("\n-------------");

//var maxHeap = new MaxHeap<int>(new int[] { 54, 45, 36, 27, 29, 18, 21, 11 });
//foreach (var item in maxHeap)
//    Console.Write(item + " ");

//var heap = new BinaryHeap<int>(SortDirection.Ascending, new int[] { 54, 45, 36, 27, 29, 18, 21, 99 });
//foreach (var item in heap)
//{
//    Console.Write(item + " ");
//}
#endregion

#region DisjointSet
//var disjointSet = new DisjointSet<int>(new int[] { 0, 1, 2, 3, 4, 5, 6 });
//disjointSet.Union(5, 6);
//disjointSet.Union(1, 2);
//disjointSet.Union(0, 2);

//for (int i = 0; i < 7; i++)
//{
//    Console.WriteLine($"Find({i}) = {disjointSet.FindSet(i)}");
//}
#endregion
Console.ReadKey();