using LaboratoryWork13;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class TestJournal
    {
        [TestMethod]
        public void TestManipulationDetection()
        {
            var list = new MyNewLinkedList<string>("Test collection");
            var journal = new Journal("Test Journal");

            list.CollectionCountChanged += journal.CollectionCountChanged;
            list.CollectionReferenceChanged += journal.CollectionReferenceChanged;

            var texts = new List<string>()
            {
                "Hello", "Hola", "Saluton", "Ohayo", "Привет", "Bonjour"
            };

            var accumulatedCount = 0;
            foreach (var text in texts)
            {
                list.Add(text);
                Assert.AreEqual(list.Count, journal.Count);

                accumulatedCount += 1;
                Assert.AreEqual(list.Count, accumulatedCount);
            }

            list.Remove(texts[0]);

            var actionCount = accumulatedCount + 1;
            accumulatedCount -= 1;

            Assert.AreEqual(list.Count, accumulatedCount);
            Assert.AreEqual(journal.Count, actionCount);

            var newValue = "Konnichi-wa";
            list[0] = newValue;
        }

        [TestMethod]
        public void TestChangeName()
        {
            var oldName = "Old Journal";
            var newName = "Le Journale nueve";

            var journal = new Journal(oldName);
            journal.Name = newName;
            
            Assert.AreEqual(newName, journal.Name);
        }
    }
}
