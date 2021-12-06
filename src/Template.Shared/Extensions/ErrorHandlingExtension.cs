using System;

using Microsoft.AspNetCore.Builder;
using Template.Shared.Errors.Middlewares;

namespace Template.Shared.Extensions
{
    /// <summary>
    ///     Error Handling Extension
    /// </summary>
    public static class ErrorHandlingExtension
    {
        /// <summary>
        ///     Uses the error handling.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">app</exception>
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}