﻿using System;

namespace Task_1_ClassHierarchy
{
    public class FoodProduct : Product
    {
        protected readonly string _manufCountry;
        protected readonly TimeSpan _shelfLive;

        public string ManufacturerCountry => _manufCountry;
        public TimeSpan ShelfLive => _shelfLive;

        public FoodProduct(string productId, string name, int cost, string manufCountry, TimeSpan shelfLife) : 
            base(productId, name, cost)
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