﻿using System;
using System.Collections.Generic;
using System.Linq;

using Task_2_DynamicTypeIdentification;
using UKit.Console;

namespace LaboratoryWorkNo11.Menu
{
    public static partial class StackManipulator
    {
        public static SortedDictionary<string, TrainCar> CarStack = new SortedDictionary<string, TrainCar>();
        public static SortedDictionary<string, TrainCar> TestCarStack = new SortedDictionary<string, TrainCar>();

        public static void PrintStack()
        {
            if (CarStack == null || CarStack.Count == 0)
            {
                ConsoleMenu.Message = "* Стек пуст *";
                return;
            }
            
            foreach (var car in CarStack)
            {
                ConsoleMenu.Message += '\n' + car.ToString();
            }
        }

        private static void PrintCollection(SortedDictionary<string, TrainCar> stack, string message = "")
        {
            if (!string.IsNullOrWhiteSpace(message))
                ConsoleMenu.Message += '\n' + message + '\n';

            foreach (var car in stack)
            {
                ConsoleMenu.Message += '\n' + car.ToString();
            }
        }

        public static void AddLocomotive()
        {
            CarStack.Push(TrainCarCreator.NewUserInputLocomotive());
            ConsoleMenu.Message = "Локомотив успешно добавлен";
        }

        public static void AddKitchenCar()
        {
            CarStack.Push(TrainCarCreator.NewUserKitchenCar());
            ConsoleMenu.Message = "Кухня успешно добавлена";
        }

        public static void AddEconomClass()
        {
            CarStack.Push(TrainCarCreator.NewUserEconomClassCar());
            ConsoleMenu.Message = "Вагон эконом-класса успешно добавлен";
        }

        public static void AddCompartmentalClass()
        {
            CarStack.Push(TrainCarCreator.NewUserCompartmentalClassCar());
            ConsoleMenu.Message = "Вагон с купе успешно добавлен";
        }

        public static void DeleteLastCar()
        {
            if (CarStack.Count == 0)
            {
                ConsoleMenu.Message = "Стек пуст -> удалять нечего";
                return;
            }

            var deletedItem = CarStack.Pop();
            ConsoleMenu.Message = $"Вагон удалён: {deletedItem}";
        }
    }
}