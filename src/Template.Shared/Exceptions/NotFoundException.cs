using System;
using Template.Shared.Errors;

namespace Template.Shared.Exceptions
{
    /// <summary>
    /// Not Found Exception.
    /// </summary>
    /// <seealso cref="BaseException" />
    public class NotFoundException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="errorCode">The error code.</param>
        public NotFoundException(Exception ex, string errorCode = ErrorCodes.NotFound) : base("", ex, errorCode)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="errorCode">The error code.</param>
        public NotFoundException(string customMessage, string errorCode = ErrorCodes.NotFound) : base(customMessage, errorCode)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="ex">The exception.</param>
        /// <param name="errorCode">The error code.</param>
        public NotFoundException(string customMessage, Exception ex, string errorCode = ErrorCodes.NotFound) : base(customMessage, ex, errorCode)
        {

        }
    }
}