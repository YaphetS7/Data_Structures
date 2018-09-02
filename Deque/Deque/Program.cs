using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque
{
    class Deque<T>
    {
        LinkedList<T> list = new LinkedList<T>();
        public int size = 0;
        public void addFront(T item)
        {
            list.AddFirst(item);
            size++;
        }
        public T removeFront()
        {
            T x = list.First();
            list.RemoveFirst();
            size--;
            return x;
        }
        public void addTail(T item)
        {
            list.AddLast(item);
            size++;
        }
        public T removeTail()
        {
            T x = list.Last();
            list.RemoveLast();
            size--;
            return x;
        }
    }
    class Program
    {
        public static bool check(string s)
        {
            int i, k = 0;
            Deque<char> qu = new Deque<char>();
            for (i = 0; i < s.Length; i++)
                qu.addTail(s[i]);
            for (i = 1; i <= s.Length / 2; i++)
            {
                if (qu.removeFront() == qu.removeTail())
                    k++;
            }
            if (s.Length % 2 == 0)
            {
                if (k == s.Length / 2)
                    return true;
                else
                    return false;
            }
            else
            {
                if (k == (s.Length - 1) / 2)
                    return true;
                else
                    return false;
            }
        }
        static void Main(string[] args)
        {
            Deque<int> qu = new Deque<int>();
            qu.addFront(10);
            qu.addTail(9);
            qu.addFront(100);
            Console.WriteLine(qu.removeTail());
            Console.WriteLine(qu.removeFront());
            Console.WriteLine(qu.removeFront());
            Console.WriteLine("Введите строку:");
            string s = Console.ReadLine();
            if (check(s))
                Console.WriteLine("Палиндром");
            else
                Console.WriteLine("Не палиндром");
            Console.ReadLine();
        }
    }
}
