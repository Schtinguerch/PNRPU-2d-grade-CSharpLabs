using LaboratoryWorkNo14;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Task_2_DynamicTypeIdentification;

namespace LabNo14Tests
{
    [TestClass]
    public class QuerryMethods
    {
        [TestMethod]
        public void Selection()
        {
            var expectedValue = new List<TrainCar>() { TestPool.Cars[3], TestPool.Cars[4], TestPool.Cars[5] };
            var actualValue = (from car in TestPool.Cars where car.Mass > 300 select car).ToList();

            CollectionAssert.AreEquivalent(expectedValue, actualValue);
        }

        [TestMethod]
        public void Union()
        {
            var expected = TestPool.Cars;
            var actual = (from car in TestPool.CarSetA select car).Union(from car in TestPool.CarSetB select car).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Intersection()
        {
            var expected = new List<TrainCar>() { TestPool.Cars[2], TestPool.Cars[3] };
            var actual = (from car in TestPool.CarSetA select car).Intersect(from car in TestPool.CarSetB select car).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void SetException()
        {
            var expected = new List<TrainCar>() { TestPool.Cars[0], TestPool.Cars[1] };
            var actual = (from car in TestPool.CarSetA select car).Except(from car in TestPool.CarSetB select car).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void SetDistinction()
        {
            var expected = new List<TrainCar>() { TestPool.Cars[0], TestPool.Cars[3], TestPool.Cars[6], TestPool.Cars[4] };
            var actual = (from car in TestPool.DuplicatedCars select car).Distinct().ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void AggrerationSum()
        {
            var expected = 2685;
            var actual = (from car in TestPool.Cars select car).Sum(c => c.Mass);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AggregationMax()
        {
            var expected = TestPool.Cars[5];
            var actual = (from car in TestPool.Cars select car).Max();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AggregationMin()
        {
            var expected = TestPool.Cars[5];
            var actual = (from car in TestPool.Cars select car).Max();

            Assert.AreEqual(expected, actual);
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

            var actual = TestPool.MyCars.SortedQueryLanguage().ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
