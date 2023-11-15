using System;
using System.Collections.Generic;

namespace Task_2_DynamicTypeIdentification
{
    public static class Request
    {
        public delegate void RequestMessageHandler(string message);
        public static event RequestMessageHandler OnRequestMessage;

        private delegate bool Condition(TrainCar car);
        private static Condition[] Conditions = new Condition[]
        {
            (car) => car is TrainCar,
            (car) => car is PassengerCar,
            (car) => car is EconomClass,
            (car) => car is CompartmentalCar,
            (car) => car is KitchenCar,
            (car) => car is Locomotive,
        };

        public static List<Type> ChooseCarType { get; set; } = new List<Type>()
        {
            typeof(TrainCar),
            typeof(PassengerCar),
            typeof(EconomClass),
            typeof(CompartmentalCar),
            typeof(KitchenCar),
            typeof(Locomotive),
        };

        public static string CarTypeListToString()
        {
            var data = "";

            for (int i = 0; i < ChooseCarType.Count; i++)
                data += $"{i + 1} {ChooseCarType[i].Name}\n";

            return data;
        }

        public static int GetCountOfPassengers(Express express, int typeIndex)
        {
            if (typeIndex < 1 || typeIndex > express.Cars.Count)
            {
                OnRequestMessage?.Invoke("Request error: Index out of range");
                return 0;
            }

            typeIndex--;

            if (ChooseCarType[typeIndex] == typeof(KitchenCar) ||
                ChooseCarType[typeIndex] == typeof(Locomotive))
            {
                OnRequestMessage?.Invoke("These types of cars doesn't contain passengers");
                return 0;
            }

            if (ChooseCarType[typeIndex] ==  typeof(TrainCar))
            {
                typeIndex++;
            }

            int passengerCount = 0;

            foreach (var car in express.Cars)
                if (Conditions[typeIndex](car))
                    passengerCount += (car as PassengerCar).PassengerCount;

            if (ChooseCarType[typeIndex] == typeof(TrainCar))
            {
                typeIndex--;
            }

            OnRequestMessage?.Invoke($"Request done: {passengerCount} found");
            return passengerCount;
        }

        public static int GetCarCount(Express express, int typeIndex)
        {
            if (typeIndex < 1 || typeIndex > express.Cars.Count)
            {
                OnRequestMessage?.Invoke("Request error: Index out of range");
                return 0;
            }

            int carCount = 0;
            typeIndex--;

            foreach (var car in express.Cars)
                if (Conditions[typeIndex](car))
                    carCount++;

            OnRequestMessage?.Invoke($"Request done: {carCount} found");
            return carCount;
        }

        public static double GetPowerMassCoefficient(Express express)
        {
            int expressMass = 0;
            int expressPower = 0;

            foreach (var car in express.Cars)
            {
                expressMass += car.Mass;

                if (car is Locomotive)
                {
                    expressPower += (car as Locomotive).EnginePower;
                }
            }

            double coefficient = (double) expressPower / expressMass;
            return coefficient;
        }
    }
}
