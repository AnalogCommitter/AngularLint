using System;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace Formula.ConsoleRestClient
{
    class Program
    {
        private static HttpClient httpClient;
        private const string ApiUrl = "http://ergast.com/api/f1/";
        private const string FilePath = @"C:\Users\madja\Dropbox\Schule\4.Klasse\PROO\05.Formula1";
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!"); 
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiUrl)
            };
            var message = await httpClient.GetAsync("2019/results");
            message.EnsureSuccessStatusCode();
            var body = await message.Content.ReadAsStringAsync();
            var lines = body.Split("\n")
                .Where(line => !line.Contains("MRData"))
                .ToArray();
            await File.WriteAllLinesAsync(FilePath + "\\http-results.xml", lines);
        }
    }
}
