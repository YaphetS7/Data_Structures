using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBST
{
    public class Node
    {
        public int value;
        public Node left, right, parent;
        public Node(int value)
        {
            this.value = value;
            left = null;
            right = null;
            parent = null;
        }
    }
    public class BalancedBSTFromArray
    {
        public Node root;
        public void FromArrayToBST(int[] arr)
        {
            Array.Sort(arr);
            int[] result = new int[arr.Length * 2 + 1];
            bool[] check = new bool[arr.Length * 2 + 1];
            SortToBTS(arr, result, 0, arr.Length - 1, 0, check);
            ArrToBST(result, check, 0);
        }
        private Node ArrToBST(int[] arr, bool[] check, int indexOfParent)
        {
            if (indexOfParent < arr.Length)
            {
                if (indexOfParent == 0)
                {
                    root = new Node(arr[indexOfParent]);
                    root.left = ArrToBST(arr, check, 1);
                    root.right = ArrToBST(arr, check, 2);
                    return root;
                }
                else
                if (check[indexOfParent])
                {
                    Node node = new Node(arr[indexOfParent]);
                    node.left = ArrToBST(arr, check, indexOfParent * 2 + 1);
                    node.right = ArrToBST(arr, check, indexOfParent * 2 + 2);
                    return node;
                }
                else
                    return null;
            }
            else
                return null;
        }
        private void SortToBTS(int[] arr, int[] result, int start, int end, int k, bool[] check)
        {
            if (end >= start)
            {
                int mid = (start + end) / 2;
                result[k] = arr[mid];
                check[k] = true;
                SortToBTS(arr, result, start, mid - 1, k * 2 + 1, check);
                SortToBTS(arr, result, mid + 1, end, k * 2 + 2, check);
            }
        }
        public void PrintTree(Node node)
        {
            Console.Write(node.value + "\t");
            if (node.left != null)
                PrintTree(node.left);
            if (node.right != null)
                PrintTree(node.right);
        }
    }
    class BalancedBST
    {
        static void Main(string[] args)
        {
            int[] a = new int[] {7, 3, 10, 9, 8, 6, 5, 1, 2, 4};
            BalancedBSTFromArray r = new BalancedBSTFromArray();
            r.FromArrayToBST(a);
            r.PrintTree(r.root);
        }
    }
}
