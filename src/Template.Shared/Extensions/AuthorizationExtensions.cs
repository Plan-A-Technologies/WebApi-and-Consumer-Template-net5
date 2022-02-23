using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

using IdentityModel.Client;

using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Template.Shared.IdentityServer.Settings;

namespace Template.Shared.Extensions
{
    /// <summary>
    ///     Extensions collection for authorization
    /// </summary>
    public static class AuthorizationExtensions
    {
        /// <summary>
        ///     Extension for connect identity server and validate token. Includes JWT-bearer authentication
        /// </summary>
        /// <param name="services">
        ///     <see cref="IServiceCollection"/>
        /// </param>
        /// <param name="configuration">
        ///     <see cref="IConfiguration"/>
        /// </param>
        /// <example>
        ///     <c>Use in appsettings:</c>
        ///     <code>
        /// "JwtBearerSettings": {
        ///     "Scheme": "",
        ///     "Authentication": {
        ///         "DefaultAuthenticateScheme": "",
        ///         "DefaultChallengeScheme": ""
        ///     },
        ///     "JwtBearer": {
        ///         "Authority": "http://localhost:1234",
        ///         "RequireHttpsMetadata": false,
        ///         "AutomaticRefreshInterval": "",
        ///         "TokenValidationParameters": {
        ///             "ValidateAudience": false,
        ///             "ValidAudience": "",
        ///             "ValidateIssuer": false,
        ///             "ValidIssuer": "",
        ///             "ValidateLifetime": true,
        ///             "ValidateIssuerSigningKey": false,
        ///             "IssuerSigningKey": ""
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        public static IServiceCollection AddJwtValidate(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthentication(options => configuration.Bind(JwtBearerSettings.AuthenticationSection, options))
                .AddJwtBearer(configuration.GetSection(JwtBearerSettings.Scheme).Value, options => configuration.Bind(JwtBearerSettings.JwtBearerSection, options));

            return services;
        }

        /// <summary>
        ///     Extension for connect identity server and validate token. Adds the OAuth 2.0 introspection handler
        /// </summary>
        /// <param name="services">
        ///     <see cref="IServiceCollection"/>
        /// </param>
        /// <param name="configuration">
        ///     <see cref="IConfiguration"/>
        /// </param>
        /// <example>
        ///     <c>Use in appsettings:</c>
        ///     <code>
        /// "IntrospectionSettings": {
        ///     "Scheme": "",
        ///     "Authentication": {
        ///         "DefaultAuthenticateScheme": "",
        ///         "DefaultScheme": "",
        ///         "DefaultChallengeScheme": ""
        ///     },
        ///     "Introspection": {
        ///         "Authority": "http://localhost:1234",
        ///         "IntrospectionEndpoint": "http://localhost:1234/connect/introspect",
        ///         "ClientId": "",
        ///         "ClientSecret": "",
        ///         "SkipTokensWithDots": false,
        ///         "DiscoveryPolicy": {
        ///             "RequireHttps": false,
        ///             "Authority": "http://localhost:1234"
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        public static IServiceCollection AddIntrospectionValidate(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAuthentication(options => configuration.Bind(IntrospectionSettings.AuthenticationSection, options))
                .AddOAuth2Introspection(configuration.GetSection(IntrospectionSettings.Scheme).Value,
                    options => configuration.Bind(IntrospectionSettings.IntrospectionSection, options));

            return services;
        }

        /// <summary>
        ///     Extension for authorization policy
        /// </summary>
        /// <param name="services">
        ///     <see cref="IServiceCollection"/>
        /// </param>
        /// <param name="configuration">
        ///     <see cref="IConfiguration"/>
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Add settings to appsettigns.json
        /// </exception>
        /// <example>
        ///     <c>Use in appsetings:</c>
        ///     <code>
        /// "PolicySettings": {
        ///     "Policies": [{
        ///         "PolicyName": "",
        ///         "Collection": [{
        ///             "Name": "",
        ///             "Values": [""]
        ///         }]
        ///     }]
        /// }
        /// </code>
        /// </example>
        public static IServiceCollection AddAuthorizationPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection(PolicySettings.Section).Get<PolicySettings>();

            if (settings == null) { throw new ArgumentNullException(nameof(configuration)); }

            services.AddAuthorization(options =>
            {
                foreach (var policy in settings.Policies)
                {
                    options.AddPolicy(policy.PolicyName, p =>
                    {
                        p.RequireAuthenticatedUser();

                        foreach (var claim in policy.Collection)
                        {
                            p.RequireClaim(claim.Name, claim.Values);
                        }
                    });
                }
            });

            return services;
        }

