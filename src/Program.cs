using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{
    public class Program
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();
        // This method gets called by the runtime. Use this method to configure the HTTP request's pipeline. 
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
