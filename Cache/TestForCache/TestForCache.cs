using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cash;
namespace TestForCache
{
    [TestClass]
    public class TestForCache
    {
        [TestMethod]
        public void TestBounds1()
        {
            Cache cache = new Cache(7);
            cache.appeal("translator");
            cache.appeal("video");
            cache.appeal("google");
            cache.appeal("yandex");
            cache.appeal("google");
            cache.appeal("video");
            cache.appeal("yandex");
            
            cache.appeal("vk.com");
           

           

            Assert.AreEqual(true, cache.dict.ContainsKey("vk.com"));
        }

        [TestMethod]
        public void TestBounds2()
        {
            Cache cache = new Cache(7);
            cache.appeal("translator");
            cache.appeal("video");
            cache.appeal("google");
            cache.appeal("yandex");
            cache.appeal("google");
            cache.appeal("video");
            cache.appeal("yandex");

            cache.appeal("vk.com");

            cache.appeal("mts");


            Assert.AreEqual(true, cache.dict.ContainsKey("vk.com"));
        }

        public void TestBounds3()
        {
            Cache cache = new Cache(7);
            cache.appeal("translator");
            cache.appeal("video");
            cache.appeal("google");
            cache.appeal("yandex");
            cache.appeal("google");
            cache.appeal("video");
            cache.appeal("yandex");

            cache.appeal("vk.com");

            cache.appeal("mts");


            Assert.AreEqual(true, cache.dict.ContainsKey("mts"));
        }

        [TestMethod]
        public void TestCount1()
        {
            Cache cache = new Cache(7);
            cache.appeal("translator");
            cache.appeal("video");
            cache.appeal("google");
            cache.appeal("yandex");
            cache.appeal("google");
            cache.appeal("video");
            cache.appeal("yandex");
            int i = cache.find_index("yandex");
            Assert.AreEqual(2, cache.CntOfAppeals[i]);
        }
        [TestMethod]
        public void TestCount2()
        {
            Cache cache = new Cache(7);
            cache.appeal("translator");
            cache.appeal("video");
            cache.appeal("google");
            cache.appeal("yandex");
            cache.appeal("google");
            cache.appeal("video");
            cache.appeal("yandex");
            int i = cache.find_index("translator");
            Assert.AreEqual(1, cache.CntOfAppeals[i]);
        }
    }
}
