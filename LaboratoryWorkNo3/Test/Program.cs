using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int stringLength = 1000000;
            const int delta = 10000;

            Console.WriteLine("через StringBuilder (Не лагает):\nНажми, чтобы начать!");
            Console.ReadKey();

            var buider = new StringBuilder("");
            var stringHolder = "";

            for (int i = 0; i < stringLength; i++)
            {
                buider.Append("a");

                if (i % delta == 0)
                    Console.WriteLine(i + "\tсимволов");
            }

            Console.WriteLine("\nчерез string (лагает):\nНажми, чтобы начать!");
            Console.ReadKey();

            for (int i = 0; i < stringLength; i++)
            {
                stringHolder += "a";

                if (i % delta == 0)
                    Console.WriteLine(i + "\tсимволов");
            }
        }
    }
}
