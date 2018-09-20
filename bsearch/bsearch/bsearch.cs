using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsearch
{
   
    class Program
    {
        public static int bsearch(List<int> lst, int value) //двоичный поиск индекса по условию*
        {
            int low = 0;
            int high = lst.Count - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (lst[mid] <= value & lst[mid + 1] >= value) // *условие
                    return mid;
                else if (value > lst[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return 0;
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 90, 100, 34, 213, 123, 12490, 1, 0 };
            list.Sort();
            foreach (int i in list)
                Console.Write(i + "\t");
            Console.WriteLine();
            Console.WriteLine(bsearch(list, 0));
        }
    }
}
