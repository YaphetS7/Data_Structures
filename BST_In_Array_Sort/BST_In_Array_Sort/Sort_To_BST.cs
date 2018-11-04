using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_In_Array_Sort
{
   
    class Sort_To_BST
    {
        public static void SortToBTS(int[] arr, int[] result, int start, int end, int k,bool[] check)
        {
            if (end >= start)
            {
                int mid = (start + end) / 2;
                result[k] = arr[mid];
                check[k] = true;
                SortToBTS(arr,result, start, mid - 1, k * 2 + 1, check);
                SortToBTS(arr,result, mid + 1, end, k * 2 + 2, check);
            }
        }
        static void Main(string[] args)
        {
            int i;
            int[] a = new int[10];
            int[] b = new int[15];
            bool[] check = new bool[15];
            for (i = 0; i < 10; i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("Начальный массив: ");
            Console.WriteLine();
            for (i = 0; i < 10; i++)
                Console.Write(a[i] + "\t");

            Array.Sort(a);
            Console.WriteLine();
            Console.Write("Отсортированный массив: ");
            Console.WriteLine();
            for (i = 0; i < 10; i++)
                Console.Write(a[i] + "\t");

            Console.WriteLine();

           
            SortToBTS(a, b, 0, a.Length - 1, 0, check);

            Console.Write("Массив, представленный в BST:");
            Console.WriteLine();
            for (i = 0; i < 15; i++)
                if (check[i])
                    Console.Write(b[i] + "\t");
                else
                    Console.Write("null" + "\t");
        }
    }
}
