using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSD_sort
{
    public class Cars
    {
        string model;
        public int count_cars = 0;
        List<string> colors = new List<string>();
        List<string> numbers = new List<string>();
        public Cars(string a)
        {
            model = a;
        }
        public void add_car(string color, string number)
        {
            colors.Add(color);
            numbers.Add(number);
            count_cars++;
        }
        public void print_cars()
        {
            int i;
            Console.WriteLine("Модель машин: " + model);
            for (i = 0; i < count_cars; i++)
            {
                Console.Write("Машина" + " имеет " + colors[i] + " цвет и номер " + numbers[i]);
                Console.WriteLine();
            }
        }
        public void SortByNumbers()
        {
            string[] arr = new string[count_cars];
            string[] col = new string[count_cars];
            string temp;
            int n = numbers[0].Length;
            int i, j, q;

            for (i = 0; i < numbers.Count; i++)
            {
                arr[i] = numbers[i];
                col[i] = colors[i];
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < count_cars; j++)
                    for (q = 0; q < count_cars - 1; q++)
                        if (arr[q][n - i - 1] > arr[q + 1][n - i - 1])
                        {
                            temp = arr[q];
                            arr[q] = arr[q + 1];
                            arr[q + 1] = temp;

                            temp = col[q];
                            col[q] = col[q + 1];
                            col[q + 1] = temp;
                        }
            }
            numbers.Clear();
            colors.Clear();
            for (i = 0; i < count_cars; i++)
            {
                numbers.Add(arr[i]);
                colors.Add(col[i]);
            }
        }
    }
   
    class Program
    {
        static void Main(string[] args)
        {
            Cars lol = new Cars("Ferrari");
            lol.add_car("синий", "ABC");
            lol.add_car("зеленый", "ROT");
            lol.add_car("темно-синий", "YYA");
            lol.add_car("черный", "BRQ");
            lol.add_car("оранжевый", "UOI");
            lol.add_car("белый", "AAA");
            lol.print_cars();
            Console.WriteLine();
            Console.WriteLine("Отсортируем машины по номерам:");
            lol.SortByNumbers(); //LSD-sort
            lol.print_cars();
        }
    }
}
