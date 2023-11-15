using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWorkNo5
{
    class Program
    {
        const int ExitCode = 0;

        static readonly ArrayBuilder ArrayBuilder = new ArrayBuilder();

        static void Main(string[] args)
        {
            var actions = new Pair<Action, string>[]
            {
                new Pair<Action, string>(
                    StartWorkingWithClassicArrays, 
                    "Работа с одномерными массивами"),

                new Pair<Action, string>(
                    StartWorkingWithTwoDimArrays, 
                    "Работа с двумерными массивами"),

                new Pair<Action, string>(
                    StartWorkingWithRaggedArrays, 
                    "Работа с рваными массивами"),
            };

            var mainMenu = new ConsoleMenu(actions, 0, 0);
            mainMenu.ShowMenu();
        }

        static void StartWorkingWithClassicArrays()
        {
            var actions = new Pair<Action, string>[]
            {
                new Pair<Action, string>(
                    ArrayBuilder.CreateNewClassicByUserInput, 
                    "Сформировать новый массив вручную"),

                new Pair<Action, string>(
                    ArrayBuilder.CreateNewClassicByRandom, 
                    "Сформировать новый массив случайным образом"),

                new Pair<Action, string>(
                    ArrayBuilder.DeleteNotEvenIndexFromClassic, 
                    "Удалить все элементы с нечётным индексом"),

                new Pair<Action, string>(
                    ArrayBuilder.PrintClassic, 
                    "Вывести элементы массива на экран"),
            };

            var menu = new ConsoleMenu(actions);
            menu.ShowMenu();
        }

        static void StartWorkingWithTwoDimArrays()
        {
            var actions = new Pair<Action, string>[]
            {
                new Pair<Action, string>(
                    ArrayBuilder.CreateNewTwoDimensionalByUserInput, 
                    "Сформировать новый двумерный массив вручную"),

                new Pair<Action, string>(
                    ArrayBuilder.CreateNewTwoDimensionalByRandom, 
                    "Сформировать новый двумерный массив случайным образом"),

                new Pair<Action, string>(
                    ArrayBuilder.AddNewColumnAfterMaxValueToTwoDimension, 
                    "Добавить новый столбец после столбца с максимальным значением"),

                new Pair<Action, string>(
                    ArrayBuilder.PrintTwoDimensional, 
                    "Вывести элементы массива на экран"),
            };

            var menu = new ConsoleMenu(actions);
            menu.ShowMenu();
        }

        static void StartWorkingWithRaggedArrays()
        {
            var actions = new Pair<Action, string>[]
            {
                new Pair<Action, string>(
                    ArrayBuilder.CreateNewRaggedByUserInput, 
                    "Сформировать новый рваный массив вручную"),

                new Pair<Action, string>(
                    ArrayBuilder.CreateNewRaggedByRandom, 
                    "Сформировать новый рваный массив случайным образом"),

                new Pair<Action, string>(
                    ArrayBuilder.AddNewRowToRagged, 
                    "Добавить новую строку к текущему рваному массиву"),

                new Pair<Action, string>(
                    ArrayBuilder.PrintRagged, 
                    "Вывести элементы массива на экран"),
            };

            var menu = new ConsoleMenu(actions);
            menu.ShowMenu();
        }
    }
}
