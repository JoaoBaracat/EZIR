using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Register.API.Extensions;
using Register.Infra.Data;
using System;

namespace Register.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development)
            {
                host.MigrateDatabase<RegisterContext>((context, services) =>
                {
                    var logger = services.GetService<ILogger<RegisterContextSeed>>();
                    RegisterContextSeed
                        .SeedAsync(context, logger)
                        .Wait();
                });
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}