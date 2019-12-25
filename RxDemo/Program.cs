using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RxDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var magic = new MagicalNumberGenerator();
            //foreach (var item in magic.Generate(5)) 
            //{
            //    Console.WriteLine($"{item}");

            //}

            var magic = new AsyncMagicalNumberGenerator();
            await foreach (var item in magic.Generate(5))
            {
                Console.WriteLine($"{item}");

            }


        }
    }

    class MagicalNumberGenerator
    {
        public IEnumerable<int> Generate(int amount) {
            for (int i = 0; i < amount; i++)
            {
                Thread.Sleep(2000);
                yield return new Random().Next(10, 100);
            }
        }
    }

    class AsyncMagicalNumberGenerator
    {
        public async IAsyncEnumerable<int> Generate(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                await Task.Delay(2000);
                yield return new Random().Next(10, 100);
            }
        }
    }
}
