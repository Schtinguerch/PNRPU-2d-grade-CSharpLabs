using Action = UKit.Console.Action;
using UKit.Console;

namespace LaboratoryWorkNo11.Menu
{
    public class AppMenu
    {
        public void ShowMainMenu() =>
            new ConsoleMenu(new Pair<Action, string>[]
            {
                new Pair<Action, string>(ShowAddMenu, "Добавить вагон в стек"),
                new Pair<Action, string>(StackManipulator.DeleteLastCar, "Удалить последний вагон из стека"),
                new Pair<Action, string>(ShowRequestMenu, "Выполнить запрос"),
                new Pair<Action, string>(StackManipulator.PrintStack, "Вывести данные всех вагонов на экран")
            }, 0, 0).ShowMenu();

        public void ShowAddMenu() =>
            new ConsoleMenu(new Pair<Action, string>[]
            {
                new Pair<Action, string>(StackManipulator.AddLocomotive, "Добавить новый ЛОКОМОТИВ в стек"),
                new Pair<Action, string>(StackManipulator.AddKitchenCar, "Добавить новый вагон-КУХНЮ"),
                new Pair<Action, string>(StackManipulator.AddEconomClass, "Добавить новый вагон ЭКОНОМ-класса"),
                new Pair<Action, string>(StackManipulator.AddCompartmentalClass, "Добавить новый вагон с КУПЕ"),
            }).ShowMenu();

        public void ShowRequestMenu() =>
            new ConsoleMenu(new Pair<Action, string>[]
            {
                new Pair<Action, string>(StackManipulator.ShowCarCountByType, "Получить кол-во вагонов определённого типа"),
                new Pair<Action, string>(StackManipulator.ShowPassengersByCarType, "Получить кол-во пассажиров вагонов определённого типа"),
                new Pair<Action, string>(StackManipulator.ShowPowerMassCoefficient, "Получить соотношение мощности к массе\n-----"),
                new Pair<Action, string>(StackManipulator.CloneCarStack, "Клонировать стек"),
                new Pair<Action, string>(StackManipulator.SortStack, "Сортировать стек"),
                new Pair<Action, string>(StackManipulator.ShowFoundItem, "Найти вагон нужной длины")
            }).ShowMenu();
    }
}
