using System;
using System.Collections;
using System.Linq;

using Task_2_DynamicTypeIdentification;
using UKit.Console;


namespace LaboratoryWorkNo11.Menu
{
    public static partial class StackManipulator
    {
        public static void ShowCarCountByType()
        {
            int typeIndex = ChoosenTypeIndex();
            int carCount = Request.GetCarCount(new Express("", CarStack.ToList()), typeIndex);

            ConsoleMenu.Message = $"Всего кол-во вагонов типа {Request.ChooseCarType[--typeIndex].Name} = {carCount}";
        }

        public static void ShowPassengersByCarType()
        {
            int typeIndex = ChoosenTypeIndex();
            int passengerCount = Request.GetCountOfPassengers(new Express("", CarStack.ToList()), typeIndex);

            ConsoleMenu.Message = $"Всего кол-во пассажиров в вагонах типа {Request.ChooseCarType[--typeIndex].Name} = {passengerCount}";
        }

        public static void ShowPowerMassCoefficient()
        {
            double coefficient = Request.GetPowerMassCoefficient(new Express("", CarStack.ToList()));
            ConsoleMenu.Message = $"Соотношение мощности к массе = {coefficient}";
        }

        public static void CloneCarStack()
        {
            TestCarStack = new Stack(CarStack.Clone() as ICollection);
            ConsoleMenu.Message = "Стек успешно клонирован в TestCarStack";

            TestCarStack.Push(new Locomotive(9999, 9999, 9999, 9999));

            PrintCollection(TestCarStack, "Клонированный стек с изменённым верхним элементом:");
            PrintCollection(CarStack, "Основной стек с вагонами (изменения отсутствуют):");
        }

        public static void SortStack()
        {
            PrintCollection(CarStack, "Стек до сортировки:");

            var sortedCollection = CarStack.ToList().OrderBy(x => x.Length);
            CarStack = sortedCollection.ToStack();

            ConsoleMenu.Message += "\nСтек успешно отсортирован";
            PrintCollection(CarStack);
        }

        public static void ShowFoundItem()
        {
            int reqLength = UConsole.ReadInt("Требуемая длина вагона: ", 1, 20);
            var foundCars = CarStack.ToList().Where(x => x.Length == reqLength);

            if (foundCars == null || foundCars.Count() == 0)
            {
                ConsoleMenu.Message = "Вагонов с заданной длиной не найдено";
            }

            PrintCollection(foundCars, "Найденные вагоны");
        }

        private static int ChoosenTypeIndex()
        {
            var inputMesage =
                "Для какого типа вагонов необходимо произвести выборку?\n" +
                Request.CarTypeListToString() + "\n >> ";

            int chosenIndex = UConsole.ReadInt(inputMesage, 1, Request.ChooseCarType.Count);
            return chosenIndex;
        }
    }
}
