using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BootstrapConfig.UnitTests
{
    [TestClass]
    public class ReadOnlyDictionaryTests
    {
        IDictionary<string, string> readonlyDictionary;

        [TestInitialize]
        public void Initialize_ReadOnlyDictionaryTests()
        {
            var standardDictionary = new Dictionary<string, string>();
            readonlyDictionary = new ReadOnlyDictionary<string, string>(standardDictionary);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Test_ReadOnlyDictionary_Add_Throws_NotSupportedException()
        {
            readonlyDictionary.Add("test", "add");
            Assert.Fail("Expected Add(string, string) to throw a not supported exception.");
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Test_ReadOnlyDictionary_Add_KeyValuePair_Throws_NotSupportedException()
        {
            readonlyDictionary.Add(new KeyValuePair<string, string>("test", "add"));
            Assert.Fail("Expected Add(KeyValuePair<string,string>) to throw a not supported exception.");
        }
    }
}
