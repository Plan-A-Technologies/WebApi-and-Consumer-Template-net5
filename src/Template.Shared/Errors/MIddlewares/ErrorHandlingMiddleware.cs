using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Security.Authentication;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Template.Shared.Errors;
using Template.Shared.Exceptions;
using Template.Shared.Extensions;
using Template.Shared.Logging;

namespace Template.Shared.Errors.Middlewares
{
    /// <summary>
    ///     Middleware for handling exceptions.
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        /// <summary>
        ///     A function that can process an HTTP request.
        /// </summary>
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        /// <summary>
        ///     Initializes a new instance of the class.
        /// </summary>
        /// <param name="next">A function that can process an HTTP request.</param>
        /// <param name="logger">Logger instance</param>
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        ///     Execute current chain requests.
        /// </summary>
        /// <param name="context">Http context.</param>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        ///     Handles the exception asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var path = context.Request.Path.Value;
            var method = context.Request.Method;

            HttpStatusCode code;

            IList<ErrorModel> errors = null;

            switch (exception)
            {
                case NotFoundException nfex:
                    code = HttpStatusCode.NotFound;
                    errors = nfex.Errors;

                    break;
                case ForbiddenException fex:
                    code = HttpStatusCode.Forbidden;
                    errors = fex.Errors;

                    break;
                case ArgumentNullException _:
                    code = HttpStatusCode.BadRequest;

                    break;
                case BadRequestException brex:
                    code = HttpStatusCode.BadRequest;
                    errors = brex.Errors;

                    break;
                case DataAccessException daex:
                    code = HttpStatusCode.InternalServerError;
                    errors = daex.Errors;

                    break;
                case UnauthorizedAccessException _:
                case AuthenticationException _:
                    code = HttpStatusCode.Unauthorized;

                    break;
                default:
                    code = HttpStatusCode.InternalServerError;

                    break;
            }

            _logger.LogError(exception, $"Method: {method}; Path: {path}");

            errors ??= new[]
            {
                new ErrorModel("000.000.000")
                {
                    Message = $"No error code specified.{Environment.NewLine}{exception.Message}",
                    Data = exception.Data
                }
            };

            foreach (var error in errors)
            {
                error.Details = Logger.GetExceptionMessage(exception, "", 0);
            }

            var result = JsonConvert.SerializeObject(errors,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int) code;

            return context.Response.WriteAsync(result);
        }
    }
}