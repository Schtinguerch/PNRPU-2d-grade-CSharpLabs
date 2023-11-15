using System;
using UKit.Console;
using Action = UKit.Console.Action;

namespace LaboratoryWorkNo14
{
    public class AppMenu
    {
        public void ShowMenu()
        {
            var listRequests = new GenericListRequests();
            var menu = new ConsoleMenu(new[]
            {
                new Pair<Action, string>(listRequests.CreateRandomCarList, "Сформировать случайный список"),
                new Pair<Action, string>(listRequests.ShowDataSelection, "LINQ - Выборка данных"),
                new Pair<Action, string>(listRequests.ShowCountByParameter, "LINQ - подсчёт кол-во по параметрам"),
                new Pair<Action, string>(listRequests.ShowSetOperations, "LINQ - операции над множествами"),
                new Pair<Action, string>(listRequests.ShowDataAggregation, "LINQ - операции аггрегирования"),
                new Pair<Action, string>(listRequests.ShowDataGroupping, "LINQ - операции группировки"),
            }, 0);

            menu.ShowMenu();
        }
    }
}
