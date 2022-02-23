using System;
using System.IO;
using System.Reflection;

using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using Newtonsoft.Json;

using Template.Shared.Filters;
using Template.Shared.Services;
using Template.Shared.Services.Abstractions;

using Swashbuckle.AspNetCore.Filters;

namespace Template.Shared.Extensions
{
    /// <summary>
    ///     Services extension.
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        ///     Adds user authentication.
        /// </summary>
        /// <param name="services">The services.</param>
        public static IServiceCollection AddUserAuthentication(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddTransient<IUserAuthenticationService, UserAuthenticationService>();

            return services;
        }

        /// <summary>
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="serviceName">The service name.</param>
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration, string serviceName)
        {
            // Add Cors
            services.AddCors();

            //Add auto mapper.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers(options =>
                {
                    //Add validation for request models
                    options.Filters.Add<RequestModelValidationFilter>();
                })

                //Set date time format to UTC.
                .AddNewtonsoftJson(options =>
                {
                    //options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    options.SerializerSettings.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'";
                });

            //TODO: doesn't work inside AddNewtonsoftJson. I haven't found a reason.
            //Set Json convert default settings.
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                // This ignores reference loop.
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            //Add swagger.
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = serviceName, Version = "v1" });
                    c.EnableAnnotations();
                    c.ExampleFilters();

                    var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{serviceName}.xml");
                    c.IncludeXmlComments(xmlPath);

                    var jwtSecurityScheme = new OpenApiSecurityScheme
                    {
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        Name = "JWT Authentication",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Description = "Put **_ONLY_** your JWT Bearer token on text box below",

                        Reference = new OpenApiReference
                        {
                            Id = JwtBearerDefaults.AuthenticationScheme,
                            Type = ReferenceType.SecurityScheme
                        }
                    };

                    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        { jwtSecurityScheme, Array.Empty<string>() }
                    });
                })
                .AddSwaggerExamplesFromAssemblies(Assembly.GetCallingAssembly());

            //Add fluent validation.
            services.AddFluentValidation(fluentValidationMvcConfiguration =>
            {
                fluentValidationMvcConfiguration.AutomaticValidationEnabled = false;
            });

            //Add authorization.
            services
                .AddAuthorizationPolicy(configuration)
                .AddIntrospectionValidate(configuration);

            //Setup user authentication service.
            services.AddUserAuthentication();

            return services;
        }
    }
}