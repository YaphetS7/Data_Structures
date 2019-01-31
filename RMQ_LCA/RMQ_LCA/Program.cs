using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMQ_LCA
{
    public delegate int Func(int v1, int v2);
    class Program
    {
        public static int FindSum(int val1,int val2)
        {
            return val1 + val2;
        }
        public static int FindMin(int val1, int val2)
        {
            if (val1 < val2)
                return val1;
            else
                return val2;
        }
        static void Main(string[] args)
        {
            int[] a = { 1, 3, 2, -1, 4};
            Func func = FindMin;
            RMQ lol = new RMQ(a, func, true);
            //lol.Print();
            Console.WriteLine(lol.Q(0, 1, a.Length - 3)); //2
        }
    }
    public class Node
    {
        public int value = 0, l, r;
        public Node parent, left, right;
        public bool isList;
        public Node()
        {

        }
        public Node(int value)
        {
            this.value = value;
        }
    }
    public class RMQ
    {
        private Func function;
        private Node[] nodes;
        private int[] arr;

        public RMQ(int[] array, Func func, bool top_dowm_tree_build)
        {
            function = func;
            arr = array;
            nodes = new Node[4 * arr.Length];
            for (int i = 0; i < nodes.Length; i++)
            {
                if (i >= arr.Length)
                    nodes[i] = new Node(int.MaxValue);
                else
                    nodes[i] = new Node();
            }
            if (top_dowm_tree_build)
                Tree_Build1(0, 0, arr.Length - 1, arr);
            else
                Tree_Build2(arr);
        }
        
        public void Print()
        {
            for (int i = 0; i < nodes.Length; i++)
                if (nodes[i].value == int.MaxValue)
                    break;
                else
                    Console.WriteLine(nodes[i].value + " [" + nodes[i].l + "; " + nodes[i].r + "] ");
        
        }
        private void Tree_Build1(int i, int l, int r, int[] arr)
        {
            if (l == r)
            {
                nodes[i].value = arr[l];
                nodes[i].l = l;
                nodes[i].r = l;
                return;
            }
            int mid = (l + r) / 2;
            Tree_Build1(i * 2 + 1, l,  mid, arr);
            Tree_Build1(i * 2 + 2, mid + 1, r, arr);
            nodes[i].value = function(nodes[i * 2 + 1].value, nodes[i * 2 + 2].value);
            nodes[i].l = nodes[i * 2 + 1].l;
            nodes[i].r = nodes[i * 2 + 2].r;
        }
        public int Q(int i, int l, int r)
        {
            int il = nodes[i].l;
            int ir = nodes[i].r;
            int mid = (il + ir) / 2;
            if (l > r)
                return int.MaxValue;
         
            if (l == il && r == ir)
                return nodes[i].value;

            return function(Q(i * 2 + 1, l, mid), Q(i * 2 + 2, mid + 1, r));
        }
        private void Tree_Build2(int[] arr)
        {
            int i;
            for (i = 0; i < arr.Length; i++)
                nodes[arr.Length - 1 + i].value = arr[i];
            for (i = arr.Length - 2; i >= 0; i--)
            {
                nodes[i].value = function(nodes[i * 2 + 1].value, nodes[i * 2 + 2].value);
            }
        }
    }
}
