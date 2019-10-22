using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MyTVStreamingService.Models;
using MyTVStreamingService.Data;

namespace MyTVStreamingService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                // This seeds the Show Table 
                try
                {
                    var context = services.GetRequiredService<MyTVContext>();
                    context.Database.Migrate();
                    SeedData.Initialize(services);
                }
              // This Seeds the User Table
                // try
                // {
                //     var context = services.GetRequiredService<MyTVContext>();
                //     context.Database.Migrate();
                //     UserSeedData.Initialize(services);
                // }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
