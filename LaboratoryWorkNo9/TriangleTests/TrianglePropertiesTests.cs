using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LaboratoryWorkNo9;

namespace TriangleTests
{
    [TestClass]
    public class TrianglePropertiesTests
    {
        /// <summary>
        /// Operators <, >, and Equals(), compare the area of triangles
        /// </summary>
        [TestMethod]
        public void IsBigger()
        {
            //area = 6
            var firstTriangle = new Triangle(3, 4, 5);

            //area = 24
            var secondTriangle = new Triangle(10, 8, 6);

            var isBigger = secondTriangle > firstTriangle;
            Assert.AreEqual(true, isBigger);
        }

        [TestMethod]
        public void IsSmaller()
        {
            //area = 9.9215674164922
            var firstTriangle = new Triangle(3, 8, 10);

            //area = 42.286966077031
            var secondTriangle = new Triangle(9, 17, 25);

            var isSmaller = firstTriangle < secondTriangle;
            Assert.AreEqual(true, isSmaller);
        }

        [TestMethod]
        public void AreEqual()
        {
            //area = 6
            var firstTriangle = new Triangle(3, 4, 5);

            //area = 6
            var secondTriangle = new Triangle(5, 3, 4);

            var areEqual = firstTriangle.Equals(secondTriangle);
            Assert.AreEqual(true, areEqual);
        }

        [TestMethod]
        public void AreNotEqual()
        {
            //area = 6
            var firstTriangle = new Triangle(3, 4, 5);

            //area = 42.286966077031
            var secondTriangle = new Triangle(9, 17, 25);

            object nullObject = null;
            int nonTriangle = 5;

            var isEqualArea = firstTriangle.Equals(secondTriangle);
            var isEqualNull = firstTriangle.Equals(nullObject);
            var isEqualOtherType = firstTriangle.Equals(nonTriangle);

            Assert.AreEqual(false, isEqualArea);
            Assert.AreEqual(false, isEqualNull);
            Assert.AreEqual(false, isEqualOtherType);
        }

        [TestMethod]
        public void IComparableCompareTo()
        {
            var unexistingTriangle = new Triangle(1, 1, 4);

            //area = 6
            var smallestTriangle = new Triangle(3, 4, 5);

            //area = 9.9215674164922
            var middleTriangle = new Triangle(3, 8, 10);
            var secondMiddleTriangle = new Triangle(10, 3, 8);

            //area = 42.286966077031
            var biggestTriangle = new Triangle(9, 17, 25);

            var isBiggerThanNull = middleTriangle.CompareTo(null) == 1;
            var isBigger = middleTriangle.CompareTo(smallestTriangle) == 1;
            var isSmaller = middleTriangle.CompareTo(biggestTriangle) == -1;
            var isEqual = middleTriangle.CompareTo(secondMiddleTriangle) == 0;

            Assert.AreEqual(true, isBiggerThanNull);
            Assert.AreEqual(true, isBigger);
            Assert.AreEqual(true, isSmaller);
            Assert.AreEqual(true, isEqual);
        }
        
        [TestMethod] 
        public void ToStringOutput()
        {
            var someTriangle = new Triangle(3, 4, 5);
            var outputString = someTriangle.ToString();

            var expectedOutput = "Треугольник: AB = 3,00, BC = 4,00, AC = 5,00; S = 6,00, P = 12,00; Существует";
            Assert.AreEqual(expectedOutput, outputString);

            var unexistingTriangle = new Triangle(1, 2, 10);
            outputString = unexistingTriangle.ToString();

            expectedOutput = "Треугольник: AB = 1,00, BC = 2,00, AC = 10,00; S = 0,00, P = 13,00; Не существует";
            Assert.AreEqual(expectedOutput, outputString);
        }
    }
}
