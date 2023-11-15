using System;

namespace Task_3_Interfaces
{
    public class FoodProduct : Product
    {
        public override object Clone()
        {
            var cloneSticker = new Sticker(_sticker.Name, _sticker.RecommendedCost);
            return new FoodProduct(cloneSticker, Id, Name, Cost, ManufacturerCountry, ShelfLive);
        }

        protected readonly string _manufCountry;
        protected readonly TimeSpan _shelfLive;

        public string ManufacturerCountry => _manufCountry;
        public TimeSpan ShelfLive => _shelfLive;

        public FoodProduct(Sticker sticker, string productId, string name, double cost, string manufCountry, TimeSpan shelfLife) : 
            base(sticker, productId, name, cost)
        {
            _manufCountry = manufCountry;
            _shelfLive = new TimeSpan(
                shelfLife.Days, 
                shelfLife.Hours, 
                shelfLife.Minutes, 
                shelfLife.Seconds);
        }

        public override string ToString() => Info();
        public override string Info() => BaseInfo();

        public new string BaseInfo() =>
            $"Продукт питания: Id = {Id}; Название = {Name}; Стоимость = {Cost}$; " +
            $"Страна-производитель = {ManufacturerCountry}; Срок годности = {ShelfLive}";
    }
}
