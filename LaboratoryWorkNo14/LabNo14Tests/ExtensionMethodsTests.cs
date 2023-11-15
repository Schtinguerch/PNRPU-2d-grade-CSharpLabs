using LaboratoryWorkNo14;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Task_2_DynamicTypeIdentification;

namespace LabNo14Tests
{
    [TestClass]
    public class ExtensionMethodsTests
    {
        [TestMethod]
        public void GetKitchens()
        {
            var expected = new List<TrainCar> { TestPool.MyCars[5], TestPool.MyCars[6] };
            var actual = TestPool.MyCars.GetKitchens().ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void AverageLength()
        {
            var expected = 179.42857142857142d;
            var accuracy = Math.Pow(10, -6);

            var actual = TestPool.MyCars.AverageLength();
            
            if (Math.Abs(expected - actual) > accuracy)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Sorted()
        {
            var expected = new List<TrainCar>() 
            {
                TestPool.MyCars[6],
                TestPool.MyCars[2],
                TestPool.MyCars[1],
                TestPool.MyCars[0],
                TestPool.MyCars[3],
                TestPool.MyCars[4],
                TestPool.MyCars[5]
            };

            var actual = TestPool.MyCars.Sorted().ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
