using System;
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
            Assert.AreEqual((mygraph.IsWayBetween(a, f).Count != 0), true);
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
            Assert.AreEqual((mygraph.IsWayBetween(a, f).Count == 0), true);
        }
    }
}
