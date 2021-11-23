using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LaboratoryWorkNo9;

namespace TriangleTests
{
    [TestClass]
    public class TriangleUnarTests
    {
        [TestMethod]
        public void ImplicitCast()
        {
            double expectedPerimeter = 12d;
            double actualPerimeter = new Triangle(3, 4, 5);

            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        [TestMethod]
        public void ExplicitCast()
        {
            var expectedExists = false;
            var actualExists = (bool) new Triangle(1, 2, 20);

            Assert.AreEqual(expectedExists, actualExists);
        }

        [TestMethod]
        public void AreaOperator()
        {
            //area = 24
            var someTriangle = new Triangle(10, 8, 6);

            double expectedArea = 24d;
            double actualArea = -someTriangle;

            Assert.AreEqual(expectedArea, actualArea);
        }
    }
}
