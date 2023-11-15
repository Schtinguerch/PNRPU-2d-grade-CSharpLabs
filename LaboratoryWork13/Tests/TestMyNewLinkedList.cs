using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LaboratoryWork13;

namespace Tests
{
    [TestClass]
    public class TestMyNewLinkedList
    {
        [TestMethod]
        public void TestIndexer()
        {
            var list = new MyNewLinkedList<string>("New test list");

            var testValue = "Hello";
            var testChangedValue = "Bonjour";
            
            list.Add(testValue);
            Assert.AreEqual(testValue, list[0]);

            list[0] = testChangedValue;
            Assert.AreEqual(testChangedValue, list[0]);
        }
    }
}
