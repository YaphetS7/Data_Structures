using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynArray
{
    class DynArray
    {
        public int count = 0;
        int capacity = 16;
        public int[] x;
        public void PrintArray()
        {
            for (int i = 0; i < count; i++)
                Console.Write(x[i] + "\t");
            Console.WriteLine();
        }
        public void array(int size)
        {
            int[] temp = new int[size];
            if (x != null)
               x.CopyTo(temp, 0);
            x = new int[size];
            if (x != null)
                temp.CopyTo(x, 0);
        }


        public void make_array(int new_capacity)
        {
            capacity = new_capacity;
            if (new_capacity > 16)
                array(new_capacity);
            else
                array(16);
        }
        public int get_item(int i)
        {
            if (i >= 0 && i <= count - 1)
                return x[i];
            else
                Console.WriteLine("Такого индекса нет");
            return 0000;
        }
        public void append(int item)
        {
            if (count == capacity)
                array(capacity * 2);
            x[count] = item;
            count++;
        }
        public void insert(int i, int item)
        {
            if (i == count)
            {
                   append(item);
            }
            else
            {
                if (count - 1 >= capacity)
                    array(count * 2);
                count++;
                for (int q = count - 1; q >= i; q--)
                    x[q + 1] = x[q];
                x[i] = item;
            }
        }
        public void delete(int i)
        {
            if (i >= 0 && i < count)
            {
                for (int j = i + 1; j < count; j++)
                    x[j - 1] = x[j];
                count--;
                if (count <= capacity - count)
                    array(16);
            }
            
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            DynArray arr = new DynArray();
            arr.make_array(20);
            arr.append(10);
            arr.append(100);
            arr.append(33);
            arr.append(789);
            arr.append(0);
            arr.append(384);
            Console.WriteLine("Начальный массив");
            arr.PrintArray();
            Console.WriteLine("Кол-во элементов = " + arr.count);
            arr.delete(0);
            Console.WriteLine("Массив после удаления нулевого элемента");
            arr.PrintArray();
            Console.WriteLine("Кол-во элементов = " + arr.count);
            Console.WriteLine("Выведем элемент с индексом 1 - " + arr.get_item(1));
            Console.WriteLine("Добавим 321 первым индексом");
            arr.insert(1, 321);
            arr.PrintArray();
            Console.WriteLine("Кол-во элементов = " + arr.count);
            Console.ReadLine();
        }
    }
}

