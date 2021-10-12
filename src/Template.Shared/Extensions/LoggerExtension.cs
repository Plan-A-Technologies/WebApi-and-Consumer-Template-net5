using System;
using Microsoft.Extensions.Logging;

namespace Template.Shared.Extensions
{
    /// <summary>
    /// The logger exception.
    /// </summary>
    public static class LoggerExtension
    {
        /// <summary>
        /// Logs the error.
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

            message = GetExceptionMessage(exception, message, 1);

            logger.LogError(message);

            return logger;
        }

        /// <summary>
        /// Gets the exception message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="exceptionLevel">The exception level.</param>
        /// <returns></returns>
        private static string GetExceptionMessage(Exception exception, string message, int exceptionLevel)
        {
            var spaces = GetSpaces(exceptionLevel);
            message = string.Concat(
                message, Environment.NewLine,
                spaces, $"{(exceptionLevel > 1 ? "Inner " : string.Empty)}Exception Type :{exception?.GetType().FullName}", Environment.NewLine,
                spaces, $"{(exceptionLevel > 1 ? "Inner " : string.Empty)}Exception Message : {exception?.Message}", Environment.NewLine,
                spaces, $"{(exceptionLevel > 1 ? "Inner " : string.Empty)}Exception StackTrace : {exception?.StackTrace}", Environment.NewLine);
            if (exception?.InnerException != null)
            {
                message = GetExceptionMessage(exception.InnerException, message, ++exceptionLevel);
            }

            return message;
        }

        /// <summary>
        /// Gets the spaces.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <returns></returns>
        private static string GetSpaces(int level)
        {
            var spaces = string.Empty;
            for (var i = 0; i < level; i++)
            {
                spaces = string.Concat(spaces, "  ");
            }

            return spaces;
        }
    }
}
