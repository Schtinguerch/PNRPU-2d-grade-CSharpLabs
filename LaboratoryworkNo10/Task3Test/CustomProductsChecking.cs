using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_3_Interfaces;
using System;

namespace Task3Test
{
    [TestClass]
    public class CustomProductsChecking
    {
        [TestMethod]
        public void Cloning()
        {
            var baseToy = new Toy(new Sticker("fff", 10), "89", "baba", 12, "air");
            var cloneToy = baseToy.Clone() as Toy;

            Assert.AreEqual(baseToy.ManufactureMaterial, cloneToy.ManufactureMaterial);

            var baseFood = new FoodProduct(new Sticker("ddd", 100), "89", "babababa", 95, "ru", new TimeSpan(1, 2, 3));
            var cloneFood = baseFood.Clone() as FoodProduct;

            Assert.AreEqual(baseFood.ManufacturerCountry, cloneFood.ManufacturerCountry);
            Assert.AreEqual(baseFood.ShelfLive, cloneFood.ShelfLive);

            var baseMilk = new MilkProduct(new Sticker("ee", 100), "89", "babababa", 95, "ru", new TimeSpan(1, 2, 3), 2.5);
            var cloneMilk = baseMilk.Clone() as MilkProduct;

            Assert.AreEqual(baseMilk.FatnessPercentage, cloneMilk.FatnessPercentage);
        }
    }
}
