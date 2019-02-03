using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treap
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<Point> list = new List<Point>();
            list.Add(new Point(0, 3));
            list.Add(new Point(2, 4));
            list.Add(new Point(3, 3));
            list.Add(new Point(4, 6));
            list.Add(new Point(5, 1));
            list.Add(new Point(6, 2));
            list.Add(new Point(7, 10));
           
            Treap tree = new Treap(list);
         
            tree.Print(tree.root);
        }
    }
    public class Point
    {
        public int key, priority;
        public Point(int key, int priority)
        {
            this.key = key;
            this.priority = priority;
        }
    }
    public class Node
    {
        public int value, weight;
        public Node left, right, parent;
        public Node(int value, int weight)
        {
            this.value = value;
            this.weight = weight;
            parent = null;
            left = null;
            right = null;
        }
        
    }
    public class Treap
    {
        public Node root;
        public List<Point> list;
        public Node[] arr;
        public Treap(List<Point> _list)
        {
            list = SortByKey(_list);
            arr = new Node[4 * list.Count];
            Build(0, list.Count - 1, root);
        }
        public void Print(Node node) //in-order tree search
        {
            if (node.left != null)
                Print(node.left);
            Console.Write(node.value + "\t");
            if (node.right != null)
                Print(node.right);

        }
        private Node Build(int l, int r, Node node)
        {
            if (l > r)
                return null;
            int index = 0;
            Point curr = FindMaxW(l, r, ref index);
            node = new Node(curr.key, curr.priority);

            if (l == 0 && r == list.Count - 1)
                root = node;
            if (l == r)
                return node;
            node.left = Build(l, index - 1, node.left);
            node.right = Build(index + 1, r, node.right);
            if (node.left != null)
                node.left.parent = node;
            if (node.right != null)
                node.right.parent = node;

            return node;

        }
        public Point FindMaxW(int l, int r, ref int index)
        {
            int key = 0, max = int.MinValue;
            for (int i = l; i <= r; i++)
            {
                if (list[i].priority > max)
                {
                    index = i;
                    max = list[i].priority;
                    key = list[i].key;
                }
            }
            return (new Point(key, max));
        }
        public List<Point> SortByKey(List<Point> list)
        {
            int cnt = list.Count;
            List<Point> interval = new List<Point>();
            foreach (Point i in list)
                interval.Add(i);
            List<Point> result = new List<Point>();
            while (result.Count < cnt)
            {
                int min = int.MaxValue;
                Point temp = interval[0];
                for (int i = 0; i < interval.Count; i++)
                {
                    int a = interval[i].key;
                    if (a < min)
                    {
                        temp = interval[i];
                        min = a;
                    }
                }
                result.Add(temp);
                interval.Remove(temp);
            }
            return result;
        }
    }
        

}
