using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1_ClassHierarchy;

using System;

namespace Task1Test
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void AddMoney()
        {
            var customer = new Customer();
            customer.Name = "Иннокентий";

            int money = 100;
            customer.Balance = money;

            var successMessage = customer.ActivityLogs[0];

            Assert.AreEqual(money, customer.Balance);
            Assert.AreEqual(true, successMessage.Contains("Пополнение средств"));
        }

        [TestMethod]
        public void BuyProduct()
        {
            var customer = new Customer();
            var boughtMessage = string.Empty;
            int startBalance = 200;

            customer.Balance = startBalance;
            customer.OnOperationDone += (s) =>
            {
                boughtMessage = s;
            };

            var toy = new Toy(
                productId: "123",
                name: "Юла",
                cost: 89,
                manufactureMaterial: "Пластмасса");

            customer.BuyProduct(toy);
            int endBalance = startBalance - toy.Cost;

            Assert.AreEqual(customer.Balance, endBalance);
            Assert.AreEqual(boughtMessage, "Товар успешно куплен");
        }

        [TestMethod]
        public void UnrealBuy()
        {
            var customer = new Customer();
            var notBoughtMessage = string.Empty;
            int startBalance = 200;

            customer.Balance = startBalance;
            customer.OnOperationError += (s) =>
            {
                notBoughtMessage = s;
            };

            var tooExpensiveToy = new Product(
                productId: "789",
                name: "Т-72Б3М",
                cost: 200000000);

            customer.BuyProduct(tooExpensiveToy);

            Assert.AreEqual(customer.Balance, startBalance);
            Assert.AreEqual(true, notBoughtMessage.Contains("Ошибка: недостаточно средств"));
        }
    }
}
