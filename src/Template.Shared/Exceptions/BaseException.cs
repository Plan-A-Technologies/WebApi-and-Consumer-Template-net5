using System;
using Template.Shared.Errors;

namespace Template.Shared.Exceptions
{
    /// <summary>
    /// Base exception.
    /// </summary>
    /// <seealso cref="Exception" />
    public abstract class BaseException : Exception
    {
        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <value>
        /// The error code.
        /// </value>
        public string ErrorCode { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="errorCode">The error code.</param>
        protected BaseException(Exception ex, string errorCode = ErrorCodes.General) : base("", ex)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="errorCode">The error code.</param>
        protected BaseException(string customMessage, string errorCode = ErrorCodes.General) : base(customMessage)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="ex">The exception.</param>
        /// <param name="errorCode">The error code.</param>
        protected BaseException(string customMessage, Exception ex, string errorCode = ErrorCodes.General) : base(customMessage, ex)
        {
            ErrorCode = errorCode;
        }
    }
}