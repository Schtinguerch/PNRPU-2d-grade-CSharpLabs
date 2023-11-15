using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using static System.Console;

namespace LaboratoryWorkNo6
{
    public class ArrayBuilder
    {
        private const int MinRandomCount = 1;
        private const int MaxRandomCount = 12;

        private const int MinRandomValue = -100;
        private const int MaxRandomValue = 100;

        private int[] _classicArray;
        private readonly Random _random = new Random();

        public void CreateNewClassicByUserInput()
        {
            int count = ConsoleReadIntNonNegative("Кол-во элементов: ");
            CheckNaturalNumbers(count);

            if (count == 0)
            {
                WriteLine("Внимание: сформирован ПУСТОЙ массив!!!");
                _classicArray = new int[0];
            }

            var newArray = new int[count];
            for (int i = 0; i < count; i++)
                newArray[i] = ConsoleReadInt($"A[{i}]: ");

            _classicArray = newArray;
        }

        public void CreateNewClassicByRandom()
        {
            int count = _random.Next(MinRandomCount, MaxRandomCount);

            var newArray = new int[count];
            for (int i = 0; i < count; i++)
            {
                var newValue = _random.Next(MinRandomValue, MaxRandomValue);
                newArray[i] = newValue;
            }

            _classicArray = newArray;
            PrintClassic();
        }

        private void CheckNaturalNumbers(params int[] numbers)
        {
            foreach (int n in numbers)
                if (n < 0)
                    throw new ArgumentException(
                    "кол-во элементов в массиве не может быть отрицательным");
        }

        private int ConsoleReadInt(string inputMessage = "")
        {
            Write(inputMessage);
            int inputNumber;

            while (!int.TryParse(ReadLine(), out inputNumber))
                Write("\nВнимание: введённое выражение не является целым числом!\n" +
                    "Повторите попытку ввода!!!\n\n>>> ");

            return inputNumber;
        }

        private int ConsoleReadIntNonNegative(string inputMessage = "")
        {
            Write(inputMessage);
            int inputNumber = 0;

            var isSuit = false;

            while (!isSuit)
            {
                var isValid = int.TryParse(ReadLine(), out inputNumber);
                var isZeroOrMore = inputNumber >= 0;

                isSuit = isValid && isZeroOrMore;

                if (!isValid)
                    Write("\nВнимание: введённое выражение не является целым числом!\n" +
                        "Повторите попытку ввода!!!\n\n >> ");

                if (!isZeroOrMore)
                    Write("\nВнимание: количество не может быть отрицательным!\n" +
                        "Повторите попытку ввода!!!\n\n >> ");
            }

            return inputNumber;
        }

        public void FindOddSumBetweenLeftMinRightMax()
        {
            if (_classicArray == null || _classicArray.Length == 0)
            {
                WriteLine("* Массив пустой, обработка невозможна");

                ConsoleMenu.WaitForKey(ConsoleKey.Enter);
                return;
            }

            int minValue = _classicArray.Min();
            int maxValue = _classicArray.Max();

            int minFirstEntry = Array.IndexOf(_classicArray, minValue);
            int maxLastEntry = Array.LastIndexOf(_classicArray, maxValue);

            int beginIndex, lastIndex;

            if (minFirstEntry <= maxLastEntry)
            {
                beginIndex = minFirstEntry;
                lastIndex = maxLastEntry;
            }
            else
            {
                beginIndex = maxLastEntry;
                lastIndex = minFirstEntry;
            }

            int length = lastIndex - beginIndex;
            var subArray = new int[length];

            Array.Copy(_classicArray, beginIndex, subArray, 0, length);
            subArray = Array.FindAll(subArray, number => number % 2 == 0);

            int sum = subArray.Sum();

            WriteLine("Элементы массива: ");
            PrintArray(_classicArray);

            WriteLine($"Мин.  значение = {minValue}; индекс ПЕРВОГО    вхождения = {minFirstEntry}");
            WriteLine($"Макс. значение = {maxValue}; индекс ПОСЛЕДНЕГО вхождения = {maxLastEntry}\n");

            WriteLine($"Подмассив с чётными числами между индексами\nСумма элементов = {sum}:");
            PrintArray(subArray);

            ConsoleMenu.WaitForKey(ConsoleKey.Enter);
        }

        public void PrintClassic()
        {
            PrintArray(_classicArray);
            ConsoleMenu.WaitForKey(ConsoleKey.Enter);
        }

        private void PrintArray(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                WriteLine("* Массив пустой...");
                return;
            }

            WriteLine($"Кол-во элементов = {array.Length}:\n");
            for (int i = 0; i < array.Length; i++)
                WriteLine($"A[{i}] = {array[i]}");
        }
    }
}
