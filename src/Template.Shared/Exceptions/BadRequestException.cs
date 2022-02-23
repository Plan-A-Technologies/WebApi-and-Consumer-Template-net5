using System;
using System.Collections.Generic;

using Template.Shared.Errors;

namespace Template.Shared.Exceptions
{
    /// <summary>
    ///     Bad Request Exception.
    /// </summary>
    /// <seealso cref="BaseException"/>
    public class BadRequestException : BaseException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="errorCode">The error code.</param>
        public BadRequestException(string customMessage, string errorCode) : base(customMessage, errorCode)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="ex">The exception.</param>
        /// <param name="errorCode">The error code.</param>
        public BadRequestException(string customMessage, Exception ex, string errorCode) : base(customMessage, ex, errorCode)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="data">The data.</param>
        public BadRequestException(string customMessage, string errorCode, object data) : base(customMessage, errorCode, data)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="errors"></param>
        public BadRequestException(IList<ErrorModel> errors) : base(errors)
        {
        }
    }
}