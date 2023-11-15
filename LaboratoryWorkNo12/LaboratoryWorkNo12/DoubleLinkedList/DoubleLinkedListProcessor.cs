﻿using System;
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
    public class DoubleLinkedListProcessor
    {
        private static DoubleLinkedListNode _firstNode;
        private static DoubleLinkedListNode _lastNode;

        private static readonly Random _random = new Random();

        public static void AddItem(TrainCar item)
        {
            if (_firstNode == null)
            {
                _firstNode = new DoubleLinkedListNode(item);
                _lastNode = _firstNode;
                return;
            }

            var newNode = new DoubleLinkedListNode(item);
            _lastNode.Next = newNode;

            newNode.Previous = _lastNode;
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
    }
}
