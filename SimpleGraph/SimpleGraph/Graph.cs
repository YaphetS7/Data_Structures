﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraph
{
    public class Vertex
    {

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
            Graph mygraph = new Graph(5);
            Vertex a = new Vertex();
            Vertex b = new Vertex();
            Vertex c = new Vertex();
            mygraph.AddVertex(a);
            mygraph.AddVertex(b);
            mygraph.AddVertex(c);
            mygraph.AddWay(a, b);
            mygraph.DelVertex(b);
            Console.WriteLine(mygraph.vertex.IndexOf(c));
        }
    }
}
