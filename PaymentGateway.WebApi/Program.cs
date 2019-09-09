using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using App.Metrics.AspNetCore;

namespace PaymentGateway.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                    .UseMetrics()
                    .UseStartup<Startup>();
    }
}