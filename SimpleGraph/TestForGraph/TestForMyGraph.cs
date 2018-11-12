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
    }
}
