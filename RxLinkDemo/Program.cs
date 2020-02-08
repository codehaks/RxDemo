using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace RxLinkDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var links = new List<string>();

            //links.Add("https://microsoft.com");
            //links.Add("https://amazon.com");        


            var query = links.ToObservable();

            

            query.Subscribe(async (url)=> {

                var client = new HttpClient();
                var page = await client.GetAsync(url);
                var pageSize = page.Content.Headers.ContentLength.Value;
                Console.WriteLine($" {url} ({pageSize})");

            });

            await query.Append("https://google.com");
            await query.Append("https://apple.com");


            await Task.Delay(10000);
            Console.ReadLine();

       

            //query.Subscribe(async (url) =>
            //{
            //    var client = new HttpClient();
            //    var page = await client.GetAsync(url);
            //    var pageSize = page.Content.Headers.ContentLength.Value;
            //}, Console.WriteLine("Done"),);


        }
    }
}
