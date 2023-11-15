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
    public static class SingleLinkedListProcessor
    {
        private static SingleLinkedNode _firstNode;
        private static SingleLinkedNode _lastNode;

        private static readonly Random _random = new Random();

        public static void AddItem(TrainCar item)
        {
            if (_firstNode == null)
            {
                _firstNode = new SingleLinkedNode(item);
                _lastNode = _firstNode;
                return;
            }

            _lastNode.Next = new SingleLinkedNode(item);
            _lastNode = _lastNode.Next;
        }

        public static void ClearList()
        {
            _firstNode = null;
            _lastNode = null;
        }

        public static void CreateNewListViaUserInput()
        {
            ClearList();
            int itemCount = UConsole.ReadInt("Кол-во вагонов: ", 1, 10);

            var addAction = new Action(() => AddItem(TrainCarCreator.NewUserCar()));
            addAction.Repeat(itemCount);
        }

        public static void CreateNewListViaRandom()
        {
            ClearList();
            int itemCount = _random.Next(2, 10);

            var addAction = new Action(() => AddItem(TrainCarCreator.NewRandomCar()));
            addAction.Repeat(itemCount);
        }

        public static void PrintItems()
        {
            if (_firstNode == null)
            {
                ConsoleMenu.Message = "*** Список пустой ***";
                return;
            }

            var pointer = _firstNode;
            while (pointer != null)
            {
                ConsoleMenu.Message += $"{pointer.Value}\n";
                pointer = pointer.Next;
            }
        }

        public static void DeleteViaPredicate(Predicate<TrainCar> predicate)
        {
            if (_firstNode == null)
            {
                ConsoleMenu.Message = "*** Список пустой ***";
                return;
            }

            if (_firstNode == _lastNode) 
            {
                if (predicate(_firstNode.Value)) ClearList();
                return;
            }

            var current = _firstNode.Next;
            var previous = _firstNode;

            while (true)
            {
                while (current != null && predicate(current.Value))
                {
                    ConsoleMenu.Message += $"Удалено: {current.Value}\n";

                    current = current.Next;
                    previous.Next = current;
                }

                if (current == null)
                {
                    break;
                }

                previous = current;
                current = current.Next;
            }

            if (predicate(_firstNode.Value))
            {
                if (_firstNode.Next != null)
                {
                    _firstNode = _firstNode.Next;
                }
                else
                {
                    ClearList();
                }
            }
        }
    }
}
