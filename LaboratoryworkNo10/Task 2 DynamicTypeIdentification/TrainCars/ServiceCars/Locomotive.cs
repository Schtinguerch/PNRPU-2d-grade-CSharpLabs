using System;

namespace Task_2_DynamicTypeIdentification
{
    public class Locomotive : TrainCar
    {
        protected int _enginePower;
        protected int _maxSpeed;

        public int EnginePower
        {
            get => _enginePower;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("The engine power cannot be <= 0");

                _enginePower = value;
            }
        }

        public int MaxSpeed
        {
            get => _maxSpeed;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("The max speed cannot be <= 0");

                _maxSpeed = value;
            }
        }

        public Locomotive(int mass, int length, int enginePower, int maxSpeed) : 
            base(mass, length)
        {
            MaxSpeed = maxSpeed;
            EnginePower = enginePower;
        }

        public override string ToString() =>
            $"Локомотив: масса = {Mass}т; длина = {Length}м; мощность " +
            $"двигателя = {EnginePower}л/с; макс. скорость = {MaxSpeed}км/ч";

        public override bool Equals(object obj)
        {
            var otherCar = obj as Locomotive;
            if (otherCar == null)
            {
                return false;
            }

            return 
                Mass == otherCar.Mass && 
                Length == otherCar.Length &&
                EnginePower == otherCar.EnginePower &&
                MaxSpeed == otherCar.MaxSpeed;
        }

        public override object Clone() => new Locomotive(Mass, Length, EnginePower, MaxSpeed);
    }
}
