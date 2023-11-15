using System;
using System.Collections.Generic;

namespace Task_3_Interfaces
{
    public class Product : IExecutable
    {
        public int CompareTo(object obj)
        {
            var otherProduct = obj as Product;

            if (otherProduct == null || Cost < otherProduct.Cost)
                return -1;

            if (Cost > otherProduct.Cost)
                return 1;

            return 0;
        }

        public virtual object Clone()
        {
            var cloneSticker = new Sticker(_sticker.Name, _sticker.RecommendedCost);
            return new Product(cloneSticker, Id, Name, Cost);
        }

        public Product ShallowCopy() =>
            (Product)MemberwiseClone();

        public void ExecuteInflation(double percentage)
        {
            _cost += _cost * percentage / 100d;
        }

        protected Sticker _sticker;

        protected double _cost;
        protected string _productId;
        protected string _name;

        public double Cost => _cost;
        public string Id => _productId;
        public string Name => _name;

        public Product(Sticker sticker, string productId, string name, double cost)
        {
            _productId = productId;
            _name = name;
            _sticker = sticker;

            if (cost <= 0)
                throw new ArgumentException("Cost cannot be < 0");

            _cost = cost;
        }

        public override string ToString() => Info();
        public virtual string Info() => BaseInfo();

        public string BaseInfo() =>
            $"Товар: Id = {Id}; Название = {Name}; Стоимость = {Cost}$";

        public string StickerInfo() =>
            $"Этикетка: Бренд = {_sticker.Name}; Рекомен. цена = {_sticker.RecommendedCost}$";
    }
}
