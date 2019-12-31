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
            
            Request req = new Request();

            req.Jsonrpc = "2.0";
            req.Id = 32;
            req.Method = "generateIntegers";
            req.Params.Add("apiKey", "9816823a-ba13-4a23-a601-bbbe6997a0cb");
            req.Params.Add("n", 2);
            req.Params.Add("min", 3);
            req.Params.Add("max", 78);
            
            await client.MakegRpcRequestAsync<GetIntegerResponse>(req);
        }
    }
}