using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_2_DynamicTypeIdentification
{
    public class KitchenCar : TrainCar
    {
        public List<string> DishAssortiment { get; set; }

        public KitchenCar(int mass, int length, List<string> dishAssortiment) :
            base(mass, length)
        {
            DishAssortiment = dishAssortiment;
        }

        public override string ToString() =>
            $"Вагон-кухня: масса = {Mass}т; длина = {Length}м; {DishAssortimentString()}";

        protected string DishAssortimentString()
        {
            if (DishAssortiment == null || DishAssortiment.Count == 0)
            {
                return "Блюд нет...";
            }

            var data = "\nСписок блюд:  ";

            foreach (var dish in DishAssortiment)
                data += $"{dish} ";

            return data;
        }

        public override bool Equals(object obj)
        {
            var otherCar = obj as KitchenCar;
            if (otherCar == null)
            {
                return false;
            }

            return 
                Mass == otherCar.Mass && 
                Length == otherCar.Length &&
                DishAssortiment.SequenceEqual(otherCar.DishAssortiment);
        }

        public override object Clone() => new KitchenCar(Mass, Length, DishAssortiment);
    }
}
