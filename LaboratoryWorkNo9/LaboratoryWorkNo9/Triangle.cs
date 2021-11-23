using System;
using static System.Console;

namespace LaboratoryWorkNo9
{
    public class Triangle : IComparable<Triangle>
    {
        public int CompareTo(Triangle other)
        {
            if (other == null || this > other)
                return 1;

            if (Equals(other))
                return 0;

            return -1;
        }

        public const string LessThanZeroExceptionMessage = "Длина стороны не может быть < 0";

        private static readonly Random _random = new Random();
        private const double RandomRangeMultipler = 50d;

        private static int _instanceCount = 0;
        public static int InstanceCount => _instanceCount;

        private double _lengthAB = 0;
        private double _lengthBC = 0;
        private double _lengthAC = 0;

        public double LengthAB
        {
            get => _lengthAB;
            set
            {
                if (value < 0)
                    throw new ArgumentException(LessThanZeroExceptionMessage);

                _lengthAB = value;
            }
        }

        public double LengthBC
        {
            get => _lengthBC;
            set
            {
                if (value < 0)
                    throw new ArgumentException(LessThanZeroExceptionMessage);

                _lengthBC = value;
            }
        }

        public double LengthAC
        {
            get => _lengthAC;
            set
            {
                if (value < 0)
                    throw new ArgumentException(LessThanZeroExceptionMessage);

                _lengthAC = value;
            }
        }

        public bool Exists =>
            LengthAB + LengthBC >= LengthAC &&
            LengthBC + LengthAC >= LengthAB &&
            LengthAB + LengthAC >= LengthBC;

        public double Area 
        {
            get
            {
                if (!Exists) return 0d;

                double p = Perimeter / 2;
                return Math.Sqrt(p * (p - LengthAB) * (p - LengthBC) * (p - LengthAC));
            }
        }

        public double Perimeter =>
            LengthAB + LengthBC + LengthAC;

        private static double ConsoleReadLength(string inputMessage = "")
        {
            Write(inputMessage);
            double inputNumber = -1;

            var isNumberSuit = false;

            while (!isNumberSuit)
            {
                var isValid = double.TryParse(ReadLine(), out inputNumber);
                var isSuit = inputNumber >= 0;

                isNumberSuit = isValid && isSuit;

                if (!isValid)
                    Write("\nВнимание: введённое выражение не является" +
                        " вещественным числом!!!\nПовторите попытку ввода!!!\n\n >>> ");

                else if (!isSuit)
                    Write("\nВнимание: длина не может быть < 0:\n" +
                        "Повторите попытку ввода!!!\n\n >>> ");
            }
            

            return inputNumber;
        }

        public static Triangle NewUserInput => new Triangle
           (ConsoleReadLength("Введите длину AB: "),
            ConsoleReadLength("Введите длину BC: "),
            ConsoleReadLength("Введите длину AC: "));

        public static Triangle NewRandom => new Triangle
           (_random.NextDouble() * RandomRangeMultipler,
            _random.NextDouble() * RandomRangeMultipler,
            _random.NextDouble() * RandomRangeMultipler);

        public static double operator - (Triangle triangle) =>
            triangle.Area;

        public static bool operator > (Triangle first, Triangle second) =>
            first.Area > second.Area;

        public static bool operator < (Triangle first, Triangle second) =>
            first.Area < second.Area;

        public static implicit operator double (Triangle triangle) =>
            triangle.Perimeter;

        public static explicit operator bool (Triangle triangle) =>
            triangle.Exists;

        public Triangle() => 
            _instanceCount++;

        public Triangle(double lengthAB, double lengthBC, double lengthAC)
        {
            LengthAB = lengthAB;
            LengthBC = lengthBC;
            LengthAC = lengthAC;

            _instanceCount++;
        }

        ~Triangle() => 
            _instanceCount--;

        public override string ToString() =>
            $"Треугольник: AB = {LengthAB:N2}, BC = {LengthBC:N2}, " + 
            $"AC = {LengthAC:N2}; S = {Area:N2}, P = {Perimeter:N2}; "+ 
            $"{(Exists? "С" : "Не с")}уществует";

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return Area == (obj as Triangle).Area;
        }
    }
}
