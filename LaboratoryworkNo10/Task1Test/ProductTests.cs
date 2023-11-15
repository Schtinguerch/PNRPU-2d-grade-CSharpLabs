using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1_ClassHierarchy;
using System;

namespace Task1Test
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void ProductsInitialazation()
        {
            var baseIds = new string[] { "1", "2", "3", "4" };
            var baseNames = new string[] { "abc", "bcd", "cde", "def" };
            var baseCosts = new int[] { 11, 22, 33, 44 };

            var products = new Product[]
            {
                new Product(
                    productId: "1",
                    name: "abc",
                    cost: 11),

                new Toy(
                    productId: "2",
                    name: "bcd",
                    cost: 22,
                    manufactureMaterial: "htns"),

                new FoodProduct(
                    productId: "3",
                    name: "cde",
                    cost: 33,
                    manufCountry: "gcrl",
                    shelfLife: new TimeSpan(1, 0, 0, 0)),

                new MilkProduct(
                    productId: "4",
                    name: "def",
                    cost: 44,
                    manufCountry: "aoeu",
                    shelfLife: new TimeSpan(2, 0, 0, 0),
                    fatnessPercentage: 6.2d),
            };

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(baseIds[i], products[i].Id);
                Assert.AreEqual(baseNames[i], products[i].Name);
                Assert.AreEqual(baseCosts[i], products[i].Cost);
            }

            Assert.AreEqual("htns", (products[1] as Toy).ManufactureMaterial);
            Assert.AreEqual(6.2d, (products[3] as MilkProduct).FatnessPercentage);

            Assert.AreEqual("gcrl", (products[2] as FoodProduct).ManufacturerCountry);
            Assert.AreEqual("aoeu", (products[3] as MilkProduct).ManufacturerCountry);

            Assert.AreEqual(new TimeSpan(1, 0, 0, 0), (products[2] as FoodProduct).ShelfLive);
            Assert.AreEqual(new TimeSpan(2, 0, 0, 0), (products[3] as MilkProduct).ShelfLive);
        }
    }
}
