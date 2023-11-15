using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var collection = new TestCollection();
            collection.AddRandomItems(100000);

            var benchmark = new Benchmark(collection);

            for (int i = 0; i < 10; i++)
            {
                benchmark.Start();
                Console.WriteLine("\n");
            }
        }
    }
}
