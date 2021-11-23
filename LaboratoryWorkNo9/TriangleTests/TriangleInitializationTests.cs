using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LaboratoryWorkNo9;

namespace TriangleTests
{
    [TestClass]
    public class TriangleInitializationTests
    {
        [TestMethod]
        public void SetNewEmptyTriangle()
        {
            var emptyTriangle = new Triangle();

            Assert.AreEqual(0d, emptyTriangle.LengthAB);
            Assert.AreEqual(0d, emptyTriangle.LengthBC);
            Assert.AreEqual(0d, emptyTriangle.LengthAC);
        }

        [TestMethod]
        public void SetNewTriangleWithValidData()
        {
            double a = 3;
            double b = 5;
            double c = 9;

            var someTriangle = new Triangle(a, b, c);
        }

        [TestMethod]
        public void SetNewTriangleWithInvalidData()
        {
            double a = -5;
            double b = 8;
            double c = -4;

            Assert.ThrowsException<ArgumentException>(() => new Triangle(a, b, c));
        }

        [TestMethod]
        public void SetExistingTriangle()
        {
            double a = 3;
            double b = 4;
            double c = 5;

            var rightTriangle = new Triangle(a, b, c);
            var expected = true;

            Assert.AreEqual(expected, rightTriangle.Exists);
        }

        [TestMethod]
        public void SetUnexistingTriangle()
        {
            double a = 2;
            double b = 7;
            double c = 100;

            var someTriangle = new Triangle(a, b, c);
            var expected = false;

            Assert.AreEqual(expected, someTriangle.Exists);
            Assert.AreEqual(0d, someTriangle.Area);
        }

        [TestMethod]
        public void SetNewRandomTriangle()
        {
            var randomTriangle = Triangle.NewRandom;
        }
    }
}
