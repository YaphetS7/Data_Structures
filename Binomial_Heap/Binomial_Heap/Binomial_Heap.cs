    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binomial_Heap
{
    class Binomial_Heap
    {
        static void Main(string[] args)
        {

        }
    }
    public class Node
    {
        public int value, cntOfChilds;
        public Node left, right, parent;
        public Node(int value)
        {
            this.value = value;
            left = null;
            right = null;
            parent = null;
            cntOfChilds = 0;
        }
    }
    public class BinomialHeap
    {
        public LinkedList<Node> roots = new LinkedList<Node>();
        public Node[] arr = new Node[100000];
        public int N;
        public string Nbit;
        private int PowerOfTwo(int value)
        {
            int k = 0;
            while(value > 1)
            {
                value = value / 2;
                k++;
            }
            return k;
        }
        public void Add(Node node)
        {
            if (node.cntOfChilds > 0)
            {
                AddTree(node);
                return;
            }
            else
            {
                if (arr[0] != null)
                    Merge(node, arr[0], 0);
                else
                    arr[0] = node;
                N += 1;
                Nbit = Convert.ToString(N, 2);
            }
            
        }
        private void AddTree(Node node)
        {
            int index = PowerOfTwo(node.cntOfChilds + 1);
            if (index > Nbit.Length || Nbit[index] != 1)
            {
                arr[index] = node;
            }
            else
            {
                Merge(node, arr[index], index);
            }
            N += node.cntOfChilds + 1;
            Nbit = Convert.ToString(N, 2);
        }
        private void Merge(Node first, Node second, int index) //index - это индекс массива, элементы которого "сливаются" с другим деревом(или элементом)
        {
            if (first.value < second.value)
                Swap(first, second);
            Node temp = first.left;
            first.left = second;
            second.right = temp;
            first.cntOfChilds += second.cntOfChilds + 1;

            arr[index] = null;
            if (arr[index + 1] != null)
            {
                Merge(arr[index + 1], first, index + 1);
            }
            else
            {
                arr[index + 1] = first;
            }
        }
        private void Swap(Node first, Node second)
        {
            Node temp = first;
            first = second;
            second = temp;
        }
    }
}
