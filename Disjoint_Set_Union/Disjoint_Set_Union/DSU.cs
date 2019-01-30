using System;
using System.Collections.Generic;

namespace Disjoint_Set_Union
{
    class Program
    {
        static void Main(string[] args)
        {
          
        }
    }
    public class Node<T>
    {
        public T value;
        public List<Node<T>> values = new List<Node<T>>();
        public Node<T> parent;
        public Node(T value)
        {
            this.value = value;
            parent = null;
        }
    }
    public class Set<T>
    {
        public Node<T> root;
        public void AddRoot(Node<T> root)
        {
            this.root = root;
            this.root.parent = root;
        }
    }
   
    public class DSU<T>
    {
        public List<Set<T>> list = new List<Set<T>>();
        public int cntOfSets = 0;
        public void MakeSet(Node<T> node)
        {
            Set<T> newset = new Set<T>();
            newset.AddRoot(node);
            list.Add(newset);
            cntOfSets++;
        }
        public Node<T> Find(Node<T> node)
        {
            if (node.parent == node)
                return node;
            node.parent = Find(node.parent);
            return node.parent;
        }
        public void Unite(Node<T> value1, Node<T> value2)
        {
            Node<T> node1 = Find(value1);
            Node<T> node2 = Find(value2);
            if (node1 == node2)
                return;
            int x = new Random().Next(1, 3);
            if (x == 1)
            {
                node1.parent = node2;
                node2.values.AddRange(node1.values);
                foreach(Set<T> set in list)
                    if (set.root == node1)
                    {
                        list.Remove(set);
                        break;
                    }
            }
            else
            {
                node2.parent = node1;
                node1.values.AddRange(node2.values);
                foreach (Set<T> set in list)
                    if (set.root == node2)
                    {
                        list.Remove(set);
                        break;
                    }
            }
            cntOfSets--;
        }
    }
}
