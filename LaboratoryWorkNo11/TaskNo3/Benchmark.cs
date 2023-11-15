using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using static System.Console;
using Task_2_DynamicTypeIdentification;

namespace TaskNo3
{
    public class Benchmark
    {
        public TestCollection TestCollection { get; set; }

        public Benchmark(TestCollection testCollection)
        {
            if (testCollection == null)
                throw new ArgumentNullException(nameof(testCollection));

            TestCollection = testCollection;
        }

        public void Start()
        {
            WriteLine("Запуск бенчмарка...");

            var searchingStrings = new string[]
            {
                TestCollection.TestStack.First(),
                TestCollection.TestStack.ElementAt(TestCollection.TestStack.Count / 2),
                TestCollection.TestStack.Last(),
                new KitchenCar(2000000000, 2000000000, new List<string>() { "Курица", "Плов" }).ToString(),
            };

            var searchingCars = new TrainCar[]
            {
                TestCollection.TestCarStack.First(),
                TestCollection.TestCarStack.ElementAt(TestCollection.TestStack.Count / 2),
                TestCollection.TestCarStack.Last(),
                new KitchenCar(2000000000, 2000000000, new List<string>() { "Курица", "Плов" }),
            };

            var sortedSearchingStringKeys = new string[]
            {
                TestCollection.TestDictionary.First().Key,
                TestCollection.TestDictionary.Last().Key,
                TestCollection.TestDictionary.ElementAt(TestCollection.TestStack.Count / 2).Key,
                new KitchenCar(2000000000, 2000000000, new List<string>() { "Курица", "Плов" }).ToString(),
            };

            var sortedSearchingCarKeys = new TrainCar[]
            {
                TestCollection.TestCarDictionary.First().Key,
                TestCollection.TestCarDictionary.Last().Key,
                TestCollection.TestCarDictionary.ElementAt(TestCollection.TestStack.Count / 2).Key,
                new KitchenCar(2000000000, 2000000000, new List<string>() { "Курица", "Плов" }),
            };

            var timeTable = new List<List<long>>();

            timeTable.Add(ExecutionTimes(TestCollection.TestStack, searchingStrings));
            timeTable.Add(ExecutionTimes(TestCollection.TestCarStack, searchingCars));

            timeTable.Add(ExecutionTimes(TestCollection.TestDictionary, sortedSearchingStringKeys));
            timeTable.Add(ExecutionTimes(TestCollection.TestCarDictionary, sortedSearchingCarKeys));

            WriteLine("Замеры завершены:");
            WriteLine(ResultTable(timeTable, new List<string>()
            {
                "Stack<string>",
                "Stack<TrainCar>",
                "SortedDictionary<string, TrainCar>",
                "SortedDictionary<TrainCar, TrainCar>",
            }));
        }

        private string ResultTable(List<List<long>> results, List<string> collectionNames)
        {
            for (int i = 0; i < collectionNames.Count; i++)
            {
                collectionNames[i] = AddSpaces(collectionNames[i], 40);
            }

            string outputTable = $"{Multiply("-", 152)}\n";

            outputTable += $"| {AddSpaces("Коллекция", 40)} |"
                + $" {AddSpaces("Первый элемент", 24)} |"
                + $" {AddSpaces("Центральный элемент", 24)} |"
                + $" {AddSpaces("Последний элемент", 24)} |"
                + $" {AddSpaces("Несуществующий элемент", 24)} |\n";

            outputTable += $"{Multiply("=", 152)}\n";

            for (int i = 0; i < results.Count; i++)
            {
                outputTable += $"| {AddSpaces(collectionNames[i], 40)} |";
                for (int j = 0; j < results[i].Count; j++)
                {
                    outputTable += $" {AddSpaces(results[i][j].ToString(), 24)} |";
                }
                outputTable += $"\n{Multiply("-", 152)}\n";
            }

            return outputTable;
        }

        private string AddSpaces(string data, int length)
        {
            while (data.Length < length)
                data += " ";

            return data;
        }

        private string Multiply(string baseString, int count)
        {
            var multiplued = baseString;

            for (int i = 1; i < count; i++)
                baseString += multiplued;

            return baseString;
        }

        private List<long> ExecutionTimes<T>(Stack<T> collection, T[] searchingItems)
        {
            var timeList = new List<long>();
            var stopwatch = new Stopwatch();

            bool hasItem;

            foreach (var item in searchingItems)
            {
                stopwatch.Restart();
                hasItem = collection.Contains(item);

                stopwatch.Stop();
                timeList.Add(stopwatch.ElapsedTicks);
            }

            return timeList;
        }

        private List<long> ExecutionTimes<TKey, TValue>(SortedDictionary<TKey, TValue> dictionary, TKey[] searchingItems)
        {
            var timeList = new List<long>();
            var stopwatch = new Stopwatch();

            bool hasItem;

            foreach (var item in searchingItems)
            {
                stopwatch.Restart();
                hasItem = dictionary.ContainsKey(item);

                stopwatch.Stop();
                timeList.Add(stopwatch.ElapsedTicks);
            }

            return timeList;
        }
    }
}
