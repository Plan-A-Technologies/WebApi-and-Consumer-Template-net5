using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Template.Api.Extensions;
using Template.Bll.Assets;
using Template.Bll.Services;
using Template.Dal;
using Template.Internal.Shared;
using Template.Shared.Config;
using Template.Shared.Constants;
using Template.Shared.EFCore.Extensions;
using Template.Shared.Extensions;
using Template.Shared.Extensions.DependencyInjection;

namespace Template.Api
{
    /// <summary>
    /// The startup class.
    /// </summary>
    public class Startup
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Configure services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //Add bll services.
            services.AddBllServices();

            //Add masstransit services.
            var rabbitMqOptions = _configuration.GetSection(nameof(RabbitMqOptions)).Get<RabbitMqOptions>();
            services.AddMassTransitServices(rabbitMqOptions);

            //Add validators.
            services.AddValidators();

            //Add db context.
            var dbConnectionString = _configuration.GetConnectionString(GlobalConstants.DbConnectionStringName);
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(dbConnectionString), ServiceLifetime.Transient);
            services.AddEntityAuditableProvider<EntityAuditProvider>();

            //Add services like:
            // - Cors.
            // - auto mapper.
            // - Newtonsoft json serializer and DateFormatString.
            // - Fluent validation.
            // - Add authorization.
            services.ConfigureServices(_configuration, GlobalConstants.TemplateApi);
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Configure application:
            // - use cors policy.
            // - Use swagger.
            // - Use Authentication.
            // - User routing.
            // - Use Error Handling.
            // - UseEndpoints using controllers.
            app.ConfigureApplication(GlobalConstants.TemplateApi);
        }
    }
}
