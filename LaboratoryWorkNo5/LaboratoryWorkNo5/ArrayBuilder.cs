using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace LaboratoryWorkNo5
{
    public class ArrayBuilder
    {
        private const int MinRandomCount = 1;
        private const int MaxRandomCount = 12;

        private const int MinRandomValue = -100;
        private const int MaxRandomValue = 100;

        private int[] _classicArray;
        private int[,] _twoDimensionalArray;
        private int[][] _raggedArray;

        private static readonly Random _random = new Random();

        private void WaitForKey(ConsoleKey key)
        {
            WriteLine();
            do
            {
                WriteLine($"Нажмите {key}, чтобы продолжить");
            }
            while (ReadKey(true).Key != key);
        }

        private void CheckNaturalNumbers(params int[] numbers)
        {
            foreach (int n in numbers)
            {
                if (n < 0)
                {
                    throw new ArgumentException(
                    "кол-во элементов в массиве не может быть отрицательным");
                }
            }
        }

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

        public void PrintClassic()
        {
            if (_classicArray == null || _classicArray.Length == 0)
            {
                WriteLine("* Массив пустой...");
                WaitForKey(ConsoleKey.Enter);
                return;
            }

            WriteLine($"Кол-во элементов = {_classicArray.Length}:\n");
            for (int i = 0; i < _classicArray.Length; i++)
                WriteLine($"A[{i + 1}] = {_classicArray[i]}");

            WaitForKey(ConsoleKey.Enter);
        }

        public void CreateNewTwoDimensionalByUserInput()
        {
            int rowCount = ConsoleReadIntNonNegative($"Кол-во строк: ");
            int columnCount = ConsoleReadIntNonNegative($"Кол-во столбцов: ");

            CheckNaturalNumbers(rowCount, columnCount);
            if (rowCount == 0 || columnCount == 0)
            {
                WriteLine("Внимание: сформирован ПУСТОЙ массив!!!");
                _twoDimensionalArray = new int[0, 0];
            }

            var newArray = new int[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                    newArray[i, j] = ConsoleReadInt($"A[{i}, {j}]: ");

                WriteLine();
            }

            _twoDimensionalArray = newArray;
        }

        public void CreateNewTwoDimensionalByRandom()
        {
            int rowCount = _random.Next(MinRandomCount, MaxRandomCount);
            int columnCount = _random.Next(MinRandomCount, MaxRandomCount);

            var newArray = new int[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    var newValue = _random.Next(MinRandomValue, MaxRandomValue);
                    newArray[i, j] = newValue;
                }
            }

            _twoDimensionalArray = newArray;
            PrintTwoDimensional();
        }

        public void PrintTwoDimensional()
        {
            if (_twoDimensionalArray == null || _twoDimensionalArray.Length == 0)
            {
                WriteLine("* Массив пустой...");
                WaitForKey(ConsoleKey.Enter);
                return;
            }

            WriteLine($"Кол-во элементов = {_twoDimensionalArray.Length}:\n");
            WriteLine($"Кол-во строк     = {_twoDimensionalArray.GetLength(0)}");
            WriteLine($"Кол-во столбцов  = {_twoDimensionalArray.GetLength(1)}\n");
            
            for (int i = 0; i < _twoDimensionalArray.GetLength(0); i++)
            {
                var outputLine = "";

                for (int j = 0; j < _twoDimensionalArray.GetLength(1); j++)
                    outputLine += $"{_twoDimensionalArray[i, j]}\t";

                WriteLine(outputLine);
            }

            WaitForKey(ConsoleKey.Enter);
        }

        public void CreateNewRaggedByUserInput()
        {
            int rowCount = ConsoleReadIntNonNegative($"Кол-во подмассивов рваного массива: ");
            CheckNaturalNumbers(rowCount);

            if (rowCount == 0)
            {
                WriteLine("Внимание: сформирован ПУСТОЙ массив!!!");
                _raggedArray = new int[0][];
            }

            var newArray = new int[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                var itemCount = ConsoleReadIntNonNegative($"Кол-во элементов подмассива: ");
                CheckNaturalNumbers(itemCount);

                newArray[i] = new int[itemCount];

                for (int j = 0; j < itemCount; j++)
                    newArray[i][j] = ConsoleReadInt($"A[{i}][{j}]: ");

                WriteLine();
            }

            _raggedArray = newArray;
        }

        public void CreateNewRaggedByRandom()
        {
            int rowCount = _random.Next(MinRandomCount, MaxRandomCount);
            var newArray = new int[rowCount][];

            for (int i = 0; i < rowCount; i++)
            {
                var itemCount = _random.Next(MinRandomCount, MaxRandomCount);
                newArray[i] = new int[itemCount];

                for (int j = 0; j < itemCount; j++)
                {
                    int newValue = _random.Next(MinRandomValue, MaxRandomValue);
                    newArray[i][j] = newValue;
                }
            }

            _raggedArray = newArray;
            PrintRagged();
        }

        public void PrintRagged()
        {
            if (_raggedArray == null || _raggedArray.Length == 0)
            {
                WriteLine("* Массив пустой...");
                WaitForKey(ConsoleKey.Enter);
                return;
            }

            WriteLine($"Кол-во подмассивов = {_raggedArray.Length}\n");

            for (int i = 0; i < _raggedArray.Length; i++)
            {
                Write($"Элементов = {_raggedArray[i].Length}:    ");
                var outputline = "";

                for (int j = 0; j < _raggedArray[i].Length; j++)
                    outputline += $"{_raggedArray[i][j]}\t";

                WriteLine(outputline);
            }

            WaitForKey(ConsoleKey.Enter);
        }

        public void DeleteNotEvenIndexFromClassic()
        {
            if (_classicArray == null || _classicArray.Length == 0)
            {
                WriteLine("Массив пустой, извлечь элементы невозможно!!!");
                WaitForKey(ConsoleKey.Enter);
                return;
            }

            WriteLine("\nДо:");
            PrintClassic();

            var evenIndexArray = new int[_classicArray.Length / 2];
            int lastIndex = -1;
           
            for (int i = 0; i < _classicArray.Length; i++)
                if ((i + 1) % 2 == 0)
                    evenIndexArray[++lastIndex] = _classicArray[i];

            _classicArray = evenIndexArray;
            WriteLine("\nПосле:");
            PrintClassic();
        }

        public void AddNewColumnAfterMaxValueToTwoDimension()
        {
            if (_twoDimensionalArray == null || _twoDimensionalArray.Length == 0)
            {
                WriteLine("Массив пустой, найти максимальное значение невозможно!!!");
                WaitForKey(ConsoleKey.Enter);
                return;
            }
            WriteLine("\nДо:");
            PrintTwoDimensional();

            int maxValue = _twoDimensionalArray[0, 0];
            int maxValueColumn = 0;

            int rowCount = _twoDimensionalArray.GetLength(0);
            int columnCount = _twoDimensionalArray.GetLength(1);

            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < columnCount; j++)
                    if (_twoDimensionalArray[i, j] > maxValue)
                    {
                        maxValue = _twoDimensionalArray[i, j];
                        maxValueColumn = j;

                        WriteLine($"Новый элемент с мaкс-значением: столбец {maxValueColumn + 1}; x = {maxValue}");
                    }

            var biggerTwoDimensionArray = new int[rowCount, ++columnCount];
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < maxValueColumn + 1; j++)
                    biggerTwoDimensionArray[i, j] = _twoDimensionalArray[i, j];

                biggerTwoDimensionArray[i, maxValueColumn + 1] = _random.Next(MinRandomValue, MaxRandomValue);

                for (int j = maxValueColumn + 2; j < columnCount; j++)
                    biggerTwoDimensionArray[i, j] = _twoDimensionalArray[i, j - 1];
            }

            _twoDimensionalArray = biggerTwoDimensionArray;

            WriteLine("\nПосле:");
            PrintTwoDimensional();
        }

        public void AddNewRowToRagged()
        {
            if (_raggedArray == null)
            {
                _raggedArray = new int[1][];
                int count = _random.Next(MinRandomCount, MaxRandomCount);

                _raggedArray[0] = new int[count];
                for (int i = 0; i < count; i++)
                    _raggedArray[0][i] = _random.Next(MinRandomValue, MaxRandomValue);

                return;
            }

            WriteLine("До:");
            PrintRagged();

            var biggerRaggedArray = new int[_raggedArray.Length + 1][];

            for (int i = 0; i < _raggedArray.Length; i++)
            {
                int currentLength = _raggedArray[i].Length;
                biggerRaggedArray[i] = new int[currentLength];

                Array.Copy(_raggedArray[i], biggerRaggedArray[i], currentLength);
            }
                

            int lastIndex = _raggedArray.Length;
            int newCount = _random.Next(MinRandomCount, MaxRandomCount);

            biggerRaggedArray[lastIndex] = new int[newCount];
            for (int i = 0; i < newCount; i++)
                biggerRaggedArray[lastIndex][i] = _random.Next(MinRandomValue, MaxRandomValue);

            _raggedArray = new int[biggerRaggedArray.Length][];
            Array.Copy(biggerRaggedArray, _raggedArray, biggerRaggedArray.Length);

            WriteLine("После:");
            PrintRagged();
        }
        
        private int ConsoleReadInt(string inputMessage = "")
        {
            Write(inputMessage);
            int inputNumber = 0;

            while (!int.TryParse(ReadLine(), out inputNumber))
                Write("\nВнимание: введённое выражение не является целым числом!\n" +
                    "Повторите попытку ввода!!!\n\n >> ");

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
    }
}
