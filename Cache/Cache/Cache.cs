using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash
{
    public class Cache
    {
        public int capacity;
        public int count = 0;
        public int[] CntOfAppeals;
        private int last_i;
        private string[] keys;
        public Dictionary<string, string> dict = new Dictionary<string, string>();
        int i;
        public void PrintCash()
        {
            Console.WriteLine();
            Console.WriteLine("Cash is:");
            foreach (string s in dict.Values)
                Console.WriteLine(s);
        }
        public int find_index(string s)
        {
            return hash_fun(s);
        }
        public Cache(int x)
        {
            capacity = x * 2;
            keys = new string[capacity];
            CntOfAppeals = new int[capacity];
            last_i = capacity + 1;
        }
        private int hash_fun(string s)
        {
            int result = 0, p = 2;
            for (int i = 0; i < s.Length; i++)
                result += s[i] - '0';
            return result % capacity;
        }
        public void appeal (string value)
        {
            i = hash_fun(value);
            string key = Convert.ToString(value);
            if (!dict.ContainsKey(key))
                dict.Add(key, value);

            keys[i] = key;
            if (count >= capacity / 2)
                ClearSlot(i);

            CntOfAppeals[i]++;
            count++;
        }
        private void ClearSlot(int index)
        {
            int imin = 0, i, min = capacity + 1;
            for (i = 0; i < capacity; i++)
                if (keys[i] != null && CntOfAppeals[i] < min && i != index && i != last_i && CntOfAppeals[i] != 0)
                {
                    min = CntOfAppeals[i];
                    imin = i;
                }
            dict.Remove(keys[imin]);
            count -= min;
            CntOfAppeals[imin] = 0;
            last_i = index;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cache cache = new Cache(7);
            cache.appeal("translator");
            cache.appeal("video");
            cache.appeal("google");
            cache.appeal("yandex");
            cache.appeal("google");
            cache.appeal("video");
            cache.appeal("yandex");
            cache.PrintCash();
           
            cache.appeal("vk.com");
            cache.PrintCash();
           
            cache.appeal("mts");
            cache.PrintCash();
            


        }
    }
}
