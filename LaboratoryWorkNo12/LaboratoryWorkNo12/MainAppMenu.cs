using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UKit.Console;
using Action = UKit.Console.Action;

namespace LaboratoryWorkNo12
{
    public class MainAppMenu
    {
        public void Show() => new ConsoleMenu(new[]
        {
            new Pair<Action, string>(ShowSinglyLinkedListMenu, "Односвязный список"),
            new Pair<Action, string>(ShowDoubleLinkedListMenu, "Двусзясный список"),
            new Pair<Action, string>(ShowBinaryTreeMenu, "Бинарное дерево"),
            new Pair<Action, string>(ShowMyOwnCollectionMenu, "Своя коллекция (односвязный список)"),
        }, 
        0, 0).ShowMenu();

        private void ShowSinglyLinkedListMenu() => new ConsoleMenu(new[]
        {
            new Pair<Action, string>(SingleLinkedListProcessor.CreateNewListViaUserInput, "Сформировать список вручную"),
            new Pair<Action, string>(SingleLinkedListProcessor.CreateNewListViaRandom, "Сформировать список автоматически"),
            new Pair<Action, string>(SingleLinkedListProcessor.PrintItems, "Печать элементов на экран"),
            new Pair<Action, string>(() => SingleLinkedListProcessor.DeleteViaPredicate(t => t.Mass % 2 == 0), "Удалить элементы с чётными инф. полями"),
        }).ShowMenu();

        private void ShowDoubleLinkedListMenu() => new ConsoleMenu(new[]
        {
            new Pair<Action, string>(DoubleLinkedListProcessor.CreateNewListViaUserInput, "Сформировать список вручную"),
            new Pair<Action, string>(DoubleLinkedListProcessor.CreateNewListViaRandom, "Сформировать список автоматически"),
            new Pair<Action, string>(DoubleLinkedListProcessor.PrintItems, "Печать элементов на экран"),
            new Pair<Action, string>(NotImplemented, "Добавить в список элемента с номерами 1, 3, 5..."),
        }).ShowMenu();

        private void ShowBinaryTreeMenu() => new ConsoleMenu(new[]
        {
            new Pair<Action, string>(NotImplemented, "Сформировать дерево вручную"),
            new Pair<Action, string>(NotImplemented, "Сформировать дерево автоматически"),
            new Pair<Action, string>(NotImplemented, "Печать элементов на экран"),
            new Pair<Action, string>(NotImplemented, "Найти мин. элемент в дереве"),
        }).ShowMenu();

        private void ShowMyOwnCollectionMenu() => new ConsoleMenu(new[]
        {
            new Pair<Action, string>(CollectionProcessor.SetItemsViaUserInput, "Сформировать список вручную"),
            new Pair<Action, string>(CollectionProcessor.SetItemsViaRandom, "Сформировать список автоматически"),
            new Pair<Action, string>(CollectionProcessor.Print, "Печать элементов на экран\n----"),
            new Pair<Action, string>(CollectionProcessor.AddItemsViaUserInput, "Добавить элементы в список вручную"),
            new Pair<Action, string>(CollectionProcessor.AddItemsViaRandom, "Добавить элементы в список автоматически"),
            new Pair<Action, string>(CollectionProcessor.RemoveItem, "Удалить элементы из списка"),
            new Pair<Action, string>(CollectionProcessor.CloneDemonstration, "Клонирование коллекции"),
            new Pair<Action, string>(CollectionProcessor.ShallowCopyDemonstration, "Поверхностное копирование коллекции"),
            new Pair<Action, string>(CollectionProcessor.ClearCollection, "Очистить список"),
        }).ShowMenu();

        private void NotImplemented() =>
            Console.WriteLine("Функция не реализована");
    }
}
