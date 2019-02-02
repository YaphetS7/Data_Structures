using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using _2D_Range_Tree;
namespace TestForTree
{
    [TestClass]
    public class TestForTree
    {
        [TestMethod]
        public void GlobalMethod()
        {
            Interval x = new Interval(0, 10);
            Interval y = new Interval(0, 10);
            Interval a = new Interval(0, 1);
            Interval b = new Interval(2, 4);
            Interval c = new Interval(3, 7);
            Interval d = new Interval(1, 1);
            Interval e = new Interval(2, 3);
            Interval f = new Interval(4, 0);
            Interval g = new Interval(0, 3);

            List<Interval> list = new List<Interval>() { a, b, c, d, e, f, g };
            RangeTree tree = new RangeTree(list);

            List<Interval> ans1 = tree.Q(x, y);
            List<Interval> ans2 = tree.Q(new Interval(0, 1), new Interval(0, 1));
            List<Interval> ans3 = tree.Q(new Interval(0, 2), new Interval(0, 1));
            List<Interval> ans4 = tree.Q(new Interval(0, 2), new Interval(0, 4));
            List<Interval> ans5 = tree.Q(new Interval(4, 100), new Interval(0, 100));

            Assert.AreEqual(7, ans1.Count);
            Assert.AreEqual(2, ans2.Count);
            Assert.AreEqual(2, ans3.Count);
            Assert.AreEqual(5, ans4.Count);
            Assert.AreEqual(f, ans5[0]);
        }
    }
}
