using System;
using System.Collections.Generic;

using UKit.Console;
using static System.Console;
using Action = UKit.Console.Action;

namespace Task_2_DynamicTypeIdentification
{
    internal class Program
    {
        private static Express _express = new Express("SchtMaschin", new List<TrainCar>()
        {
            new Locomotive(
                mass: 3,
                length: 8,
                enginePower: 2000,
                maxSpeed: 60),

            new Locomotive(
                mass: 4,
                length: 9,
                enginePower: 3100,
                maxSpeed: 70),

            new KitchenCar(
                mass: 7,
                length: 10,
                dishAssortiment: new List<string>
                {
                    "Стейк",
                    "Паста",
                    "Салат",
                    "Кальмар",
                }),

            new EconomClass(
                mass: 6,
                length: 10,
                passengerCapacity: 100,
                levelCount: 2),

            new EconomClass(
                mass: 5,
                length: 10,
                passengerCapacity: 80,
                levelCount: 2),

            new CompartmentalCar(
                mass: 8,
                length: 10,
                passengerCapacity: 80,
                includesSoundProofing: true),
        });

        static void Main(string[] args)
        {
            (_express.Cars[3] as PassengerCar).AddPassengers("Николай", "Лев", "Илья", "Вика", "Азат");
            (_express.Cars[4] as PassengerCar).AddPassengers("Марат", "Сармат", "Вардеат", "Байшат");
            (_express.Cars[5] as PassengerCar).AddPassengers("Август", "Александр", "Анна");

            WriteLine(_express.ToString());
            ConsoleMenu.WaitForKey(ConsoleKey.Enter);

            new ConsoleMenu(new Pair<Action, string>[]
            {
                new Pair<Action, string>(PerformFirstRequest,
                    "Запрос №1: получить кол-во пассажиров"),

                new Pair<Action, string>(PerformSecondRequest,
                    "Запрос №2: почулить кол-во вагонов"),

                new Pair<Action, string>(PerformThirdRequest,
                    "Запрос №3: получить отношение мощности к массе"),

                new Pair<Action, string>(PrintAllCars,
                    "Печать всех вагонов на экран"),

            }, 0, 0).ShowMenu();
        }
       
        static int ChoosenTypeIndex()
        {
            var inputMesage =
                "Для какого типа вагонов необходимо произвести выборку?\n" +
                Request.CarTypeListToString() + "\n >> ";

            int chosenIndex = UConsole.ReadInt(inputMesage, 1, Request.ChooseCarType.Count);
            return chosenIndex;
        }


        static void PrintAllCars()
        {
            WriteLine(_express.ToString());
            ConsoleMenu.WaitForKey(ConsoleKey.Enter);
        }
            

        static void PerformFirstRequest()
        {
            int passengerCount = Request.GetCountOfPassengers(_express, ChoosenTypeIndex());
            WriteLine($"Кол-во пассажиров = {passengerCount}");

            ConsoleMenu.WaitForKey(ConsoleKey.Enter);
        }

        static void PerformSecondRequest()
        {
            int passengerCount = Request.GetCarCount(_express, ChoosenTypeIndex());
            WriteLine($"Кол-во вагонов = {passengerCount}");

            ConsoleMenu.WaitForKey(ConsoleKey.Enter);
        }

        static void PerformThirdRequest()
        {
            double coefficient = Request.GetPowerMassCoefficient(_express);
            WriteLine($"Соотношение мощности к массе = {coefficient}");

            ConsoleMenu.WaitForKey(ConsoleKey.Enter);
        }
    }
}
