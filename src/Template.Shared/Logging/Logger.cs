using System;

using Serilog;

using Microsoft.Extensions.Configuration;
using Serilog.Sinks.Elasticsearch;

namespace Template.Shared.Logging
{
    /// <summary>
    ///     Logger.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        ///     Creates logger.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="serviceName">The service name.</param>
        public static ILogger CreateLogger(IConfiguration configuration, string serviceName)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{SourceContext}] [{EventId}] {Message:lj}{NewLine}{Exception}";

            return new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: outputTemplate)
                .WriteTo.File("/Logs/log-.txt", outputTemplate: outputTemplate, rollingInterval: RollingInterval.Day)
                //.WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment, serviceName))
                .CreateLogger();
        }

        /// <summary>
        ///     Gets the exception message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="exceptionLevel">The exception level.</param>
        /// <returns>The exception message.</returns>
        public static string GetExceptionMessage(Exception exception, string message, int exceptionLevel)
        {
            var spaces = new string(' ', exceptionLevel * 2);

            message = string.Concat(
                message, Environment.NewLine,
                spaces, $"{(exceptionLevel > 1 ? "Inner " : string.Empty)}Exception Type: {exception?.GetType().FullName}", Environment.NewLine,
                spaces, $"{(exceptionLevel > 1 ? "Inner " : string.Empty)}Exception Message: {exception?.Message}", Environment.NewLine,
                spaces, $"{(exceptionLevel > 1 ? "Inner " : string.Empty)}Exception StackTrace: {exception?.StackTrace}", Environment.NewLine);

            if (exception?.InnerException != null)
            {
                message = GetExceptionMessage(exception.InnerException, message, ++exceptionLevel);
            }

            return message;
        }

        /// <summary>
        ///     Configures elastic sink.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="serviceName">The service name.</param>
        private static ElasticsearchSinkOptions ConfigureElasticSink(IConfiguration configuration, string environment, string serviceName)
        {
            return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
            {
                AutoRegisterTemplate = true,
                IndexFormat = $"{serviceName.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
            };
        }
    }
}