        /// <summary>
        ///     Extensions for client authorization
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///     Add settings to appsettigns
        /// </exception>
        /// <param name="services">
        ///     <see cref="IServiceCollection"/>
        /// </param>
        /// <param name="configuration">
        ///     <see cref="IConfiguration"/>
        /// </param>
        /// <example>
        ///     <c>Use in appsetings:</c>
        ///     <code>
        /// "ClientSettings": {
        ///     "BaseAddress": "",
        ///     "AccessTokenAddress": "",
        ///     "Client": {
        ///         "Credentials": {
        ///             "ClientName": "",
        ///             "ClientId": "",
        ///             "ClientSecret": "",
        ///             "Scope": "",
        ///             "GrantType": ""
        ///     },
        ///     "Policy": {
        ///         "WaitAndRetry": [""]
        ///     }
        /// }
        /// </code>
        ///     <c>Use in controller:</c>
        ///     <code>
        /// public async Task&lt;IActionResult&gt; CallApi()
        /// {
        ///     var accessToken = await HttpContext.GetTokenAsync("access_token");
        ///     var client = new HttpClient();
        ///     client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        ///     var content = await client.GetStringAsync("https://localhost:1234/identity");
        ///     return Ok(content);
        /// }
        /// </code>
        /// </example>
        public static IServiceCollection AddClientAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection(ClientSettings.Section).Get<ClientSettings>();

            if (settings == null) { throw new ArgumentNullException(nameof(configuration)); }

            services.AddClientAccessTokenHttpClient(settings.Client.Credentials.ClientName, configureClient: client => { client.BaseAddress = new Uri(settings.BaseAddress); });

            services
                .AddAccessTokenManagement(options =>
                {
                    options.Client.Clients.Add(settings.Client.Credentials.ClientName, new ClientCredentialsTokenRequest
                    {
                        Address = settings.AccessTokenAddress,
                        ClientId = settings.Client.Credentials.ClientId,
                        ClientSecret = settings.Client.Credentials.ClientSecret,
                        Scope = settings.Client.Credentials.Scope,
                        GrantType = settings.Client.Credentials.GrantType
                    });
                })
                .ConfigureBackchannelHttpClient()
                .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(settings.Client.RetryPolicy.WaitAndRetry));

            return services;
        }

        /// <summary>
        ///     Extensions for OpenId authorization
        /// </summary>
        /// <param name="services">
        ///     <see cref="IServiceCollection"/>
        /// </param>
        /// <param name="configuration">
        ///     <see cref="IConfiguration"/>
        /// </param>
        /// <example>
        ///     <c>Use in appsettings:</c>
        ///     <code>
        /// "OpenIdConnectSettings": {
        ///     "Scheme": "",
        ///     "Authentication": {
        ///         "DefaultScheme": "",
        ///         "DefaultChallengeScheme": ""
        ///     },
        ///     "CookieAuthentication": {
        ///         "Cookie": {
        ///             "Name": ""
        ///         },
        ///         "ExpireTimeSpan": "00:00:00",
        ///         "SlidingExpiration": false
        ///     },
        ///     "OpenIdConnect": {      
        ///         "RequireHttpsMetadata": false,
        ///         "CorrelationCookie": {
        ///             "HttpOnly": false,
        ///             "IsEssential": false,
        ///             "SameSite": 0
        ///         },
        ///         "NonceCookie": {
        ///             "HttpOnly": false,
        ///             "IsEssential": false,
        ///             "SameSite": 0
        ///         },
        ///         "Authority": "http://localhost:1234",
        ///         "ClientId": "",
        ///         "ClientSecret": "",
        ///         "ResponseType": "",
        ///         "UsePkce": false,
        ///         "Scope": [""],
        ///         "SaveTokens": false
        ///     }
        /// }
        /// </code>
        ///     <c>Use in controller:</c>
        ///     <code>
        /// private readonly IHttpClientFactory _factory;
        /// public HomeController(IHttpClientFactory factory)
        /// {
        ///     _factory = factory;
        /// }
        /// 
        /// public async Task&lt;IActionResult&gt; CallApiViaClientCredentials()
        /// {
        ///     var client = _factory.CreateClient("service");
        ///     var content = await client.GetAsync("https://localhost:1234/identity");
        ///     return Ok(content);
        /// }
        /// </code>
        /// </example>
        public static IServiceCollection AddOpenIdAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services
                .AddAuthentication(options => configuration.Bind(OpenIdConnectSettings.AuthenticationSection, options))
                .AddCookie(options => configuration.Bind(OpenIdConnectSettings.CookieSection, options))
                .AddOpenIdConnect(configuration.GetSection(OpenIdConnectSettings.Scheme).Value,
                    options => configuration.Bind(OpenIdConnectSettings.OpenIdConnectSection, options));

            return services;
        }

        /// <summary>
        ///     Bypass authorization and [Authorize]
        /// </summary>
        /// <param name="services">
        ///     <see cref="IServiceCollection"/>
        /// </param>
        /// <param name="logger">
        ///     <see cref="ILogger"/>
        /// </param>
        public static IServiceCollection AddValidateBypass(this IServiceCollection services, ILogger logger)
        {
            logger.LogWarning("WARNING! Authorization bypass enabled");

            services.AddSingleton<IAuthorizationHandler, ByPassAuthorization>();

            return services;
        }

        /// <summary>
        ///     Bypassing authorization
        /// </summary>
        private class ByPassAuthorization : IAuthorizationHandler
        {
            /// <inheritdoc/>
            public Task HandleAsync(AuthorizationHandlerContext context)
            {
                foreach (var requirement in context.PendingRequirements.ToList())
                {
                    context.Succeed(requirement);
                }

                return Task.CompletedTask;
            }
        }
    }
}