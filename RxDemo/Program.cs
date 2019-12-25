using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RxDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var magic = new MagicalNumberGenerator();
            //foreach (var item in magic.Generate(5)) 
            //{
            //    Console.WriteLine($"{item}");

            //}

            //var magic = new AsyncMagicalNumberGenerator();
            //await foreach (var item in magic.Generate(5))
            //{
            //    Console.WriteLine($"{item}");

            //}

            var magic = new MagicalNumberGenerator();
            var subscription = magic.GenerateNumber(5)
                .Timestamp()
                .Subscribe((number) => Console.WriteLine($"{number.Value} - {number.Timestamp.Second}"));

            Console.ReadLine();

        }
    }

    class MagicalNumberGenerator
    {
        public IEnumerable<int> Generate(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Thread.Sleep(2000);
                yield return new Random().Next(10, 100);
            }
        }

        public IObservable<int> GenerateNumber(int amount)
        {
            return Observable.Create<int>((o,ct) =>
            {
                return Task.Run(() =>
                {
                    foreach (var prime in Generate(amount))
                    {
                        ct.ThrowIfCancellationRequested();
                        o.OnNext(prime);

                    }
                    o.OnCompleted();
                });
                //return Disposable.Empty;
            });
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
