using System;
using Template.Shared.Errors;

namespace Template.Shared.Exceptions
{
    /// <summary>
    /// Bad Request Exception.
    /// </summary>
    /// <seealso cref="BaseException" />
    public class BadRequestException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="errorCode">The error code.</param>
        public BadRequestException(Exception ex, string errorCode = ErrorCodes.BadRequest) : base("", ex, errorCode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="errorCode">The error code.</param>
        public BadRequestException(string customMessage, string errorCode = ErrorCodes.BadRequest) : base(customMessage, errorCode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="ex">The exception.</param>
        /// <param name="errorCode">The error code.</param>
        public BadRequestException(string customMessage, Exception ex, string errorCode = ErrorCodes.BadRequest) : base(customMessage, ex, errorCode)
        {
        }
    }
}