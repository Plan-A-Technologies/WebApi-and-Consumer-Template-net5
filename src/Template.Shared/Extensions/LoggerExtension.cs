using System;

using Microsoft.Extensions.Logging;

using Template.Shared.Logging;

namespace Template.Shared.Extensions
{
    /// <summary>
    ///     The logger exception.
    /// </summary>
    public static class LoggerExtension
    {
        /// <summary>
        ///     Logs the error.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="additionalInfo">The additional information.</param>
        /// <returns></returns>
        public static ILogger LogError(this ILogger logger, Exception exception, string additionalInfo = "")
        {
            var message = $"{Environment.NewLine}An unhandled exception occurred.";

            if (!string.IsNullOrWhiteSpace(additionalInfo))
            {
                message = string.Concat(message, $"{Environment.NewLine}{additionalInfo}");
            }

            message = Logger.GetExceptionMessage(exception, message, 0);

            logger.LogError(message);

            return logger;
        }
    }
}