using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class HeapT
    {
        public int[] arr;
        public bool[] check;
        int capacity, count = 0;
        public HeapT(int value, int capacity)
        {
            arr = new int[capacity];
            check = new bool[capacity];
            arr[count] = value;
            check[count] = true;
            count++;
            this.capacity = capacity;
        }
        public void AddValue(int value)
        {
            if (count < capacity)
            {
                arr[count] = value;
                check[count] = true;
                ReIndex(count);
                count++;
            }
        }
        private void ReIndex(int i)
        {
            int ip; // index of parent
            int temp;
            if (i >= 0)
            {
                
                if (i % 2 == 0)
                    ip = (i - 2) / 2;
                else
                    ip = (i - 1) / 2;

                if (ip >= 0 && arr[ip] < arr[i])
                {
                    
                    temp = arr[ip];
                    arr[ip] = arr[i];
                    arr[i] = temp;
                    ReIndex(ip);
                }
            }
        }
        public void DelRoot(int i)
        {
            int imax;
            imax = FindMaxIndexOfParent(i);
            if (imax > 0)
            {
                arr[i] = arr[imax];
                DelRoot(imax);
            }
            else
            {
                MoveArr(i);
                count--;
            }
            

        }
        private void MoveArr(int i)
        {
            if (check[i + 1])
            {
                check[i + 1] = false;
                arr[i] = arr[i + 1];
            }
        }
        private int FindMaxIndexOfParent(int i)
        {
            int index = -1;
            if (i * 2 + 2 < count)
            {
                if (arr[i * 2 + 1] > arr[i * 2 + 2])
                    index = i * 2 + 1;
                else
                    index = i * 2 + 2;
            }
            else
            {
                if (i * 2 + 1 < count)
                    index = i * 2 + 1;
            }
            return index;
        }
        public void PrintHeap(int index)
        {
            for (int i = 0; i < count; i++)
                Console.Write(arr[i] + "\t");
            Console.WriteLine();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            HeapT heap = new HeapT(11, 12);
            heap.AddValue(20);
            heap.PrintHeap(0);
            
        }
    }
}
