using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Splay_Tree;
namespace TestForTree
{
    [TestClass]
    public class TestForSplayTree
    {
        [TestMethod]
        public void GlobalTest()
        {
            SplayTree tree = new SplayTree(100);
            tree.Insert(50);
            Assert.AreEqual(50, tree.root.value);
            tree.Insert(101);
            Assert.AreEqual(101, tree.root.value);
            tree.Insert(0);
            Assert.AreEqual(0, tree.root.value);
            tree.Insert(1);
            Assert.AreEqual(1, tree.root.value);
            tree.Insert(-100);
            Assert.AreEqual(-100, tree.root.value);
            tree.Insert(90);
            Assert.AreEqual(90, tree.root.value);
            tree.Insert(70);
            Assert.AreEqual(70, tree.root.value);
            tree.Insert(1000);
            Assert.AreEqual(1000, tree.root.value);
            tree.Insert(1010);
            Assert.AreEqual(1010, tree.root.value);
            tree.Insert(-9000);
            Assert.AreEqual(-9000, tree.root.value);
            tree.Insert(65);
            Assert.AreEqual(65, tree.root.value);
            tree.Insert(9999);
            Assert.AreEqual(9999, tree.root.value);
            tree.Insert(346);
            Assert.AreEqual(346, tree.root.value);
            tree.Insert(23412);
            Assert.AreEqual(23412, tree.root.value);
            tree.Insert(-558);
            Assert.AreEqual(-558, tree.root.value);
            tree.Insert(63453);
            Assert.AreEqual(63453, tree.root.value);

        }
    }
}
