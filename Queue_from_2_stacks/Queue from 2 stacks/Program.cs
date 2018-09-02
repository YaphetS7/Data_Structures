using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_from_2_stacks
{
    class Queue
    {
        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();
        public int size = 0;
        public void enqueue(int item)
        {
            stack1.Push(item);
            size++;
        }
        public int dequeue()
        {
            int x, i;
            for ( i = 0; i < size; i++)
                stack2.Push(stack1.Pop());
            x = stack2.Pop();
            size--;
            for (i = 0; i < size; i++)
                stack1.Push(stack2.Pop());
            return x;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue qu = new Queue();
            qu.enqueue(0);
            qu.enqueue(1);
            qu.enqueue(2);
            Console.WriteLine(qu.dequeue());
            Console.WriteLine(qu.dequeue());
            Console.WriteLine(qu.dequeue());

        }
    }
}
