using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{
    /// <summary>
    /// Program called by runtime to add services and configure HTTP requests
    /// </summary>
    public class Program
    {

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        /// <summary>
        /// This method gets called by the runtime. Use this method to 
        /// configure the HTTP request's pipeline. 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
