using System;
using static System.Console;
using static System.Math;

namespace LaboratoryWorkNo3
{
    class Program
    {
        static double BaseFunction(double x)
        {
            double value = (Exp(x) - Exp(-x)) / 2;
            return value;
        }

        static double FullTaylorSeriesFunction(double x, double epsilon)
        {
            if (epsilon <= 0)
                throw new ArgumentException("Точность не может быть <= 0");

            double value = x;
            double powerValue = x;
            long factorialValue = 1;

            var continueCompitung = true;

            for (int i = 1; continueCompitung; i++)
            {
                powerValue *= x * x;
                factorialValue *= 2 * i * (2 * i + 1);

                if (factorialValue == 0)
                    factorialValue = long.MaxValue;

                double elementValue = powerValue / factorialValue;
                value += elementValue;

                if (elementValue <= epsilon)
                    continueCompitung = false;
            }
            return value;
        }

        static double FullTaylorSeriesFunction(double x, int iterationCount)
        {
            if (iterationCount <= 0)
                throw new ArgumentException("Кол-во итераций не может быть <= 0");

            double value = x;
            double powerValue = x;
            long factorialValue = 1;

            for (int i = 1; i <= iterationCount; i++)
            {
                powerValue *= x * x;
                factorialValue *= 2 * i * (2 * i + 1);

                if (factorialValue == 0)
                    factorialValue = long.MaxValue;

                double elementValue = powerValue / factorialValue;
                value += elementValue;
            }
            return value;
        }

        static void Main(string[] args)
        {
            const double StartX = 0.1;
            const double EndX = 1;
            const double ComputingAccuracy = 0.000001;

            const int ArgumentCount = 10;
            const int IterationCount = 20;

            double deltaX = (EndX - StartX) / ArgumentCount;

            WriteLine("Сокращения:\n" +
                $"Base_Fun - Базовая функция,\n" +
                $"TS_Iters - Ряд тейлора, кол-во итераций = {IterationCount},\n" +
                $"TS_Epsil - Ряд тейлора, точность = {ComputingAccuracy},\n" +
                $"Интервал - [{StartX}; {EndX}]\n");

            for (double x = StartX; x <= EndX; x += deltaX)
                WriteLine($"   X: {x:N4} =>    " +
                    $"Base_Fun: {BaseFunction(x):N8};    " +
                    $"TS_Iters: {FullTaylorSeriesFunction(x, IterationCount):N8}    " +
                    $"TS_Epsil: {FullTaylorSeriesFunction(x, ComputingAccuracy):N8};" );
        }
    }
}
