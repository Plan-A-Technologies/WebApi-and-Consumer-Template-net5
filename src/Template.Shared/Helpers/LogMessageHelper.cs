using System;

namespace Template.Shared.Helpers
{
    public static class LogMessageHelper
    {
        /// <summary>
        /// Creates the log message.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="additionalInfo">The additionalInfo text message.</param>
        /// <returns>Log exception message.</returns>
        public static string CreateLogMessage(Exception ex, string additionalInfo = "") {
            return $"{Environment.NewLine}" +
                   $"An unhandled exception occurred." +
                   $"{additionalInfo}{Environment.NewLine}" +
                   $"  Exception Type :{ex?.GetType().FullName}{Environment.NewLine}" +
                   $"  Exception Message : {ex?.Message} {Environment.NewLine}" +
                   $"  Exception StackTrace : {ex?.StackTrace}{Environment.NewLine}" +
                   $"    Inner Exception Message :  {ex?.InnerException?.Message}{Environment.NewLine}" + 
                   $"    Inner Inner Exception Message :  {ex?.InnerException?.InnerException?.Message}{Environment.NewLine}" + 
                   $"    Inner Exception StackTrace : {ex?.InnerException?.StackTrace}{Environment.NewLine}";
        }
    }
}