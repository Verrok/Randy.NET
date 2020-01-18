using System;
using System.Threading.Tasks;
using Randy;
using Randy.Requests;
using Randy.Requests.Responses;

namespace RandyConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GeneratorClient client = new GeneratorClient("9816823a-ba13-4a23-a601-bbbe6997a0cb");

            var resp = await client.GetIntegersAsync(2, 0, 10);
            
            Console.WriteLine(resp.Id);
            Console.WriteLine(resp.AdvisoryDelay);
            Console.WriteLine(resp.BitsLeft);
            Console.WriteLine(resp.BitsUsed);
            Console.WriteLine(resp.RequestsLeft);
            Console.WriteLine(resp.JsonResponse);
        }
    }
}