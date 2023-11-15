using System;

namespace Task_2_DynamicTypeIdentification
{
    public class TrainCar : IComparable, ICloneable
    {
        protected int _mass;
        protected int _length;

        public int Mass
        {
            get => _mass;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("The mass cannot be <= 0");

                _mass = value;
            }
        }

        public int Length
        {
            get => _length;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("The length cannot be <= 0");
                
                _length = value;
            }
        }

        public TrainCar(int mass, int length)
        {
            Mass = mass;
            Length = length;
        }

        public TrainCar BaseCar() =>
            new TrainCar(Mass, Length);

        public override string ToString() =>
            $"Вагон: масса = {Mass}т; длина = {Length}м";

        public int CompareTo(object obj)
        {
            var otherCar = obj as TrainCar;

            if (otherCar == null || Mass < otherCar.Mass)
                return -1;

            if (otherCar.Mass == Mass && otherCar.Length == Length)
                return 0;

            return 1;
        }

        public override bool Equals(object obj)
        {
            var otherCar = obj as TrainCar;
            if (otherCar == null)
            {
                return false;
            }

            return Mass == otherCar.Mass && Length == otherCar.Length;
        }

        public virtual object Clone() => new TrainCar(Mass, Length);
    }
}
