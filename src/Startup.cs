using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{
    /// <summary>
    /// Startup class to add services to the container and configure HTTP requests
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Data middle tier
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddServerSideBlazor();
            services.AddHttpClient();
            services.AddControllers();
            services.AddTransient<JsonFileLocationService>();
            services.AddTransient<JsonFileLocationHoursService>();
            services.AddTransient<JsonFileLocationTypeService>();
            services.AddTransient<JsonFileMeetupService>();
            services.AddTransient<JsonFileUserService>();
            services.AddTransient<JsonFileAttendeeService>();
            services.AddSession();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method 
        /// to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/");
                //app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
            });
        }

    }
}
