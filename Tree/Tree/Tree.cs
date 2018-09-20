using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Node
    {
        public int value;
        public Node parent;
        public bool HaveChild = false;
        public List<Node> childs = new List<Node>();
        public Node(int x)
        {
            value = x;
            parent = null;
        }
    }

    public class SimpleTree
    {
        public Node root;

        public int CountOfNodes = 0;
        public SimpleTree(int x)
        {
            CountOfNodes = 1;
            root = new Node(x);
        }
        public void AddNewChild(Node temp, Node item)
        {
            temp.childs.Add(item);
            temp.HaveChild = true;
            if (temp == root)
            {
                item.parent = root;
                root.HaveChild = true;
            }
            else
                item.parent = temp;
            CountOfNodes++;
        }
        public void RemoveNode(Node node)
        {
            node.parent.childs.Remove(node);

            if (node.parent.childs.Count == 0)
                node.parent.HaveChild = false;

            node.parent = null;
        }
        public void MoveNode(Node start, Node end)
        {
            if (start == root)
                return;

            start.parent.childs.Remove(start);

            if (start.parent.childs.Count == 0)
                start.parent.HaveChild = false;

            start.parent = end;
            end.HaveChild = true;
        }
       
       
        public Node FindNode(int x, Node node, List<Node> list)
        {
            list.Add(node);
            if (node.value == x)
                return node;
            foreach(Node child in node.childs)
            {
                Node n = FindNode(x, child, list);
                if (n != null)
                    return n;
            }
            return null;
        }
        public void PrintTree(Node node)
        {
            Console.Write(node.value + "\t");
            foreach (Node child in node.childs)
            {
                PrintTree(child); 
            }
        }
        public void CountOfLists(int k)
        {
            Node node = root;
            if (!node.HaveChild)
                k++;
            foreach (Node child in node.childs)
            {
                CountOfLists(k);
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        { 
            SimpleTree tree = new SimpleTree(100);
            List<Node> qqw = new List<Node>();
            Node a = tree.FindNode(100, tree.root, qqw);
            qqw.Clear();
            
            tree.AddNewChild(a, new Node(99));
            tree.AddNewChild(a, new Node(0));
            tree.AddNewChild(a, new Node(1234));

            Node b = tree.FindNode(99, tree.root, qqw);
           
            qqw.Clear();
            tree.AddNewChild(b, new Node(1050));
           
            Node c = tree.FindNode(1050, tree.root, qqw);
         
            tree.AddNewChild(c, new Node(1));
            tree.PrintTree(tree.root);
        }
    }
}
