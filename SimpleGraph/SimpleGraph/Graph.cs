using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraph
{
    public class Vertex
    {
        public bool hit;
        public int LengthOfWay;
    }
    public class Graph
    {
        public int max_vertex;
        public int[,] m_adjacency;
        public int cntOfVertex = 0;
        public List<Vertex> vertex = new List<Vertex>();

        public Graph(int CountOfVertex)
        {
            max_vertex = CountOfVertex;
            m_adjacency = new int[max_vertex, max_vertex];
        }
        public bool IsWay(Vertex first, Vertex second)
        {
            int i1, i2;
            if (vertex.Contains(first))
                i1 = vertex.IndexOf(first);
            else
                return false;

            if (vertex.Contains(second))
                i2 = vertex.IndexOf(second);
            else
                return false;

            if (i1 < max_vertex && i2 < max_vertex)
                return (m_adjacency[i1, i2] == 1);
            else
                return false;
        }
        public void AddVertex(Vertex vertex)
        {
            if (cntOfVertex <= max_vertex)
            {
                this.vertex.Add(vertex);
                cntOfVertex++;
            }
        }
        public void AddWay(Vertex first, Vertex second)
        {
            int i1 = vertex.IndexOf(first);
            int i2 = vertex.IndexOf(second);
            if (i1 < max_vertex && i2 < max_vertex)
            {
                m_adjacency[i1, i2] = 1;
                m_adjacency[i2, i1] = 1;
            }
        }
        public void DelWay(Vertex first, Vertex second)
        {
            int i1 = vertex.IndexOf(first);
            int i2 = vertex.IndexOf(second);
            if (i1 < max_vertex && i2 < max_vertex)
            {
                m_adjacency[i1, i2] = 0;
                m_adjacency[i2, i1] = 0;
            }
        }
        public void DelVertex(Vertex vertex)
        {
            int q;
            int i = this.vertex.IndexOf(vertex);
            this.vertex.RemoveAt(i);
            int j = i;
            while (i < max_vertex)
            {
                for (q = 0; q < max_vertex - 1; q++)
                {
                    m_adjacency[q, i] = m_adjacency[q + 1, i];
                }
                i++;
            }
            i = j;
            while (i < max_vertex)
            {
                for (q = 0; q < max_vertex - 1; q++)
                {
                    m_adjacency[i, q] = m_adjacency[i, q + 1];
                }
                i++;
            }
            cntOfVertex--;
        }
        public Stack<Vertex> DF_search(Vertex first, Vertex second)
        {
            int i, j;
            bool check = false;
            Stack<Vertex> stack = new Stack<Vertex>();
            stack.Push(first);
            first.hit = true;
            while(stack.Count > 0 && !stack.Contains(second))
            {
                check = false;
                i = vertex.IndexOf(stack.Peek());
                for (j = 0; j < vertex.Count; j++)
                {
                    if (m_adjacency[i, j] == 1 && !vertex[j].hit)
                    {
                        stack.Push(vertex[j]);
                        vertex[j].hit = true;
                        check = true;
                        break;
                    }
                }
                if (!check)
                    stack.Pop();
            }
            HitOff();
            return stack;
        }
        public Stack<Vertex> BF_search(Vertex first, Vertex second)
        {
            int i, j, k = 0;
            bool check;
            Queue<Vertex> queue = new Queue<Vertex>();
            Stack<Vertex> stack = new Stack<Vertex>();
            queue.Enqueue(first);
            first.hit = true;
            first.LengthOfWay = k;
            while (queue.Count > 0 && !queue.Contains(second))
            {
                check = false;
                k++;
                i = vertex.IndexOf(queue.Peek());
                for (j = 0; j < vertex.Count; j++)
                {
                    if (m_adjacency[i, j] == 1 && !vertex[j].hit)
                    {
                        check = true;
                        queue.Enqueue(vertex[j]);
                        vertex[j].LengthOfWay = k;
                        vertex[j].hit = true;
                    }
                }
                if (!check)
                    k--;
                queue.Dequeue();
            }
            if (queue.Count > 0)
            {
                stack.Push(second);
                while (!stack.Contains(first))
                {
                    i = vertex.IndexOf(stack.Peek());
                    for (j = 0; j < vertex.Count; j++)
                    {
                        //если вершина связана с вершиной из стэка и длина пути от вершины first до данной вершины на единицу меньше, чем вершины из стэка, то добавить эту вершину в стэк
                        if (m_adjacency[i, j] == 1 && vertex[j].LengthOfWay == stack.Peek().LengthOfWay - 1 )
                        {
                            stack.Push(vertex[j]);
                            break;
                        }
                    }
                }
            }
            HitOff();
            return stack;
        }
        private void HitOff()
        {
            foreach (Vertex a in vertex)
            {
                a.hit = false;
                a.LengthOfWay = -1;
            }
        }
        public void PrintGraph()
        {
            for (int i = 0; i < cntOfVertex; i++)
            {
                for (int j = 0; j < cntOfVertex; j++)
                {
                    Console.Write(m_adjacency[i, j] + "\t");
                }
                Console.WriteLine();
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Graph mygraph = new Graph(10);
            Vertex a = new Vertex();
            Vertex b = new Vertex();
            Vertex c = new Vertex();
            Vertex d = new Vertex();
            Vertex f = new Vertex();
            Vertex e = new Vertex();
            Vertex g = new Vertex();
            Vertex h = new Vertex();
            Vertex i = new Vertex();
            mygraph.AddVertex(a);
            mygraph.AddVertex(b);
            mygraph.AddVertex(c);
            mygraph.AddVertex(d);
            mygraph.AddVertex(e);
            mygraph.AddVertex(f);
            mygraph.AddVertex(g);
            mygraph.AddVertex(h);
            mygraph.AddVertex(i);
            mygraph.AddWay(a, b);
            mygraph.AddWay(a, c);
            mygraph.AddWay(c, g);
            mygraph.AddWay(g, h);
            mygraph.AddWay(g, i);
            mygraph.AddWay(b, d);
            mygraph.AddWay(b, e);
            mygraph.AddWay(b, f);
            mygraph.AddWay(h, i);
            Stack<Vertex> stack = mygraph.BF_search(f, i);
            if (stack.Count - 1 == 5)
                Console.WriteLine("есть дорога");
             

        }
    }
}
