using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMQ_LCA;
namespace TestForRMQ_LCA
{
    [TestClass]
    public class TestsForRMQ_LCA
    {
        [TestMethod]
        public void TestForMin()
        {
            int[] a = { 1, 3, 2, -1, 4 };
            Func func = Program.FindMin;
            RMQ rmq = new RMQ(a, func, true);

            Assert.AreEqual(-1 ,rmq.Q(0, 0, a.Length - 1));
            Assert.AreEqual(-1, rmq.Q(0, 2, a.Length - 1));
            Assert.AreEqual(1, rmq.Q(0, 0, a.Length - 3));
        }
        [TestMethod]
        public void TestForMax()
        {
            int[] a = { 1, 3, 2, -1, 4 };
            Func func = Program.FindMax;
            RMQ rmq = new RMQ(a, func, true);

            Assert.AreEqual(4, rmq.Q(0, 0, a.Length - 1));
            Assert.AreEqual(4, rmq.Q(0, 2, a.Length - 1));
            Assert.AreEqual(3, rmq.Q(0, 0, a.Length - 3));
        }
        [TestMethod]
        public void TestForSum()
        {
            int[] a = { 1, 3, 2, -1, 4 };
            Func func = Program.FindSum;
            RMQ rmq = new RMQ(a, func, true);

            Assert.AreEqual(9, rmq.Q(0, 0, a.Length - 1));
            Assert.AreEqual(5, rmq.Q(0, 2, a.Length - 1));
            Assert.AreEqual(6, rmq.Q(0, 0, a.Length - 3));
        }
    }
}
