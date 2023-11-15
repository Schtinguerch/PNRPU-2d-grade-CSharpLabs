using System;
using System.Collections.Generic;

namespace Task_1_ClassHierarchy
{
    public class Product
    {
        protected readonly int _cost;
        protected readonly string _productId;
        protected readonly string _name;

        public int Cost => _cost;
        public string Id => _productId;
        public string Name => _name;

        public Product(string productId, string name, int cost)
        {
            _productId = productId;
            _cost = cost;
            _name = name;
        }

        public override string ToString() => Info();
        public virtual string Info() => BaseInfo();

        public string BaseInfo() =>
            $"Товар: Id = {Id}; Название = {Name}; Стоимость = {Cost}$";
    }
}
