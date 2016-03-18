using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Appsensor.Services;
using Microsoft.Extensions.Configuration;
using Appsensor.Models;

namespace Appsensor
{
    public class Startup
    {
        private IHostingEnvironment hostingEnviroment;
        public Startup(IHostingEnvironment env)
        {
            this.hostingEnviroment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<ISensorService, SensorService>();

            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("temperatureSettings.json")
                .AddEnvironmentVariables();

            var config = builder.Build();

            services.Configure<TemperatureSettings>(config);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory factoryLogger)
        {
            //factoryLogger.AddConsole(minLevel : LogLevel.Information);
            //var logger = factoryLogger.CreateLogger("info");

            if (hostingEnviroment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseIISPlatformHandler();

                            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseStaticFiles();
            app.UseStatusCodePages();
          //  app.UseStatusCodePagesWithRedirects("~/error/code{0}");

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("Antes de Hello world");
            //    await context.Response.WriteAsync("Hello World!");
            //    logger.LogInformation("Despues de Hello world");
            //    await next();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello Universe!");
            //});
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
