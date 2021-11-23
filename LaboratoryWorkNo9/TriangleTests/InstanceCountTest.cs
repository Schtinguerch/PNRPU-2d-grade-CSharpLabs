using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using LaboratoryWorkNo9;

namespace TriangleTests
{
    [TestClass]
    public class InstanceCountTest
    {
        [TestMethod]
        public void CreateCountOfEmpty()
        {
            var triangles = new List<Triangle>();
            int newCount = 10;
            
            int currentInstanceCount = Triangle.InstanceCount;
            int expectedCount = currentInstanceCount + newCount;

            for (int i = 0; i < newCount; i++)
                triangles.Add(new Triangle());

            Assert.AreEqual(expectedCount, Triangle.InstanceCount);
        }

        [TestMethod]
        public void CreateCoutnOfFilled()
        {
            var triangles = new List<Triangle>();
            int newCount = 16;

            int currentInstanceCount = Triangle.InstanceCount;
            int expectedCount = currentInstanceCount + newCount;

            for (int i = 0; i < newCount; i++)
                triangles.Add(new Triangle(3, 4, 5));

            Assert.AreEqual(expectedCount, Triangle.InstanceCount);
        }

        [TestMethod]
        public void DeleteCount()
        {
            //Wating for deleting all garbage (the count of instances has to be equal 0)
            GC.Collect();
            GC.WaitForPendingFinalizers();

            var currentInstanceCount = Triangle.InstanceCount;

            //Generating garbage instances to test the destructor
            for (int i = 0; i < 20; i++)
            {
                var garbageTriangle = new Triangle();
                garbageTriangle = null;
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            //0 has to be equal 0
            Assert.AreEqual(currentInstanceCount, Triangle.InstanceCount);
        }
    }
}
