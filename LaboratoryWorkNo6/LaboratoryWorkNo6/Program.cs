using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace LaboratoryWorkNo6
{
    class Program
    {
        static readonly ArrayBuilder ArrayBuilder = new ArrayBuilder();
        static readonly TextBuilder TextBuilder = new TextBuilder();

        static void Main(string[] args)
        {
            var actions = new Pair<Action, string>[]
            {
                new Pair<Action, string>(WorkWithArray, "Работа с массивом"),
                new Pair<Action, string>(WorkWithString, "Работа со строкой"),
            };

            var mainMenu = new ConsoleMenu(actions, 0, 0);
            mainMenu.ShowMenu();
        }

        static void WorkWithArray()
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
                    ArrayBuilder.FindOddSumBetweenLeftMinRightMax,
                    "Найти сумму всех чётных элементов, которые находятся\n" + 
                    "   * между первым минимальным элементом и последним\n" + 
                    "   * максимальным элементом массива"),

                new Pair<Action, string>(
                    ArrayBuilder.PrintClassic,
                    "Вывести элементы массива на экран"),
            };

            var menu = new ConsoleMenu(actions);
            menu.ShowMenu();
        }

        static void WorkWithString()
        {
            var actions = new Pair<Action, string>[]
            {
                new Pair<Action, string>(
                    TextBuilder.CreateNewTextByUserInput,
                    "Сформировать новую строку вручную"),

                new Pair<Action, string>(
                    TextBuilder.CreateNewTextByRandom,
                    "Сформировать новую строку случайным образом"),

                new Pair<Action, string>(
                    TextBuilder.DeleteWordsWhichBeginAndEndSameChar,
                    "Удалить из строки все слова, которые начинаются и\n" +
                    "   * заканчиваются на один и тот же символ"),

                new Pair<Action, string>(
                    TextBuilder.PrintText,
                    "Вывести текст на экран"),
            };

            var menu = new ConsoleMenu(actions);
            menu.ShowMenu();
        }
    }
}
