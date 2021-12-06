using Microsoft.AspNetCore.Builder;

namespace Template.Shared.Extensions
{
    /// <summary>
    ///     App builder extension
    /// </summary>
    public static class AppBuilderExtension
    {
        /// <summary>
        ///     Configure application
        /// </summary>
        /// <param name="app">The app builder.</param>
        /// <param name="serviceName">The service name.</param>
        public static IApplicationBuilder ConfigureApplication(this IApplicationBuilder app, string serviceName)
        {
            // Use cors policy.
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(_ => true) // allow any origin
                .AllowCredentials()); // allow credentials

            // Use swagger.
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{serviceName} v1"));

            //Use routing and error handling.
            app.UseRouting();
            app.UseErrorHandling();

            //Use Authentication.
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            return app;
        }
    }
}