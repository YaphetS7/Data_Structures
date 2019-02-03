using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splay_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            SplayTree tree = new SplayTree(100);
            tree.Insert(50);
            tree.Insert(101);
            Console.WriteLine(tree.root.value); //101
        }
    }
    public class Node
    {
        public int value;
        public Node parent, left, right;
        public Node(int value)
        {
            this.value = value;
            parent = null;
            left = null;
            right = null;
        }
    }
    public class SplayTree
    {
        public Node root;
        public SplayTree(int value)
        {
            root = new Node(value);
        }
        private void Splay(Node node)
        {
            
            if (node.parent == null)
            {
                root = node;
                return;
            }
            Node parent = node.parent;
            Node gparent = node.parent.parent;
            if (gparent == null)
            {
                Rotate(parent, node);
                root = node;
                return;
            }
            else
            {
                bool zigzig = (gparent.left == parent) == (parent.left == node);
                if (zigzig)
                {
                    Rotate(gparent, parent);
                    Rotate(parent, node);
                }
                else
                {
                    Rotate(parent, node);
                    Rotate(gparent, node);
                }
            }
            Splay(node);
        }
        private void Rotate(Node parent, Node child)
        {
            Node gparent = parent.parent;
            if (gparent != null)
            {
                if (gparent.left == parent)
                    gparent.left = child;
                else
                    gparent.right = child;
            }

            if (parent.left == child)
            {
                parent.left = child.right;
                child.right = parent;
                parent.parent = child;
                if (parent.left != null)
                    parent.left.parent = parent;
            }
            else
            {
                parent.right = child.left;
                parent.parent = child;
                child.left = parent;
                if (parent.right != null)
                    parent.right.parent = parent;
            }
            child.parent = gparent;
        }
        public Node Find(int value)////
        {
            Node node = root;
            while (node != null)
            {
                if (node.value == value)
                    return node;
                if (value > node.value)
                    node = node.right;
                else
                    node = node.left;
            }
            if (node != null)
                Splay(node);
            return root;
        }
        public void Insert(int value)////
        {
            Node newnode = new Node(value);
            Node node = root;
            while (true)
            {
                if (node.value == value)
                {
                    AddRight(node, newnode);
                    break;
                }
                if (value < node.value)
                {
                    if (node.left == null)
                    {
                        node.left = newnode;
                        newnode.parent = node;
                        break;
                    }
                    else
                    {
                        if (value == node.left.value)
                        {
                            AddRight(node.left, newnode);
                            break;
                        }
                        if (value > node.left.value)
                        {
                            AddLeft(node, newnode);
                            break;
                        }
                        node = node.left;
                    }
                }
                else
                {
                    if (node.right == null)
                    {
                        node.right = newnode;
                        newnode.parent = node;
                        break;
                    }
                    else
                    {
                        if (value == node.right.value)
                        {
                            AddRight(node.right, newnode);
                            break;
                        }
                        if (value < node.right.value)
                        {
                            AddRight(node, newnode);
                            break;
                        }
                        node = node.right;
                    }
                }
            }
            Splay(newnode);
        }
        private Node FindMaxFrom(Node start)
        {
            while (start.right != null)
                start = start.right;
            return start;
        }
        private Node FindMinFrom(Node start)
        {
            while (start.left != null)
                start = start.left;
            return start;
        }
        private void AddRight(Node parent, Node child)
        {
            Node temp = parent.right;
            parent.right = child;
            child.right = temp;
            child.parent = parent;
            if (temp != null)
                temp.parent = child;
        }
        private void AddLeft(Node parent, Node child)
        {
            Node temp = parent.left;
            child.left = temp;
            child.parent = parent;
            parent.left = child;
            if (temp != null)
                temp.parent = child;
        }
        public void Remove(int value)////
        {
            Node node = Find(value);
            if (node != null)
                Splay(node);
            else
                return;
            Merge(node.left, node.right);
        }
        public void Merge(Node first, Node second)////
        {
            Node max = FindMaxFrom(first);
            Node min = FindMinFrom(second);
            if (max.value <= min.value)
            {
                Splay(max);
                first.right = second;
                second.parent = first;
            }
        }
    }
}
