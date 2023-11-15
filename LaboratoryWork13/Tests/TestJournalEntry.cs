using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaboratoryWork13;
using System;

namespace Tests
{
    [TestClass]
    public class TestJournalEntry
    {
        [TestMethod]
        public void TestRecordSaving()
        {
            var collectionName = "Some collection name";
            var eventType = "Addition";
            var objectInvoker = "Hello teammate!";

            var entry = new JournalEntry(objectInvoker, collectionName, eventType);

            Assert.AreEqual(collectionName, entry.CollectionName);
            Assert.AreEqual(eventType, entry.EventType);
            Assert.AreEqual(objectInvoker, entry.ChangedObjectInformation);
        }
    }
}
