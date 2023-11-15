using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Task_2_DynamicTypeIdentification;

namespace LabNo14Tests
{
    [TestClass]
    public class ExtensionMethods
    {

        [TestMethod]
        public void Selection()
        {
            var expectedValue = new List<TrainCar>() { TestPool.Cars[3], TestPool.Cars[4], TestPool.Cars[5] };
            var actualValue = TestPool.Cars.Where(c => c.Mass > 300).ToList();

            CollectionAssert.AreEquivalent(expectedValue, actualValue);
        }

        [TestMethod]   
        public void CountByCondition()
        {
            var expectedValue = 1;
            var actualValue = TestPool.Cars.Count(c => c is EconomClass && c.Length > 80);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Union()
        {
            var expected = TestPool.Cars;
            var actual = TestPool.CarSetA.Union(TestPool.CarSetB).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Intersection()
        {
            var expected = new List<TrainCar>() { TestPool.Cars[2], TestPool.Cars[3] };
            var actual = TestPool.CarSetA.Intersect(TestPool.CarSetB).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void SetException()
        {
            var expected = new List<TrainCar>() { TestPool.Cars[0], TestPool.Cars[1] };
            var actual = TestPool.CarSetA.Except(TestPool.CarSetB).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void SetDistinction()
        {
            var expected = new List<TrainCar>() { TestPool.Cars[0], TestPool.Cars[3], TestPool.Cars[6], TestPool.Cars[4] };
            var actual = TestPool.DuplicatedCars.Distinct().ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void AggrerationSum()
        {
            var expected = 2685;
            var actual = TestPool.Cars.Sum(c => c.Mass);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AggregationMax()
        {
            var expected = TestPool.Cars[5];
            var actual = TestPool.Cars.Max();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AggregationMin()
        {
            var expected = TestPool.Cars[6];
            var actual = TestPool.Cars.Min();

            Assert.AreEqual(expected, actual);
        }
    }
}
