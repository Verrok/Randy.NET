using System;
using System.Threading.Tasks;
using Randy;
using Randy.Requests;
using Randy.Enums;
namespace RandyConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GeneratorClient client = new GeneratorClient("9816823a-ba13-4a23-a601-bbbe6997a0cb");

            var resp = await client.GetStringsAsync(1, 10);
            
            Console.WriteLine(resp.Id);
            Console.WriteLine(resp.ResultInfo.AdvisoryDelay);
            Console.WriteLine(resp.ResultInfo.BitsLeft);
            Console.WriteLine(resp.ResultInfo.BitsUsed);
            Console.WriteLine(resp.ResultInfo.RequestsLeft);
            Console.WriteLine(resp.JsonResponse);
            Console.WriteLine(resp.CompletionTime);
            
            foreach (var i in resp.Data)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}