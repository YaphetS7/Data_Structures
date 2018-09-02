using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Queue
    {
        List<int> list = new List<int>();
        public int size = 0;
        public void enqueue(int item)
        {
            list.Add(item);
            size++;
        }
        public int dequeue()
        {
            int x = list[0];
            list.RemoveAt(0);
            size--;
            return (x);
        }
        public void rotate()
        {
            for (int i = 0; i < size - 1; i++)
            {
                enqueue(list[0]);
                dequeue();
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue qu = new Queue();
            qu.enqueue(1);
            qu.enqueue(2);
            qu.enqueue(3);
            qu.rotate();
            Console.WriteLine(qu.dequeue());
            Console.WriteLine(qu.dequeue());
            Console.WriteLine(qu.dequeue());
            Console.ReadLine();
        }
    }
}
