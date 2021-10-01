/*
 * 09.10.2021
 * Variant 25
 * 
 * Shumilov Lev, ISD-20-1b
 * Шумилов Лев,  РИС-20-1б
 * 
 * Laboratory work #1
 * Task #3: Computing complex expressions
 */

using System;
using static System.Console;
using static System.Math;

namespace TaskNo3
{
    class Program
    {
        static void GetExpressionValueDouble()
        {
            WriteLine("Вычисление дроби через тип DOUBLE:\n");

            const double
                A = 100d,
                B = 0.001d;

            double 
                k = Pow(A - B, 3),
                l = Pow(A, 3);

            double 
                m = -Pow(B, 3),
                n = 3 * A * Pow(B, 2),
                p = 3 * Pow(A, 2) * B;

            double 
                numerator = k - l,
                denominator = m + n - p;

            if (denominator == 0)
            {
                var errorMessage =
                    "Внимание, знаменатель = 0;\n" +
                    "Дальнейшее вычисление невозможно!!!\n";

                WriteLine(errorMessage);
                return;
            }

            double result = numerator / denominator;

            var outputMessage =
                $"При a = 100, b = 0.001:\n" +
                $"Значение выражения = {result};\n\n" +
                $" >> K = (a - b)^3  = {k};\n" +
                $" >> L = a^3        = {l};\n" +
                $" >> M = -b^3       = {m};\n" +
                $" >> N = 3ab^2      = {n};\n" +
                $" >> P = 3a^2 * b   = {p};\n\n" +
                $" >> числитель      = {numerator};\n" +
                $" >> знаменатель    = {denominator};\n";

            WriteLine(outputMessage);
        }

        static void GetExpressionValueFloat()
        {
            WriteLine("\n\nВычисление дроби через тип FLOAT:\n");

            const float
                A = 100f,
                B = 0.001f;

            float 
                k = (float) Pow(A - B, 3),
                l = (float) Pow(A, 3);

            float 
                m = (float) -Pow(B, 3),
                n = (float) Pow(B, 2) * 3 * A,
                p = (float) Pow(A, 2) * 3 * B;

            float 
                numerator = k - l,
                denominator = m + n - p;

            if (denominator == 0)
            {
                var errorMessage =
                    "Внимание, знаменатель = 0;\n" +
                    "Дальнейшее вычисление невозможно!!!\n";

                WriteLine(errorMessage);
                return;
            }

            float result = numerator / denominator;

            WriteLine(
                $"При a = 100, b = 0.001:\n" +
                $"Значение выражения = {result};\n\n" +
                $" >> K = (a - b)^3  = {k};\n" +
                $" >> L = a^3        = {l};\n" +
                $" >> M = -b^3       = {m};\n" +
                $" >> N = 3ab^2      = {n};\n" +
                $" >> P = 3a^2 * b   = {p};\n\n" +
                $" >> числитель      = {numerator};\n" +
                $" >> знаменатель    = {denominator};\n");
        }

        static void Main(string[] args)
        {
            WriteLine(
                "Входная дробь:\n\n" +
                "  (a - b)^3 - (a^3)\n" +
                " -------------------\n" +
                "-b^3 + 3ab^2 -  3a^2b\n\n");

            GetExpressionValueDouble();
            GetExpressionValueFloat();

            WriteLine("Выполнение программы успешно завершено!");
            ReadKey();
        }
    }
}
