using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Heap;

namespace TestForHeap
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestMethodForAdd()
        {
            HeapT heap = new HeapT(100, 10);
            heap.AddValue(101);
            Assert.AreEqual(101, heap.arr[0]);
            Assert.AreEqual(100, heap.arr[1]);
        }
        [TestMethod]
        public void TestMethodForDelete()
        {
            HeapT heap = new HeapT(100, 10);
            heap.AddValue(101);
            heap.DelRoot(0);
            Assert.AreEqual(100, heap.arr[0]);
            
        }
    }
}
