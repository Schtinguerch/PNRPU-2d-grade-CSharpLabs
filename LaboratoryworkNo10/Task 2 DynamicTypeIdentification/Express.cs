using System;
using System.Collections.Generic;

namespace Task_2_DynamicTypeIdentification
{
    public class Express
    {
        public string Name { get; set; }

        public bool AbleToUsing
        {
            get
            {
                var containsLocomotive = false;
                var containsPassengerCar = false;
                var containsKitchenCar = false;

                if (Cars == null || Cars.Count == 0)
                    return false;

                foreach (var car in Cars)
                {
                    if (car is Locomotive)
                    {
                        containsLocomotive = true;
                        continue;
                    }
                        
                    if (car is PassengerCar)
                    {
                        containsPassengerCar = true;
                        continue;
                    }

                    if (car is KitchenCar)
                    {
                        containsKitchenCar = true;
                        continue;
                    }
                }

                return containsLocomotive &&
                    containsPassengerCar &&
                    containsKitchenCar;
            }
        }

        public int PassengerCount
        {
            get
            {
                if (Cars == null || Cars.Count == 0)
                    return 0;

                int passengerCount = 0;

                foreach (var car in Cars)
                    if (car is PassengerCar)
                        passengerCount += (car as PassengerCar).PassengerCount;

                return passengerCount;
            }
        }

        public List<TrainCar> Cars { get; set; }

        public Express(string name, List<TrainCar> cars)
        {
            Name = name;
            Cars = cars;
        }

        public override string ToString()
        {
            var data = $"Экспресс \"{Name}\":\n";
            data += (AbleToUsing ? "МОЖЕТ" : "НЕ МОЖЕТ") + " выйти на рейс.\n";
            
            if (Cars == null || Cars.Count == 0)
            {
                data += "Вагоны отсутствуют...";
                return data;
            }

            data += "Список вагонов:\n\n";

            foreach (var car in Cars)
            {
                data += $"{car}\n\n";
            }

            data += $"\nВсего пассажиров = {PassengerCount}";
            return data;
        }
    }
}
