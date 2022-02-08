using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        public List<Node<T>> list { get; private set; }

        public BinaryTree()
        {
            list = new List<Node<T>>();
        }
        public List<Node<T>> InOrder(Node<T> node)
        {
            if (node != null)
            {
                InOrder(node.Left);
                list.Add(node);
                InOrder(node.Right);
            }
            return list;
        }
        public List<Node<T>> PreOrder(Node<T> node)
        {
            if (node != null)
            {
                list.Add(node);
                PreOrder(node.Left);
                PreOrder(node.Right);
            }
            return list;
        }
        public List<Node<T>> PostOrder(Node<T> node)
        {
            if (node != null)
            {
                PreOrder(node.Left);
                PreOrder(node.Right);
                list.Add(node);
            }
            return list;
        }
        public Node<T> DeepestNode(Node<T> node)
        {
            if (node == null)
                throw new Exception("Empty tree");
            Node<T> temp = null;
            var q = new DataStructures.Queue.Queue<Node<T>>();
            q.EnQueue(node);
            while (q.Count > 0)
            {
                temp = q.Dequeue();
                if (temp.Left != null)
                    q.EnQueue(temp.Left);
                if (temp.Right != null)
                    q.EnQueue(temp.Right);
            }
            return temp;
        }
        public void ClearList() => list.Clear();
        public static int MaxDepth(Node<T> node)
        {
            if (node == null)
                return 0;
            int leftDepth = MaxDepth(node.Left);
            int rightDepth = MaxDepth(node.Right);

            return (leftDepth > rightDepth) ? leftDepth + 1 : rightDepth + 1;
        }
        public static int NumberOfLeafs(Node<T> node)
        {
            int count = 0;
            if (node == null)
                return count;
            var q = new DataStructures.Queue.Queue<Node<T>>();
            q.EnQueue(node);
            while (q.Count > 0)
            {
                var temp = q.Dequeue();
                if (temp.Left == null && temp.Right == null)
                    count++;
                if (temp.Left != null)
                    q.EnQueue(temp.Left);
                if (temp.Right != null)
                    q.EnQueue(temp.Right);
            }
            return count;
        }
    }
}
