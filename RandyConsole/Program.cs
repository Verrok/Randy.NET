using System.Threading.Tasks;
using Randy;
using Serilog;

namespace RandyConsole
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            
            GeneratorClient client = new GeneratorClient("9816823a-ba13-4a23-a601-bbbe6997a0cb");

            var resp = await client.GetUsageAsync();
            
            log.Information("{@u}", resp.ResultInfo);
            
        }
    }
}