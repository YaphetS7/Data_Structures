using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinTreeInArray
{
    public class BinTree
    {
        int[] arr;
        public bool[] check;
        int root;
        int cap;
        public BinTree(int capacity, int ValueOfRoot)
        {
            arr = new int[capacity];
            check = new bool[capacity];
            cap = capacity;
            arr[0] = ValueOfRoot;
            check[0] = true;
            root = ValueOfRoot;
        }
        public void AddChild(int value)
        {
            int i = 0;
            while(check[i])
            {
                if (value >= arr[i])
                    i = i * 2 + 2;
                else
                    i = i * 2 + 1;
            }
            if (i >= cap)
                return;
            arr[i] = value;
            check[i] = true;
        }
        public void PrintTree()
        {
            for (int i = 0; i < cap; i++)
            {
                if (check[i])
                    Console.Write(arr[i] + "\t");
                else
                    Console.Write("null" + "\t");
            }
        }
        public int FindNode(int value)
        {
            int i = 0;
            while(i < cap && check[i] && arr[i] != value)
            {
                if (value >= arr[i])
                    i = i * 2 + 2;
                else
                    i = i * 2 + 1;
            }
            if (i >= cap)
                return cap * (-1);

            if (check[i] && value == arr[i])
                return i;

            if (!check[i])
                return -1 * i;

            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinTree tree = new BinTree(30, 50);
            tree.AddChild(25);
            //tree.AddChild(20);
            tree.AddChild(75);
            tree.AddChild(37);
            tree.AddChild(62);
            tree.AddChild(84);
            tree.AddChild(31);
            tree.AddChild(43);
            tree.AddChild(55);
            tree.AddChild(92);
            tree.PrintTree();
            Console.WriteLine(tree.FindNode(62));
        }
    }
}
