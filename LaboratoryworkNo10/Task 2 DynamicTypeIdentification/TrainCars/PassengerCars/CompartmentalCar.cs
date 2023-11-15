using System;

namespace Task_2_DynamicTypeIdentification
{
    public class CompartmentalCar : PassengerCar
    {
        public bool IncludesSoundProofing { get; set; }

        public CompartmentalCar(int mass, int length, int passengerCapacity, bool includesSoundProofing) : 
            base(mass, length, passengerCapacity)
        {
            IncludesSoundProofing = includesSoundProofing;
        }

        public override string ToString() =>
            $"Пассажирский вагон с купе: масса = {Mass}т; длина = {Length}м " +
            $"Вместимость = {PassengerCapacity}п; Кол-во пассажиров = {PassengerCount}; " +
            $"Наличие звукоизоляции = {(IncludesSoundProofing? "ЕСТЬ" : "НЕТ")}; {PassengersString()}";

        public override bool Equals(object obj)
        {
            var otherCar = obj as CompartmentalCar;
            if (otherCar == null)
            {
                return false;
            }

            return
                Mass == otherCar.Mass &&
                Length == otherCar.Length &&
                PassengerCount == otherCar.PassengerCount &&
                PassengerCapacity == otherCar.PassengerCapacity &&
                IncludesSoundProofing == otherCar.IncludesSoundProofing;
        }

        public override object Clone() => new CompartmentalCar(Mass, Length, PassengerCapacity, IncludesSoundProofing);
    }
}
