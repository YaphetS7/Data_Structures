using System;
using System.Collections.Generic;

namespace Disjoint_Set_Union
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class DSU<T>
    {
        private Dictionary<T, T> parents = new Dictionary<T, T>();
        public void MakeSet(T value)
        {
            if (!parents.ContainsKey(value))
                parents.Add(value, value);
        }
        public T Find(T value)
        {
            if (Convert.ToString(parents[value]) == Convert.ToString(value))
            {
                return value;
            }
            parents[value] = Find(parents[value]); //эвристика сжатия путей
            return parents[value];

        }
        public void Unite(T value1, T value2)
        {
            if (!parents.ContainsKey(value1) || !parents.ContainsKey(value2))
                return;
            int x = new Random().Next(1, 3);
            if (x == 1)
            {
                parents[value1] = value2;
            }
            else
            {
                parents[value2] = value1;
            }
        }
    }
}
