﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerSet;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestSet
{
    [TestClass]
    public class TestSet
    {
        [TestMethod]
        public void TestMethodPut()
        {
            PowerSet1 set = new PowerSet1();

            set.put(22);
            set.put(22);

            Assert.AreEqual(1, set.cnt);
        }
        [TestMethod]
        public void TestMethodRemove()
        {
            PowerSet1 set = new PowerSet1();

            set.put(22);
            set.remove(22);

            Assert.AreEqual(1, set.cnt);
        }
        [TestMethod]
        public void TestMethodIntersection1()
        {
            PowerSet1 set1 = new PowerSet1();
            PowerSet1 set2 = new PowerSet1();
            Dictionary<int, object> dict = new Dictionary<int, object>();
            set1.put(22);
            set1.put(201);
            set2.put(22);
            dict = set1.intersection(set2);
            Assert.AreEqual(1, dict.Count);

        }
        [TestMethod]
        public void TestMethodIntersection2()
        {
            PowerSet1 set1 = new PowerSet1();
            PowerSet1 set2 = new PowerSet1();
            Dictionary<int, object> dict = new Dictionary<int, object>();
            set1.put(22);
            set1.put(201);
            set2.put("LOL");
            dict = set1.intersection(set2);
            Assert.AreEqual(0, dict.Count);

        }
        [TestMethod]
        public void TestMethodUnion1()
        {
            PowerSet1 set1 = new PowerSet1();
            PowerSet1 set2 = new PowerSet1();
            Dictionary<int, object> dict = new Dictionary<int, object>();
            set1.put(22);
            set1.put(201);
            set2.put("NOO");
            dict = set2.union(set1);
            Assert.AreEqual(3, dict.Count);

        }
        [TestMethod]
        public void TestMethodUnion2()
        {
            PowerSet1 set1 = new PowerSet1();
            PowerSet1 set2 = new PowerSet1();
            Dictionary<int, object> dict = new Dictionary<int, object>();
            set1.put(22);
            set1.put(201);
            dict = set1.union(set2);
            Assert.AreEqual(2, dict.Count);

        }

        [TestMethod]
        public void TestMethodDifference1()
        {
            PowerSet1 set1 = new PowerSet1();
            PowerSet1 set2 = new PowerSet1();
            Dictionary<int, object> dict = new Dictionary<int, object>();
            set1.put(22);
            set1.put(201);
            set2.put(22);
            set2.put("hard");
            dict = set1.difference(set2);
            Assert.AreEqual(1, dict.Count);

        }
        [TestMethod]
        public void TestMethodDifference2()
        {
            PowerSet1 set1 = new PowerSet1();
            PowerSet1 set2 = new PowerSet1();
            Dictionary<int, object> dict = new Dictionary<int, object>();
            set1.put(22);
            set2.put(22);
            set2.put("hard");
            dict = set1.difference(set2);
            Assert.AreEqual(0, dict.Count);

        }

        [TestMethod]
        public void TestMethodIsSubSet1()
        {
            PowerSet1 set1 = new PowerSet1();
            PowerSet1 set2 = new PowerSet1();
            Dictionary<int, object> dict = new Dictionary<int, object>();
            set1.put(22);
            set1.put("привет");
            set1.put("thx");
            set2.put(22);
            set2.put("thx");
            bool check = set1.issubset(set2);
            Assert.AreEqual(true, check);
        }
        [TestMethod]
        public void TestMethodIsSubSet2()
        {
            PowerSet1 set1 = new PowerSet1();
            PowerSet1 set2 = new PowerSet1();
            Dictionary<int, object> dict = new Dictionary<int, object>();
            set2.put(22);
            set2.put("привет");
            set2.put("thx");
            set1.put(22);
            set1.put("thx");
            bool check = set1.issubset(set2);
            Assert.AreEqual(false, check);
        }
        public void TestMethodIsSubSet3()
        {
            PowerSet1 set1 = new PowerSet1();
            PowerSet1 set2 = new PowerSet1();
            Dictionary<int, object> dict = new Dictionary<int, object>();
            set2.put(22);
            set2.put("привет");
            set2.put("thx");
            set1.put(22);
            set1.put("thx");
            set1.put("а такого нет");
            bool check = set2.issubset(set1);
            Assert.AreEqual(false, check);
        }
    }
}
