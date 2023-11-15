using System;
using System.Collections.Generic;

namespace Task_2_DynamicTypeIdentification
{
    public abstract class PassengerCar : TrainCar
    {
        protected int _passengerCapacity;
        protected List<string> _passengers;

        public List<string> Passengers => _passengers;

        public int PassengerCapacity
        {
            get => _passengerCapacity;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("The passenger-car cannot has to contain passengers");

                _passengerCapacity = value;
            }
        }

        public int PassengerCount => _passengers.Count;

        public PassengerCar(int mass, int length, int passengerCapacity) : base(mass, length)
        {
            PassengerCapacity = passengerCapacity;
            _passengers = new List<string>();
        }

        public void AddPassengers(params string[] passengers)
        {
            if (passengers.Length + _passengers.Count > _passengerCapacity)
                throw new ArgumentOutOfRangeException("The car cannot load so many people");

            foreach (var passenger in passengers)
                _passengers.Add(passenger);
        }

        public override string ToString() =>
            $"Пассажирский вагон: масса = {Mass}т; длина = {Length}м " + 
            $"Вместимость = {PassengerCapacity}п; Кол-во пассажиров = {PassengerCount}; {PassengersString()}";

        protected string PassengersString()
        {
            if (_passengers == null || _passengers.Count == 0)
            {
                return "пассажиров нет...";
            }

            var data = "\nСписок пассажиров:  ";

            foreach (var dish in _passengers)
                data += $"{dish} ";

            return data;
        }

        public override bool Equals(object obj)
        {
            var otherCar = obj as PassengerCar;
            if (otherCar == null)
            {
                return false;
            }

            return 
                Mass == otherCar.Mass && 
                Length == otherCar.Length && 
                PassengerCapacity == otherCar.PassengerCapacity && 
                PassengerCount == otherCar.PassengerCount;
        }
    }
}
