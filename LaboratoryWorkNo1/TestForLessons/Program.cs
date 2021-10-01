using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TestForLessons
{
    class Program
    {
        static readonly Random MainRandomizer = new Random();

        static void Main(string[] args)
        {
            var jmas = new int[5][];

            for (int i = 0; i < jmas.Length; i++)
            {
                jmas[i] = new int[MainRandomizer.Next(1, 10)];

                for (int j = 0; j < jmas[i].Length; j++)
                    jmas[i][j] = MainRandomizer.Next(-100, 100);
            }

            foreach (var row in jmas)
            {
                foreach (var item in row) 
                    Write(item + "\t");
               
                Write("\n");
            }

            ReadKey();
        }
    }
}
