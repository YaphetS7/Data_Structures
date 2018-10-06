using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSet
{
    public class PowerSet1
    {
        Dictionary<int, object> dict = new Dictionary<int, object>();
        public int cnt = 0;
        private int hash(string s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
                result += s[i] - '0';
            return result % 119;
        }
        public void remove(object value)
        {
            string s = Convert.ToString(value);
            int i = hash(s);
            dict.Remove(i);
        }
        public void PrintSet()
        {
            foreach (object val in dict)
                Console.Write(val + "\t");
        }
        public void put(object value)
        {
            string s = Convert.ToString(value);
            int i = hash(s);
            if (!dict.ContainsKey(i))
            {
                dict.Add(i, value);
                cnt++;
            }
        }
        public Dictionary<int, object> difference (PowerSet1 set)
        {
            int i; string s;
            Dictionary<int, object> temp = new Dictionary<int, object>();
            foreach (object a in dict.Values)
            {
                s = Convert.ToString(a);
                i = hash(s);
                temp.Add(i, a);
            }
            foreach (object a in set.dict.Values)
                if (temp.ContainsValue(a))
                    temp.Remove(hash(Convert.ToString(a)));
            return temp;
        }

        public Dictionary<int, object> intersection (PowerSet1 set)
        {
            int i; string s;
            Dictionary<int, object> result = new Dictionary<int, object>();

            foreach (object a in dict.Values)
            {
                s = Convert.ToString(a);
                i = hash(s);
                if (set.dict.ContainsKey(i))
                    result.Add(i, a);
            }

            foreach (object a in set.dict.Values)
            {
                i = hash(Convert.ToString(a));
                if (dict.ContainsKey(i) && !result.ContainsKey(i))
                    result.Add(i, a);
            }

            return result;
        }
        public Dictionary<int, object> union (PowerSet1 set)
        {
            int i; string s;
            Dictionary<int, object> temp = new Dictionary<int, object>();
            foreach(object a in dict.Values)
            {
                s = Convert.ToString(a);
                i = hash(s);
                temp.Add(i, a);
            }
            foreach (object a in set.dict.Values)
            {
                s = Convert.ToString(a);
                i = hash(s);
                if (!temp.ContainsKey(i))
                     temp.Add(i, a);
            }
            return temp;
        }
        public Dictionary<int, object> xor(PowerSet1 set)
        {
            Dictionary<int, object> temp1 = new Dictionary<int, object>();
            Dictionary<int, object> temp2 = new Dictionary<int, object>();
            temp1 = union(set);
            temp2 = intersection(set);
            foreach (object a in temp2.Values)
                temp1.Remove(hash(Convert.ToString(a)));

            return temp1;
        }

        public bool issubset(PowerSet1 set)
        {
            int k = 0;
            foreach (object a in set.dict.Values)
                if (dict.ContainsValue(a))
                    k++;
            return (k == set.cnt);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            PowerSet1 set = new PowerSet1();
            PowerSet1 set2 = new PowerSet1();
            Dictionary<int, object> dict = new Dictionary<int, object>();

            set2.put("я долго тупил");
            set2.put(123);
            set.put("awd");
            set.put("awd");
            set.put(123);
            set.put(1);
            set.put(123);
            Console.WriteLine("Первое множество:");
            set.PrintSet();

            Console.WriteLine();
            Console.WriteLine("Множество второе:");
            set2.PrintSet();

            Console.WriteLine();
            dict = set.union(set2);
            Console.WriteLine("Объединение множеств:");
            foreach (object a in dict)
                Console.Write(a + "\t");

            Console.WriteLine();
            Console.WriteLine("Разность множеств:");
            dict = set.difference(set2);
            foreach (object a in dict)
                Console.Write(a + "\t");

            Console.WriteLine();
            Console.WriteLine("Пересечение множеств:");
            dict = set.intersection(set2);
            foreach (object a in dict)
                Console.Write(a + "\t");

            Console.WriteLine();
            Console.WriteLine("XOR множеств:");
            dict = set.xor(set2);
            foreach (object a in dict)
                Console.Write(a + "\t");


           
        }
    }
}
