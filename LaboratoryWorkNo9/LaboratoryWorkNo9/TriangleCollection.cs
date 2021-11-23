using System;
using System.Collections.Generic;
using System.Linq;

using static System.Console;

namespace LaboratoryWorkNo9
{
    public enum Initialization
    {
        Null,
        UserInput,
        Random
    }

    public class TriangleCollection
    {
        public const string NotFoundExistingTriangleMessage = "В коллекции нет существующих треугольников!";
        public const string EmptyCollectionMessage = "Массив треугольников пуст!";

        private const int MinRandomCount = 5;
        private const int MaxRandomCount = 25;

        private readonly Random _random = new Random();

        private Triangle[] _triangles;

        public Triangle this[int index]
        {
            get => _triangles[index];
            set => _triangles[index] = value;
        }

        public int Count => _triangles == null ? 0 : _triangles.Length;

        private static int ConsoleReadCount(string inputMessage = "")
        {
            Write(inputMessage);
            int inputNumber = -1;

            var isNumberSuit = false;

            while (!isNumberSuit)
            {
                var isValid = int.TryParse(ReadLine(), out inputNumber);
                var isSuit = inputNumber >= 0;

                isNumberSuit = isValid && isSuit;

                if (!isValid)
                    Write("\nВнимание: введённое выражение не является" +
                        " целым числом!!!\nПовторите попытку ввода!!!\n\n >>> ");

                else if (!isSuit)
                    Write("\nВнимание: длина не может быть < 0:\n" +
                        "Повторите попытку ввода!!!\n\n >>> ");
            }


            return inputNumber;
        }

        private void CreateNewCollectionByUserInput()
        {
            int itemCount = ConsoleReadCount("Введите кол-во треугольников: ");
            _triangles = new Triangle[itemCount];

            for (int i = 0; i < itemCount; i++)
            {
                _triangles[i] = Triangle.NewUserInput;
                WriteLine();
            }
        }

        private void CreateNewCollectionByRandom()
        {
            int itemCount = _random.Next(MinRandomCount, MaxRandomCount);
            _triangles = new Triangle[itemCount];

            for (int i = 0; i < itemCount; i++)
                _triangles[i] = Triangle.NewRandom;
        }

        public Triangle MinAreaTriangle
        {
            get
            {
                if (_triangles == null || _triangles.Length == 0)
                    throw new ArgumentNullException(EmptyCollectionMessage);

                var existingTriangles = _triangles.Where(t => t.Exists);

                if (existingTriangles.Count() == 0)
                    throw new ArgumentNullException(NotFoundExistingTriangleMessage);

                return existingTriangles.Min();
            }
        }
           

        public TriangleCollection() =>
            _triangles = null;

        public TriangleCollection(IEnumerable<Triangle> collection) =>
            _triangles = collection.ToArray();

        public TriangleCollection(Initialization initialization)
        {
            switch (initialization)
            {
                case Initialization.Null:
                    _triangles = null;
                    break;

                case Initialization.UserInput:
                    CreateNewCollectionByUserInput();
                    break;

                case Initialization.Random:
                    CreateNewCollectionByRandom();
                    break;
            }
        }

        public override string ToString()
        {
            if (_triangles == null || _triangles.Length == 0)
                return EmptyCollectionMessage;

            var stringData = $"Кол-во элементов = {_triangles.Length}\n";

            foreach (var triangle in _triangles)
                stringData += $" * {triangle};\n";

            return stringData;
        }
    }
}
