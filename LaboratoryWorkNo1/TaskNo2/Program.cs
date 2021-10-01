/*
 * 09.10.2021
 * Variant 25
 * 
 * Shumilov Lev, ISD-20-1b
 * Шумилов Лев,  РИС-20-1б
 * 
 * Laboratory work #1
 * Task #2: 2D Geometry belonging
 */

using System;
using static System.Console;
using static System.Math;

namespace TaskNo2
{
    class Program
    {
        static Triangle ColoredTriangle = new Triangle()
        {
            VertexA = new Point(-10, 0),
            VertexB = new Point(0, 5),
            VertexC = new Point(0, -5),
        };

        static Circle ColoredCircle = new Circle()
        {
            Radius = 5,
            CenterPoint = new Point(5, -1),
        };

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

        static void Main(string[] args)
        {
            while (true)
            {
                WriteLine("\nВведите координаты точки:");
                var inputPoint = new Point()
                {
                    X = ConsoleReadDouble("X: "),
                    Y = ConsoleReadDouble("Y: "),
                };

                var isOnCircle = ColoredCircle.IncludesPoint(inputPoint);
                var isOnTriangle = ColoredTriangle.IncludesPoint(inputPoint);

                var isOnFilledArea = isOnCircle || isOnTriangle;
                var outputMessage = $"Точка M({inputPoint.X}; {inputPoint.Y}) ";

                outputMessage += !isOnFilledArea ? "НЕ " : "";
                outputMessage += "ВХОДИТ в закрашенную область;\n";

                outputMessage += isOnCircle ? " * входит в КРУГ;\n" : "";
                outputMessage += isOnTriangle ? " * входит в ТРЕУГОЛЬНИК;\n" : "";

                var nextStepMessage =
                    "\nBackspace: завершение программы;\n" +
                    "Остальные клавиши: новая точка;\n";

                WriteLine(outputMessage);
                WriteLine(nextStepMessage);

                if (ReadKey().Key == ConsoleKey.Backspace) break;
            }

            WriteLine("Выполнение программы успешно завершено!");
            ReadKey();
        }
    }
}
