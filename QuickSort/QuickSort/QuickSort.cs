using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
   

   
    class Program
    {
       public static int find(int[] array, int left, int right)
        {
            int marker = left;
            for (int i = left; i <= right; i++)
            {
                if (array[i] <= array[right])
                {
                    int temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            return marker - 1;
        }

        public static void quicksort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            int pos = find(array, left, right);
            quicksort(array, left, pos - 1);
            quicksort(array, pos + 1, right);
        }

        static void Main(string[] args)
        {
           

            int[] arr = new int[] {9, 10, 100, 6, 15, 35 };
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + "\t");
            Console.WriteLine();
            quicksort(arr, 0, arr.Length - 1);
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + "\t");

        }
    }
}
