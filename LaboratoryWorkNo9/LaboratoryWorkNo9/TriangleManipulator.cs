using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKit.Console;

namespace LaboratoryWorkNo9
{
    public static class TriangleManipulator
    {
        private static Triangle _singleTriangle = new Triangle();
        private static TriangleCollection _triangleCollection = new TriangleCollection();
        private static readonly Random _random = new Random();

        public static void InputNewTriangle()
        {
            _singleTriangle = Triangle.NewUserInput;
        }

        public static void NewRandomTraingle()
        {
            _singleTriangle = Triangle.NewRandom;
        }

        public static void PrintTriangle()
        {
            Console.WriteLine(_singleTriangle.ToString());
            ConsoleMenu.WaitForKey(ConsoleKey.Enter);
        }


        public static void InputNewTriangleCollection()
        {
            _triangleCollection = new TriangleCollection(Initialization.UserInput);
        }

        public static void NewRandomTriangleCollection()
        {
            _triangleCollection = new TriangleCollection(Initialization.Random);
        }

        public static void PrintCollectionViaMethod()
        {
            Console.WriteLine(_triangleCollection.ToString());
            ConsoleMenu.WaitForKey(ConsoleKey.Enter);
        }

        public static void PrintCollectionViaIndex()
        {
            if (_triangleCollection.Count == 0)
                Console.WriteLine("* Массив пустой *");
            
            for (int i = 0; i < _triangleCollection.Count; i++)
                Console.WriteLine($"№{i + 1}: {_triangleCollection[i].ToString()}");

            ConsoleMenu.WaitForKey(ConsoleKey.Enter);
        }

        public static void PrintMinAreaTriangle()
        {
            try
            {
                var minAriaTriangle = _triangleCollection.MinAreaTriangle;
                Console.WriteLine(minAriaTriangle.ToString());
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            ConsoleMenu.WaitForKey(ConsoleKey.Enter);
        }
    }
}
