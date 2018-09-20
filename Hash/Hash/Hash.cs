using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    public class HashTable
    {
        public int capacity;
        int count = 0;
        int step;
        public bool[] check;
        public string[] arr;
        public HashTable(int cap, int st)
        {
            capacity = cap;
            step = st;
            check = new bool[capacity];
            arr = new string[capacity];
            for (int i = 0; i < capacity; i++)
                check[i] = false;
        }
        public int hash_fun (string value)
        {
            char[] a = new char[value.Length];
            int sum = 0;
            for (int i = 0; i < value.Length; i++)
            {
                a[i] = value[i];
                sum += a[i] - '0';
            }
            return (sum % capacity);
        }
        public int seek_slot (string value)
        {
            int i;
            i = hash_fun(value);
            while (i < capacity && check[i] == true)
            {
                i += step;
            }
            if (i >= capacity)
            {
                i = 0;
                while (check[i] == true)
                    i++;
            }
            if (i >= capacity)
                return -1;
            return i;
        }
        public void put (string value)
        {
            int i;
            i = seek_slot(value);
            if (i != -1)
            {
                check[i] = true;
                arr[i] = value;
                count++;
            }
        }
        public int find(string str)
        {
            int i = hash_fun(str);
            return i;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            HashTable hash = new HashTable(17, 3);
            hash.put("first message");
            hash.put("я сделал это!");
            hash.put("думал, что очень сложно");
            hash.put("надеюсь, правильно");
            for (int i = 0; i < hash.capacity; i++)
            {
                if (hash.check[i])
                {
                    Console.Write("Под индексом " + i + " строка: " + hash.arr[i]);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.ReadLine();
           
           
        }
    }
}
