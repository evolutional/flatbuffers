using System;
using FlatBuffersBenchmark;

namespace FlatbuffersBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new BenchmarkRunner();
            runner.Run(10, 50);

            Console.WriteLine("\nPress a key...");
            Console.ReadKey();
        }
    }
}
