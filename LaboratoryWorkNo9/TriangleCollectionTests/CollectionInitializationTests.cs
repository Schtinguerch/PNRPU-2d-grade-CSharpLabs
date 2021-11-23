using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using LaboratoryWorkNo9;

namespace TriangleCollectionTests
{
    [TestClass]
    public class CollectionInitializationTests
    {
        [TestMethod]
        public void RandomCollection()
        {
            var randomCollection = new TriangleCollection(Initialization.Random);
            randomCollection[0] = new Triangle(1, 1, 1);
            
            for (int i = 0; i < randomCollection.Count; i++)
            {
                double boo = randomCollection[i].Area;
            }

            Assert.AreEqual(3, randomCollection[0].Perimeter);
        }

        [TestMethod]
        public void NullCollection()
        {
            var nullCollection = new TriangleCollection(Initialization.Null);
            Assert.AreEqual(0, nullCollection.Count);
        }

        [TestMethod]
        public void EmptyConstructor()
        {
            var collection = new TriangleCollection();
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void IEnumerableConstructor()
        {
            var triangleArray = new Triangle[]
            {
                new Triangle(3, 4, 5),
                new Triangle(9, 8, 11),
                new Triangle(100, 4, 8),
            };

            var triangleList = new List<Triangle>
            {
                new Triangle(5, 6, 7),
                new Triangle(23, 56, 90),
                new Triangle(1, 9, 3),
                new Triangle(7, 8, 11),
            };

            var arrayCollection = new TriangleCollection(triangleArray);
            var listCollection = new TriangleCollection(triangleList);

            Assert.AreEqual(triangleArray.Length, arrayCollection.Count);
            Assert.AreEqual(triangleList.Count, listCollection.Count);
        }
    }
}
