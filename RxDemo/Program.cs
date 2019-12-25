using System;
using System.Linq;
using System.Reactive.Linq;

namespace RxDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var numbers = Enumerable.Range(1, 10);
            var observableQuery = numbers.ToObservable();

            observableQuery.Subscribe((n) =>
            {
                Console.WriteLine($" Number = {n} ");
            },
            _ =>
            {

                Console.WriteLine("Done!");
            });


        }
    }
}
