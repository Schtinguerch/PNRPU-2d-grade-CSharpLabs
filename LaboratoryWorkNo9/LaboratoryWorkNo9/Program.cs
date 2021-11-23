using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;
using Action = UKit.Console.Action;
using UKit.Console;

namespace LaboratoryWorkNo9
{
    class Program
    {
        static void Main(string[] args) =>
            new ConsoleMenu(new Pair<Action, string>[]
            {
                new Pair<Action, string>(SingleTriangleSubmenu, "Работа с одним треугольником"),
                new Pair<Action, string>(TriangleArraySubmenu, "Работа с массивом треугольников"),
            }, 0, 0).ShowMenu();

        static void SingleTriangleSubmenu() =>
            new ConsoleMenu(new Pair<Action, string>[]
            {
                new Pair<Action, string>(TriangleManipulator.InputNewTriangle, "Ввести новый треугольник вручную"),
                new Pair<Action, string>(TriangleManipulator.NewRandomTraingle, "Сформировать новый треугольник автоматически\n"),
                new Pair<Action, string>(TriangleManipulator.PrintTriangle, "Вывести данные треугольника на экран")
            }).ShowMenu();

        static void TriangleArraySubmenu() =>
            new ConsoleMenu(new Pair<Action, string>[]
            {
                new Pair<Action, string>(TriangleManipulator.InputNewTriangleCollection, "Ввести новый массив вручную"),
                new Pair<Action, string>(TriangleManipulator.NewRandomTriangleCollection, "Сформировать новый массив автоматически\n"),
                new Pair<Action, string>(TriangleManipulator.PrintCollectionViaMethod, "Вывод массива через специальный метод"),
                new Pair<Action, string>(TriangleManipulator.PrintCollectionViaIndex, "Вывод массива через индексатор и цикл for\n"),
                new Pair<Action, string>(TriangleManipulator.PrintMinAreaTriangle, "Найти треугольник с минимальной площадью"),
            }).ShowMenu();
    }
}
