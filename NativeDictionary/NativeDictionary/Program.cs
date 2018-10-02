using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    public class NativeDictionary
    {
       
        public static int capacity = 23;
        HashTable hash = new HashTable(capacity, 3);
        public int cnt = 0;

        public void put(string key, int val)
        {
            hash.put(key);
            int i = hash.find(key);
            hash.value[i] = val;
            cnt++;
        }

        public bool is_key(string key)
        {
            int i = hash.find(key);
            return (hash.key[i] == key);
        }

        public int get(string key)
        {
            int i = hash.find(key);
            if (hash.key[i] == key)
                return hash.value[i];
            else
                return -1;
        }

    }
    public class HashTable
    {
        public int capacity;
        int count = 0;
        int step;
        public bool[] check;
        public string[] key;
        public int[] value;
        public HashTable(int cap, int st)
        {
            capacity = cap;
            step = st;
            check = new bool[capacity];
            key = new string[capacity];
            value = new int[capacity];
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
            else
                return i;
        }
        public void put (string value)
        {
            int i;
            i = seek_slot(value);
            if (i != -1)
            {
                check[i] = true;
                key[i] = value;
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

            NativeDictionary dict = new NativeDictionary();
            dict.put("mom", 903222);
            dict.put("family", 324422);
            dict.put("Ilyuza", 666666);
            if (dict.is_key("Ilyuza"))
            {
                Console.WriteLine("Пользователь с именем Ilyuza есть в базе, номер:");
                Console.WriteLine(dict.get("Ilyuza"));
            }

        }
    }
}
