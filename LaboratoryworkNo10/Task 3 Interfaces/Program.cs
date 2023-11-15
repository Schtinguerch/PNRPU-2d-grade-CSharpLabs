using System;
using static System.Console;

namespace Task_3_Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
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

            var sameProducts = new IExecutable[products.Length];
            products.CopyTo(sameProducts, 0);

            PrintCollection(products, "Изначальный список продуктов:\n");

            MakeInflation(products, 10);
            PrintCollection(products, "\nПродукты после инфляции:\n");

            Array.Sort(sameProducts);
            PrintCollection(sameProducts, "\nСортированный список по стоимости (через IComparable):\n");

            Array.Sort(products, new CostComparer());
            PrintCollection(products, "\nСортированный список по стоимости (через IComparer):\n");

            DeepCopyingDemonstration();
            ShallowCopyingDemonstration();


        }

        static void PrintCollection(IExecutable[] collection, string message = "")
        {
            if (!string.IsNullOrWhiteSpace(message))
                WriteLine(message);

            foreach (var item in collection)
                WriteLine(item.ToString());
        }

        static void MakeInflation(IExecutable[] products, double percentage)
        {
            foreach (var product in products)
                product.ExecuteInflation(percentage);
        }

        static void DeepCopyingDemonstration()
        {
            var baseSticker = new Sticker("Шабай-Балай", 10);

            var someProduct = new Product(
                sticker: baseSticker,
                productId: "&025",
                name: "Энергетический напиток",
                16);

            var clonedProduct = someProduct.Clone() as Product;
            baseSticker.Name = "МегаМозг";
            baseSticker.RecommendedCost = 12;

            WriteLine("\nПродукт был клонирован.\n" +
                "Также у основного продукта изменилась этикетка,\n" +
                "А у клона - нет (ибо этикетка была скопирована)\n");

            WriteLine(someProduct.StickerInfo());
            WriteLine(clonedProduct.StickerInfo());
        }

        static void ShallowCopyingDemonstration()
        {
            var baseSticker = new Sticker("Докторяга", 99);

            var someProduct = new Product(
                sticker: baseSticker,
                productId: "&099",
                name: "Колбаса",
                cost: 125);

            var copyiedProduct = someProduct.ShallowCopy();
            baseSticker.Name = "Парам-папарам";
            baseSticker.RecommendedCost = 80;

            WriteLine("\nБыло произведено лишь поверхностное копирование\n" +
                "Этикетка является классом, т. е. имеет ссылочный тип.\n" +
                "Из этого следует, что скопировалась лишь ссылка на этикетку\n");

            WriteLine(someProduct.StickerInfo());
            WriteLine(copyiedProduct.StickerInfo());
        }
    }
}
