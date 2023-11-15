using LaboratoryWorkNo12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Task_2_DynamicTypeIdentification;
using UKit.Console;
using Action = UKit.Console.Action;

namespace LaboratoryWorkNo14
{
    public class GenericListRequests
    {
        const int MinValue = 1, MaxValue = 100, MaxCountValue = 12;

        private static readonly Random _random = new Random();
        private List<List<TrainCar>> _cars;

        public void CreateRandomCarList()
        {
            int itemCount = _random.Next(MinValue, MaxCountValue);
            _cars = new List<List<TrainCar>>();

            for (int i = 0; i < itemCount; i++)
            {
                int carCount = _random.Next(MinValue, MaxCountValue);
                var list = new List<TrainCar>(carCount);

                for (int j = 0; j < carCount; j++)
                {
                    list.Add(TrainCarCreator.NewRandomCar());
                }

                _cars.Add(list);
            }

            PrintList(_cars);
        }

        public void ShowDataSelection()
        {
            ConsoleMenu.Message += "Выборка данных (метод расширения):\n";

            var filteredList = _cars.Where(x => x.Count > 5).ToList();
            PrintList(filteredList);

            ConsoleMenu.Message += "Выборка данных (query language):\n";

            filteredList = (
                from cars in _cars 
                where cars.Count > 5 
                select cars)
            .ToList();

            PrintList(filteredList);
        }

        public void ShowCountByParameter()
        {
            ConsoleMenu.Message += "Подсчёт кол-ва элементов (метод расширения):\n";
            int locomotiveCount = 0;

            foreach (var carList in _cars)
            {
                locomotiveCount += carList.Count(x => x is Locomotive);
            }

            ConsoleMenu.Message += $"Кол-во локомотивов = {locomotiveCount}";


            ConsoleMenu.Message += "Подсчёт кол-ва элементов (query language):\n";
            locomotiveCount = 0;

            foreach (var carList in _cars)
            {
                locomotiveCount += (
                    from car in carList
                    where car is Locomotive
                    select car).Count();
            }

            ConsoleMenu.Message += $"Кол-во локомотивов = {locomotiveCount}";
        }

        public void ShowSetOperations()
        {
            ConsoleMenu.Message += "Операции множеств (метод расширения):\n";
            var testCars = new List<List<TrainCar>>();
            
            testCars.Add(_cars[0]);
            testCars.Add(_cars[1]);
            
            var unitedList = _cars.Union(testCars).ToList();
            var intersectedList = _cars.Intersect(testCars).ToList();
            var exceptedList = _cars.Except(testCars).ToList();
            var distinctedList = _cars.Distinct().ToList();

            ConsoleMenu.Message += "Объединение\n";
            PrintList(unitedList);

            ConsoleMenu.Message += "Пересечение\n";
            PrintList(intersectedList);

            ConsoleMenu.Message += "Исключение\n";
            PrintList(exceptedList);

            ConsoleMenu.Message += "Удаление дубликатов\n";
            PrintList(distinctedList);
            
            
            ConsoleMenu.Message += "Операции множеств (query expression):\n";
            
            //MEH no sense for that type of expressions

            unitedList = ((from car in _cars select car).Union(from car in testCars select car)).ToList();
            intersectedList = ((from car in _cars select car).Intersect(from car in testCars select car)).ToList();
            exceptedList = ((from car in _cars select car).Except(from car in testCars select car)).ToList();
            distinctedList = (from car in _cars select car ).Distinct().ToList();

            ConsoleMenu.Message += "Объединение\n";
            PrintList(unitedList);

            ConsoleMenu.Message += "Пересечение\n";
            PrintList(intersectedList);

            ConsoleMenu.Message += "Исключение\n";
            PrintList(exceptedList);

            ConsoleMenu.Message += "Удаление дубликатов\n";
            PrintList(distinctedList);

        }

        public void ShowDataAggregation()
        {
            ConsoleMenu.Message += "Аггрегирование\n";

            var maxTrain = _cars.SelectMany(c => c).Max();
            var minTrain = _cars.SelectMany(c => c).Min();
            
            ConsoleMenu.Message += $"!!!!!! Вагон с макс.значением = {maxTrain}";
            ConsoleMenu.Message += $"!!!!!! Вагон с мин. значением = {minTrain}";
        }

        public void ShowDataGroupping()
        {
            ConsoleMenu.Message += "Группировка\n";

            var groupedCars = _cars.GroupBy(c => c.Count).ToList();
            foreach (var group in groupedCars)
            {
                ConsoleMenu.Message += $"КЛЮЧ = {group.Key}:\n";
                PrintList(group.ToList());
            }
        }

        public void PrintList(List<List<TrainCar>> cars)
        {
            ConsoleMenu.Message += "Данные списка:\n";
            int index = 0;

            foreach (var list in cars)
            {
                index += 1;
                ConsoleMenu.Message += $"[{index}]:\n";

                int carIndex = 0;
                foreach (var car in list)
                {
                    carIndex += 1;
                    ConsoleMenu.Message += $"    ({carIndex}): {car}\n";
                }
            }
        }
    }
}
