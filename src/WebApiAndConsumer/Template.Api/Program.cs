using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Template.Bll.Services.Abstractions;
using Template.Shared.Logging;

namespace Template.Api
{
    /// <summary>
    /// The program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Configuration
        /// </summary>
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        /// <summary>
        /// The main
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static async Task Main(string[] args)
        {
            Log.Logger = Logger.CreateLogger(Configuration);

            try
            {
                var host = CreateHostBuilder(args).Build();
                
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        Log.Information("Migrating database");
                        var initDbService = services.GetRequiredService<IDbInitService>();
                        await initDbService.InitDb();
                        Log.Information("Database has been migrated");
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "An error occurred while migrating the database");
                        throw;
                    }
                }

                Log.Information("Start API");

                await host.RunAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        /// CreateHostBuilder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog();
    }
}
