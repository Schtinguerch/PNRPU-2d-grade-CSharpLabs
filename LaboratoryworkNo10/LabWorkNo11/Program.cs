using System;
using static System.Console;

namespace Task_1_ClassHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var richCustomer = new Customer();
            richCustomer.Balance = 1000;

            richCustomer.OnOperationDone += ProductBought;
            richCustomer.OnOperationError += BuyOnError;

            richCustomer.BuyProduct(new Product(
                productId: "&472",
                name: "Юла",
                cost: 28));

            richCustomer.BuyProduct(new FoodProduct(
                productId: "&912",
                name: "Мармелад",
                cost: 71,
                manufCountry: "Россия",
                shelfLife: new TimeSpan(180, 0, 0, 0)));

            richCustomer.BuyProduct(new MilkProduct(
                productId: "&074",
                name: "Кефир",
                cost: 9,
                manufCountry: "Финляндия",
                shelfLife: new TimeSpan(5, 0, 0, 0),
                fatnessPercentage: 3.2d));

            richCustomer.BuyProduct(new Toy(
                productId: "&987",
                name: "Сборный планёр",
                cost: 89,
                manufactureMaterial: "Сосна"));

            WriteLine(richCustomer.BoughtProductsData());

            richCustomer.BuyProduct(new Toy(
                productId: "&666",
                name: "БМП-3",
                cost: 1000000,
                manufactureMaterial: "Гамогенная броневая сталь"));
        }

        static void ProductBought(string message) =>
            WriteLine(message);

        static void BuyOnError(string message) =>
            WriteLine(message);
    }
}
