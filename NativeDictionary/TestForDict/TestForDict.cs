using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hash;
namespace TestForDict
{
    [TestClass]
    public class TestForDict
    {
        [TestMethod]
        public void TestForPutAndIsKey()
        {

            NativeDictionary dict = new NativeDictionary();

            dict.put("home", 328910);

            Assert.AreEqual(true, dict.is_key("home"));

            Assert.AreEqual(false, dict.is_key("qwerty"));
        }
        [TestMethod]
        public void TestForGet()
        {
            NativeDictionary dict = new NativeDictionary();

            dict.put("region", 903299);

            Assert.AreEqual(903299, dict.get("region"));

            Assert.AreEqual(-1, dict.get("home"));
        }
    }
}
