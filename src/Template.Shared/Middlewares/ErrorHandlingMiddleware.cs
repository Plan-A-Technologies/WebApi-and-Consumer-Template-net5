using System;
using System.Net;
using System.Net.Mime;
using System.Security.Authentication;
using System.Threading.Tasks;
using MassTransit.Monitoring.Performance;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Template.Shared.Errors;
using Template.Shared.Exceptions;

namespace Template.Shared.Middlewares
{
    /// <summary>
    /// Middleware for handling exceptions.
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        /// <summary>
        /// A function that can process an HTTP request.
        /// </summary>
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        /// <summary>
        /// Initializes a new instance of the class. 
        /// </summary>
        /// <param name="next">A function that can process an HTTP request.</param>
        /// <param name="logger">Logger instance</param>
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Execute current chain requests.
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
        /// Handles the exception asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var path = context.Request.Path.Value;
            var method = context.Request.Method;

            var code = HttpStatusCode.InternalServerError;
            string message = string.Empty;
            string innerCode = null;

            switch (exception)
            {
                case NotFoundException nfex:
                    {
                        code = HttpStatusCode.NotFound;
                        innerCode = ErrorCodes.NotFound;
                        message = nfex.Message;
                        break;
                    }
                case ForbiddenException fex:
                    {
                        code = HttpStatusCode.Forbidden;
                        innerCode = ErrorCodes.Forbidden;
                        message = fex.Message;
                        break;
                    }
                case ArgumentNullException _:
                    {
                        code = HttpStatusCode.BadRequest;
                        break;
                    }
                case BadRequestException brex:
                    {
                        innerCode = ErrorCodes.BadRequest;
                        message = brex.Message;
                        code = HttpStatusCode.BadRequest;
                        break;
                    }
                case DataAccessException daex:
                {
                    innerCode = ErrorCodes.DataAccess;
                    message = daex.Message;
                    code = HttpStatusCode.InternalServerError;
                    break;
                }
                case UnauthorizedAccessException _:
                case AuthenticationException _:
                {
                    code = HttpStatusCode.Unauthorized;
                    break;
                }
            }

            _logger.LogError(exception, $"{method}: {path}");

            if (string.IsNullOrWhiteSpace(message))
                message = exception.Message;

            var result = JsonConvert.SerializeObject(
                new ErrorModel(innerCode ?? ErrorModel.ErrorCodeGeneral) { Message = message },
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
