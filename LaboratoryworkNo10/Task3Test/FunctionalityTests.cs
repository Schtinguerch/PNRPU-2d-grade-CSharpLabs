using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_3_Interfaces;
using System;

namespace Task3Test
{
    [TestClass]
    public class FunctionalityTests
    {
        [TestMethod]
        public void ShallowCopy()
        {
            var baseSticker = new Sticker("lalala", 13);

            var firstProduct = new Product(baseSticker, "17", "hello", 20);
            var secondProduct = firstProduct.ShallowCopy();

            baseSticker.Name = "lololo";
            Assert.AreEqual(firstProduct.StickerInfo(), secondProduct.StickerInfo());
        }

        [TestMethod]
        public void DeepCopy()
        {
            var baseSticker = new Sticker("lalala", 13);

            var firstProduct = new Product(baseSticker, "17", "hello", 20);
            var secondProduct = firstProduct.Clone() as Product;

            baseSticker.Name = "lololo";
            Assert.AreNotEqual(firstProduct.StickerInfo(), secondProduct.StickerInfo());
        }

        [TestMethod]
        public void CompareTwoProducts()
        {
            var firstProduct = new Product(null, "123", "a", 25);
            var secondProduct = new Product(null, "133", "b", 35);
            var thirdProduct = new Product(null, "2345", "c", 35);

            Assert.AreEqual(firstProduct.CompareTo(secondProduct), -1);
            Assert.AreEqual(secondProduct.CompareTo(firstProduct), 1);
            Assert.AreEqual(secondProduct.CompareTo(thirdProduct), 0);
        }

        [TestMethod]
        public void CompareWithOtherType()
        {
            var firstProduct = new Product(null, "123", "a", 25);
            var notProduct = "hello world";

            Assert.AreEqual(firstProduct.CompareTo(notProduct), -1);
        }

        [TestMethod]
        public void IComparerWorking()
        {
            var firstProduct = new Product(null, "123", "a", 25);
            var secondProduct = new Product(null, "133", "b", 35);
            var thirdProduct = new Product(null, "2345", "c", 35);

            var comparer = new CostComparer();

            Assert.AreEqual(comparer.Compare(firstProduct, secondProduct), -1);
            Assert.AreEqual(comparer.Compare(secondProduct, firstProduct), 1);
            Assert.AreEqual(comparer.Compare(secondProduct, thirdProduct), 0);
        }
    }
}
