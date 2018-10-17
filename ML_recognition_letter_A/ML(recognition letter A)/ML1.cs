using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ML_recognition_letter_A_
{
    public class Neuron
    {
        double[,] w;
        int generation = 0;
        int ThresholdOUT;
        public Neuron(int n, int m, int threshold)
        {
            ThresholdOUT = threshold;
            w = new double[n, m];
        }
        public void learn(string path, bool check)
        {
            int i, j;
            string[] a = File.ReadAllLines(path);

            if (check)
            {
                for (i = 0; i < 9; i++)
                    for (j = 0; j < 9; j++)
                    {
                        if (a[i][j] == '1')
                            w[i, j] += 0.7;
                        else
                            w[i, j] -= 0.2;
                    }
            }
            else
            {
                for (i = 0; i < 9; i++)
                    for (j = 0; j < 9; j++)
                    {
                        if (a[i][j] == '1')
                            w[i, j] -= 0.1;
                    }
            }
            generation++;
            Console.WriteLine("Generation = " + generation);
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    w[i, j] = Math.Round(w[i, j], 2);
                    Console.Write(w[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public bool IsA(string path)
        {
            double result = 0;
            string[] a = File.ReadAllLines(path);
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (a[i][j] == '1')
                        result += w[i, j];
                }
            return (result >= ThresholdOUT);
        }

    }
    class ML1
    {
        static void Main(string[] args)
        {
            Neuron lol = new Neuron(9, 9, 35);
            //start learn
            lol.learn("А1.txt", true);
            lol.learn("А2.txt", true);
            lol.learn("А3.txt", true);
            lol.learn("А4.txt", true);
            lol.learn("А5.txt", true);
            lol.learn("А6.txt", true);
            lol.learn("А7.txt", true);
            lol.learn("А8.txt", true);
            lol.learn("неА1.txt", false);
            lol.learn("неА2.txt", false);
            lol.learn("неА3.txt", false);
            lol.learn("неА4.txt", false);
            lol.learn("неА5.txt", false);
            //end learn


            if (lol.IsA("check1.txt"))
                Console.WriteLine("Letter A");
            else
                Console.WriteLine("Not letter A");
        }
    }
}
