using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task_2_DynamicTypeIdentification;
using UKit.Console;
using static System.Console;
using Action = System.Action;

namespace LaboratoryWorkNo12
{
    public static class CollectionProcessor
    {
        private static MyOwnLinkedList<TrainCar> _carList = new MyOwnLinkedList<TrainCar>();
        private static readonly Random _random = new Random();

        public static void SetItemsViaUserInput()
        {
            _carList.Clear();
            AddItemsViaUserInput();
        }

        public static void SetItemsViaRandom()
        {
            _carList.Clear();
            AddItemsViaRandom();
        }

        public static void AddItemsViaUserInput()
        {
            int itemCount = UConsole.ReadInt("Кол-во вагонов: ", 1, 10);

            var addAction = new Action(() => _carList.Add(TrainCarCreator.NewUserCar()));
            addAction.Repeat(itemCount);
        }

        public static void AddItemsViaRandom()
        {
            int itemCount = _random.Next(2, 10);

            var addAction = new Action(() => _carList.Add(TrainCarCreator.NewRandomCar()));
            addAction.Repeat(itemCount);
        }

        public static void Print()
        {
            Print(_carList);
        }

        public static void Print(MyOwnLinkedList<TrainCar> list)
        {
            if (list.Count == 0)
            {
                ConsoleMenu.Message += "* Список пустой *\n";
                return;
            }

            foreach (var car in list)
            {
                ConsoleMenu.Message += $"{car}\n";
            }
        }

        public static void ClearCollection()
        {
            _carList.Clear();
        }

        public static void RemoveItem()
        {
            int chosenIndex = UConsole.ReadInt("Введите номер вагона, который требуется удалить", 1, _carList.Count) - 1;
            _carList.Remove(_carList[chosenIndex]);

            Print();
        }

        public static void CloneDemonstration()
        {
            var clonedlist = _carList.Clone() as MyOwnLinkedList<TrainCar>;
            foreach (var car in clonedlist)
            {
                car.Mass += 1000;
                car.Length += 1000;
            }

            ConsoleMenu.Message += "\nКлонированный изменённый список\n";
            Print(clonedlist);

            ConsoleMenu.Message += "\nБазовый список\n";
            Print();
        }

        public static void ShallowCopyDemonstration()
        {
            var clonedlist = _carList.ShallowCopy() as MyOwnLinkedList<TrainCar>;
            foreach (var car in clonedlist)
            {
                car.Mass += 1000;
                car.Length += 1000;
            }

            ConsoleMenu.Message += "Клонированный изменённый список\n";
            Print(clonedlist);

            ConsoleMenu.Message += "Базовый список\n";
            Print();
        }
    }
}
