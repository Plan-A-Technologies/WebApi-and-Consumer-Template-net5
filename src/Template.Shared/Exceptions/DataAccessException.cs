using System;
using System.Collections.Generic;

using Template.Shared.Errors;

namespace Template.Shared.Exceptions
{
    /// <summary>
    ///     Data access exception.
    /// </summary>
    /// <seealso cref="BaseException"/>
    public class DataAccessException : BaseException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="errorCode">The error code.</param>
        public DataAccessException(string customMessage, string errorCode) : base(customMessage, errorCode)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="ex">The exception.</param>
        /// <param name="errorCode">The error code.</param>
        public DataAccessException(string customMessage, Exception ex, string errorCode) : base(customMessage, ex, errorCode)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        /// <param name="errors"></param>
        public DataAccessException(IList<ErrorModel> errors) : base(errors)
        {
        }
    }
}