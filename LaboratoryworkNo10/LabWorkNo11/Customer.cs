using System;
using System.Collections.Generic;

namespace Task_1_ClassHierarchy
{
    public sealed class Customer
    {
        private int _balance;
        private List<string> _activityLogs = new List<string>();
        private List<Product> _boughtProducts = new List<Product>();

        public string Name { get; set; }

        public List<string> ActivityLogs => _activityLogs;

        public delegate void OperationErrorHandler(string message);
        public event OperationErrorHandler OnOperationError;

        public delegate void OperationDoneHandler(string message);
        public event OperationDoneHandler OnOperationDone;

        public int Balance
        {
            get
            {
                _activityLogs.Add($"Проверка баланса: {_balance}$");
                return _balance;
            }

            set
            {
                if (value < 0)
                {
                    int moneyRange = _balance - value;
                    var errorMessage = $"Balance -> Ошибка: недостаточно средств для списания {moneyRange}$";

                    _activityLogs.Add(errorMessage);
                    throw new ArgumentOutOfRangeException(errorMessage);
                }

                if (value > _balance)
                {
                    int addMoneyRange = value - _balance;
                    var addMoneyMessage = $"Пополнение средств: +{addMoneyRange}$";

                    _activityLogs.Add(addMoneyMessage);
                }

                else
                {
                    int debitMoneyRange = _balance - value;
                    var debitMoneyMessage = $"Списание средств: -{debitMoneyRange}$";

                    _activityLogs.Add(debitMoneyMessage);
                }

                _balance = value;
            }
        }

        public void BuyProduct(Product product)
        {
            try
            {
                Balance -= product.Cost;
                _boughtProducts.Add(product);

                _activityLogs.Add($"ПРИОБРЕТЕНИЕ: {product}");
                OnOperationDone?.Invoke("Товар успешно куплен");
            }

            catch (ArgumentOutOfRangeException e)
            {
                OnOperationError?.Invoke(e.Message);
            }
        }

        public string BoughtProductsData()
        {
            var data = "\nПриобретённые товары:\n\nЧерез override:\n";

            foreach (var product in _boughtProducts)
                data += $"{product}\n";

            data += "\nЧерез overdloading:\n";

            foreach (var product in _boughtProducts)
                data += $"{product.BaseInfo()}\n";

            return data;
        }

        public string Info() =>
            $"Покупатель: Имя = {Name}; Баланс = {Balance}$;\n{BoughtProductsData()}";

        public override string ToString() => Info();
    }
}
