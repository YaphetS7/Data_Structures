using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleGraph;
namespace TestForGraph
{
    [TestClass]
    public class TestForMyGraph
    {
        [TestMethod]
        public void TestMethodForAddVertex()
        {
            Graph mygraph = new Graph(5);
            Vertex a = new Vertex();
            Vertex b = new Vertex();
            Vertex c = new Vertex();
            mygraph.AddVertex(a);
            mygraph.AddVertex(b);
            mygraph.AddVertex(c);
            Assert.AreEqual(mygraph.IsWay(a, b), false);
            Assert.AreEqual(mygraph.IsWay(a, c), false);
        }
        [TestMethod]
        public void TestMethodForAddWay()
        {
            Graph mygraph = new Graph(5);
            Vertex a = new Vertex();
            Vertex b = new Vertex();
            Vertex c = new Vertex();
            mygraph.AddVertex(a);
            mygraph.AddVertex(b);
            mygraph.AddVertex(c);
            mygraph.AddWay(a, b);
            Assert.AreEqual(mygraph.IsWay(a, b), true);
        }
        [TestMethod]
        public void TestMethodForDelWay()
        {
            Graph mygraph = new Graph(5);
            Vertex a = new Vertex();
            Vertex b = new Vertex();
            Vertex c = new Vertex();
            mygraph.AddVertex(a);
            mygraph.AddVertex(b);
            mygraph.AddVertex(c);
            mygraph.AddWay(a, b);
            Assert.AreEqual(mygraph.IsWay(a, b), true);
            mygraph.DelWay(a, b);
            Assert.AreEqual(mygraph.IsWay(a, b), false);
        }
        [TestMethod]
        public void TestMethodForDelVertex()
        {
            Graph mygraph = new Graph(5);
            Vertex a = new Vertex();
            Vertex b = new Vertex();
            Vertex c = new Vertex();
            mygraph.AddVertex(a);
            mygraph.AddVertex(b);
            mygraph.AddVertex(c);
            mygraph.AddWay(a, b);
            Assert.AreEqual(mygraph.IsWay(a, b), true);
            mygraph.DelVertex(b);
            Assert.AreEqual(mygraph.IsWay(a, b), false);
        }
        [TestMethod]
        public void TestMethodForFindWay1()
        {
            Graph mygraph = new Graph(5);
            Vertex a = new Vertex();
            Vertex b = new Vertex();
            Vertex c = new Vertex();
            mygraph.AddVertex(a);
            mygraph.AddVertex(b);
            mygraph.AddVertex(c);
            Vertex d = new Vertex();
            Vertex f = new Vertex();
            mygraph.AddVertex(d);
            mygraph.AddVertex(f);
            mygraph.AddWay(a, b);
            mygraph.AddWay(b, c);
            mygraph.AddWay(c, d);
            mygraph.AddWay(d, f);
            int Lway = mygraph.DF_search(a, f).Count - 1;
            Assert.AreEqual((Lway == 4), true);
        }
        [TestMethod]
        public void TestMethodForFindWay2()
        {
            Graph mygraph = new Graph(5);
            Vertex a = new Vertex();
            Vertex b = new Vertex();
            Vertex c = new Vertex();
            mygraph.AddVertex(a);
            mygraph.AddVertex(b);
            mygraph.AddVertex(c);
            Vertex d = new Vertex();
            Vertex f = new Vertex();
            mygraph.AddVertex(d);
            mygraph.AddVertex(f);
            mygraph.AddWay(a, b);
            mygraph.AddWay(b, c);
            mygraph.AddWay(c, d);
            //mygraph.AddWay(d, f);
            Assert.AreEqual((mygraph.DF_search(a, f).Count == 0), true);
        }
        [TestMethod]
        public void TestMethodForDFS()
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
            Assert.AreEqual(5, stack.Count - 1);
        }
    }
}
