using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_3_Interfaces;
using System;

namespace Task3Test
{
    [TestClass]
    public class InitialazitonTests
    {
        [TestMethod]
        public void InitializeValidProducts()
        {
            var products = new IExecutable[]
               {
                new Toy(
                    sticker: new Sticker("Shaitan", 31.2),
                    productId: "&293",
                    name: "Плюшевый мишка",
                    cost: 300,
                    manufactureMaterial: "Ткань"),

                new MilkProduct(
                    sticker: new Sticker("ПермМолоко", 18.5),
                    productId: "&890",
                    name: "Молоко",
                    cost: 25,
                    manufCountry: "Россия",
                    shelfLife: new TimeSpan(5, 0, 0, 0),
                    fatnessPercentage: 3.4),

                new FoodProduct(
                    sticker: new Sticker("БулОЧКА", 10),
                    productId: "&666",
                    name: "Булочка",
                    cost: 20,
                    manufCountry: "Украина",
                    shelfLife: new TimeSpan(12, 0, 0, 0)),

                new Product(
                    sticker: new Sticker("ЛяШутка", 200),
                    productId: "&001",
                    name: "Набор фокусника",
                    cost: 221)
               };
        }

        [TestMethod]
        public void InvalidCostInitialization()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var badProduct = new Product(null, "", "", -2);
            });
        }

        [TestMethod]
        public void IndavidFatnesPercentageInit()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var badMilk = new MilkProduct(null, "", "", 1, "", new TimeSpan(), -4);
            });
        }

        [TestMethod]
        public void MakeMoreExpensive()
        {
            var product = new Toy(null, "234", "bubu", 100, "oak");
            var cost = product.Cost;

            product.ExecuteInflation(10);
            var newCost = 110;

            Assert.AreEqual(product.Cost, newCost);
        }

        [TestMethod]
        public void CheckInfo()
        {
            var sticker = new Sticker("Krio", 10);
            var id = "789";
            var name = "kukareku";
            var cost = 200;

            var product = new Product(sticker, id, name, cost);

            Assert.AreEqual(id, product.Id);
            Assert.AreEqual(name, product.Name);
            Assert.AreEqual(cost, product.Cost);
        }
    }
}
