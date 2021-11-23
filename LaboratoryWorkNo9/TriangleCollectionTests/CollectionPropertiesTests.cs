using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LaboratoryWorkNo9;

namespace TriangleCollectionTests
{
    [TestClass]
    public class CollectionPropertiesTests
    {
        [TestMethod]
        public void GetMinAreaTriangleValidArray()
        {
            var triangleArray = new Triangle[]
            {
                new Triangle(3, 4, 5),
                new Triangle(9, 8, 11),
                new Triangle(100, 4, 8),
                new Triangle(8, 8, 8),
            };

            var notEmptyCollection = new TriangleCollection(triangleArray);
            var minAreaTriangle = notEmptyCollection.MinAreaTriangle;

            Assert.AreEqual(new Triangle(3, 4, 5), minAreaTriangle);
        }

        [TestMethod]
        public void GetMinAreaTriangleInvalidArray()
        {
            var unexistingTriangles = new Triangle[]
            {
                new Triangle(1, 2, 10),
                new Triangle(23, 8, 7),
                new Triangle(23, 99, 9),
            };

            var unexistingTriangleCollection = new TriangleCollection(unexistingTriangles);

            try
            {
                var minAreaTriangle = unexistingTriangleCollection.MinAreaTriangle;
            }

            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, TriangleCollection.NotFoundExistingTriangleMessage);
                return;
            }

            Assert.Fail("The exception wasn't thrown");
        }

        [TestMethod]
        public void GetMinTriangleEmptyArray()
        {
            var emptyCollection = new TriangleCollection();

            try
            {
                var minAreaTriangle = emptyCollection.MinAreaTriangle;
            }

            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, TriangleCollection.EmptyCollectionMessage);
                return;
            }

            Assert.Fail("The exception wasn't thrown");
        }

        [TestMethod]
        public void ToStringOutput()
        {
            var expectedMessage = "Кол-во элементов = 3\n" +
                " * Треугольник: AB = 3,00, BC = 4,00, AC = 5,00; S = 6,00, P = 12,00; Существует;\n" +
                " * Треугольник: AB = 10,00, BC = 6,00, AC = 8,00; S = 24,00, P = 24,00; Существует;\n" +
                " * Треугольник: AB = 40,00, BC = 50,00, AC = 30,00; S = 600,00, P = 120,00; Существует;\n";

            var actualMessage = new TriangleCollection(new Triangle[]
            {
                new Triangle(3, 4, 5),
                new Triangle(10, 6, 8),
                new Triangle(40, 50, 30),
            }).ToString();

            Assert.AreEqual(expectedMessage, actualMessage);

            actualMessage = new TriangleCollection().ToString();
            expectedMessage = TriangleCollection.EmptyCollectionMessage;

            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
