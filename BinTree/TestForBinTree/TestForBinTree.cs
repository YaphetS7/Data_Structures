using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinTree;
namespace TestForBinTree
{
    [TestClass]
    public class TestForBinTree
    {
        [TestMethod]
        public void TestForFind1()
        {
            Tree2 tree = new Tree2(10);
            bool check = false, isright = false;
            Node a = tree.FindNode(100, ref check, ref isright);
            Assert.AreEqual(false, check);
        }
        [TestMethod]
        public void TestForFind2()
        {
            Tree2 tree = new Tree2(10);
            tree.AddChild(new Node(9));
            bool check = false, isright = false;
            Node a = tree.FindNode(9, ref check, ref isright);
            Assert.AreEqual(true, check);
        }
        [TestMethod]
        public void TestForAdd1()
        {
            Node a;
            Tree2 tree = new Tree2(10);
            tree.AddChild(new Node(9));
            bool check = false, isright = false;

            a = tree.FindNode(100, ref check, ref isright);
            Assert.AreEqual(false, check);

            tree.AddChild(new Node(100));
            a = tree.FindNode(100, ref check, ref isright);
            Assert.AreEqual(true, check);
        }
        [TestMethod]
        public void TestForAdd2()
        {
            Node a = new Node(9);
            Node b = new Node(11);
            Tree2 tree = new Tree2(10);
            tree.AddChild(a);
            tree.AddChild(b);
            Assert.AreEqual(a, tree.root.left);
            Assert.AreEqual(b, tree.root.right);
        }
        [TestMethod]
        public void TestForAdd3()
        {
            Tree2 tree = new Tree2(10);
            tree.AddChild(new Node(9));
            tree.AddChild(new Node(9));
            Assert.AreEqual(2, tree.CntOfNodes);
        }
        [TestMethod]
        public void TestForRemove()
        {
            Tree2 tree = new Tree2(10);
            Node a = new Node(9);
            Node b = new Node(50);
            Node c = new Node(100);
            tree.AddChild(a);
            tree.AddChild(b);
            tree.AddChild(c);
            Assert.AreEqual(c, b.right);
            tree.RemoveNode(100);
            Assert.AreEqual(null, b.right);
        }
        [TestMethod]
        public void TestForFindMaxAndMin1()
        {
            Tree2 tree = new Tree2(10);
            tree.AddChild(new Node(10));
            tree.AddChild(new Node(9));
            tree.AddChild(new Node(7));
            tree.AddChild(new Node(1));
            tree.AddChild(new Node(12));
            tree.AddChild(new Node(11));
            tree.AddChild(new Node(15));
            Node max = tree.FindMaxFrom(tree.root);
            Node min = tree.FindMinFrom(tree.root);
            Assert.AreEqual(1, min.value);
            Assert.AreEqual(15, max.value);
        }
        [TestMethod]
        public void TestForFindMaxAndMin2()
        {
            Tree2 tree = new Tree2(10);
            Node a = new Node(7);
            tree.AddChild(new Node(9));
            tree.AddChild(a);
            tree.AddChild(new Node(8));
            tree.AddChild(new Node(1));
            tree.AddChild(new Node(12));
            tree.AddChild(new Node(11));
            tree.AddChild(new Node(15));
            Node max = tree.FindMaxFrom(a);
            Node min = tree.FindMinFrom(a);
            Assert.AreEqual(1, min.value);
            Assert.AreEqual(8, max.value);
        }
    }
}
