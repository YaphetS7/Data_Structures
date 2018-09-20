using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    class Program
    {
        public static void Swap(ref int x, ref int y)
        {
            int c;
            c = x;
            x = y;
            y = c;
        }
        public static int[] sort(int[] x, int step)
        {
            int i, j, q;
            if (step == 0)
            {
                while (step <= x.Length)
                {
                    if ((step * 3 + 1) > x.Length)
                        break;
                    else
                        step = step * 3 + 1;
                }
            }
            else
            {
                step = (step - 1) / 3;
            }

            for (i = 0; i < x.Length - step; i++)
            {
                for (j = i + step; j < x.Length; j += step)
                {
                    for (q = i + step; q < x.Length; q += step)
                        if (x[q - step] > x[q])
                        {
                            Swap(ref x[q - step], ref x[q]);
                        }
                }

            }
            if (step == 1)
                return x;
            else
                return sort(x, step);
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 7, 6, 5, 4, 3, 10,100,200,190,320,653,134,1000,2, 1 };

            arr = sort(arr, 0);
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + "\t");
        }
    }
}
