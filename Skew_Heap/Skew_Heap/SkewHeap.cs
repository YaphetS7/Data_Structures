using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skew_Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            SkewHeap h = new SkewHeap(100);
            h.Add(new Node(-1));
            h.Add(new Node(12323));
            h.Add(new Node(-213));
            h.Add(new Node(21));
            Console.WriteLine(h.root.data);
            //h.Print(h.root);
        }
    }
    public class Node
    {
        public int data;
        public Node parent, left, right;
        public Node(int data)
        {
            this.data = data;
            parent = null;
            left = null;
            right = null;
        }
    }
    public class SkewHeap
    {
        public Node root;
        public SkewHeap(int data)
        {
            root = new Node(data);
        }
        public Node Merge(Node first, Node second)
        {
            if (first == null)
                return second;
            if (second == null)
                return first;

            if (first.data > second.data)
                Swap(ref first, ref second);
            root = first;

            Node temp = first.left;
            first.left = first.right;
            first.right = temp;
            if (temp != null)
                temp.parent = first;
            if (first.right != null)
                first.right.parent = first;

            first.left = Merge(second, first.left);
            return first;
        }
        public void Print(Node node)
        {
            if (node.left != null)
                Print(node.left);
            Console.Write(node.data + "\t");
            if (node.right != null)
                Print(node.right);
        }
        public void Add(Node node)
        {
            Merge(node, root);
        }
        public Node RemoveMin()
        {
            Node node = root;
            Merge(root.left, root.right);
            return node;
        }
        private void Swap(ref Node first,ref Node second)
        {
            Node temp = first;
            first = second;
            second = temp;
        }
    }
}
