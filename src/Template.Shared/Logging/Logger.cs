using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace Template.Shared.Logging
{
    public static class Logger
    {
        public static ILogger CreateLogger(IConfiguration configuration)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{SourceContext}] [{EventId}] {Message:lj}{NewLine}{Exception}";

            return new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: outputTemplate)
                .WriteTo.File(path: "/Logs/log-.txt", outputTemplate: outputTemplate, rollingInterval: RollingInterval.Day)
                .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
                .CreateLogger();
        }

        private static ElasticsearchSinkOptions ConfigureElasticSink(IConfiguration configuration, string environment)
        {
            return new(new Uri(configuration["ElasticConfiguration:Uri"]))
            {
                AutoRegisterTemplate = true,
                IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name?.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
            };
        }
    }
}
