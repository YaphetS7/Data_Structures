using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinTree
{
   public class Node
    {
        public int value;
        public Node parent, left, right;
        public bool HasChild;
        public Node(int x)
        {
            value = x;
            HasChild = false;
            parent = null;
            left = null;
            right = null;
        }
    }
    public class Tree2
    {
        public Node root;
        public int CntOfNodes = 0;
        public Tree2(int x)
        {
            root = new Node(x);
            CntOfNodes++;
        }

        public void AddChild(Node node)
        {
            bool contain = false, isright = false;
            Node temp = FindNode(node.value,ref contain,ref isright);
            if (contain)
                return;
            CntOfNodes++;
            if (isright)
                temp.right = node;
            else
                temp.left = node;
            node.parent = temp;
            temp.HasChild = true;
        }

        public Node FindNode(int x,ref bool check,ref bool isright) //(slot == 0) is left child, (slot == 1) is right child
        {
            Node node = root;
            while (node.HasChild && node.value != x)
            {
                if (x < node.value && node.left != null)
                    node = node.left;

                if (x >= node.value && node.right != null)
                    node = node.right;

                if (x < node.value && node.left == null)
                    break;

                if (x >= node.value && node.right == null)
                    break;
            }
            if (x != node.value)
            {
                check = false;
                if (x < node.value)
                    isright = false;
                else
                    isright = true;

                return node;
            }
            else
            {
                check = true;
                return node;
            }
        }
        public Node FindMaxFrom(Node start)
        {
            while (start.right != null)
                start = start.right;
            return start;
        }
        public Node FindMinFrom(Node start)
        {
            while (start.left != null)
                start = start.left;
            return start;
        }

        public void RemoveNode(int x)
        {
            
            bool check = false, q = false;
            Node temp = FindNode(x,ref check,ref q);
            if (!check)
                return;
            if (temp == root)
                return;
            Node parent = temp.parent;

            if (temp.value < parent.value)
                parent.left = null;
            else
                parent.right = null;

            if (temp.left == null && temp.right == null)
            {
                temp.parent = null;
            }

            if (temp.left == null && temp.right != null)
            {
                temp.parent = null;
                temp = temp.right;

                while (temp.left != null)
                    temp = temp.left;

                temp.parent = parent;
                if (temp.value < parent.value)
                    parent.left = temp;
                else
                    parent.right = temp;
            }

            if (temp.left != null && temp.right == null)
            {
                temp.parent = null;
            }
        }
    }
    class BinTree
    {
        static void Main(string[] args)
        {
            Tree2 tree = new Tree2(10);
            tree.AddChild(new Node(10));
            tree.AddChild(new Node(9));
           
            Console.WriteLine(tree.CntOfNodes);//2
            tree.AddChild(new Node(7));
            tree.AddChild(new Node(1));
            tree.AddChild(new Node(12));
            tree.AddChild(new Node(11));
            tree.AddChild(new Node(15));
            Node max = tree.FindMaxFrom(tree.root);
            Node min = tree.FindMinFrom(tree.root);
            Console.WriteLine(max.value);//15
            Console.WriteLine(min.value);//1
        }
    }
}
