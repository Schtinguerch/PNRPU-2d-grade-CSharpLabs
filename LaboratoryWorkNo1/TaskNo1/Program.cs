/*
 * 12.september.2021
 * Variant 25
 * 
 * Shumilov Lev, ISD-20-1b
 * Шумилов Лев,  РИС-20-1б
 * 
 * Laboratory work #1
 * Task #1: Expressions processing
 */

using System;
using static System.Console;
using static System.Math;

namespace TaskNo1
{
    class Program
    {
        const int ExitCode = 0;

        static void Main(string[] args)
        {
            ShowMenu();

            WriteLine("Выполнение программы успешно завершено!");
            ReadKey();
        }

        static void ShowMenu()
        {
            WriteLine("Выражения про проверок:\n" +
                "1) m + --n\n" +
                "2) m++ < --n\n" +
                "3) --m > n--\n" +
                "4) arccos(x + x^2)\n\n" +
                $"{ExitCode}) Завершение работы.\n");
            int chosenExpressionNumber;

            do
            {
                chosenExpressionNumber = ConsoleReadInt("Выберите номер выражения: ");
                CheckExpression(chosenExpressionNumber);
            }
            while (chosenExpressionNumber != ExitCode);
        }

        static int ConsoleReadInt(string inputMessage = "")
        {
            Write(inputMessage);
            int inputNumber;

            while (!int.TryParse(ReadLine(), out inputNumber))
                WriteLine(
                    "\nВнимание: введённое выражение не является целым числом!\n" +
                    "Повторите попытку ввода!!!\n");

            return inputNumber;
        }

        static void CheckExpression(int expressionNumber)
        {
            if (expressionNumber < 1 || expressionNumber > Methods.Length)
            {
                if (expressionNumber != ExitCode)
                    WriteLine("Внимание: множество не содержит выражения" +
                        $" с порядковым номером {expressionNumber}!!!\n");

                return;
            }

            Methods[--expressionNumber]();
        }

        delegate void Method();
        static Method[] Methods =
        {
            new Method(GetExpressionValue),
            new Method(CompareFirstBoolExpression),
            new Method(CompareSecondBoolExpression),
            new Method(GetMathFunctionValue),
        };

        static string ToRussian(bool state) => state ? "Истина" : "Ложь";

        static void GetExpressionValue()
        {
            int m = ConsoleReadInt("M: ");
            int n = ConsoleReadInt("N: ");
            
            var outputMessage = $"\nПри M = {m}, N = {n}:\n";
            int expressionValue = m + --n;

            outputMessage +=
                $" => M + --N = {m} + {n}" +
                $" = {expressionValue};\n";

            WriteLine(outputMessage);
        }

        static void CompareFirstBoolExpression()
        {
            int m = ConsoleReadInt("M: ");
            int n = ConsoleReadInt("N: ");

            var outputMessage = $"\nПри N = {n}, M = {m}:\n";
            var compareValue = m++ < --n;

            outputMessage +=
                $" => M++ < --N = {--m} < {n};\n" +
                $" => {ToRussian(compareValue)};\n";

            WriteLine(outputMessage);
        }

        static void CompareSecondBoolExpression()
        {
            int m = ConsoleReadInt("M: ");
            int n = ConsoleReadInt("N: ");

            var outputMessage = $"\nПри N = {n}, M = {m}:\n";
            var compareValue = --m > n--;

            outputMessage +=
                $" => --M > N-- = {m} > {++n};\n" +
                $" => {ToRussian(compareValue)};\n";

            WriteLine(outputMessage);
        }

        static void GetMathFunctionValue()
        {
            double x = ConsoleReadDouble("X: ");

            double argument = x + Pow(x, 2);
            if (argument < -1 || argument > 1)
            {
                WriteLine($"\nВнимание: при X = {x}, аргумент X + X^2 = {argument}\n" +
                    $"не входит в интервал ограничения функции Accos [-1; 1]!!!\n");

                return;
            }

            double value = Acos(argument);
            double angle = value * 180 / PI;

            WriteLine($"\nПри X = {x}:\n" +
                $"Arccos(X + X^2) = Arccos({argument})" +
                $" = {value} рад = {angle} гр;\n");
        }

        static double ConsoleReadDouble(string inputMessage = "")
        {
            Write(inputMessage);
            double inputNumber;

            while (!double.TryParse(ReadLine(), out inputNumber))
                WriteLine(
                    "\nВнимание: введённое выражение не является вещественным числом!!!\n" +
                    "Повторите попытку ввода!!!\n");

            return inputNumber;
        }
    }
}
