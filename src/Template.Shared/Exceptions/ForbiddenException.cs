using System;
using Template.Shared.Errors;

namespace Template.Shared.Exceptions
{
    /// <summary>
    /// Forbidden Exception
    /// </summary>
    /// <seealso cref="Template.Shared.Exceptions.BaseException" />
    public class ForbiddenException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="errorCode">The error code.</param>
        public ForbiddenException(Exception ex, string errorCode = ErrorCodes.Forbidden) : base("", ex, errorCode)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="errorCode">The error code.</param>
        public ForbiddenException(string customMessage, string errorCode = ErrorCodes.Forbidden) : base(customMessage, errorCode)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="ex">The exception.</param>
        /// <param name="errorCode">The error code.</param>
        public ForbiddenException(string customMessage, Exception ex, string errorCode = ErrorCodes.Forbidden) : base(customMessage, ex, errorCode)
        {

        }
    }
}