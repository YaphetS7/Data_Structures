using System;
using System.Collections;
namespace Stack
{
    class Stack
    {
        public int size = 0;
        ArrayList list = new ArrayList();
        public void push(object x)
        {
            list.Add(x);
            size++;
        }
        public object pop()
        {
            object x = list[size - 1];
            list.RemoveAt(size - 1);
            size--;
            return x;
        }
    }
    class Program
    {
        public static bool check(string s)
        {
            Stack mem = new Stack();
            mem.push(0);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    mem.push(0);
                else
                    mem.pop();
                if (mem.size == 0)
                    return false;
            }
            return (mem.size == 1);
        }
        static void Main(string[] args)
        {
            Stack stack = new Stack(); 
            stack.push(10);
            stack.push("привет");
            stack.push(19);
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.pop());
            Console.WriteLine("Введите строку скобок:");
            string a = Console.ReadLine();
            bool x = check(a);
            if (x)
                Console.WriteLine("Строка сбалансированна");
            else
                Console.WriteLine("Строка несбалансированна");
        }
    }
}