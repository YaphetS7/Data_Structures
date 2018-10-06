using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSet1
{
    public class PowerSet
    {
        public Dictionary<string, object> dict = new Dictionary<string, object>();
        public int cnt = 0;

        public void remove(object value)
        {
            string s = Convert.ToString(value);
            dict.Remove(s);
        }
        public void PrintSet()
        {
            foreach (object val in dict.Values)
                Console.Write(val + "\t");
        }
        public void put(object value)
        {
            string s;
            s = Convert.ToString(value);
            if (!dict.ContainsKey(s))
            {
                dict.Add(s, value);
                cnt++;
            }
        }
        public PowerSet difference(PowerSet set)
        {
            PowerSet temp = new PowerSet();
            foreach (object a in dict.Values)
            {
                temp.put(a);
            }
            foreach (object a in set.dict.Values)
                if (dict.ContainsKey(Convert.ToString(a)))
                    temp.remove(a);
            return temp;
        }

        public PowerSet intersection(PowerSet set)
        {
            PowerSet result = new PowerSet();

            foreach (object a in dict.Values)
            {
                if (set.dict.ContainsValue(a))
                    result.put(a);
            }

            foreach (object a in set.dict.Values)
            {
                if (dict.ContainsValue(a) && !result.dict.ContainsValue(a))
                    result.put(a);
            }

            return result;
        }
        public PowerSet union(PowerSet set)
        {
            PowerSet temp = new PowerSet();
            foreach (object a in dict.Values)
            {
                temp.put(a);
            }
            foreach (object a in set.dict.Values)
            {
                if (!temp.dict.ContainsValue(a))
                    temp.put(a);
            }
            return temp;
        }
        public PowerSet xor(PowerSet set)
        {
            PowerSet temp1 = new PowerSet();
            PowerSet temp2 = new PowerSet();
            temp1 = union(set);
            temp2 = intersection(set);
            foreach (object a in temp2.dict.Values)
                temp1.remove(a);

            return temp1;
        }

        public bool issubset(PowerSet set)
        {
            int k = 0;
            foreach (object a in set.dict.Values)
                if (dict.ContainsValue(a))
                    k++;
            return (k == set.cnt);
        }

    }
    class Set
    {
        static void Main(string[] args)
        {
            PowerSet set = new PowerSet();
            PowerSet set2 = new PowerSet();
            PowerSet dict = new PowerSet();

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
            dict.PrintSet();

            Console.WriteLine();
            Console.WriteLine("Разность множеств:");
            dict = set.difference(set2);
            dict.PrintSet();

            Console.WriteLine();
            Console.WriteLine("Пересечение множеств:");
            dict = set.intersection(set2);
            dict.PrintSet();

            Console.WriteLine();
            Console.WriteLine("XOR множеств:");
            dict = set.xor(set2);
            dict.PrintSet();


        }
    }
}

