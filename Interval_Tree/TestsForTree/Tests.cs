using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Interval_Tree;
namespace TestsForTree
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void GlobalTest()
        {
            Interval interval = new Interval(0, 5);
            Interval interval2 = new Interval(4, 6);
            Interval interval3 = new Interval(8, 10);
            List<Interval> list = new List<Interval>();
            list.Add(interval);
            list.Add(interval2);
            list.Add(interval3);
            
            IntervalTree tree = new IntervalTree(list);
            List<Interval> ans1 = tree.Q(0, tree.root);
            List<Interval> ans2 = tree.Q(1, tree.root);
            List<Interval> ans3 = tree.Q(2, tree.root);
            List<Interval> ans4 = tree.Q(3, tree.root);
            List<Interval> ans5 = tree.Q(4, tree.root);
            List<Interval> ans6 = tree.Q(5, tree.root);
            List<Interval> ans7 = tree.Q(6, tree.root);
            List<Interval> ans8 = tree.Q(8, tree.root);
            List<Interval> ans9 = tree.Q(9, tree.root);
            List<Interval> ans10 = tree.Q(10, tree.root);

            Assert.AreEqual(0 ,ans1[0].start);
            Assert.AreEqual(0, ans2[0].start);
            Assert.AreEqual(0, ans3[0].start);
            Assert.AreEqual(0, ans4[0].start);
            Assert.AreEqual(2, ans5.Count);
            Assert.AreEqual(2, ans6.Count);
            Assert.AreEqual(4, ans7[0].start);
            Assert.AreEqual(8, ans8[0].start);
            Assert.AreEqual(8, ans9[0].start);
            Assert.AreEqual(10, ans10[0].end);
        }
    }
}
