using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlayerSoft.Template.Bll.Contracts;
using Serilog;

namespace PlayerSoft.Template.Api
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        public static async Task Main(string[] args)
        {
            var outputTemplate =
                "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{SourceContext}] [{EventId}] {Message:lj}{NewLine}{Exception}";
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: outputTemplate)
                .WriteTo.File(path: "/Logs/log-.txt", outputTemplate: outputTemplate, rollingInterval: RollingInterval.Day)
                .CreateLogger();

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

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog();
    }
}
