using System;

namespace Task_2_DynamicTypeIdentification
{
    public class EconomClass : PassengerCar
    {
        protected int _levelCount;

        public int LevelCount
        {
            get => _levelCount;
            set
            {
                if (value <= 0 || value > 3)
                    throw new ArgumentException("It's unreal car");

                _levelCount = value;
            }
        }

        public EconomClass(int mass, int length, int passengerCapacity, int levelCount) : 
            base(mass, length, passengerCapacity)
        {
            LevelCount = levelCount;
        }

        public override string ToString() =>
            $"Пассажирский вагон эконом-класа: масса = {Mass}т; длина = {Length}м " +
            $"Вместимость = {PassengerCapacity}п; Кол-во пассажиров = {PassengerCount}; " + 
            $"кол-во ярусов = {LevelCount}; {PassengersString()}";

        public override bool Equals(object obj)
        {
            var otherCar = obj as EconomClass;
            if (otherCar == null)
            {
                return false;
            }

            return 
                Mass == otherCar.Mass && 
                Length == otherCar.Length &&
                PassengerCount == otherCar.PassengerCount &&
                PassengerCapacity == otherCar.PassengerCapacity &&
                LevelCount == otherCar.LevelCount;
        }

        public override object Clone() => new EconomClass(Mass, Length, PassengerCapacity, LevelCount);
    }
}
