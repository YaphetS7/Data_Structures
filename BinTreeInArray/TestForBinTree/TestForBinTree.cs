using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinTreeInArray;
namespace TestForBinTree
{
    [TestClass]
    public class TestForBinTree
    {
        [TestMethod]
        public void TestForAddAndFind()
        {
            BinTree tree = new BinTree(30, 50);
            tree.AddChild(25);
            //tree.AddChild(20);
            tree.AddChild(75);
            tree.AddChild(37);
            tree.AddChild(62);
            tree.AddChild(84);
            tree.AddChild(31);
            tree.AddChild(43);
            tree.AddChild(55);
            tree.AddChild(92);
            tree.PrintTree();

            Assert.AreEqual(-3, tree.FindNode(20));
            Assert.AreEqual(5, tree.FindNode(62));
            Assert.AreEqual(-30, tree.FindNode(100));
        }
    }
}
