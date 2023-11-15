using System;

namespace Task_3_Interfaces
{
    public class MilkProduct : FoodProduct
    {
        public override object Clone()
        {
            var cloneSticker = new Sticker(_sticker.Name, _sticker.RecommendedCost);
            return new MilkProduct(cloneSticker, Id, Name, Cost, ManufacturerCountry, ShelfLive, FatnessPercentage);
        }

        protected readonly double _fatnessPercentage;

        public double FatnessPercentage => _fatnessPercentage;

        public MilkProduct(Sticker sticker, 
            string productId, 
            string name, 
            double cost, 
            string manufCountry, 
            TimeSpan shelfLife, 
            double fatnessPercentage) : 

            base(sticker, productId, 
                name, 
                cost, 
                manufCountry, 
                shelfLife)
        {
            if (fatnessPercentage <= 0)
                throw new ArgumentException("The fatness cannot be <= 0%");

            _fatnessPercentage = fatnessPercentage;
        }

        public override string ToString() => Info();
        public override string Info() => BaseInfo();

        public new string BaseInfo() =>
            $"Молочный продукт: Id = {Id}; Название = {Name}; Стоимость = {Cost}$; " +
            $"Страна-производитель = {ManufacturerCountry}; Срок годности = {ShelfLive}; " +
            $"Жирность = {FatnessPercentage}";
    }
}
