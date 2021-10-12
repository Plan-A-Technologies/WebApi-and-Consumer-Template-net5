using System;
using Template.Shared.Errors;

namespace Template.Shared.Exceptions
{
    /// <summary>
    /// Data access exception.
    /// </summary>
    /// <seealso cref="BaseException" />
    public class DataAccessException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="errorCode">The error code.</param>
        public DataAccessException(Exception ex, string errorCode = ErrorCodes.DataAccess) : base("", ex, errorCode)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="errorCode">The error code.</param>
        public DataAccessException(string customMessage, string errorCode = ErrorCodes.DataAccess) : base(customMessage, errorCode)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="ex">The exception.</param>
        /// <param name="errorCode">The error code.</param>
        public DataAccessException(string customMessage, Exception ex, string errorCode = ErrorCodes.DataAccess) : base(customMessage, ex, errorCode)
        {
            ErrorCode = errorCode;
        }
    }
}