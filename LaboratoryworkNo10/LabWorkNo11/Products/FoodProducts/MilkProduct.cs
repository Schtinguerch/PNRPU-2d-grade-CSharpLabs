using System;

namespace Task_1_ClassHierarchy
{
    public class MilkProduct : FoodProduct
    {
        protected readonly double _fatnessPercentage;

        public double FatnessPercentage => _fatnessPercentage;

        public MilkProduct(string productId, 
            string name, 
            int cost, 
            string manufCountry, 
            TimeSpan shelfLife, 
            double fatnessPercentage) : 

            base(productId, 
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
